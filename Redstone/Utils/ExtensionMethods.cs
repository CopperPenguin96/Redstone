using System.Security.Cryptography;
using System.Text;
using java.util;
using SmartNbt.Tags;

namespace Redstone.Utils
{
    public static class ExtensionMethods
    {
        public static NbtList ToNbtList<T>(this List<T> list, string listName)
        {
            NbtList lst = new(listName);

            if (typeof(T) == typeof(byte))
            {
                foreach (T b in list)
                {
                    lst.Add(new NbtByte(Convert.ToByte(b)));
                }
            }
            else if (typeof(T) == typeof(short))
            {
                foreach (T b in list)
                {
                    lst.Add(new NbtShort(Convert.ToInt16(b)));
                }
            }
            else if (typeof(T) == typeof(int))
            {
                foreach (T b in list)
                {
                    lst.Add(new NbtInt(Convert.ToInt32(b)));
                }
            }
            else if (typeof(T) == typeof(long))
            {
                foreach (T b in list)
                {
                    lst.Add(new NbtLong(Convert.ToInt64(b)));
                }
            }
            else if (typeof(T) == typeof(float))
            {
                foreach (T b in list)
                {
                    lst.Add(new NbtFloat(Convert.ToSingle(b)));
                }
            }
            else if (typeof(T) == typeof(double))
            {
                foreach (T b in list)
                {
                    lst.Add(new NbtDouble(Convert.ToDouble(b)));
                }
            }
            else if (typeof(T) == typeof(string))
            {
                foreach (T b in list)
                {
                    lst.Add(new NbtShort(Convert.ToString(b)));
                }
            }

            return lst;
        }

        public static string Join(this string[] parts, string glue)
        {
            string str = "";
            bool isFirst = true;
            foreach (string part in parts)
            {
                if (!isFirst)
                {
                    str += glue;
                }
                else
                {
                    isFirst = false;
                }

                str += part;
            }

            return str;
        }

        public static string Join(this List<string> parts, string glue)
        {
            return Join(parts.ToArray(), glue);
        }

        public static int[] GetIntArray(this UUID uuid)
        {
            if (uuid == null) throw new NullReferenceException(nameof(uuid));

            int[] i = new int[4];
            long msb = uuid.getMostSignificantBits();
            long lsb = uuid.getLeastSignificantBits();

            i[0] = (int) (msb >> 32);
            i[1] = (int) (msb);
            i[2] = (int) (lsb >> 32);
            i[3] = (int) (lsb);
            return i;
        }

        public static byte ToByte(this bool b)
        {
            return b ? (byte) 1 : (byte) 0;
        }

        public static string Base64Encode(this string original)
        {
            if (original == null) throw new NullReferenceException(nameof(original));

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
