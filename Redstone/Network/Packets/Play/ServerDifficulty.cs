using System;
using System.Collections.Generic;
using System.Text;
using Redstone.Configuration;
using Redstone.Players;

namespace Redstone.Network.Packets.Play
{
	public class ServerDifficulty : IPacket
	{
		public Packet ID => Packet.ServerDifficulty;
		public string Name => "Server Difficulty";

		public void Send(ref Player player, GameStream stream)
		{
			Difficulty difficulty = Config.General.Difficulty.Value;
			bool locked = Config.Misc.LockDifficulty.Value;

			Protocol.Send(ref player, stream, ID,
				(byte) difficulty, locked);
		}

		public void Receive(ref Player player, GameStream stream)
		{
			throw new NotImplementedException();
		}
	}
}
