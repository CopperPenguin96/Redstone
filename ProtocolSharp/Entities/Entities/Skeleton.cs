using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Skeleton : AbstractSkeleton
	{
		public override EntityType Type => EntityType.Skeleton;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.99f;

		public override Identifier ID => new Identifier("skeleton");

		public override bool UseWithSpawnObject => false;

	}
}