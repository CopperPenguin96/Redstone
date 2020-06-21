using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Players.Events
{
	
	public class PlayerSlotChangedEvent : EventArgs
	{
		public Player Player;
		public byte Slot;

		public PlayerSlotChangedEvent(Player player, byte slot)
		{
			Player = player;
			Slot = slot;
		}
	}
}
