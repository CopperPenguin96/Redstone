using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class ElderGuardian : Guardian
	{
		public override EntityType Type => EntityType.ElderGuardian;

		public override float BoundingBoxX => 1.9975f;

		public override float BoundingBoxY => 1.9975f;

		public override Identifier ID => new Identifier("elder_guardian");

		public override bool UseWithSpawnObject => false;
	}
}