namespace ProtocolSharp.Entities.Entities
{
	public class BasePiglin : Monster
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsImmuneToZombification);
		}

		public EntityMetaBool IsImmuneToZombification =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};
	}
}