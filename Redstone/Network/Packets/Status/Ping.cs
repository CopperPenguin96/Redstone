using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Players;

namespace Redstone.Network.Packets.Status
{
	public class Ping : IPacket
	{
		public Packet ID => Packet.Ping;
		public string Name => "Ping";

		public void Send(ref Player player, GameStream stream)
		{
			throw new NotImplementedException();
		}

		public void Receive(ref Player player, GameStream stream)
		{
			long payload = stream.ReadLong();
			player.Payload = payload;
			new Pong().Send(ref player, stream);
		}
	}
}
