using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Parrot : TameableAnimal
	{
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