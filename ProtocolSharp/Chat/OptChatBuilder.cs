using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolSharp.Chat
{
	/// <summary>
	/// Utilized by the Entity Metadata.
	/// If true sends back to client with chat
	/// </summary>
	public class OptChatBuilder
	{
		public bool IsDisplayed = false;

		public ChatBuilder Chat { get; set; }
	}
}
