using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Slime : Mob
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Size);
		}

		public EntityMetadata<VarInt> Size =
			new EntityMetadata<VarInt>
			{
				Index = 15,
				DefaultValue = 1
			};
	}
}