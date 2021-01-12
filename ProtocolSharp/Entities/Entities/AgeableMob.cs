namespace ProtocolSharp.Entities.Entities
{
	public class AgeableMob : PathfinderMob
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