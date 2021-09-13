using System;
using Redstone.AppSystem;

namespace Redstone.Network
{
	public class ProtocolException : RedstoneException
	{
		protected override string BaseMessage => "There was an issue with the protocol.";

		public ProtocolException(LogType type = LogType.Error) : base(type)
		{
		}

		public ProtocolException(string message, LogType type = LogType.Error) : base(message, type)
		{
		}

		public ProtocolException(string message, Exception inner, LogType type) : base(message, inner, type)
		{
		}

		public ProtocolException(Exception inner, LogType type = LogType.Error) : base(inner, type)
		{
		}
	}
}