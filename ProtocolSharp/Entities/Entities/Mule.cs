using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Mule : ChestedHorse
	{
		public override EntityType Type => EntityType.Mule;

		public override float BoundingBoxX => 1.39648f;

		public override float BoundingBoxY => 1.6f;

		public override Identifier ID => new Identifier("mule");

		public override bool UseWithSpawnObject => false;
	}
}