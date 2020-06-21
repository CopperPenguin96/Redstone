using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.AppSystem.Logging
{
	public sealed class Log
	{
		public string Content { get; set; }
		public LogType Type { get; set; }
		public DateTime Time { get; set; }

		public const string Format = "<{Time}> {Type} {Content}";

		/// <summary>
		/// Gets the string representation of the log
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string newStr = Format.Replace("{Type}", GetType());
			newStr = newStr.Replace("{Time}", Time.ToShortDateString() + " " + Time.ToShortTimeString());
			newStr = newStr.Replace("{Content}", Content);
			return newStr;
		}

		private new string GetType()
		{
			switch (Type)
			{
				case LogType.ConsoleOutput:
				case LogType.ConsoleInput:
					return "[Console]";
				case LogType.Crash:
					return "[CRASH]";
				case LogType.Error:
					return "[Error]";
				case LogType.Warning:
					return "[Warning]";
				default:
					return "";
			}
		}
	}
}
