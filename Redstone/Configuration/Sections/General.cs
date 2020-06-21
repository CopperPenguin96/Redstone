using System;
using System.Collections.Generic;
using System.Text;
using Redstone.Players;

namespace Redstone.Configuration.Sections
{
	public class General : ConfigSection
	{
		public override string Name => "General";

		public ConfigString ServerName = 
			new ConfigString("server-name", "The official name of the server.", "[Redstone] MC Server", 1, 64);

		public ConfigString MOTD =
			new ConfigString("motd", "Message of the day", "A Redstone-Powered Minecraft server", 1, 64);

		public ConfigInt MaxPlayers =
			new ConfigInt("max-players", "The max amount of players allowed to be on at one time", 20, 1, false);

		public ConfigInt Port =
			new ConfigInt("port", "Port for the server to listen on.", 25565, 1, 65565);

		public ConfigProperty<GameMode> GameMode =
			new ConfigProperty<GameMode>("game-mode", "The default gamemode (survival, creative, adventure, spectator)",
				Players.GameMode.Survival);

		public ConfigProperty<Difficulty> Difficulty =
			new ConfigProperty<Difficulty>("difficulty",
				"The default difficulty of the server.",
				Players.Difficulty.Normal);

		public override void LoadDefaults()
		{
			ServerName.SetDefault();
			MOTD.SetDefault();
			MaxPlayers.SetDefault();
			Port.SetDefault();
			GameMode.SetDefault();
			Difficulty.SetDefault();
		}
	}
}
