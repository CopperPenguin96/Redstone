using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Boat : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(TimeSinceLastHit);
			MetaRegistry.Add(ForwardDirection);
			MetaRegistry.Add(DamageTaken);
			MetaRegistry.Add(Type);
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

		public EntityMetadata<VarInt> Type =
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