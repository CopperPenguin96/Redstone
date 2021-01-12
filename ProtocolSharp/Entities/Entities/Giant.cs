using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Giant : Monster
	{
		public override EntityType Type => EntityType.Giant;

		public override float BoundingBoxX => 3.6f;

		public override float BoundingBoxY => 12.0f;

		public override Identifier ID => new Identifier("giant");

		public override bool UseWithSpawnObject => false;
	}
}