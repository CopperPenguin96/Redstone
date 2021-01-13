using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Rabbit : Animal
	{
		public override EntityType Type => EntityType.Rabbit;

		public override float BoundingBoxX => 0.4f;

		public override float BoundingBoxY => 0.5f;

		public override Identifier ID => new Identifier("rabbit");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(RabbitType);
		}

		public EntityMetadata<VarInt> RabbitType =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};
	}
}