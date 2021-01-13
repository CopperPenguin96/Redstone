using ProtocolSharp.Chat;
using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class MinecartCommandBlock : AbstractMinecart
	{
		public override EntityType Type => EntityType.MinecartCommandBlock;

		public override float BoundingBoxX => 0.98f;

		public override float BoundingBoxY => 0.7f;

		public override Identifier ID => new Identifier("commandblock_minecart");

		public override bool UseWithSpawnObject => true;

		public override int Data => 6;

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