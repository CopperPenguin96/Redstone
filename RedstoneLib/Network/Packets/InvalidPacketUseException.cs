using System;
using Redstone.AppSystem;

namespace Redstone.Network.Packets
{
	/// <summary>
	/// Thrown when a packet is incorrectly used or a better packet
	/// should be used.
	/// </summary>
	public class InvalidPacketUseException : RedstoneException
	{
		protected override string BaseMessage => "There was an issue with a packet.";

		public InvalidPacketUseException(LogType type = LogType.Error) : base(type)
		{
		}

		public InvalidPacketUseException(string message, LogType type = LogType.Error) : base(message, type)
		{
		}

		public InvalidPacketUseException(string message, Exception inner, LogType type) : base(message, inner, type)
		{
		}

		public InvalidPacketUseException(Exception inner, LogType type = LogType.Error) : base(inner, type)
		{
		}
	}
}