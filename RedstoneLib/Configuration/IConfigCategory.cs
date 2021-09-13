namespace Redstone.Configuration
{
	/// <summary>
	/// Represents the basic structure of config categories.
	/// </summary>
	public interface IConfigCategory
	{
		ConfigCategory Category { get; }

		string Name { get; }

		ConfigItemList Items { get; }
	}
}
