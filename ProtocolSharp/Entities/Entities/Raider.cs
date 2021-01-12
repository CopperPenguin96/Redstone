namespace ProtocolSharp.Entities.Entities
{
	public class Raider : Monster
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsCelebrating);
		}

		public EntityMetaBool IsCelebrating =
			new EntityMetaBool
			{
				Index = 15, // Celebrate good times come on!
				DefaultValue = false
			};
	}
}