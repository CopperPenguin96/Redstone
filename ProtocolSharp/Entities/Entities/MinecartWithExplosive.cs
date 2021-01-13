using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class MinecartWithExplosive : AbstractMinecart
	{
		public override EntityType Type => EntityType.MinecartExplosive;

		public override float BoundingBoxX => 0.98f;

		public override float BoundingBoxY => 0.7f;

		public override Identifier ID => new Identifier("tnt_minecart");

		public override bool UseWithSpawnObject => true;

		public override int Data => 3;
	}
}