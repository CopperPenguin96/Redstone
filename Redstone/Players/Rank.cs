using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redstone.Players
{
	public class Rank
	{
		public string Name { get; set; }

		public string ID { get; set; }

		public int Index { get; }

		public Permission[] Permissions { get; set; }

		public bool Can(Permission permission)
		{
			return Permissions.Any(p => p == permission);
		}
	}
}
