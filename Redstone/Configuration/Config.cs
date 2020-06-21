using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Redstone.AppSystem.Logging;
using Redstone.Configuration.Sections;

namespace Redstone.Configuration
{
	public class Config
	{
		public static int Version = 0;
		public const string Dir = "Redstone/config.json";

		public static General General = new General();
		public static Chat Chat = new Chat();
		public static Sections.Worlds Worlds = new Sections.Worlds();
		public static Ranks Ranks = new Ranks();
		public static Security Security = new Security();
		public static Advanced Advanced = new Advanced();
		public static Sections.Plugins Plugins = new Sections.Plugins();
		public static Misc Misc = new Misc();

		public class JsonFile
		{
			public int FileVersion = Version;

			public General General = new General();
			public Chat Chat = new Chat();
			public Sections.Worlds Worlds = new Sections.Worlds();
			public Ranks Ranks = new Ranks();
			public Security Security = new Security();
			public Advanced Advanced = new Advanced();
			public Sections.Plugins Plugins = new Sections.Plugins();
			public Misc Misc = new Misc();
			public JsonFile()
			{

			}
		}

		public static void Save()
		{
			JsonFile file = new JsonFile {FileVersion = Version};

			file.General = General;
			file.Chat = Chat;
			file.Worlds = Worlds;
			file.Ranks = Ranks;
			file.Security = Security;
			file.Advanced = Advanced;
			file.Plugins = Plugins;
			file.Misc = Misc;

			var writer = File.CreateText(Dir);
			string json = JsonConvert.SerializeObject(file, Formatting.Indented);
			writer.Write(json);
			writer.Flush();
			writer.Close();
		}

		public static void LoadDefaults()
		{
			General.LoadDefaults();
			Chat.LoadDefaults();
			Worlds.LoadDefaults();
			Ranks.LoadDefaults();
			Security.LoadDefaults();
			Advanced.LoadDefaults();
			Plugins.LoadDefaults();
			Misc.LoadDefaults();
		}

		public bool TrySave()
		{
			try
			{
				Save();
				return true;
			}
			catch (Exception e)
			{
				Logger.Log(LogType.Error, "Error saving config: " + e);
				return false;
			}
		}

		public static bool TryLoad()
		{
			try
			{
				Load();
				return true;
			}
			catch (Exception e)
			{
				Logger.Log(LogType.Error, "Error loading config: " + e);
				return false;
			}
		}

		public static void Load()
		{
			if (!File.Exists(Dir))
			{
				Logger.Log(LogType.Warning, "config.json not found. Loading defaults");
				LoadDefaults();
				Save();
				return;
			}

			JsonFile file = JsonConvert.DeserializeObject<JsonFile>(File.ReadAllText(Dir));
			if (Version < file.FileVersion)
			{
				Logger.Log(LogType.Warning,
					"Newer or unrecognized config format. Recommended you backup your server before continuing.");
			}

			// Gen Chat Worlds Ranks
			General = file.General;
			Chat = file.Chat;
			Worlds = file.Worlds;
			Ranks = file.Ranks;
			Security = file.Security;
			Advanced = file.Advanced;
			Plugins = file.Plugins;
			Misc = file.Misc;
		}

	}
}
