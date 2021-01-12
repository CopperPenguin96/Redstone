using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class EnderDragon : Mob
	{
		public override EntityType Type => EntityType.EnderDragon;

		public override float BoundingBoxX => 16.0f;

		public override float BoundingBoxY => 8.0f;

		public override Identifier ID => new Identifier("ender_dragon");

		public override bool UseWithSpawnObject => false;

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