namespace ProtocolSharp.Entities.Entities
{
	public class Zoglin : Monster
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsBaby);
		}

		public EntityMetaBool IsBaby =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};

	}
}