using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class CaveSpider : Spider
	{
		public override EntityType Type => EntityType.CaveSpider;

		public override float BoundingBoxX => 0.7f;

		public override float BoundingBoxY => 0.5f;

		public override Identifier ID => new Identifier("cave_spider");

		public override bool UseWithSpawnObject => false;
	}
}