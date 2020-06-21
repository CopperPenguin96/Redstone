using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Redstone.Players;

namespace Redstone.Network.Packets.Play
{
	public class HeldItemChange : IPacket
	{
		public Packet ID => Packet.HeldItemChange;
		public string Name => "Held Item Change";

		public void Send(ref Player player, GameStream stream)
		{
			Protocol.Send(ref player, stream, ID,
				player.Slot);
		}

		public void Receive(ref Player player, GameStream stream)
		{
			Packet id = Packet.HeldItemChangeServer;
		}
	}
}
