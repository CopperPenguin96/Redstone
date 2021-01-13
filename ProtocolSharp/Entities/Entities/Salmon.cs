using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Salmon : AbstractFish
	{
		public override EntityType Type => EntityType.Salmon;

		public override float BoundingBoxX => 0.7f;

		public override float BoundingBoxY => 0.4f;

		public override Identifier ID => new Identifier("salmon");

		public override bool UseWithSpawnObject => false;
	}
}