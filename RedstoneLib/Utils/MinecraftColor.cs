using System;

namespace Redstone.Utils
{
	public sealed class MinecraftColor
	{
		#region Color Definitions 

		public static readonly ColorDefinition Black = new()
		{
			Code = '0',
			R = 0, G = 0, B = 0,
			Hex = "000000",
			Name = "Black", ID = "black"
		};

		public static readonly ColorDefinition DarkBlue = new()
		{
			Code = '1',
			R = 0, G = 0, B = 170,
			Hex = "0000AA",
			Name = "Dark Blue", ID = "dark_blue"
		};

		public static readonly ColorDefinition DarkGreen = new()
		{
			Code = '2',
			R = 0, G = 170, B = 0,
			Hex = "00AA00",
			Name = "Dark Green", ID = "dark_green"
		};

		public static readonly ColorDefinition DarkAqua = new()
		{
			Code = '3',
			R = 0, G = 170, B = 170,
			Hex = "00AAAA",
			Name = "Dark Aqua", ID = "dark_aqua"
		};

		public static readonly ColorDefinition DarkRed = new()
		{
			Code = '4',
			R = 170, G = 0, B = 0,
			Hex = "AA0000",
			Name = "Dark Red", ID = "dark_red"
		};

		public static readonly ColorDefinition DarkPurple = new()
		{
			Code = '5',
			R = 170, G = 0, B = 170,
			Hex = "AA00AA",
			Name = "Dark Purple", ID = "dark_purple"
		};

		public static readonly ColorDefinition Gold = new()
		{
			Code = '6',
			R = 255, G = 170, B = 0,
			Hex = "FFAA00",
			Name = "Gold", ID = "gold"
		};

		public static readonly ColorDefinition Gray = new()
		{
			Code = '7',
			R = 170, G = 170, B = 170,
			Hex = "AAAAAA",
			Name = "Gray", ID = "Gray"
		};

		public static readonly ColorDefinition DarkGray = new()
		{
			Code = '8',
			R = 85, G = 85, B = 85,
			Hex = "555555",
			Name = "Dark Gray", ID = "dark_gray"
		};

		public static readonly ColorDefinition Blue = new()
		{
			Code = '9',
			R = 85, G = 85, B = 255,
			Hex = "5555FF",
			Name = "Blue", ID = "blue"
		};

		public static readonly ColorDefinition Green = new()
		{
			Code = 'a',
			R = 85, G = 255, B = 85,
			Hex = "55FF55",
			Name = "Green", ID = "green"
		};

		public static readonly ColorDefinition Aqua = new()
		{
			Code = 'b',
			R = 85, G = 255, B = 255,
			Hex = "55FFFF",
			Name = "Aqua", ID = "aqua"
		};

		public static readonly ColorDefinition Red = new()
		{
			Code = 'c',
			R = 255, G = 85, B = 85,
			Hex = "FF5555",
			Name = "Red", ID = "red"
		};

		public static readonly ColorDefinition LightPurple = new()
		{
			Code = 'd',
			R = 255, G = 85, B = 255,
			Hex = "FF55FF",
			Name = "Light Purple", ID = "light_purple"
		};

		public static readonly ColorDefinition Yellow = new()
		{
			Code = 'e',
			R = 255, G = 255, B = 85,
			Hex = "FFFF55",
			Name = "Yellow", ID = "yellow"
		};

		public static readonly ColorDefinition White = new()
		{
			Code = 'f',
			R = 255, G = 255, B = 255,
			Hex = "FFFFFF",
			Name = "White", ID = "white"
		};

		/// <summary>
		/// Bedrock only
		/// </summary>
		public static readonly ColorDefinition MinecoinGold = new()
		{
			Code = 'g',
			R = 221, G = 214, B = 5,
			Hex = "DDD605",
			Name = "Minecoin Gold", ID = "minecoin_gold"
		};

		#endregion

		#region Formatting Definitions

		public static readonly ColorDefinition Obfuscated = new()
		{
			Code = 'k',
			Name = "Obfuscated"
		};

		public static readonly ColorDefinition Bold = new()
		{
			Code = 'l',
			Name = "Bold"
		};

		public static readonly ColorDefinition Strikethrough = new()
		{
			Code = 'm',
			Name = "Strikethrough"
		};

		public static readonly ColorDefinition Underline = new()
		{
			Code = 'n',
			Name = "Italic"
		};

		public static readonly ColorDefinition Italic = new()
		{
			Code = 'o',
			Name = "Italic"
		};

		public static readonly ColorDefinition Reset = new()
		{
			Code = 'r',
			Name = "Reset"
		};

		#endregion

		private readonly ColorDefinition _color;

		private MinecraftColor(char color)
		{
			bool assigned = false;
			foreach (ColorDefinition col in _defs)
			{
				if (col.Code == color)
				{
					_color = col;
					assigned = true;
				}
			}

			if (assigned) return;

			_color = White;
		}

		private static readonly ColorDefinition[] _defs =
		{
			Black, DarkBlue, DarkGreen, DarkAqua, DarkRed, DarkPurple,
			Gold, Gray, DarkGray, Blue, Green, Aqua, Red, LightPurple,
			Yellow, White, MinecoinGold,
			Obfuscated, Bold, Strikethrough, Underline, Italic, Reset
		};

		public static implicit operator string(MinecraftColor color)
		{
			if (Black == (ColorDefinition) color) return $"&{Black.Code}";
			if (DarkBlue == (ColorDefinition) color) return $"&{DarkBlue.Code}";
			if (DarkGreen == (ColorDefinition) color) return $"&{DarkGreen.Code}";
			if (DarkAqua == (ColorDefinition) color) return $"&{DarkAqua.Code}";
			if (DarkRed == (ColorDefinition) color) return $"&{DarkRed.Code}";
			if (DarkPurple == (ColorDefinition)color) return $"&{DarkPurple.Code}";
			if (Gold == (ColorDefinition)color) return $"&{Gold.Code}";
			if (Gray == (ColorDefinition)color) return $"&{Gray.Code}";
			if (DarkGray == (ColorDefinition)color) return $"&{DarkGray.Code}";
			if (Blue == (ColorDefinition)color) return $"&{Blue.Code}";
			if (Green == (ColorDefinition)color) return $"&{Green.Code}";
			if (Aqua == (ColorDefinition)color) return $"&{Aqua.Code}";
			if (Red == (ColorDefinition)color) return $"&{Red.Code}";
			if (LightPurple == (ColorDefinition)color) return $"&{LightPurple.Code}";
			if (Yellow == (ColorDefinition)color) return $"&{Yellow.Code}";
			if (White == (ColorDefinition)color) return $"&{White.Code}";
			if (MinecoinGold == (ColorDefinition)color) return $"&{MinecoinGold.Code}";
			if (Obfuscated == (ColorDefinition)color) return $"&{Obfuscated.Code}";
			if (Bold == (ColorDefinition)color) return $"&{Bold.Code}";
			if (Strikethrough == (ColorDefinition)color) return $"&{Strikethrough.Code}";
			if (Underline == (ColorDefinition)color) return $"&{Underline.Code}";
			if (Italic == (ColorDefinition)color) return $"&{Italic.Code}";
			if (Reset == (ColorDefinition)color) return $"&{Reset.Code}";
			return "";
		}

		public static explicit operator ConsoleColor(MinecraftColor color)
		{
			if (Black == (ColorDefinition)color) return ConsoleColor.Black;
			if (DarkBlue == (ColorDefinition)color) return ConsoleColor.DarkBlue;
			if (DarkGreen == (ColorDefinition) color) return ConsoleColor.DarkGreen;
			if (DarkAqua == (ColorDefinition) color) return ConsoleColor.DarkCyan;
			if (DarkRed == (ColorDefinition) color) return ConsoleColor.DarkRed;
			if (DarkPurple == (ColorDefinition) color) return ConsoleColor.DarkMagenta;
			if (Gold == (ColorDefinition)color) return ConsoleColor.DarkYellow;
			if (Gray == (ColorDefinition)color) return ConsoleColor.Gray;
			if (DarkGray == (ColorDefinition) color) return ConsoleColor.DarkGray;
			if (Blue == (ColorDefinition)color) return ConsoleColor.Blue;
			if (Green == (ColorDefinition)color) return ConsoleColor.Green;
			if (Aqua == (ColorDefinition) color) return ConsoleColor.Cyan;
			if (Red == (ColorDefinition)color) return ConsoleColor.Red;
			if (LightPurple == (ColorDefinition)color) return ConsoleColor.DarkMagenta;
			if (Yellow == (ColorDefinition) color) return ConsoleColor.Yellow;
			if (White == (ColorDefinition) color) return ConsoleColor.White;
			if (MinecoinGold == (ColorDefinition)color) return ConsoleColor.DarkYellow;
			return ConsoleColor.White;
		}

		public static implicit operator MinecraftColor(char color)
		{
			return new MinecraftColor(color);
		}

		public static implicit operator char(MinecraftColor mcColor)
		{
			return mcColor._color.Code;
		}

		public static implicit operator MinecraftColor(ColorDefinition def)
		{
			return new MinecraftColor(def.Code);
		}

		public static implicit operator ColorDefinition(MinecraftColor col)
		{
			return col._color;
		}
		
		public class ColorDefinition
		{
			public char Code { get; set; }

			public int R { get; set; }

			public int G { get; set; }

			public int B { get; set; }

			private string _hex = "000000";

			public string Hex
			{
				get => "#" + _hex;
				set => _hex = value;
			}

			public string Name { get; set; }

			public string ID { get; set; }
		}
	}
}
