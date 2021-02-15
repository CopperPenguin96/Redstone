using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_Editor
{
	public class Stackable
	{
		public bool Is { get; set; }

		private short _count = 1;
		public short Count
		{
			get => Is ? _count : (short) -1;
			set => _count = value;
		}

		public Stackable(bool stackable, short count)
		{
			Is = stackable;
			Count = count;
		}

		public static bool operator ==(bool val, Stackable second)
		{
			return val == second.Is;
		}

		public static bool operator !=(bool val, Stackable second)
		{
			return !(val == second);
		}

		public static bool operator ==(Stackable first, bool second)
		{
			return first.Is == second;
		}

		public static bool operator !=(Stackable first, bool second)
		{
			return !(first == second);
		}

		public static implicit operator Stackable(bool val)
		{
			return new Stackable(val, 0);
		}
	}
}
