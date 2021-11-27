using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Redstone.Utils;

namespace Redstone.Configuration
{
    public class Config
    {
        public const int Version = 0;
        public const string Dir = Server.Path + "Config/";
        public const string Path = Dir + "main.json";
        public static bool Loaded = false;

        #region General

        public static string ServerName { get; set; }
        public static int Port { get; set; }
        public static string MessageOfTheDay { get; set; }
        public static int MaxPlayers { get; set; }

        #endregion

        #region Logging

        public static MinecraftFormatting LogNormalColor { get; set; }
        public static MinecraftFormatting LogChatColor { get; set; }
        public static MinecraftFormatting LogSystemColor { get; set; }
        public static MinecraftFormatting LogWarningColor { get; set; }
        public static MinecraftFormatting LogErrorColor { get; set; }
        public static MinecraftFormatting LogFatalColor { get; set; }
        public static bool LogSavingEnabled { get; set; }
        public static LogSaveMode LogSaveMode { get; set; }

        #endregion

        #region Misc

        public static string IconFile { get; set; }

        #endregion

        #region Saving

        private static readonly JsonObject SaveObject = new();
        public static void Save()
        {
            if (!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(Dir);
            }

            SaveObject.Add(VersionName, Config.Version);
            SaveGeneral();
            SaveLogging();
            SaveMisc();

            string json = SaveObject.ToString();
            object o = JsonConvert.DeserializeObject(json)!;
            json = JsonConvert.SerializeObject(o, Formatting.Indented);

            var writer = File.CreateText(Path);
            writer.WriteLine(json);
            writer.Flush();
            writer.Close();
        }

        private static void SaveGeneral()
        {
            SaveObject.Add(ServerNameName, ServerName);
            SaveObject.Add(PortName, Port);
            SaveObject.Add(MotdName, MessageOfTheDay);
            SaveObject.Add(MaxPlayersName, MaxPlayers);
        }

        private static void SaveLogging()
        {
            SaveObject.Add(LogNormalName, LogNormalColor.Code.ToString());
            SaveObject.Add(LogChatName, LogChatColor.Code.ToString());
            SaveObject.Add(LogSystemName, LogSystemColor.Code.ToString());
            SaveObject.Add(LogWarningName, LogWarningColor.Code.ToString());
            SaveObject.Add(LogErrorName, LogErrorColor.Code.ToString());
            SaveObject.Add(LogFatalName, LogFatalColor.Code.ToString());
            SaveObject.Add(LogSavingName, LogSavingEnabled);
            SaveObject.Add(LogSaveModeName, LogSaveMode);
        }

        private static void SaveMisc()
        {
            SaveObject.Add(IconName, IconFile);
        }

        #endregion

        #region Loading

        private static JObject _obj;
        public static void Load(bool defaults = false)
        {
            if (!Directory.Exists(Dir)
                || !File.Exists(Path)) // If config does not exist, automatically assume loading defaults
            {
                Logger.Log("Config not found. Loadng defaults", LogLevel.Warning);
                LoadGeneral(true);
                LoadLogging(true);
                LoadMisc(true);
                Save();
                Loaded = true;
            }
            else
            {
                _obj = JObject.Parse(File.ReadAllText(Path));
                try
                {
                    int version = _obj[VersionName].Value<int>();
                    if (version < Config.Version)
                    {
                        Logger.Log("Config version is out of date. Updates will be applied and then saved.");
                        Save();
                        Load();
                    }

                    LoadGeneral(defaults);
                    LoadLogging(defaults);
                    LoadMisc(defaults);
                    Loaded = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error loading the config! " + e);
                }
            }
        }

        private static void LoadGeneral(bool defaults)
        {
            if (defaults)
            {
                ServerName = "[Redstone] Default";
                Port = 25565;
                MessageOfTheDay = "Welcome to the server!";
                MaxPlayers = 20;
            }
            else
            {
                ServerName = _obj[ServerNameName].Value<string>();
                Port = _obj[PortName].Value<int>();
                MessageOfTheDay = _obj[MotdName].Value<string>();
                MaxPlayers = _obj[MaxPlayersName].Value<int>();
            }
        }

        
        private static void LoadLogging(bool defaults)
        {
            if (defaults)
            {
                LogNormalColor = MinecraftFormatting.White;
                LogChatColor = MinecraftFormatting.Gray;
                LogSystemColor = MinecraftFormatting.DarkGray;
                LogWarningColor = MinecraftFormatting.Yellow;
                LogErrorColor = MinecraftFormatting.Red;
                LogFatalColor = MinecraftFormatting.DarkRed;
            }
            else
            {
                LogNormalColor = _obj[LogNormalName].Value<char>();
                LogChatColor = _obj[LogChatName].Value<char>();
                LogSystemColor = _obj[LogSystemName].Value<char>();
                LogWarningColor = _obj[LogWarningName].Value<char>();
                LogErrorColor = _obj[LogErrorName].Value<char>();
                LogFatalColor = _obj[LogFatalName].Value<char>();
                LogSavingEnabled = _obj[LogSavingName].Value<bool>();
                LogSaveMode = (LogSaveMode) _obj[LogSaveModeName].Value<int>();
            }
        }

        private static void LoadMisc(bool defaults)
        {
            if (defaults)
            {
                IconFile = "Redstone/ricon.png";
            }
            else
            {
                IconFile = _obj[IconName].Value<string>();
            }
        }

        #endregion

        #region Constants

        // General
        private const string VersionName = "configVersion";
        private const string ServerNameName = "serverName";
        private const string PortName = "port";
        private const string MotdName = "motd";
        private const string MaxPlayersName = "maxPlayers";

        // Logging
        private const string LogNormalName = "logNormalColor";
        private const string LogChatName = "logChatColor";
        private const string LogSystemName = "logSystemColor";
        private const string LogWarningName = "logWarningColor";
        private const string LogErrorName = "logErrorColor";
        private const string LogFatalName = "logFatalColor";
        private const string LogSavingName = "logSaving";
        private const string LogSaveModeName = "logSaveMode";

        // Misc
        private const string IconName = "listIcon";

        #endregion
    }
}
