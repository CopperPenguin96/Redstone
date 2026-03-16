using System.Text;

namespace Redstone.Core.Logging
{
    public class Logger
    {
        private static void Log(Log log)
        {
            Console.ForegroundColor = log.Type switch
            {
                LogType.System => ConsoleColor.Gray,
                LogType.Warning => ConsoleColor.Yellow,
                LogType.Error => ConsoleColor.Red,
                LogType.Fatal => ConsoleColor.DarkRed,
                _ => ConsoleColor.White
            };

            Console.WriteLine(log.ToString());
            Console.ResetColor();
        }

        public static void Log(string message, LogType type = LogType.Normal)
        {
            Log(new Log(message, type));
        }

        public static void LogSystem(string message)
        {
            Log(message, LogType.System);
        }

        public static void LogWarning(string message)
        {
            Log(message, LogType.Warning);
        }

        public static void LogError(string message)
        {
            Log(message, LogType.Error);
        }

        public static void LogFatal(string message)
        {
            Log(message, LogType.Fatal);
        }

        internal static void Log(byte library, string message, LogType type = LogType.Normal)
        {
            // Todo - impliment
            // byte 
        }
    }

    public enum LogType
    {
        Normal = 0,
        System = 1,
        Warning = 2,
        Error = 3,
        Fatal = 4
    }

    internal struct Log(string message, LogType type = LogType.Normal)
    {
        public DateTime Time { get; private set; } = DateTime.Now;

        public string Message { get; private set; } = message;

        public LogType Type { get; private set; } = type;

        public override readonly string ToString()
        {
            StringBuilder builder = new($"({Time:MM/dd/yyyy HH:mm:ss.ffff}) ");

            switch (Type)
            {
                case LogType.System:
                    builder.Append("(System) ");
                    break;
                case LogType.Warning:
                    builder.Append("(Warning) ");
                    break;
                case LogType.Error:
                    builder.Append("(Error) ");
                    break;
                case LogType.Fatal:
                    builder.Append("(!!!FATAL!!!) ");
                    break;
                default:
                    break;
            }

            builder.Append(Message);
            return builder.ToString();
        }
    }
}
