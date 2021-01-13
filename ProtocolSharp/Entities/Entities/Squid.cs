using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Squid : WaterAnimal
	{
		public override EntityType Type => EntityType.Squid;

		public override float BoundingBoxX => 0.8f;

		public override float BoundingBoxY => 0.8f;

		public override Identifier ID => new Identifier("squid");

		public override bool UseWithSpawnObject => false;
	}
}