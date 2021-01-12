using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Cod : AbstractFish
	{
		public override EntityType Type => EntityType.Cod;

		public override float BoundingBoxX => 0.5f;

		public override float BoundingBoxY => 0.3f;

		public override Identifier ID => new Identifier("cod");

		public override bool UseWithSpawnObject => false;
	}
}