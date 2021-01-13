using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class MinecartChest : AbstractMinecartContainer
	{
		public override EntityType Type => EntityType.MinecartChest;

		public override float BoundingBoxX => 0.98f;

		public override float BoundingBoxY => 0.7f;

		public override Identifier ID => new Identifier("chest_minecart");

		public override bool UseWithSpawnObject => true;

		public override int Data => 1;
	}
}