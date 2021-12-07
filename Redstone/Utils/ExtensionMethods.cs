using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Utils
{
    public static class ExtensionMethods
    {
        public static byte ToByte(this bool b)
        {
            return b ? (byte) 1 : (byte) 0;
        }

        public static string Base64Encode(this string original)
        {
            if (original == null) throw new ArgumentNullException(nameof(original));

            byte[] plainBytes = Encoding.UTF8.GetBytes(original);
            return System.Convert.ToBase64String(plainBytes);
        }

        public static byte[] ToBytes(this string str, Encoding enc)
        {
            return enc.GetBytes(str);
        }

        public static byte[] ToBytes(this string str)
        {
            return ToBytes(str, Encoding.UTF8);
        }

        public static string GetSHA256(this string str, out byte[] bytes)
        {
            using var sha256 = SHA256.Create();
            bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
            var builder = new StringBuilder();
            foreach (byte t in bytes)
            {
                builder.Append(t.ToString("x2"));
            }

            return builder.ToString();
        }

        public static string GetSHA256(this string str)
        {
            return GetSHA256(str, out _);
        }
    }
}
