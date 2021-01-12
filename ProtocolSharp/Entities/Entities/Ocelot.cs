namespace ProtocolSharp.Entities.Entities
{
	public class Ocelot : Animal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsTrusting);
		}

		public EntityMetaBool IsTrusting =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};
	}
}