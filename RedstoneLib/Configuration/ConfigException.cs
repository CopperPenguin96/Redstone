using System;
using Redstone.AppSystem;

namespace Redstone.Configuration
{
	public class ConfigException : RedstoneException
	{
		protected override string BaseMessage => "There was an issue with the config.";

		public ConfigException(LogType type = LogType.Error) : base(type)
		{
		}

		public ConfigException(string message, LogType type = LogType.Error) : base(message, type)
		{
		}

		public ConfigException(string message, Exception inner, LogType type) : base(message, inner, type)
		{
		}

		public ConfigException(Exception inner, LogType type = LogType.Error) : base(inner, type)
		{
		}
	}
}
