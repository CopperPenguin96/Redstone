using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Piglin : BasePiglin
	{
		public override EntityType Type => EntityType.Piglin;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.95f;

		public override Identifier ID => new Identifier("piglin");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsBaby);
			MetaRegistry.Add(IsChargingCrossbow);
			MetaRegistry.Add(IsDancing);
		}

		public EntityMetaBool IsBaby =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};

		public EntityMetaBool IsChargingCrossbow =
			new EntityMetaBool
			{
				Index = 17,
				DefaultValue = false
			};

		public EntityMetaBool IsDancing =
			new EntityMetaBool
			{
				Index = 18,
				DefaultValue = false
			};
	}
}