using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.AppSystem;
using Redstone.Players;

namespace Redstone.Network.Packets
{
	public class Handshake : IPacket
	{
		public Packet ID => Packet.Handshake;
		public string Name => "Handshake";

		public void Send(ref Player player, GameStream stream)
		{
			throw new NotImplementedException();
		}

		public void Receive(ref Player player, GameStream stream)
		{
			VarInt protocolVersion = stream.ReadVarInt();
			if (protocolVersion > Protocol.Version)
			{
				player.Disconnect("Outdated server");
				return;
			}

			if (protocolVersion < Protocol.Version)
			{
				player.Disconnect("Outdated client");
				return;
			}

			string serverAddress = stream.ReadString();
			ushort serverPort = stream.ReadShort();
			VarInt nextState = stream.ReadVarInt();

			if (nextState == 1)
			{
				player.State = ConnectionState.Status;
			}
			else if (nextState == 2)
			{
				player.State = ConnectionState.Login;
			}
			else
			{
				player.Disconnect("Invalid state sent from client.");
				return;
			}
		}
	}
}
