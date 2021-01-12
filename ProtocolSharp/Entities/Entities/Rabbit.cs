using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Rabbit : Animal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Type);
		}

		public EntityMetadata<VarInt> Type =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};
	}
}