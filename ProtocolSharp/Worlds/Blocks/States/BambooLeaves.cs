using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolSharp.Worlds.Blocks.States
{
	public sealed class BambooLeaves
	{
		public const string Large = "large";
		public const string None = "none";
		public const string Small = "small";

		public static string Value { get; private set; } = None;
	}

	public sealed class SaplingType
	{
		public const string Acacia = "acacia";
		public const string Birch = "birch";
		public const string DarkOak = "dark_oak";
		public const string Jungle = "jungle";
		public const string Oak = "oak";
		public const string Spruce = "spruce";

		public static string Value { get; private set; } = Oak;
	}
}
