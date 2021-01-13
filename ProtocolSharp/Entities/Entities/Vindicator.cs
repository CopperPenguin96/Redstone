using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Vindicator : AbstractIllager
	{
		public override EntityType Type => EntityType.Vindicator;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.95f;

		public override Identifier ID => new Identifier("vindicator");

		public override bool UseWithSpawnObject => false;
	}
}