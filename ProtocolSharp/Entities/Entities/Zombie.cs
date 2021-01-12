namespace ProtocolSharp.Entities.Entities
{
	public class Zombie : Monster // Like some of you in the morning
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsBaby);
			MetaRegistry.Add(IsBecomingDrowned);
		}

		public EntityMetaBool IsBaby =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};

		public EntityMetaBool IsBecomingDrowned =
			new EntityMetaBool
			{
				Index = 17,
				DefaultValue = false
			};
	}
}