namespace ProtocolSharp.Entities.Entities
{
	public class Ghast : Flying
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsAttacking);
		}

		public EntityMetaBool IsAttacking =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};
	}
}