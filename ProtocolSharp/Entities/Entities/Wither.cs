using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Wither : Monster
	{
		public override EntityType Type => EntityType.Wither;

		public override float BoundingBoxX => 0.9f;

		public override float BoundingBoxY => 3.5f;

		public override Identifier ID => new Identifier("wither");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(CenterHeadTarget);
			MetaRegistry.Add(LeftHeadTarget);
			MetaRegistry.Add(RightHeadTarget);
			MetaRegistry.Add(InvulnerableTime);
		}

		public EntityMetadata<VarInt> CenterHeadTarget =
			new EntityMetadata<VarInt>
			{
				Index = 15,
				DefaultValue = 0
			};

		public EntityMetadata<VarInt> LeftHeadTarget =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};

		public EntityMetadata<VarInt> RightHeadTarget =
			new EntityMetadata<VarInt>
			{
				Index = 17,
				DefaultValue = 0
			};

		public EntityMetadata<VarInt> InvulnerableTime =
			new EntityMetadata<VarInt>
			{
				Index = 18,
				DefaultValue = 0
			};
	}
}