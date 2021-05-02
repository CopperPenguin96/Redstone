using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;

namespace ProtocolSharp.Utils
{
	public static class StringUtil
	{
        public static string Base64Encode(this string original)
        {
            if (original == null) throw new ArgumentNullException(nameof(original));
            byte[] plainBytes = Encoding.UTF8.GetBytes(original);
            return System.Convert.ToBase64String(plainBytes);
        }

		public static byte[] ToBytes(this string str, Encoding encoding)
		{
			return encoding.GetBytes(str);
		}

		/// <summary>
		/// Assumes default encoding UTF-8
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static byte[] ToBytes(this string str)
		{
			return ToBytes(str, Encoding.UTF8);
		}

		public static string GetSHA256(this string str, out byte[] bytes)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
				StringBuilder builder = new StringBuilder();
				foreach (var t in bytes)
				{
					builder.Append(t.ToString("x2"));
				}

				return builder.ToString();
			}
		}

		public static string GetSHA256(this string str)
		{
			return GetSHA256(str, out _);
		}
	}

	public static class ImageUtil
	{
		public static string GetString(this Image image)
		{
			MemoryStream ms = new MemoryStream();
			image.Save(ms, image.RawFormat);
			byte[] array = ms.ToArray();
			return Convert.ToBase64String(array);
		}

		public static string GetString(this Bitmap bitmap)
		{
			return GetString((Image)bitmap);
		}
	}

	public static class ByteUtil
	{
		public static byte ToByte(this bool b)
		{
			return b ? (byte) 1 : (byte) 0;
		}
	}
}
