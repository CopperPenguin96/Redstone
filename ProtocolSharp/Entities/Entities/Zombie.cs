using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Zombie : Monster // Like some of you in the morning
	{
		public override EntityType Type => EntityType.Zombie;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.95f;

		public override Identifier ID => new Identifier("zombie");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsBaby);
			MetaRegistry.Add(IsBecomingDrowned);
		}

		public EntityMetaBool IsBaby =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};

		public EntityMetaBool IsBecomingDrowned =
			new EntityMetaBool
			{
				Index = 17,
				DefaultValue = false
			};
	}
}