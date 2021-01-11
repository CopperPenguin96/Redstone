using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolSharp.Chat
{
	public class ChatMessage
	{
	}

	public enum ChatActionType
	{
		ClickEvent,
		HoverEvent
	}

	public enum ChatMode
	{
		Enabled = 0,
		CommandsOnly = 1,
		Hidden = 2
	}

	public enum ClickEvent
	{
		OpenUrl,
		RunCommand,
		SuggestCommand,
		ChangePage
	}

	public enum HoverEvent
	{
		ShowText,
		ShowItem,
		ShowEntity
	}

	public class ChatPart
	{
		public bool Bold { get; set; }
		public bool Italic { get; set; }
		public bool Underline { get; set; }
		public bool StrikeThrough { get; set; }
		public bool Goofy { get; set; }
		public string Color { get; set; }
		public ChatAction Action { get; set; }
		public string Text { get; set; }
	}

	public sealed class ChatColor
	{
		public const string Black = "§0";
		public const string DarkBlue = "§1";
		public const string DarkGreen = "§2";
		public const string DarkCyan = "§3";
		public const string DarkRed = "§4";
		public const string Purple = "§5";
		public const string Gold = "§6";
		public const string Gray = "§7";
		public const string DarkGray = "§8";
		public const string Blue = "§9";
		public const string BrightGreen = "§a";
		public const string Cyan = "§b";
		public const string Red = "§c";
		public const string Pink = "§d";
		public const string Yellow = "§e";
		public const string White = "§f";
		public const string Goofy = "§k";
		public const string Bold = "§l";
		public const string StrikeThrough = "§m";
		public const string Underline = "§n";
		public const string Italic = "§o";
		public const string Reset = "§r";
	}

	public class ChatAction
	{
		public ChatActionType Type { get; }

		public int Method { get; }

		public string Value { get; }

		public ChatAction(ChatActionType type, ClickEvent ev, string value)
		{
			Type = type;
			Method = (int)ev;
			Value = value;
		}

		public ChatAction(ChatActionType type, HoverEvent hv, string value)
		{
			Type = type;
			Method = (int)hv;
			Value = value;
		}
	}
}
