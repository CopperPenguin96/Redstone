using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Zoglin : Monster
	{
		public override EntityType Type => EntityType.Zoglin;

		public override float BoundingBoxX => 1.39648f;

		public override float BoundingBoxY => 1.4f;

		public override Identifier ID => new Identifier("zoglin");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsBaby);
		}

		public EntityMetaBool IsBaby =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};

	}
}