using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class EvokerFangs : Entity
	{
		public override EntityType Type => EntityType.EvokerFangs;

		public override float BoundingBoxX => 0.5f;

		public override float BoundingBoxY => 0.8f;

		public override Identifier ID => new Identifier("evoker_fangs");

		public override bool UseWithSpawnObject => false;
	}
}