using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class ZombieHorse : AbstractHorse
	{
		public override EntityType Type => EntityType.ZombieHorse;

		public override float BoundingBoxX => 1.39648f;

		public override float BoundingBoxY => 1.6f;

		public override Identifier ID => new Identifier("zombie_horse");

		public override bool UseWithSpawnObject => false;
	}
}