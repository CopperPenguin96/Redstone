using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Network;

namespace ProtocolSharp.Packets.Status
{
	public class Request : IReceivingPacket
	{
		public Packet Packet => Packet.Request;

		public string Name => "Request";

		public void Receive(ref MinecraftClient client, GameStream stream)
		{
			new Response().Send(ref client, stream);
		}
	}
}
