using System;
using System.Collections.Generic;
using System.Text;
using Org.BouncyCastle.Bcpg.OpenPgp;
using ProtocolSharp.Network;

namespace ProtocolSharp.Packets.Status
{
	public class Ping : IReceivingPacket
	{
		public Packet Packet => Packet.Ping;

		public string Name => "Ping";

		public void Receive(ref MinecraftClient client, GameStream stream)
		{
			client.PayLoad = stream.ReadLong();
			new Pong().Send(ref client, stream);
		}
	}
}
