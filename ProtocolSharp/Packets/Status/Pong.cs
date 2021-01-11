using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Network;

namespace ProtocolSharp.Packets.Status
{
	public class Pong : ISendingPacket
	{
		public Packet Packet => Packet.Pong;

		public string Name => "Pong";

		public void Send(ref MinecraftClient client, GameStream stream)
		{
			Protocol.Send(ref client, stream, Packet, client.PayLoad);
		}
	}
}
