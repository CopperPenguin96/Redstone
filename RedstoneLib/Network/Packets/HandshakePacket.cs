using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Network.Packets
{
	public class HandshakePacket : IReceivingPacket
	{
		public Packet Packet => Packet.Handshake;

		public string Name => "Handshake";

		public void Receive(ref MinecraftClient client, GameStream stream)
		{
			VarInt protocolVersion = stream.ReadVarInt();
			if (protocolVersion > Protocol.Version)
			{
				client.Disconnect("Outdated Server");
				return;
			}

			if (protocolVersion < Protocol.Version)
			{
				client.Disconnect("Outdated game");
				return;
			}

			string serverAddress = stream.ReadString();
			ushort port = stream.ReadShort();
			VarInt nextState = stream.ReadVarInt();

			if (nextState == 1) client.State = ConnectionState.Status;
			else if (nextState == 2) client.State = ConnectionState.Login;
			else client.Disconnect("Invalid state sent from game.");
		}
	}
}
