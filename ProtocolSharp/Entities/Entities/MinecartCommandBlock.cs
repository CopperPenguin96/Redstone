using ProtocolSharp.Chat;

namespace ProtocolSharp.Entities.Entities
{
	public class MinecartCommandBlock : AbstractMinecart
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Command);
			MetaRegistry.Add(LastOutput);
		}

		public EntityMetadata<string> Command =
			new EntityMetadata<string>
			{
				Index = 13,
				DefaultValue = ""
			};

		public EntityMetadata<ChatBuilder> LastOutput =
			new EntityMetadata<ChatBuilder>
			{
				Index = 14,
				DefaultValue = ChatMessage.BlankMessage
			};
	}
}