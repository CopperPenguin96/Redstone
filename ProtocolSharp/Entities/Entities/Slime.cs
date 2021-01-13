using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Slime : Mob
	{
		public override EntityType Type => EntityType.Slime;

		public override float BoundingBoxX => 0.51000005f * Size.Value.Value;

		public override float BoundingBoxY => 0.51000005f * Size.Value.Value;

		public override Identifier ID => new Identifier("slime");

		public override bool UseWithSpawnObject => false;

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