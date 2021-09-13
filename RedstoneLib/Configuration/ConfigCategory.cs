namespace Redstone.Configuration
{
	/// <summary>
	/// Enum to define the categories as pertains to the config
	/// </summary>
	public enum ConfigCategory
	{
		/// <summary>
		/// Basic Config Items (i.e. Server name, Port, etc.)
		/// </summary>
		Basic = 0,

		/// <summary>
		/// Security Config Items (i.e. Proxy enabled, encryption, etc.)
		/// </summary>
		Security = 1,

		/// <summary>
		/// Chat Config Items (i.e. Colors, restrictions, etc.)
		/// </summary>
		Chat = 2,

		/// <summary>
		/// Rank Config Items (i.e. Rank definitions, permissions, etc.)
		/// </summary>
		Ranks = 3,

		/// <summary>
		/// Advanced Config Items
		/// </summary>
		Advanced = 4,

		/// <summary>
		/// Misc Config Items
		/// </summary>
		Misc = 5
	}
}
