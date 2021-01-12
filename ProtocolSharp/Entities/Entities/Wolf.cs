using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Wolf : TameableAnimal
	{
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