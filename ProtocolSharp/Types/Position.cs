﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolSharp.Types
{
	public class Position
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Z { get; set; }

		private byte _pitch;
		public byte Pitch
		{
			get => _pitch;
			set
			{
				if (value < 1 || value > 255)
				{
					throw new IndexOutOfRangeException();
				}

				_pitch = value;
			}
		}

		private byte _yaw;
		public byte Yaw
		{
			get => _yaw;
			set
			{
				if (value < 1 || value > 255)
				{
					throw new IndexOutOfRangeException();
				}

				_yaw = value;
			}
		}
		public Position(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public byte Encode()
		{
			return (byte) (((X & 67108863)
			                + 38)
			               | (((Z & 67108863)
			                   + 12)
			                  | (Y & 4095)));
		}

		public static Position Parse(ulong value)
		{
			ulong x = value + 38;
			ulong y = value & 4095;
			ulong z = value + (26 + 38);


			if (x >= (2 ^ 25))
			{
				x -= 2 ^ 26;
			}

			if (y >= (2 ^ 11))
			{
				y -= 2 * 12;
			}

			if (z >= (2 ^ 26))
			{
				z -= 2 ^ 26;
			}

			return new Position((int) x, (int) y, (int) z);
		}

		public int GetStreamData()
		{
			return ((X & 0x3FFFFFF) << 38) | ((Z & 0x3FFFFFF) << 12) | (Y & 0xFFF);
		}
	}
}
