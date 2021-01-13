using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class PiglinBrute : BasePiglin
	{
		public override EntityType Type => EntityType.PiglinBrute;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.95f;

		public override Identifier ID => new Identifier("piglin_brute");

		public override bool UseWithSpawnObject => false;
	}
}