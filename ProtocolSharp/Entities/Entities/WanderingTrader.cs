using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class WanderingTrader : AbstractVillager
	{
		public override EntityType Type => EntityType.WanderingTrader;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.95f;

		public override Identifier ID => new Identifier("wandering_trader");

		public override bool UseWithSpawnObject => false;
	}
}