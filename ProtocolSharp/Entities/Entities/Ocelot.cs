using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Ocelot : Animal
	{
		public override EntityType Type => EntityType.Ocelot;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 0.7f;

		public override Identifier ID => new Identifier("ocelot");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsTrusting);
		}

		public EntityMetaBool IsTrusting =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};
	}
}