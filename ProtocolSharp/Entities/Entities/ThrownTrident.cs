using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class ThrownTrident : AbstractArrow
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(LoyaltyLevel);
			MetaRegistry.Add(HasEnchantmentGlint);
		}

		public EntityMetadata<VarInt> LoyaltyLevel =
			new EntityMetadata<VarInt>
			{
				Index = 9,
				DefaultValue = 0
			};

		public EntityMetaBool HasEnchantmentGlint =
			new EntityMetaBool
			{
				Index = 10,
				DefaultValue = false
			};
	}
}