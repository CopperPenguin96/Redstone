using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class WitherSkeleton : AbstractSkeleton
	{
		public override EntityType Type => EntityType.WitherSkeleton;

		public override float BoundingBoxX => 0.7f;

		public override float BoundingBoxY => 2.4f;

		public override Identifier ID => new Identifier("wither_skeleton");

		public override bool UseWithSpawnObject => false;
	}
}