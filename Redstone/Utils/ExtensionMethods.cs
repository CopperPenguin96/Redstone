using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Redstone.Players;

namespace Redstone.Utils
{
	public static class StringUtil
	{
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
			return GetString((Image) bitmap);
		}
	}
}
