using Redstone.Core.Configuration.Sections;
using Redstone.Core.Logging;
using Tomlyn;
using Tomlyn.Model;

namespace Redstone.Core.Configuration
{
    public sealed class ConfigManifest
    {
        public const byte Version = 0x00;

        internal const string Path = Redstone.Path + "config.toml";

        internal List<ConfigSection> Sections = [];

        public static void Init()
        {
            Logger.LogSystem("Attempting to load the config.");
            ConfigManifest manifest = new();
            GeneralConfig general = new();
            PlayerConfig player = new();
            WorldConfig world = new();
            NetworkConfig network = new();
            SecurityConfig security = new();
            AdvancedConfig advanced = new();
            MiscConfig misc = new();

            bool defaults = false;
            bool save = false;

            Redstone.ConfigManifest = new();

            if (!File.Exists(Path))
            {
                Logger.LogWarning("Config not found. Defaults will be loaded.");
                defaults = true;
                save = true;
            }
            else
            {
                Logger.LogSystem("Config found. Attempting to load...");
                string content = File.ReadAllText(Path);
                if (string.IsNullOrEmpty(content))
                {
                    Logger.LogWarning("Config is empty! Loading defaults.");
                    defaults = true;
                    save = true;
                }
                else
                {
                    TomlTable masterTable = Toml.ToModel(content);
                    if (!masterTable.ContainsKey("config-version"))
                    {
                        Logger.LogWarning("Config does not have a registered version. Some data loss might occur.");
                    }
                    else
                    {
                        byte version = (byte)(long)masterTable["config-version"];
                        if (version < Version)
                        {
                            Logger.LogWarning("Config outdated. Will attempt to update. Some data loss might occur.");
                        }
                        else if (version > Version)
                        {
                            Logger.LogWarning("Unrecognized config config version found. Will correct with current version. Some data loss might occur.");
                        }
                        else
                        {
                            foreach (string key in masterTable.Keys)
                            {
                                switch (key)
                                {
                                    case "general":
                                        general.Load((TomlTable)masterTable[key]);
                                        break;
                                    case "player":
                                        player.Load((TomlTable)masterTable[key]);
                                        break;
                                    case "world":
                                        world.Load((TomlTable)masterTable[key]);
                                        break;
                                    case "network":
                                        network.Load((TomlTable)masterTable[key]);
                                        break;
                                    case "security":
                                        security.Load((TomlTable)masterTable[key]);
                                        break;
                                    case "advanced":
                                        advanced.Load((TomlTable)masterTable[key]);
                                        break;
                                    case "misc":
                                        misc.Load((TomlTable)masterTable[key]);
                                        break;
                                    default:
                                        if (key == "config-version") break;

                                        Logger.LogError("Unrecognized config section found. Will not be kept. Data loss will occur.");
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            Redstone.ConfigManifest = new(); // just for safety
            Redstone.ConfigManifest.Sections.AddRange([general, player, world, network, security, advanced, misc]); // populate the manifest

            Logger.LogSystem("Config loaded.");
            if (save) Save();
        }

        public static void Save()
        {
            Logger.LogSystem("Saving the config...");
            TomlTable mainTable = new TomlTable
            {
                { "config-version", Version }
            };

            foreach (ConfigSection section in Redstone.ConfigManifest.Sections)
            {
                mainTable[section.Name] = section.TomlTable();
            }

            string tomlString = Toml.FromModel(mainTable);

            var fileWriter = File.CreateText(Path);
            fileWriter.Write(tomlString);
            fileWriter.Flush();
            fileWriter.Close();
            Logger.LogSystem("Config saved!");
        }

        public static T Get<T>(string sectionName, string keyName)
        {
            foreach (ConfigSection section in Redstone.ConfigManifest.Sections)
            {
                if (section.Name == sectionName)
                {
                    IConfigKey key = section.GetKey(keyName);

                    if (key != null)
                    {
                        return (T)key.ValueAsObject();
                    }

                    throw new RedstoneException($"Key '{keyName}' not found in section '{sectionName}'.", Severity.Warning);
                }
            }

            throw new RedstoneException($"Section '{sectionName}' not found.", Severity.Warning);
        }
    }
}
