using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class MinecartFurnace : AbstractMinecart
	{
		public override EntityType Type => EntityType.MinecartFurnace;

		public override float BoundingBoxX => 0.98f;

		public override float BoundingBoxY => 0.7f;

		public override Identifier ID => new Identifier("furnace_minecart");

		public override bool UseWithSpawnObject => true;

		public override int Data => 2;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(HasFuel);
		}

		public EntityMetaBool HasFuel =
			new EntityMetaBool
			{
				Index = 13,
				DefaultValue = false
			};
	}
}