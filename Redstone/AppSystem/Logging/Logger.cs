using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Redstone.AppSystem.Logging
{
	public sealed class Logger
	{
		public static List<Log> Logs = new List<Log>();

		public const string Dir = "Redstone/Logs/";
		public static int SessionNumber => Directory.GetFiles(Dir).Length;

		public static void Load()
		{
			if (!Enabled) return;
			LoggingInterval logInterval = LoggingInterval.Daily; // For now TODO add logging config?
			switch (logInterval)
			{
				case LoggingInterval.OneFile:
					const string file = "Redstone/Logs/Log.json";
					if (File.Exists(file))
					{
						Logs = JsonConvert.DeserializeObject<List<Log>>(File.ReadAllText(file));
					}

					break;
				case LoggingInterval.Daily:
					string dayFile = "Redstone/Logs/" + DateTime.Now.ToShortDateString() + ".json";
					if (File.Exists(dayFile))
					{
						Logs = JsonConvert.DeserializeObject<List<Log>>(File.ReadAllText(dayFile));
					}

					break;
			}
		}

		public static void Save()
		{
			if (!Enabled) return;
			if (!Directory.Exists("Redstone/")) Directory.CreateDirectory("Redstone/");
			if (!Directory.Exists("Redstone/Logs/")) Directory.CreateDirectory("Redstone/Logs/");

			LoggingInterval logInterval = LoggingInterval.Daily;
			string file = "";
			switch (logInterval)
			{
				case LoggingInterval.OneFile:
					file = "Redstone/Logs/Log.json";
					break;
				case LoggingInterval.Daily:
					file = "Redstone/Logs/" + DateTime.Now.ToShortDateString() + ".json";
					break;
				case LoggingInterval.Session:
					file = "Redstone/Logs/" + "Session" + SessionNumber + ".json";
					break;
			}

			if (File.Exists(file)) File.Delete(file);
			var writer = File.CreateText(file);
			writer.WriteLine(JsonConvert.SerializeObject(Logs));
			writer.Flush();
			writer.Close();
		}

		/// <summary>
		/// Whether or not logging is enabled for this server.
		/// </summary>
		public static bool Enabled = true;

		#region Log Methods

		public static void Log(LogType type, string message)
		{
			/* Regardless if the server has logging disabled or not,
				still creates a "log" object so console can be written
			 */

			Log log = new Log
			{
				Time = DateTime.Now,
				Content = message,
				Type = type
			};

			if (Enabled) Logs.Add(log);

			switch (type)
			{
				case LogType.ConsoleOutput:
				case LogType.ConsoleInput:
					Console.ForegroundColor = ConsoleColor.Gray;
					break;
				case LogType.Crash:
					Console.ForegroundColor = ConsoleColor.DarkRed;
					break;
				case LogType.Error:
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				case LogType.Warning:
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;
				case LogType.SystemActivity:
					Console.ForegroundColor = ConsoleColor.DarkGray;
					break;
				default:
					Console.ForegroundColor = ConsoleColor.White;
					break;
			}
			Console.WriteLine(log.ToString());
		}

		[StringFormatMethod("message")]
		public static void Log(LogType type, string message, params string[] args)
		{
			Log(type, string.Format(message, args));
		}

		public static void Log(string message)
		{
			Log(LogType.Normal, message);
		}

		[StringFormatMethod("message")]
		public static void Log(string message, params string[] args)
		{
			Log(LogType.Normal, message, args);
		}

		#endregion
	}

}
