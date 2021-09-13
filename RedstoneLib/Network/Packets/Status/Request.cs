using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Network.Packets.Status
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
