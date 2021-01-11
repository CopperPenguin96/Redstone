using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolSharp.Types
{
	public class Rotation
	{
		public float X { get; set; }

		public float Y { get; set; }

		public float Z { get; set; }

		public Rotation(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}
	}
}
