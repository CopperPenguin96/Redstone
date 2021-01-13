using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Stray : AbstractSkeleton
	{
		public override EntityType Type => EntityType.Stray;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.99f;

		public override Identifier ID => new Identifier("stray");

		public override bool UseWithSpawnObject => false;
	}
}