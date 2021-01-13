using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolSharp.Packets.Exceptions
{
	/// <summary>
	/// Thrown when a packet is incorrectly used or a better packet should be used
	/// </summary>
	public class InvalidPacketUseException : Exception
	{
		public InvalidPacketUseException() : base()
		{
		}

		public InvalidPacketUseException(string message) : base(message)
		{
		}

		public InvalidPacketUseException(string message, Exception inner) : base(message, inner)
		{
		}

		public InvalidPacketUseException(Exception inner) : base("", inner)
		{
		}

	}
}
