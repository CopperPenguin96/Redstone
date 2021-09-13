namespace Redstone.Configuration.Categories
{
	/// <summary>
	/// Advanced configurations in the config.
	/// </summary>
	public class AdvancedConfig : IConfigCategory
	{
		public ConfigCategory Category => ConfigCategory.Advanced;

		public string Name => "Advanced";

		public ConfigItemList Items => new()
		{
			TwentyFourTimeFormat,
			CheckForUpdates
		};

		/// <summary>
		/// Whether or not server's time should be displayed in a 12 hour format or 24 hour format.
		/// </summary>
		public ConfigItem<bool> TwentyFourTimeFormat =
			new("24 Hour Time", false);

		/// <summary>
		/// Whether or not to check for updates for Redstone.
		/// </summary>
		public ConfigItem<bool> CheckForUpdates =
			new("Check for Updates", true);
	}
}
