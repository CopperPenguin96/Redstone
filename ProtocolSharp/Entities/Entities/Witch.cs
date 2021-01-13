using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Witch : Raider
	{
		public override EntityType Type => EntityType.Witch;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.95f;

		public override Identifier ID => new Identifier("witch");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsDrinkingPotion);
		}

		public EntityMetaBool IsDrinkingPotion =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};
	}
}