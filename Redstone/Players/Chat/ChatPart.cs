namespace Redstone.Players.Chat
{
	
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
}
