namespace ProtocolSharp.Entities.Entities
{
	public class SpellcasterIllager : AbstractIllager
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Spell);
		}

		public EntityMetaByte Spell =
			new EntityMetaByte
			{
				Index = 16,
				DefaultValue = (byte) IllagerSpell.None
			};
	}
}