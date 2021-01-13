using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class MinecartSpawner : AbstractMinecart
	{
		public override EntityType Type => EntityType.MinecartSpawner;

		public override float BoundingBoxX => 0.98f;

		public override float BoundingBoxY => 0.7f;

		public override Identifier ID => new Identifier("spawner_minecart");

		public override bool UseWithSpawnObject => true;

		public override int Data => 4;

	}
}