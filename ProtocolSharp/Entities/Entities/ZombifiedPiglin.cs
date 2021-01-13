using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class ZombifiedPiglin : Zombie
	{
		public override EntityType Type => EntityType.ZombifiedPiglin;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.95f;

		public override Identifier ID => new Identifier("zombified_piglin");

		public override bool UseWithSpawnObject => false;
	}
}