using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class SkeletonHorse : AbstractHorse
	{
		public override EntityType Type => EntityType.SkeletonHorse;

		public override float BoundingBoxX => 1.39648f;

		public override float BoundingBoxY => 1.6f;

		public override Identifier ID => new Identifier("skeleton_horse");

		public override bool UseWithSpawnObject => false;
	}
}