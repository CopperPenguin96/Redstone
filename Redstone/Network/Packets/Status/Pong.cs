using System;
using Redstone.Players;

namespace Redstone.Network.Packets.Status
{
	public class Pong : IPacket
	{
		public Packet ID => Packet.Pong;
		public string Name => "Pong";

		public void Send(ref Player player, GameStream stream)
		{
			Protocol.Send(ref player, stream, ID, player.Payload);
		}

		public void Receive(ref Player player, GameStream stream)
		{
			throw new NotImplementedException();
		}
	}
}
