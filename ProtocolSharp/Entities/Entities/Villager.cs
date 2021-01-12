namespace ProtocolSharp.Entities.Entities
{
	public class Villager : AbstractVillager
	{
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