using System;
using System.Collections.Generic;
using System.Text;
using Redstone.Configuration;
using Redstone.Players;
using Redstone.Worlds;
using Redstone.Utils;

namespace Redstone.Network.Packets.Play
{
	public class JoinGame : IPacket
	{
		public Packet ID => Packet.JoinGame;
		public string Name => "Join Game";

		public void Send(ref Player player, GameStream stream)
		{
			int entityID = player.ID;
			GameMode gameMode = Config.General.GameMode.Value;
			Dimension dim = Config.Worlds.DefaultDimension.Value;
			string sha256 = player.World.Seed.GetSHA256(out byte[] bts);
			List<byte> bytes = new List<byte>();

			for (int x = 0; x < 8; x++)
			{
				bytes.Add(bts[x]);
			}

			int max = Config.General.MaxPlayers.Value;
			string levelType = player.World.LevelType;
			int viewDistance = Config.Advanced.RenderDistance.Value;
			bool reducedInfo = Config.Advanced.ReducedDebugInfo.Value;
			bool respawnScreen = !player.World.ImmediateRespawn;

			Protocol.Send(ref player, stream, ID,
				entityID, gameMode, dim, bytes.ToArray(),
				max, levelType, viewDistance, reducedInfo, respawnScreen);
		}

		public void Receive(ref Player player, GameStream stream)
		{
			throw new NotImplementedException();
		}
	}
}
