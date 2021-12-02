using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Utils
{
    public sealed class MinecraftFormatting
    {
        public char Code { get; }

        public static readonly MinecraftFormatting Black = new('0');
        public static readonly MinecraftFormatting DarkBlue = new('1');
        public static readonly MinecraftFormatting DarkGreen = new('2');
        public static readonly MinecraftFormatting DarkAqua = new('3');
        public static readonly MinecraftFormatting DarkRed = new('4');
        public static readonly MinecraftFormatting DarkPurple = new('5');
        public static readonly MinecraftFormatting Gold = new('6');
        public static readonly MinecraftFormatting Gray = new('7');
        public static readonly MinecraftFormatting DarkGray = new('8');
        public static readonly MinecraftFormatting Blue = new('9');
        public static readonly MinecraftFormatting Green = new('a');
        public static readonly MinecraftFormatting Aqua = new('b');
        public static readonly MinecraftFormatting Red = new('c');
        public static readonly MinecraftFormatting LightPurple = new('d');
        public static readonly MinecraftFormatting Yellow = new('e');
        public static readonly MinecraftFormatting White = new('f');

        public static readonly MinecraftFormatting Bold = new('l');
        public static readonly MinecraftFormatting Underline = new('n');
        public static readonly MinecraftFormatting Italic = new('o');
        public static readonly MinecraftFormatting Magic = new('k');
        public static readonly MinecraftFormatting Strike = new('m');
        public static readonly MinecraftFormatting Reset = new('r');

        public static implicit operator MinecraftFormatting(char code)
        {
            return new MinecraftFormatting(code);
        }

        internal MinecraftFormatting(char code)
        {
            Code = code;
        }

        public static bool operator ==(MinecraftFormatting mf, char ch)
        {
            return mf.Code == ch;
        }

        public static bool operator !=(MinecraftFormatting mf, char ch)
        {
            return !(mf == ch);
        }

        public ConsoleColor ToConsoleColor()
        {
            if (Code == Black.Code) return ConsoleColor.Black;
            if (Code == DarkBlue.Code) return ConsoleColor.DarkBlue;
            if (Code == DarkGreen.Code) return ConsoleColor.DarkGreen;
            if (Code == DarkAqua.Code) return ConsoleColor.DarkCyan;
            if (Code == DarkRed.Code) return ConsoleColor.DarkRed;
            if (Code == DarkPurple.Code) return ConsoleColor.DarkMagenta;
            if (Code == Gold.Code) return ConsoleColor.DarkYellow;
            if (Code == Gray.Code) return ConsoleColor.Gray;
            if (Code == DarkGray.Code) return ConsoleColor.DarkGray;
            if (Code == Blue.Code) return ConsoleColor.Blue;
            if (Code == Green.Code) return ConsoleColor.Green;
            if (Code == Aqua.Code) return ConsoleColor.Cyan;
            if (Code == Red.Code) return ConsoleColor.Red;
            if (Code == LightPurple.Code) return ConsoleColor.Magenta;
            if (Code == Yellow.Code) return ConsoleColor.Yellow;

            return ConsoleColor.White;
        }

        public Color ToColor()
        {
            if (Code == Black.Code) return Color.Black;
            if (Code == DarkBlue.Code) return Color.DarkBlue;
            if (Code == DarkGreen.Code) return Color.DarkGreen;
            if (Code == DarkAqua.Code) return Color.DarkCyan;
            if (Code == DarkRed.Code) return Color.DarkRed;
            if (Code == DarkPurple.Code) return Color.DarkMagenta;
            if (Code == Gold.Code) return Color.Goldenrod;
            if (Code == Gray.Code) return Color.Gray;
            if (Code == DarkGray.Code) return Color.DarkGray;
            if (Code == Blue.Code) return Color.Blue;
            if (Code == Green.Code) return Color.Green;
            if (Code == Aqua.Code) return Color.Cyan;
            if (Code == Red.Code) return Color.Red;
            if (Code == LightPurple.Code) return Color.Magenta;
            if (Code == Yellow.Code) return Color.Yellow;

            return Color.White;
        }

        public static string CodeToId(string code)
        {
            switch (code)
            {
                case "0": return "black";
                case "1": return "dark_blue";
                case "2": return "dark_green";
                case "3": return "dark_aqua";
                case "4": return "dark_red";
                case "5": return "dark_purple";
                case "6": return "gold";
                case "7": return "gray";
                case "8": return "dark_gray";
                case "9": return "blue";
                case "a": return "green";
                case "b": return "aqua";
                case "c": return "red";
                case "d": return "light_purple";
                case "e": return "yellow";
                default: return "white";
            }
        }
    }
}
