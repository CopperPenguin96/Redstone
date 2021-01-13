using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Silverfish : Monster
	{
		public override EntityType Type => EntityType.Silverfish;

		public override float BoundingBoxX => 0.4f;

		public override float BoundingBoxY => 0.3f;

		public override Identifier ID => new Identifier("silverfish");

		public override bool UseWithSpawnObject => false;
	}
}