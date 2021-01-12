using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class EnderDragon : Mob
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(DragonPhase);
		}

		public EntityMetadata<VarInt> DragonPhase =
			new EntityMetadata<VarInt>
			{
				Index = 15,
				DefaultValue = (int) Entities.DragonPhase.HoveringNoAI
			};
	}
}