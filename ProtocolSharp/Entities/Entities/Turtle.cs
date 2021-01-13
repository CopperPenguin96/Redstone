using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Turtle : Animal
	{
		public override EntityType Type => EntityType.Turtle;

		public override float BoundingBoxX => 1.2f;

		public override float BoundingBoxY => 0.4f;

		public override Identifier ID => new Identifier("turtle");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(HomePos);
			MetaRegistry.Add(HasEgg);
			MetaRegistry.Add(IsLayingEgg);
			MetaRegistry.Add(TravelPos);
			MetaRegistry.Add(IsGoingHome);
			MetaRegistry.Add(IsTraveling);
		}

		public EntityMetadata<Position> HomePos =
			new EntityMetadata<Position>
			{
				Index = 16,
				DefaultValue = new Position(0, 0, 0)
			};

		public EntityMetaBool HasEgg =
			new EntityMetaBool
			{
				Index = 17,
				DefaultValue = false
			};

		public EntityMetaBool IsLayingEgg =
			new EntityMetaBool
			{
				Index = 18,
				DefaultValue = false
			};

		public EntityMetadata<Position> TravelPos =
			new EntityMetadata<Position>
			{
				Index = 19,
				DefaultValue = new Position(0, 0, 0)
			};

		public EntityMetaBool IsGoingHome =
			new EntityMetaBool
			{
				Index = 20,
				DefaultValue = false
			};

		public EntityMetaBool IsTraveling =
			new EntityMetaBool
			{
				Index = 21,
				DefaultValue = false
			};
	}
}