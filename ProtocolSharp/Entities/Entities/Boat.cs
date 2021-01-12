using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Boat : Entity
	{
		public override EntityType Type => EntityType.Boat;

		public override float BoundingBoxX => 1.375f;

		public override float BoundingBoxY => 0.5625f;

		public override Identifier ID => new Identifier("boat");

		public override bool UseWithSpawnObject => true;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(TimeSinceLastHit);
			MetaRegistry.Add(ForwardDirection);
			MetaRegistry.Add(DamageTaken);
			MetaRegistry.Add(WoodType);
			MetaRegistry.Add(LeftPaddleTurning);
			MetaRegistry.Add(RightPaddleTurning);
			MetaRegistry.Add(SplashTimer);
		}

		public EntityMetadata<VarInt> TimeSinceLastHit =
			new EntityMetadata<VarInt>
			{
				Index = 7,
				DefaultValue = 0
			};

		public EntityMetadata<VarInt> ForwardDirection =
			new EntityMetadata<VarInt>
			{
				Index = 8,
				DefaultValue = 1
			};

		public EntityMetaFloat DamageTaken =
			new EntityMetaFloat
			{
				Index = 9,
				DefaultValue = 0.0f
			};

		public EntityMetadata<VarInt> WoodType =
			new EntityMetadata<VarInt>
			{
				Index = 10,
				DefaultValue = (int) BoatType.Oak
			};

		public EntityMetaBool LeftPaddleTurning =
			new EntityMetaBool
			{
				Index = 11,
				DefaultValue = false
			};

		public EntityMetaBool RightPaddleTurning =
			new EntityMetaBool
			{
				Index = 12,
				DefaultValue = false
			};

		public EntityMetadata<VarInt> SplashTimer =
			new EntityMetadata<VarInt>
			{
				Index = 13,
				DefaultValue = 0
			};
	}
}