namespace Redstone.Configuration.Categories
{
	/// <summary>
	/// Basic configurations in the config.
	/// </summary>
	public class BasicConfig : IConfigCategory
	{
		public ConfigCategory Category => ConfigCategory.Basic;

		public string Name => "Basic";

		public ConfigItemList Items => new()
		{
			ServerName,
			ServerPort,
			BedrockPort,
			MessageOfTheDay,
			IconLocation
		};

		/// <summary>
		/// The name for the server.
		/// Shown on the the (Coming Soon) official server list.
		/// </summary>
		public ConfigItem<string> ServerName =
			new("Server Name", "[Redstone] Default");

		/// <summary>
		/// The port that the server will listen on.
		/// Default is 25565.
		/// NOTE: This is not the bedrock port.
		/// </summary>
		public ConfigItem<int> ServerPort =
			new("Server Port", 25565);

		/// <summary>
		/// The port that the server will listen on for Bedrock clients.
		/// Default is 19132.
		/// NOTE: This is not the java edition port.
		/// </summary>
		public ConfigItem<int> BedrockPort =
			new("Bedrock Port", 19132);

		/// <summary>
		/// The MOTD (Message of the day) that is shown on server lists.
		/// </summary>
		public ConfigItem<string> MessageOfTheDay =
			new("MOTD", "Welcome to the server!");

		/// <summary>
		/// Server list icon location
		/// </summary>
		public ConfigItem<string> IconLocation =
			new("Icon Location", "");
	}
}
