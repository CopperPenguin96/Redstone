namespace ProtocolSharp.Entities.Entities
{
	public class Hoglin : Animal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsImmuneToZombification);
		}

		public EntityMetaBool IsImmuneToZombification =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};
	}
}