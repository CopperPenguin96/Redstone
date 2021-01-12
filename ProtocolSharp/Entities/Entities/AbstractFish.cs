namespace ProtocolSharp.Entities.Entities
{
	public class AbstractFish : WaterAnimal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(FromBucket);
		}

		public EntityMetaBool FromBucket =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};
	}
}