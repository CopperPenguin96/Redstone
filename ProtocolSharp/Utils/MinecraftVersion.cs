namespace ProtocolSharp.Utils
{
	/// <summary>
	/// Object related to Minecraft Version and corresponding protocol number
	/// Public objects within start with 1.16.4 (754) as this is the first
	/// version that this project supports
	/// </summary>
	public class MinecraftVersion
	{
		public short Major { get; }

		public short Minor { get; }

		public short Build { get; }

		public short Revision { get; }

		public int ProtocolVersion { get; }

		public MinecraftVersion(int pro, short major, short minor,
			short build = -1, short revision = -1)
		{
			ProtocolVersion = pro;
			Major = major;
			Minor = minor;
			Build = build;
			Revision = revision;
		}

		public static ResponseVersion GetResponseVersion()
		{
			var rv = new ResponseVersion(
				Current.ToString(),
				Current.ProtocolVersion
			);
			return rv;
		}

		/// <summary>
		/// Minecraft Version 1.16.4
		/// </summary>
		public static readonly MinecraftVersion Pro754 =
			new MinecraftVersion(754, 1, 16, 4);

		public static readonly MinecraftVersion Current = Pro754;
	}
}
