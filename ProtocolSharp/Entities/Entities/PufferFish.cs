using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class PufferFish : AbstractFish
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(PuffState);
		}

		/// <summary>
		/// Puff State (varies from 0 to 2)
		/// </summary>
		public EntityMetadata<VarInt> PuffState =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};
	}
}