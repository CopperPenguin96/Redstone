using Redstone.Utils;

namespace Redstone.Configuration.Categories
{
	/// <summary>
	/// Chat configurations in the config.
	/// </summary>
	public class ChatConfig : IConfigCategory
	{
		public ConfigCategory Category => ConfigCategory.Chat;

		public string Name => "Chat";

		public ConfigItemList Items => new()
		{
			NormalColor,
			ChatColor,
			ConsoleColor,
			WarningColor,
			SystemColor,
			ErrorColor,
			CrashColor
		};

		/// <summary>
		/// The normal color for the console/ game messages.
		/// Most activity will be seen in this.
		/// </summary>
		public ConfigItem<MinecraftColor> NormalColor =
			new("Normal Color", MinecraftColor.Gray);

		/// <summary>
		/// The chat color for the console/in game messages.
		/// Unformatted chat messages will be seen as this.
		/// </summary>
		public ConfigItem<MinecraftColor> ChatColor =
			new("Chat Color", MinecraftColor.White);

		/// <summary>
		/// The chat color for the console/in game messages.
		/// Unformatted chat messages from the console will be seen as this.
		/// </summary>
		public ConfigItem<MinecraftColor> ConsoleColor =
			new("Console Color", MinecraftColor.DarkPurple);

		/// <summary>
		/// The system color for the console/in game messages.
		/// Messages from the server's system will be sent as this.
		/// </summary>
		public ConfigItem<MinecraftColor> SystemColor =
			new("System Color", MinecraftColor.DarkGray);

		/// <summary>
		/// The warning color for the console/in game messages.
		/// Warnings will be displayed in this color.
		/// </summary>
		public ConfigItem<MinecraftColor> WarningColor =
			new("Warning Color", MinecraftColor.Yellow);

		/// <summary>
		/// The error color for the console/in game messages.
		/// Errors will be displayed in this color.
		/// </summary>
		public ConfigItem<MinecraftColor> ErrorColor =
			new("Error Color", MinecraftColor.Red);

		/// <summary>
		/// The crash color fo the console/in game messages.
		/// Serious Errors/Crash will be displayed in this color.
		/// </summary>
		public ConfigItem<MinecraftColor> CrashColor =
			new("Crash Color", MinecraftColor.DarkRed);
	}
}
