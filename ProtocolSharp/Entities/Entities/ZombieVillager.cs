namespace ProtocolSharp.Entities.Entities
{
	public class ZombieVillager : Zombie
	{
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