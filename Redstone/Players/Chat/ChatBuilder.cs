using System;
using System.Collections.Generic;

namespace Redstone.Players.Chat
{
	public class ChatBuilder
	{
		private const string Translate = "chat.type.text";
		private readonly List<ChatPart> _parts = new List<ChatPart>();
		public JsonObject FullObject;
		public void Add(ChatPart part)
		{
			if (part == null) throw new ArgumentNullException(nameof(part));
			if (part.Text == null) throw new ArgumentNullException(nameof(part.Text));

			_parts.Add(part);
		}

		public JsonObject Retrieve()
		{
			JsonObject jObject = new JsonObject {{"translate", Translate}};

			JsonArray jArray = new JsonArray();
			foreach (ChatPart p in _parts)
			{
				JsonObject part = new JsonObject();
				if (p.Action != null)
				{
					JsonObject action = new JsonObject
					{
						{"action", GetActionName(p.Action)}, {"value", p.Action.Value}
					};

					switch (p.Action.Type)
					{
						case ChatActionType.ClickEvent:
							part.Add("clickEvent", action);
							break;
						case ChatActionType.HoverEvent:
							part.Add("hoverEvent", action);
							break;
					}
				}

				part.Add("text", p.Text);
				part.Add("bold", GetBoolValue(p.Bold));
				part.Add("italic", GetBoolValue(p.Italic));
				part.Add("underlined", GetBoolValue(p.Underline));
				part.Add("strikethrough", GetBoolValue(p.StrikeThrough));
				part.Add("obfuscated", GetBoolValue(p.Goofy));
				part.Add("color", p.Color);

				jArray.Add(part);
			}

			jObject.Add("with", jArray);
			return jObject;
		}

		private string GetBoolValue(bool b)
		{
			return b ? "true" : "false";
		}

		private string GetActionName(ChatAction act)
		{
			switch (act.Type)
			{
				case ChatActionType.ClickEvent:
					switch ((ClickEvent) act.Method)
					{
						case ClickEvent.OpenUrl:
							return "open_url";
						case ClickEvent.RunCommand:
							return "run_command";
						case ClickEvent.SuggestCommand:
							return "suggest_command";
						case ClickEvent.ChangePage:
							return "change_page";
					}

					throw new Exception("Invalid Click Event type");
				case ChatActionType.HoverEvent:
					switch ((HoverEvent) act.Method)
					{
						case HoverEvent.ShowText:
							return "show_text";
						case HoverEvent.ShowItem:
							return "show_item";
						case HoverEvent.ShowEntity:
							return "show_entity";
					}

					throw new Exception("Invalid Hover Event type");
			}

			throw new Exception("Unknown Chat Action");
		}
	}
}
