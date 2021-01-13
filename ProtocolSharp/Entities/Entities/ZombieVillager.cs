using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class ZombieVillager : Zombie
	{
		public override EntityType Type => EntityType.ZombieVillager;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.95f;

		public override Identifier ID => new Identifier("zombie_villager");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsConverting);
			MetaRegistry.Add(VillagerData);
		}

		public EntityMetaBool IsConverting =
			new EntityMetaBool
			{
				Index = 18,
				DefaultValue = false
			};

		public EntityMetadata<VillagerData> VillagerData =
			new EntityMetadata<VillagerData>
			{
				Index = 19,
				DefaultValue = new VillagerData(VillagerType.Plains, VillagerJob.None, 1)
			};
	}
}