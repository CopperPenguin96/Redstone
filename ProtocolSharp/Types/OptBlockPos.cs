using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolSharp.Types
{
	public class OptBlockPos : OptObject<Position>
	{
		public Position Position
		{
			get => Value;
			set => Value = value;
		}

		public OptBlockPos(bool enabled, Position value = null) : base(enabled, value)
		{
		}
	}
}
