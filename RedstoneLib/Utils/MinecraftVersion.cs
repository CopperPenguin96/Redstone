using Version = Version_Management.Version;

namespace Redstone.Utils
{
	/// <summary>
	/// Object related to Minecraft Version and corresponding protocol number
	/// Public objects within start with 1.16.4 (754) as this is the first
	/// version that this project supports
	/// </summary>
	public class MinecraftVersion : Version
	{
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
				Server.MinecraftVersion.ToString(),
				Server.MinecraftVersion.ProtocolVersion
			);
			return rv;
		}

		/// <summary>
		/// Minecraft Version 1.17.1
		/// </summary>
		public static readonly MinecraftVersion Pro756 =
			new MinecraftVersion(754, 1, 16, 4);
	}
}
