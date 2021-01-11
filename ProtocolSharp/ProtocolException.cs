using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolSharp
{
	public class ProtocolException : Exception
	{
		public ProtocolException(string message) : base(message)
		{
			
		}

		public ProtocolException(string message, Exception inner) : base(message, inner)
		{

		}

		public ProtocolException(Exception inner) : base("", inner)
		{

		}
	}
}
