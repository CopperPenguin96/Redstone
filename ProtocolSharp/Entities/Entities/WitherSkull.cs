namespace ProtocolSharp.Entities.Entities
{
	public class WitherSkull : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsInvulnerable);
		}

		public EntityMetaBool IsInvulnerable =
			new EntityMetaBool
			{
				Index = 7,
				DefaultValue = false
			};

	}
}