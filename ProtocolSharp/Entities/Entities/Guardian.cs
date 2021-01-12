using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Guardian : Monster
	{
		public override EntityType Type => EntityType.Guardian;

		public override float BoundingBoxX => 0.85f;

		public override float BoundingBoxY => 0.85f;

		public override Identifier ID => new Identifier("guardian");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsRetractingSpikes);
			MetaRegistry.Add(TargetEID);
		}

		public EntityMetaBool IsRetractingSpikes =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};

		public EntityMetadata<VarInt> TargetEID =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};
	}
}