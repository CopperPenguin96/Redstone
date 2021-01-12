using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class FallingBlock : Entity
	{
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