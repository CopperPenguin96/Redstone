using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Ravager : Raider
	{
		public override EntityType Type => EntityType.Ravager;

		public override float BoundingBoxX => 1.95f;

		public override float BoundingBoxY => 2.2f;

		public override Identifier ID => new Identifier("ravager");

		public override bool UseWithSpawnObject => false;
	}
}