using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Drowned : Zombie
	{
		public override EntityType Type => EntityType.Drowned;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.95f;

		public override Identifier ID => new Identifier("drowned");

		public override bool UseWithSpawnObject => false;
	}
}