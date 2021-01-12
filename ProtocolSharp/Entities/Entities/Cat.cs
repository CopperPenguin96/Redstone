using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Cat : TameableAnimal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Type);
			MetaRegistry.Add(IsLying);
			MetaRegistry.Add(IsRelaxed);
			MetaRegistry.Add(CollarColor);
		}

		public EntityMetadata<VarInt> Type =
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