using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Chicken : Animal // https://www.youtube.com/watch?v=W4WGQmWcrbs
	{
		public override EntityType Type => EntityType.Chicken;

		public override float BoundingBoxX => 0.4f;

		public override float BoundingBoxY => 0.7f;

		public override Identifier ID => new Identifier("chicken");

		public override bool UseWithSpawnObject => false;
	}
}