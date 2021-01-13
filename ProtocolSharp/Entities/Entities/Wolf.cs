using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Wolf : TameableAnimal
	{
		public override EntityType Type => EntityType.Wolf;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 0.85f;

		public override Identifier ID => new Identifier("wolf");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsBegging);
			MetaRegistry.Add(CollarColor);
			MetaRegistry.Add(AngerTime);
		}

		public EntityMetaBool IsBegging =
			new EntityMetaBool
			{
				Index = 18,
				DefaultValue = false
			};

		public EntityMetadata<VarInt> CollarColor =
			new EntityMetadata<VarInt>
			{
				Index = 19,
				DefaultValue = 14
			};

		public EntityMetadata<VarInt> AngerTime =
			new EntityMetadata<VarInt>
			{
				Index = 20,
				DefaultValue = 0
			};
	}
}