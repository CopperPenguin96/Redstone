namespace ProtocolSharp.Entities.Entities
{
	public class MinecartFurnace : AbstractMinecart
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(HasFuel);
		}

		public EntityMetaBool HasFuel =
			new EntityMetaBool
			{
				Index = 13,
				DefaultValue = false
			};
	}
}