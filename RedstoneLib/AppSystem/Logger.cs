using System;
using System.Collections.Generic;
using System.Text;
using Redstone.Configuration;
using Redstone.Players;
using Redstone.Utils;

namespace Redstone.AppSystem
{
	/// <summary>
	/// Logging/Console system for Redstone.
	/// </summary>
	public class Logger
	{
		/// <summary>
		/// List of logs for the current session
		/// </summary>
		internal static List<Log> Logs = new();

		/// <summary>
		/// Writes the provided log object
		/// </summary>
		/// <param name="log">The log to be written</param>
		public static void Log(Log log)
		{
			Logs.Add(log);
			Server.WriteLine(log);

			foreach (Player player in Server.OnlinePlayers)
			{
				switch (log.Type)
				{
					case LogType.Normal:
					case LogType.Chat:
						player.SendMessage(log);
						break;
					case LogType.Warning:
					case LogType.Error:
					case LogType.Crash:
						if (!player.IsConsole || !player.IsSuper || !player.CanReadDebug) break;
						player.SendMessage(log);
						break;
					case LogType.System:
						if (!player.CanReadDebug) break;
						player.SendMessage(log);
						break;
				}
			}
		}

		/// <summary>
		/// Logs a warning
		/// </summary>
		/// <param name="message">The warning to be written</param>
		/// <param name="ex">Optional exception that caused this log.</param>
		public static void LogWarning(string message, Exception ex = null!)
		{
			Log(new Log(message, LogType.Warning));
			if (ex != null) Log(ex.ToString(), LogType.Warning);
		}

		/// <summary>
		/// Logs an error
		/// </summary>
		/// <param name="message">The error to be written</param>
		/// <param name="ex">Optional exception that caused this log.</param>
		public static void LogError(string message, Exception ex = null!)
		{
			Log(new Log(message, LogType.Error));
			if (ex != null) Log(ex.ToString(), LogType.Error);
		}

		/// <summary>
		/// Logs a crash
		/// </summary>
		/// <param name="message">The crash report to be written</param>
		/// <param name="ex">Optional exception that caused this crash.</param>
		public static void LogCrash(string message, Exception ex = null!)
		{
			Log(new Log(message, LogType.Crash));
			if (ex != null) Log(ex.ToString(), LogType.Crash);
		}

		/// <summary>
		/// Writes a log.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		/// <param name="type">The type of log to be written.</param>
		public static void Log(string message, LogType type = LogType.Normal)
		{
			Log(new Log(message, type));
		}
	}

	/// <summary>
	/// Class that represents the log object.
	/// </summary>
	public class Log
	{
		/// <summary>
		/// The type of log
		/// </summary>
		public LogType Type { get; set; }

		/// <summary>
		/// The time to display on the log
		/// </summary>
		public DateTime Time { get; set; }

		/// <summary>
		/// The message to be written on the log
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Optional, the player who sent the log/chat
		/// </summary>
		public Player? Sender { get; set; }

		/// <summary>
		/// Normal log with time set as now.
		/// </summary>
		/// <param name="message">Message to be written.</param>
		public Log(string message) : this(message, DateTime.Now, LogType.Normal) {}

		/// <summary>
		/// Normal log with time set as provided.
		/// </summary>
		/// <param name="message">Message to be written.</param>
		/// <param name="time">Time to display on the log.</param>
		public Log(string message, DateTime time) : this(message, time, LogType.Normal) {}
		
		/// <summary>
		/// Log as specified type with time set as now.
		/// </summary>
		/// <param name="message">Message to be written.</param>
		/// <param name="type">Type of log to be written.</param>
		public Log(string message, LogType type) : this(message, DateTime.Now, type) {}

		/// <summary>
		/// Log as specified type with specified time.
		/// </summary>
		/// <param name="message">Message to be written.</param>
		/// <param name="time">Time to display on the log.</param>
		/// <param name="type">Type of log to be written.</param>
		public Log(string message, DateTime time, LogType type)
		{
			Message = message ?? throw new ArgumentNullException(nameof(message));
			Time = time;
			Type = type;
		}

		/// <summary>
		/// <inherdoc />
		/// </summary>
		/// <returns><inheritdoc /></returns>
		public override string ToString()
		{
			StringBuilder builder = new();

			// Prevents null reference when starting before config is loaded.
			if (!Config.Init)
			{
				builder.Append("<Starting>");
			}
			else if ((bool)Server.Config.GetItem(ConfigCategory.Advanced, "24 Hour Time").Value!)
			{
				builder.Append($"<{Time:HH:mm:ss}>");
			}
			else
			{
				builder.Append($"<{Time:hh:mm:ss tt}>");
			}

			// Type stamp
			if (!Config.Init)
			{
				builder.Append(" [Loading]");
			}
			else
			{
				builder.Append(Type switch
				{
					LogType.Console => (MinecraftColor)Server.Config.GetItem(ConfigCategory.Chat, "Console Color") + " [Console]&r",
					LogType.Warning => (MinecraftColor)Server.Config.GetItem(ConfigCategory.Chat, "Warning Color") + " [Warning]",
					LogType.Error => (MinecraftColor)Server.Config.GetItem(ConfigCategory.Chat, "Error Color") + " [Error]",
					LogType.Crash => (MinecraftColor)Server.Config.GetItem(ConfigCategory.Chat, "Crash Color") + " [Crash]",
					LogType.System => (MinecraftColor)Server.Config.GetItem(ConfigCategory.Chat, "System Color") + " [System]",
					_ => " "
				});
			}
			

			// Attach player names where needed
			switch (Type)
			{
				case LogType.Chat when Sender == null:
					throw new NullReferenceException(nameof(Sender));
				case LogType.Chat:
					builder.Append(" " + Sender.DisplayName + "&r:");
					break;
			}

			// Attach message
			builder.Append(" " + Message);

			// Return
			return builder.ToString();
		}
	}

	/// <summary>
	/// Type of logs
	/// </summary>
	public enum LogType
	{
		/// <summary>
		/// Normal logs from commands and information.
		/// </summary>
		Normal,

		/// <summary>
		/// Logs that represent chats.
		/// </summary>
		Chat,

		/// <summary>
		/// Logs that represent messages from Console.
		/// </summary>
		Console,

		/// <summary>
		/// Logs that represent system activity.
		/// </summary>
		System,

		/// <summary>
		/// Logs that represent warnings.
		/// </summary>
		Warning,

		/// <summary>
		/// Logs that represent errors.
		/// </summary>
		Error,

		/// <summary>
		/// Logs that represent crashes.
		/// </summary>
		Crash
	}
}
