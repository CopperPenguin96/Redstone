using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class PrimedExplosive : Entity
	{
		public override EntityType Type => EntityType.PrimedExplosive;

		public override float BoundingBoxX => 0.98f;

		public override float BoundingBoxY => 0.98f;

		public override Identifier ID => new Identifier("tnt");

		public override bool UseWithSpawnObject => false;

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

