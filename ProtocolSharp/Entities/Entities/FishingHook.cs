using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class FishingHook : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(HookedID);
			MetaRegistry.Add(IsCatchable);
		}

		/// <summary>
		/// Hooked entity ID + 1, or 0 if there is no hooked entity
		/// </summary>
		public EntityMetadata<VarInt> HookedID =
			new EntityMetadata<VarInt>
			{
				Index = 7,
				DefaultValue = 0
			};

		public EntityMetaBool IsCatchable =
			new EntityMetaBool
			{
				Index = 8,
				DefaultValue = false
			};
	}
}