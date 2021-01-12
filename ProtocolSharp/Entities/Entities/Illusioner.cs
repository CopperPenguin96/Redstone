using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Illusioner : SpellcasterIllager
	{
		public override EntityType Type => EntityType.Illusioner;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.95f;

		public override Identifier ID => new Identifier("illusioner");

		public override bool UseWithSpawnObject => false;
	}
}