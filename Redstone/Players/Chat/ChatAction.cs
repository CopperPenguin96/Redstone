using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Players.Chat
{
	public class ChatAction
	{
		public ChatActionType Type { get; }

		public int Method { get; }

		public string Value { get; }

		public ChatAction(ChatActionType type, ClickEvent ev, string value)
		{
			Type = type;
			Method = (int) ev;
			Value = value;
		}

		public ChatAction(ChatActionType type, HoverEvent hv, string value)
		{
			Type = type;
			Method = (int) hv;
			Value = value;
		}
	}
}
