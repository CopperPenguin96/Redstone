using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Cat : TameableAnimal
	{
		public override EntityType Type => EntityType.Cat;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 0.7f;

		public override Identifier ID => new Identifier("cat");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(CatType);
			MetaRegistry.Add(IsLying);
			MetaRegistry.Add(IsRelaxed);
			MetaRegistry.Add(CollarColor);
		}

		public EntityMetadata<VarInt> CatType =
			new EntityMetadata<VarInt>
			{
				Index = 18,
				DefaultValue = 1
			};

		public EntityMetaBool IsLying =
			new EntityMetaBool
			{
				Index = 19,
				DefaultValue = false
			};

		public EntityMetaBool IsRelaxed =
			new EntityMetaBool
			{
				Index = 20,
				DefaultValue = false
			};

		public EntityMetadata<VarInt> CollarColor =
			new EntityMetadata<VarInt>
			{
				Index = 21,
				DefaultValue = 14
			};
	}
}