using System;
using System.Collections.Generic;
using System.Text;
using Redstone.AppSystem.Logging;
using Redstone.Players;

namespace Redstone.Commands.Categories
{
	public sealed class BasicCommands
	{
		public static void Init()
		{
			CommandManager.Register(CmdSay);
		}

		private static Command CmdSay = new Command
		{
			Name = "Say",
			Category = CommandCategory.Basic,
			IsConsoleSafe = true,
			Permissions = new[] { Permission.Say },
			Handler = SayHandler
		};

		private static void SayHandler(Player player, Command cmd)
		{
			string message = "[Say] " + cmd.NextAll();
			foreach (Player p in Server.OnlinePlayers)
			{
				p.SendMessage(message);
			}

			Logger.Log(LogType.PlayerActivity, message);
		}
	}
}