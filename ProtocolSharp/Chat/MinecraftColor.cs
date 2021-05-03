using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace ProtocolSharp.Chat
{
    public class MinecraftColor
    {
        public static readonly Dictionary<string, string> Colors = new Dictionary<string, string>
        {
            {"0", "Black"},
            {"1", "Blue"},
            {"2", "Green"},
            {"3", "Cyan"},
            {"4", "Maroon"},
            {"5", "Purple"},
            {"6", "Gold"},
            {"7", "Silver"},
            {"8", "Gray"},
            {"9", "Blue"},
            {"a", "Lime"},
            {"b", "Aqua"},
            {"c", "Red"},
            {"d", "Pink"},
            {"e", "Yellow"},
            {"f", "White"}
        };
    }

    public abstract class DyeColor
    {
        public const string Black = "black";
        public const string White = "white";
        public const string Orange = "orange";
        public const string Magenta = "magenta";
        public const string LightBlue = "light_blue";
        public const string Yellow = "yellow";
        public const string Lime = "lime";
        public const string Pink = "pink";
        public const string Gray = "gray";
        public const string LightGray = "light_gray";
        public const string Cyan = "cyan";
        public const string Purple = "purple";
        public const string Blue = "blue";
        public const string Brown = "brown";
        public const string Green = "green";
        public const string Red = "red";
        public const string Default = "black";

        private string _val;
        private string Value
        {
            get => _val.ToLower();
            set => value.ToLower();
        }

        private static bool CheckVal(string val)
        {
            switch (val.ToLower())
            {
                case White:
                case Orange:
                case Magenta:
                case LightBlue:
                case Yellow:
                case Lime:
                case Pink:
                case Gray:
                case LightGray:
                case Cyan:
                case Purple:
                case Blue:
                case Brown:
                case Green:
                case Red:
                    return true;
                default:
                    return false;
            }
        }

        public static implicit operator DyeColor(string val)
        {
            if (val == null) throw new ArgumentNullException(nameof(val));
            DyeColor dc = "";
            dc.Value = val.ToLower();

            if (!CheckVal(val))
            {
                dc.Value = Default;
            }

            return dc;
        }

        public static implicit operator string(DyeColor v)
        {
            if (v == null) throw new ArgumentNullException(nameof(v));

            return v.Value.ToLower();
        }
    }
}
