using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Network.Packets
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
