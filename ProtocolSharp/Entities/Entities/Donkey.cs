using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Donkey : ChestedHorse
	{
		public override EntityType Type => EntityType.Donkey;

		public override float BoundingBoxX => 1.5f;

		public override float BoundingBoxY => 1.39648f;

		public override Identifier ID => new Identifier("donkey");

		public override bool UseWithSpawnObject => false;
	}
}