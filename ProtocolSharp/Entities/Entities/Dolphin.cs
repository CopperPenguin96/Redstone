using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Dolphin : WaterAnimal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(TreasurePosition);
			MetaRegistry.Add(CanFindTreasure);
			MetaRegistry.Add(HasFish);
		}

		public EntityMetadata<Position> TreasurePosition =
			new EntityMetadata<Position>
			{
				Index = 15,
				DefaultValue = new Position(0, 0, 0)
			};

		public EntityMetaBool CanFindTreasure =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};

		public EntityMetaBool HasFish =
			new EntityMetaBool
			{
				Index = 17,
				DefaultValue = false
			};
	}
}