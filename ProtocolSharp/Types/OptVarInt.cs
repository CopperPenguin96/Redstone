using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolSharp.Types
{
	public class OptVarInt : OptObject<VarInt>
	{
		public OptVarInt(bool enabled, VarInt value = null) : base(enabled, value)
		{
		}
	}
}
