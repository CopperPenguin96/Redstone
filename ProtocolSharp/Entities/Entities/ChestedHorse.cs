namespace ProtocolSharp.Entities.Entities
{
	public class ChestedHorse : AbstractHorse
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(HasChest);
		}

		public EntityMetaBool HasChest =
			new EntityMetaBool
			{
				Index = 18,
				DefaultValue = false
			};
	}
}