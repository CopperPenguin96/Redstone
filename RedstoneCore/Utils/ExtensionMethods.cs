using System.Text.RegularExpressions;

namespace Redstone.Core.Utils
{
    public static class ExtensionMethods
    {
        public static string[] RegexSplit(this string input, string regex)
        {
            return Regex.Split(input, regex);
        }
        public static bool IsByteSize(this string str)
        {
            return byte.TryParse(str, out _);
        }

        public static bool IsShortSize(this string str)
        {
            return short.TryParse(str, out _);
        }

        public static bool IsIntSize(this string str)
        {
            return int.TryParse(str, out _);
        }

        public static bool IsLongSize(this string str)
        {
            return long.TryParse(str, out _);
        }

        public static bool IsFloat(this string str)
        {
            return float.TryParse(str, out _);
        }

        public static bool IsDouble(this string str)
        {
            return double.TryParse(str, out _);
        }
    }
}
