using System;
using System.Collections.Generic;
using Redstone.AppSystem;
using Redstone.Configuration;
using Redstone.Configuration.Categories;
using Redstone.Network.Packets.Status;
using Redstone.Players;
using Redstone.Utils;
using Version_Management;
using Version = Version_Management.Version;

namespace Redstone
{
	public class Server
	{
		public static Config Config = null!;
		public static List<Player> OnlinePlayers = new();

		public static readonly MinecraftVersion MinecraftVersion = MinecraftVersion.Pro756;
		public static readonly Version Version = new();
		public const BuildVersion BuildType = BuildVersion.Testing;
		public const int Build = 0;
		private static readonly DateTime LatestPre = new(2021, 9, 8);

		public static void WriteLine(Log log)
		{
			Console.ForegroundColor = ConsoleColor.White;
			string messageRaw = log.ToString();
			bool skipNext = false;
			for (int x = 0; x < messageRaw.Length; x++)
			{
				if (skipNext)
				{
					skipNext = false;
					continue;
				}
				if (messageRaw[x] == '&')
				{
					if (messageRaw[x + 1] is 'a' or 'b' or 'c' or 'd' or 'e' or 'f' or 'g' || char.IsDigit(messageRaw[x + 1]))
					{
						Console.ForegroundColor = (ConsoleColor) (MinecraftColor) messageRaw[x + 1];
					}
					

					skipNext = true;
					continue;
				}
				else
				{
					if (x == messageRaw.Length - 1) Console.WriteLine(messageRaw[x]);
					else Console.Write(messageRaw[x]);
				}
			}
		}

		private static char[] _alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

		public static void Start()
		{
			string current = Version.ToString();
			if (BuildType == BuildVersion.PreRelease)
			{
				string lets = Build switch
				{
					<= 25 => "" + _alphabet[Build],
					<= 50 => "a" + _alphabet[(50 - Build)],
					<= 100 => "b" + _alphabet[(100 - Build)],
					<= 150 => "c" + _alphabet[(150 - Build)],
					<= 200 => "d" + _alphabet[(200 - Build)]
				};
				// PreRelease format major_day-month_lettercode
				current = $"{Version.Major}_{LatestPre.Day}-{LatestPre.Month}_{lets}";
			}
			else if (BuildType == BuildVersion.Testing)
			{
				current += " Build " + Build;
			}

			Logger.Log("Loading Redstone " + current + "...", LogType.System);
			Config = Config.Load(out bool defaults);
			if (defaults)
			{
				Logger.LogWarning("Could not find config.json. Loaded default configs.");
			}

			var latest = new VersionChecker()
				.GetLatest("https://redstoneserver.000webhostapp.com/Versions/Redstone.php?action=echo");
			switch (BuildType)
			{
				case BuildVersion.Testing:
					Logger.LogWarning("You are using an unsupported test version of Redstone.");
					Logger.LogWarning("There maybe major issues in this build.");
					Logger.LogWarning("Please make sure you have a backup before continuing.");
					Logger.LogWarning($"Consider updating to the latest version. ({latest})");
					break;
				case BuildVersion.PreRelease:
					Logger.LogWarning("You are using an unsupported build version of Redstone.");
					Logger.LogWarning("There maybe major issues in this build.");
					Logger.LogWarning("Please make sure you have a backup before continuing.");
					Logger.LogWarning($"Consider updating to the latest version. ({latest})");
					break;
				default:
					if (!CheckForUpdatesEnabled())
					{
						Logger.LogWarning("Update checks are disabled. Will not look for udpates.");
						break;
					}
					else if (latest > Version)
					{
						Logger.LogWarning("You are using an outdated version of Redstone.");
						Logger.LogWarning($"Consider updating to the latest version ({latest}) to get all the latest features.");
						break;
					}
					else
					{
						Logger.Log("Your version of Redstone is the current version.", LogType.System);
						break;
					}
			}
		}

		/// <summary>
		/// Checks the config to see if updates are enabled.
		/// </summary>
		/// <returns><inheritdoc cref="AdvancedConfig.CheckForUpdates"/></returns>
		public static bool CheckForUpdatesEnabled()
		{
			return (bool) Config.GetItem(ConfigCategory.Advanced, "Check for Updates").Value!;
		}
	}

	public enum BuildVersion
	{
		Release, PreRelease, Testing
	}
}
