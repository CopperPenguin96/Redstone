using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Husk : Zombie
	{
		public override EntityType Type => EntityType.Husk;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.95f;

		public override Identifier ID => new Identifier("husk");

		public override bool UseWithSpawnObject => false;
	}
}