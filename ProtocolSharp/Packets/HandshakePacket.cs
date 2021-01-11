using ProtocolSharp.Network;
using ProtocolSharp.Types;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Packets
{
	public class HandshakePacket : IReceivingPacket
	{
		public Packet Packet => Packet.Handshake;

		public string Name => "Handshake";

		public void Receive(ref MinecraftClient client, GameStream stream)
		{
			VarInt protocolVersion = stream.ReadVarInt();
			if (protocolVersion > MinecraftVersion.Current.ProtocolVersion)
			{
				client.Disconnect("Outdated server");
				return;
			}

			if (protocolVersion < MinecraftVersion.Current.ProtocolVersion)
			{
				client.Disconnect("Outdated game");
				return;
			}

			string serverAddress = stream.ReadString();
			ushort port = stream.ReadShort();
			VarInt nextState = stream.ReadVarInt();

			if (nextState == 1)
			{
				client.State = ConnectionState.Status;
			} 
			else if (nextState == 2)
			{
				client.State = ConnectionState.Login;
			}
			else
			{
				client.Disconnect("Invalid state sent from game.");
				return;
			}
		}

	}
}
