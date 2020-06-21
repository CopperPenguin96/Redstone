using System;
using System.Collections.Generic;
using System.Text;
using Redstone.Players;

namespace Redstone.Commands
{
	public delegate void Handler(Player player, Command cmd);
	public class Command
	{
		public string Name { get; set; }

		public string[] Aliases { get; set; }

		public CommandCategory Category { get; set; }

		public Handler Handler { get; set; }

		public Player ExecutingPlayer { get; set; }

		public string[] Args { get; set; }

		public bool IsConsoleSafe { get; set; }

		public Permission[] Permissions { get; set; }

		private int _last = 0;

		public string Next()
		{
			string next = Args[_last];
			_last++;
			return next;
		}

		public string NextAll()
		{
			string full = "";
			for (int x = _last; x < Args.Length; x++)
			{
				if (x == Args.Length - 1) full += Args[x];
				else full += Args[x] + " ";
			}

			return full;
		}
	}
}
