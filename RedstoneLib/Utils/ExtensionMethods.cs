using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Redstone.Utils
{
	public static class StringUtil
	{
		public static string Base64Encode(this string original)
		{
			if (original == null) throw new NullReferenceException(nameof(original));
			byte[] plainBytes = Encoding.UTF8.GetBytes(original);
			return System.Convert.ToBase64String(plainBytes);
		}

		/// <summary>
		/// Converts to a byte array.
		/// </summary>
		/// <param name="str">The string to be converted</param>
		/// <param name="encoding">The encoding to use</param>
		/// <returns>The byte array from the string with the specified encoding.</returns>
		public static byte[] ToBytes(this string str, Encoding encoding)
		{
			return encoding.GetBytes(str);
		}

		/// <summary>
		/// <inheritdoc cref="ToBytes(string,System.Text.Encoding)" />
		/// </summary>
		/// <param name="str"><inheritdoc cref="str" /></param>
		/// <returns>The byte array from the string with UTF-8.</returns>
		public static byte[] ToBytes(this string str)
		{
			return ToBytes(str, Encoding.UTF8);
		}

		public static string CreateSha256(this string str, out byte[] bytes)
		{
			using SHA256 sha256 = SHA256.Create();
			bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
			StringBuilder builder = new();
			foreach (byte t in bytes)
			{
				builder.Append(t.ToString("x2"));
			}

			return builder.ToString();
		}

		public static string CreateSha256(this string str)
		{
			return CreateSha256(str, out _);
		}
	}

	public static class ImageUtil
	{
		public static string GetString(this Image image)
		{
			MemoryStream ms = new();
			image.Save(ms, image.RawFormat);
			byte[] array = ms.ToArray();
			return Convert.ToBase64String(array);
		}

		public static string GetString(this Bitmap bitmap)
		{
			return GetString((Image) bitmap);
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
