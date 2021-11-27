using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Math.EC;
using Redstone.Configuration;

namespace Redstone.Utils
{
    /// <summary>
    /// Logging system used by Redstone.
    /// </summary>
    public sealed class Logger
    {
        /// <summary>
        /// Holds the logs before they are sent to the console/logs
        /// </summary>
        internal static readonly Queue Logs = new();

        public static void Log(Log log)
        {
            Logs.Enqueue(log);
        }

        private const string Path = Server.Path + "Logs/";

        private static readonly StringBuilder CurrentFile = new();

        /// <summary>
        /// Waits for logs to show, then pushes them.
        /// Also handles the log file(s).
        /// </summary>
        public static void Watch()
        {
            while (!Config.Loaded)
            {
                
            }
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            string file = "";
            while (true)
            {
                if (Logs.Count <= 0) continue; // wait for more logs
                Log log = (Log) Logs.Dequeue()!;

                ConsoleColor color = ConsoleColor.White;
                switch (log.Level)
                {
                    case LogLevel.Normal:
                        color = Config.LogNormalColor.ToConsoleColor();
                        break;
                    case LogLevel.Chat:
                        color = Config.LogChatColor.ToConsoleColor();
                        break;
                    case LogLevel.System:
                        color = Config.LogSystemColor.ToConsoleColor();
                        break;
                    case LogLevel.Warning:
                        color = Config.LogWarningColor.ToConsoleColor();
                        break;
                    case LogLevel.Error:
                        color = Config.LogErrorColor.ToConsoleColor();
                        break;
                    case LogLevel.Fatal:
                        color = Config.LogFatalColor.ToConsoleColor();
                        break;
                }

                // push to console
                Console.ForegroundColor = color;
                Console.WriteLine(log);

                // handle saving
                List<string> fileContents = new();
                if (Config.LogSavingEnabled)
                {
                    switch (Config.LogSaveMode)
                    {
                        case LogSaveMode.OneFile:
                            file = Path + "logs.txt";
                            if (File.Exists(file)) fileContents = File.ReadAllLines(file).ToList();
                            break;
                        case LogSaveMode.Session:
                            file = Path + Server.StartTime.Ticks + ".txt";
                            if (File.Exists(file)) fileContents = File.ReadAllLines(file).ToList();
                            break;
                        case LogSaveMode.Day:
                            file = $"{Path}{Server.StartTime.Day}_{Server.StartTime.Month}_{Server.StartTime.Year}.txt";
                            if (File.Exists(file)) fileContents = File.ReadAllLines(file).ToList();
                            break;
                    }

                    foreach (string line in fileContents)
                    {
                        CurrentFile.AppendLine(line);
                    }

                    CurrentFile.AppendLine(log.ToString());

                    var writer = File.CreateText(file);
                    writer.WriteLine(CurrentFile.ToString());
                    writer.Flush();
                    writer.Close();
                }
            }
        }

        public static void Log(string message, LogLevel level = LogLevel.Normal)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            Log(new Log(message, level));
        }

        public static void LogWarning(string message)
        {
            Log(message, LogLevel.Warning);
        }

        public static void LogError(string message)
        {
            Log(message, LogLevel.Error);
        }

        public static void LogFatal(string message)
        {
            Log(message, LogLevel.Fatal);
        }

        public static void LogChat(string message)
        {
            Log(message, LogLevel.Chat);
        }
    }

    public struct Log
    {
        public LogLevel Level { get; set; } = LogLevel.Normal;

        public string Message { get; set; }

        public DateTime SentTime { get; set; }

        public Log(string message, LogLevel level = LogLevel.Normal)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
            SentTime = DateTime.Now;
            Level = level;
        }

        public override string ToString()
        {
            StringBuilder logString = new($"[{DateTime.Now:yyyy-MM-dd hh:mm:ss tt}]");

            switch (Level)
            {
                case LogLevel.Warning:
                    logString.Append(" [Warning]: ");
                    break;
                case LogLevel.Error:
                    logString.Append(" [Error]: ");
                    break;
                case LogLevel.Fatal:
                    logString.Append(" [Fatal]: ");
                    break;
                case LogLevel.System:
                    logString.Append(" [System]: ");
                    break;
                default:
                    logString.Append(": ");
                    break;
            }

            logString.Append(Message);
            return logString.ToString();
        }
    }

    /// <summary>
    /// Enum representing the different types of logs
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Normal activity, not particular to the system
        /// </summary>
        Normal, 
        
        /// <summary>
        /// Redstone interworking
        /// </summary>
        System, 
        
        /// <summary>
        /// Player communication
        /// </summary>
        Chat, 
        
        /// <summary>
        /// Warnings that may have an affect on software performance or gameplay.
        /// </summary>
        Warning, 
        
        /// <summary>
        /// Errors that will prevent certain actions from continuing.
        /// </summary>
        Error,

        /// <summary>
        /// Errors that cause a software shutdown/crash.
        /// </summary>
        Fatal
    }

    /// <summary>
    /// Enum representing types of log files
    /// </summary>
    public enum LogSaveMode
    {
        /// <summary>
        /// When logs are saved under this mode, there is 1 file that is simply appended to.
        /// File name is logs.txt
        /// </summary>
        OneFile,
        
        /// <summary>
        /// When logs are saved under this mode, log files are separated by Redstone sessions.
        /// File names are represented as the date and time in which the session started.
        /// </summary>
        Session, 
        
        /// <summary>
        /// When logs are saved under this mode, log files are separated by days.
        /// File names are represented as the date. At midnight, a new log file is started.
        /// </summary>
        Day
    }
}
