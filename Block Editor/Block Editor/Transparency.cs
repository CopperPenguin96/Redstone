using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_Editor
{
	public class Transparency
	{
		public const string True = "True";
		public const string False = "False";
		public const string Partial = "Partial";

		public string Value { get; set; }

		public static bool operator ==(Transparency t1, bool t2)
		{
			bool val = t1.Value == True;
			return val == t2;
		}

		public static bool operator !=(Transparency t1, bool t2)
		{
			return !(t1 == t2);
		}

		public static implicit operator Transparency(bool val)
		{
			Transparency t = new Transparency {Value = val == true ? Transparency.True : Transparency.False};
			return t;
		}

		public static implicit operator Transparency(string val)
		{
			if (val == null) throw new ArgumentNullException(nameof(val));

			return new Transparency {Value = val};
		}
	}
}
