using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redstone.Commands.Categories;
using Redstone.Players;

namespace Redstone.Commands
{
	public class CommandManager
	{
		public static List<Command> AllCommands = new List<Command>();

		public static void Load()
		{
			BasicCommands.Init();
		}

		public static void Register(Command cmd)
		{
			AllCommands.Add(cmd);
		}

		public static bool ExecuteCommand(string command, string[] args, Player player, out string failMessage)
		{
			Command found = null;
			foreach (Command cmd in AllCommands)
			{
				if (string.Equals(cmd.Name, command, StringComparison.CurrentCultureIgnoreCase))
				{
					found = cmd;
				}
				else
				{
					foreach (string arg in cmd.Args)
					{
						if (string.Equals(arg, command, StringComparison.CurrentCultureIgnoreCase))
						{
							found = cmd;
						}
					}
				}
				
			}

			if (found == null)
			{
				failMessage = "not_found";
				return false;
			}

			if (!found.IsConsoleSafe && player.IsConsole)
			{
				failMessage = "console_not_allowed";
				return false;
			}

			found.ExecutingPlayer = player;
			found.Args = args;

			if (found.Permissions.Any(p => !player.Can(p)))
			{
				failMessage = "permission";
				return false;
			}

			failMessage = "";
			found.Handler(player, found);
			return true;
		}
	}
}
