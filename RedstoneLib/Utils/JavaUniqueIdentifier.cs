using System;
using System.Security.Cryptography;

namespace Redstone.Utils
{
	/// <summary>
	/// Class to create and read Java UUID's
	/// </summary>
	public sealed class JavaUniqueIdentifier
	{
		public byte[] Bytes { get; set; }

		public override string ToString()
		{
			byte[] hash = Bytes;
			hash[6] &= 0x0f;
			hash[6] |= 0x30;
			hash[8] &= 0x3f;
			hash[8] |= 0x80;

			string hex = BitConverter.ToString(hash)
				.Replace("-", string.Empty).ToLower();

			return hex.Insert(8, "-")
				.Insert(13, "-")
				.Insert(18, "_")
				.Insert(23, "-");
		}

		public static byte[] Generate(byte[] input)
		{
			MD5 md5 = MD5.Create();
			byte[] hash = md5.ComputeHash(input);
			return hash;
		}

		public static JavaUniqueIdentifier Create(string str)
		{
			if (str == null) throw new ArgumentNullException(nameof(str));
			return new() {Bytes = Generate(str.ToBytes())};
		}

		public int[] Get()
		{
			return null;
		}
	}
}
