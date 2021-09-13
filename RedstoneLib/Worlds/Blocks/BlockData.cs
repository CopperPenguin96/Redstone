using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Worlds.Blocks
{
	public class BlockData
	{
		public string Name { get; set; }

		public object Value { get; set; }

		public BlockData(string name, object val)
		{
			Name = name ?? throw new ArgumentNullException(nameof(name));
			Value = val ?? throw new ArgumentNullException(nameof(val));
		}
	}
}
