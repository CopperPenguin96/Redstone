using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Bee : Animal
	{
		public override EntityType Type => EntityType.Bee;

		public override float BoundingBoxX => 0.7f;

		public override float BoundingBoxY => 0.6f;

		public override Identifier ID => new Identifier("bee");

		public override bool UseWithSpawnObject => false;
	}
}