using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolSharp.Entities
{
	public sealed class DustColor
	{
		private float _r;

		public float R
		{
			get => _r;
			set => _r = value <= 0 ? 0 : 1;
		}

		private float _g;

		public float G
		{
			get => _g;
			set => _g = value <= 0 ? 0 : 1;
		}

		private float _b;

		public float B
		{
			get => _b;
			set => _b = value <= 0 ? 0 : 1;
		}

		private float _scale;

		public float Scale
		{
			get => _scale;
			set
			{
				if (value < 0.01) _scale = 0.01f;
				else if (value > 4) _scale = 4f;
				else _scale = value;
			}
		}
	}
}
