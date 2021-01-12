using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Guardian : Monster
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsRetractingSpikes);
			MetaRegistry.Add(TargetEID);
		}

		public EntityMetaBool IsRetractingSpikes =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};

		public EntityMetadata<VarInt> TargetEID =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};
	}
}