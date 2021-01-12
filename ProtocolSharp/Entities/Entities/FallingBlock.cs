using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class FallingBlock : Entity
	{
		public override EntityType Type => EntityType.FallingBlock;

		public override float BoundingBoxX => 0.98f;

		public override float BoundingBoxY => 0.98f;

		public override Identifier ID => new Identifier("falling_block");

		public override bool UseWithSpawnObject => true;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(SpawnPosition);
		}

		public EntityMetadata<Position> SpawnPosition =
			new EntityMetadata<Position>
			{
				Index = 7,
				DefaultValue = new Position(0, 0, 0)
			};
	}
}