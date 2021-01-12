using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class AbstractMinecart : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(ShakingPower);
			MetaRegistry.Add(ShakingDirection);
			MetaRegistry.Add(ShakingMultiplier);
			MetaRegistry.Add(CustomBlockIDAndDamage);
			MetaRegistry.Add(BlockYPos);
			MetaRegistry.Add(ShowCustomBlock);
		}

		public EntityMetadata<VarInt> ShakingPower =
			new EntityMetadata<VarInt>
			{
				Index = 7,
				DefaultValue = 0
			};

		public EntityMetadata<VarInt> ShakingDirection =
			new EntityMetadata<VarInt>
			{
				Index = 8,
				DefaultValue = 1
			};

		public EntityMetaFloat ShakingMultiplier =
			new EntityMetaFloat
			{
				Index = 9,
				DefaultValue = 0.0f
			};

		public EntityMetadata<VarInt> CustomBlockIDAndDamage =
			new EntityMetadata<VarInt>
			{
				Index = 10,
				DefaultValue = 0
			};

		/// <summary>
		/// Custom Y POS (in 16ths of a block)
		/// </summary>
		public EntityMetadata<VarInt> BlockYPos =
			new EntityMetadata<VarInt>
			{
				Index = 11,
				DefaultValue = 6
			};

		public EntityMetaBool ShowCustomBlock =
			new EntityMetaBool
			{
				Index = 12,
				DefaultValue = false
			};
	}
}