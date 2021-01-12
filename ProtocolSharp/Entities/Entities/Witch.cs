namespace ProtocolSharp.Entities.Entities
{
	public class Witch : Raider
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsDrinkingPotion);
		}

		public EntityMetaBool IsDrinkingPotion =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};
	}
}