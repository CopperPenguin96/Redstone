namespace Redstone.Players.Chat
{
	public class Chat
	{
		public ChatBuilder Builder { get; set; }

		public Chat(ChatBuilder builder)
		{
			Builder = builder;
		}

		public override string ToString()
		{
			return Builder.Retrieve().ToString();
		}
	}
}
