using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Evoker : SpellcasterIllager
	{
		public override EntityType Type => EntityType.Evoker;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.95f;

		public override Identifier ID => new Identifier("evoker");

		public override bool UseWithSpawnObject => true;
	}
}