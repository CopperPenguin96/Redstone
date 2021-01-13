using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Parrot : TameableAnimal
	{
		public override EntityType Type => EntityType.Parrot;

		public override float BoundingBoxX => 0.5f;

		public override float BoundingBoxY => 0.9f;

		public override Identifier ID => new Identifier("parrot");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Variant);
		}

		public EntityMetadata<VarInt> Variant =
			new EntityMetadata<VarInt>
			{
				Index = 18,
				DefaultValue = (int) ParrotType.RedBlue
			};

		public void SetType(ParrotType type)
		{
			Variant.Value = (int) type;
		}
	}
}