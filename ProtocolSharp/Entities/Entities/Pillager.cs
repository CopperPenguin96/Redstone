using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Pillager : AbstractIllager
	{
		public override EntityType Type => EntityType.Pillager;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.95f;

		public override Identifier ID => new Identifier("pillager");

		public override bool UseWithSpawnObject => false;
	}
}