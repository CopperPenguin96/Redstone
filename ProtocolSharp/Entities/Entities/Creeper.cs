using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Creeper : Monster
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(State);
			MetaRegistry.Add(IsCharged);
			MetaRegistry.Add(IsIgnited);
		}

		/// <summary>
		/// -1 for idle and 1 for fuse
		/// </summary>
		public EntityMetadata<VarInt> State =
			new EntityMetadata<VarInt>
			{
				Index = 15,
				DefaultValue = -1
			};

		public EntityMetaBool IsCharged =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};

		public EntityMetaBool IsIgnited =
			new EntityMetaBool
			{
				Index = 17,
				DefaultValue = false
			};
	}
}