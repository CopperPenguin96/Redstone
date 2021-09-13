using System.Collections.Generic;
using System.IO;
using System.Linq;
using Redstone.AppSystem;
using Redstone.Configuration.Categories;
using Redstone.Utils;

namespace Redstone.Configuration
{
	/// <summary>
	/// Represents the Configuration of Redstone.
	/// </summary>
	public class Config
	{
		/// <summary>
		/// The current version of the config.
		/// </summary>
		public const short Version = 0;
		
		/// <summary>
		/// Used to determine if the config has been loaded.
		/// </summary>
		public static bool Init { get; private set; }

		/// <summary>
		/// The different "categories" of the config.
		/// </summary>
		public List<IConfigCategory> Categories = new();

		/// <summary>
		/// Looks for specified item by name in the specified category.
		/// </summary>
		/// <param name="category">The category to look in.</param>
		/// <param name="name">The name of the config.</param>
		/// <returns>The value of the config item.</returns>
		public ConfigObject GetItem(ConfigCategory category, string name)
		{
			return (from cat in Categories where cat.Category == category from ConfigObject cObj in cat.Items where name == cObj.Name select cObj).FirstOrDefault()!;
		}

		/// <summary>
		/// Looks for the speccified item by name in the specific category.
		/// If wrong type specified, throws an exception.
		/// </summary>
		/// <typeparam name="T">The type of the object</typeparam>
		/// <param name="category">The category to look in.</param>
		/// <param name="name">The name of the config.</param>
		/// <returns>The value of the config item.</returns>
		public ConfigItem<T> GetItem<T>(ConfigCategory category, string name)
		{
			ConfigObject obj = GetItem(category, name);
			if (obj.DefaultValue.GetType() == typeof(T))
			{
				return new ConfigItem<T>(obj.Name, (T) obj.DefaultValue)
				{
					Value = (T) obj.Value!
				};
			}

			throw new ConfigException("Type mismatch.");
		}

		/// <summary>
		/// Sets the specified item by name in the specified category.
		/// </summary>
		/// <typeparam name="T">The type of the object being set.</typeparam>
		/// <param name="category">The category to set in.</param>
		/// <param name="name">The name of the config.</param>
		/// <param name="value">he value of the config item.</param>
		public void SetItem<T>(ConfigCategory category, string name, T value)
		{
			// ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
			foreach (var t in Categories)
			{
				if (t.Category != category) continue;
				for (int x = 0; x < t.Items.Count; x++)
				{
					ConfigObject o = t.Items[x];
					if (o.Name == name)
					{
						t.Items[x].Value = value;
					}
				}
			}

			throw new ConfigException("Config Item not found (" + category.ToString() + ":" + name + ")");
		}
		
		/// <summary>
		/// The file path that pertains to the configuration.
		/// </summary>
		private const string FilePath = "Redstone/config.json";

		/// <summary>
		/// Only exists to keep the constructor private.
		/// </summary>
		private Config()
		{
		}
		
		/// <summary>
		/// Loads the config.
		/// </summary>
		/// <param name="defaults">Returns as true if defaults were loaded.</param>
		/// <returns>The state of the config.</returns>
		internal static Config Load(out bool defaults)
		{
			Config loaded = new();
			Logger.Log("Loading the config.", LogType.System);
			if (!Directory.Exists("Redstone/")) Directory.CreateDirectory("Redstone/");

			if (!File.Exists(FilePath)) // Load Defaults
			{
				loaded.Categories = new List<IConfigCategory>
				{
					new BasicConfig(), new ChatConfig(), new AdvancedConfig()
				};
				Init = true;
				defaults = true;
				return loaded;
			}
			else
			{
				dynamic json = SimpleJson.DeserializeObject(File.ReadAllText(FilePath));
				if (json.Version < Version)
				{
					Logger.LogWarning(
						"Loaded config has an outdated config version. Will be updated to the current version.");
					// TODO : updates
				}
				else
				{
					loaded.Categories = json.Categories;
				}

				Init = true;
				defaults = false;
				return loaded;
			}
		}

		/// <summary>
		/// Saves the config.
		/// </summary>
		public void Save()
		{
			Logger.Log("Saving the config.", LogType.System);
			JsonObject obj = new()
			{
				{"Version", Version},
				{"Categories", Categories}
			};

			string json = obj.ToString();
			var writer = File.CreateText(FilePath);
			writer.WriteLine(json);
			writer.Flush();
			writer.Close();
			Logger.Log("Config saved.", LogType.System);
		}
	}
}