using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Network
{
	public class DataLength
	{
		public const int Byte = 1;
		public const int Short = 2;
		public const int Int = 4;
		public const int Long = 8;
		public const int Magic = 16;

		public static int GetLength(object o)
		{
			return GetLength(new[] {o});
		}

		public static int GetLength(object[] objs)
		{
			int count = 0;
			foreach (object o in objs)
			{
				switch (o)
				{
					case byte _:
						count += Byte;
						break;
					case short _:
						count += Short;
						break;
					case int _:
						count += Int;
						break;
					case long _:
						count += Long;
						break;
				}

				if (o is byte[] a) count += a.Length;
				if (o is short[] b) count += b.Length;
				if (o is int[] c) count += c.Length;
				if (o is long[] d) count += d.Length;
				if (o is string s) count += Byte + s.Length;
			}

			return count;
		}
	}
}
