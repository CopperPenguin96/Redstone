using Redstone.Core.Configuration;
using Redstone.Core.Logging;
using Redstone.Core.Utils;

namespace Redstone.Core
{
    public sealed class Redstone
    {
        public const string Path = "redstone/";

        public static bool IsInit { get; private set; }

        public static bool IsDebug { get; private set; }

        public static bool IsTest { get; private set; }

        public static ConfigManifest ConfigManifest = new();

        /// <summary>
        /// Inits the library with parameters if applied. Possible parameters are:
        /// - no_init_dir -> Instructs Redstone not to init the directories
        /// - no_init_config -> Instructs Redstone not to init the configuration
        /// - debug -> signals that we are in debug mode to the server. #if DEBUG methods will operate.
        /// - test -> signals that we are in test mode to the server. #if 
        /// </summary>
        public static void Init(params string[] parameters)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Title.Main());
            Console.ResetColor();
            Logger.LogSystem("Initializing the Redstone library...");

            if (IsInit) return;

            foreach (var parameter in parameters)
            {
                Logger.LogSystem("Init passed argument " + parameter);
            }

            if (!parameters.Contains("no_init_dir")) InitDirectories();
            if (!parameters.Contains("no_init_config")) ConfigManifest.Init();

            if (parameters.Contains("debug"))
            {
                Logger.LogWarning("Redstone has entered DEBUG mode.");
                IsTest = true;
            }

            if (parameters.Contains("test"))
            {
                Logger.LogWarning("Redstone has entered TEST mode.");
                IsDebug = true;
            }

            IsInit = true;
        }

        private static void InitDirectories()
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
        }
    }
}
