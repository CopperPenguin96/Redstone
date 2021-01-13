using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Villager : AbstractVillager
	{
		public override EntityType Type => EntityType.Villager;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.95f;

		public override Identifier ID => new Identifier("villager");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(VillagerData);
		}

		public EntityMetadata<VillagerData> VillagerData =
			new EntityMetadata<VillagerData>
			{
				Index = 17,
				DefaultValue = new VillagerData(VillagerType.Plains, VillagerJob.None, 1)
			};
	}
}