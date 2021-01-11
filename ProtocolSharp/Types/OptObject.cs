using System.Runtime.InteropServices;
using Org.BouncyCastle.Crypto.Digests;

namespace ProtocolSharp.Types
{
	/// <summary>
	/// There are several types in the Minecraft Protocol called "Opt{Type}"
	/// These types are represented first as a bool.
	/// If that bool is false, nothing else proceeds as far as this object goes.
	/// If that bool is true, then the object is written.
	/// Its an "optional" object
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class OptObject<T>
	{
		public bool Enabled { get; set; }

		public T Value { get; set; }

		public OptObject(bool enabled, [Optional] T value)
		{
			Enabled = enabled;

			if (enabled)
			{
				Value = value;
			}
		}
	}
}
