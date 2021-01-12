namespace ProtocolSharp.Entities.Entities
{
	public class PolarBear : Animal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsStandingUp);
		}

		public EntityMetaBool IsStandingUp =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};
	}
}