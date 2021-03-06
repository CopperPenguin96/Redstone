﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using ProtocolSharp.Network;

namespace ProtocolSharp.Utils
{
	public class JavaUUID
	{
		public byte[] Bytes { get; set; }

		public override string ToString()
		{
			byte[] hash = Bytes;
			hash[6] &= 0x0f;
			hash[6] |= 0x30;
			hash[8] &= 0x3f;
			hash[8] |= 0x80;
			string hex = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
			return hex.Insert(8, "-").Insert(13, "-").Insert(18, "-").Insert(23, "-");
		}

		public static byte[] Generate(byte[] input)
		{
			MD5 md5 = MD5.Create();
			byte[] hash = md5.ComputeHash(input);
			return hash;
		}

		public static JavaUUID Create(string str)
		{
			return new JavaUUID {Bytes = Generate(str.ToBytes())};
		}

		/// <summary>
		/// NBT requires a 4 integer array representation of the UUID.
		/// </summary>
		/// <returns>A 4 integer array representing the UUID</returns>
		public int[] Get()
		{
			GameStream stream = new GameStream(new MemoryStream(Bytes));
			return new[] // Utilize GameStream to read a UUID as an int[]
			{
				stream.ReadInt(),
				stream.ReadInt(),
				stream.ReadInt(),
				stream.ReadInt()
			};
		}

		public Guid ToGuid()
		{
			byte[] hash = Bytes;

			byte temp = hash[6];
			hash[6] = hash[7];
			hash[7] = temp;

			temp = hash[4];
			hash[4] = hash[5];
			hash[5] = temp;

			temp = hash[0];
			hash[0] = hash[3];
			hash[3] = temp;

			temp = hash[1];
			hash[1] = hash[2];
			hash[2] = temp;
			return new Guid(hash);
		}
	}
}
