using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Endermite : Monster
	{
		public override EntityType Type => EntityType.Endermite;

		public override float BoundingBoxX => 0.4f;

		public override float BoundingBoxY => 0.3f;

		public override Identifier ID => new Identifier("endermite");

		public override bool UseWithSpawnObject => false;
	}
}