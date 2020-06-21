using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Players;

namespace Redstone.Network.Packets.Status
{
	public class Request : IPacket
	{
		public Packet ID => Packet.Request;
		public string Name => "Request";

		public void Send(ref Player player, GameStream stream)
		{
			throw new NotImplementedException();
		}

		public void Receive(ref Player player, GameStream stream)
		{
			new Response().Send(ref player, stream);
		}
	}
}
