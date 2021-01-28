using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolSharp.Worlds.Blocks
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
