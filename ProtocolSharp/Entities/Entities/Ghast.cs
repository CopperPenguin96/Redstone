using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Ghast : Flying
	{
		public override EntityType Type => EntityType.Ghast;

		public override float BoundingBoxX => 4.0f;

		public override float BoundingBoxY => 4.0f;

		public override Identifier ID => new Identifier("ghast");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsAttacking);
		}

		public EntityMetaBool IsAttacking =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};
	}
}