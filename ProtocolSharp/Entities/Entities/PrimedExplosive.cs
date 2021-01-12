using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	#region Arrows/Tridents

	#endregion


	#region Living Entities

	#endregion

	// Why tf?

	public class PrimedExplosive : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(FuseTime);
		}

		public EntityMetadata<VarInt> FuseTime =
			new EntityMetadata<VarInt>
			{
				Index = 7,
				DefaultValue = 80
			};
	}
}

