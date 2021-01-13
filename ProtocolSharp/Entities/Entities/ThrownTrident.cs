using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class ThrownTrident : AbstractArrow
	{
		public override EntityType Type => EntityType.ThrownTrident;

		public override float BoundingBoxX => 0.5f;

		public override float BoundingBoxY => 0.5f;

		public override Identifier ID => new Identifier("trident");

		public override bool UseWithSpawnObject => true;

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