using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class ItemEntity : Entity
	{
		public override EntityType Type => EntityType.Item;

		public override float BoundingBoxX => 0.25f;

		public override float BoundingBoxY => 0.25f;

		public override Identifier ID => new Identifier("item");

		public override int Data => 1;

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Item);
		}

		public EntityMetadata<Slot> Item =
			new EntityMetadata<Slot>
			{
				Index = 7,
				DefaultValue = new Slot()
			};
	}
}