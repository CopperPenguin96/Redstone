using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Cow : Animal
	{
		public override EntityType Type => EntityType.Cow;

		public override float BoundingBoxX => 0.9f;

		public override float BoundingBoxY => 1.4f;

		public override Identifier ID => new Identifier("cow");

		public override bool UseWithSpawnObject => false;
	}
}