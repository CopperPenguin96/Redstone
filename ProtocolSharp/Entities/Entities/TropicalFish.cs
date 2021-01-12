using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class TropicalFish : AbstractFish
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Variant);
		}

		public EntityMetadata<VarInt> Variant =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};
	}
}