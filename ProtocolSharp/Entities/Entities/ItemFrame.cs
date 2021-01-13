using Org.BouncyCastle.Ocsp;
using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class ItemFrame : Entity
	{
		public override EntityType Type => EntityType.ItemFrame;
		public override float BoundingBoxX => 0.75f;

		public override float BoundingBoxY => 0.75f;

		public override Identifier ID => new Identifier("item_frame");

		public override bool UseWithSpawnObject => true;

		public Direction Orientation { get; set; }

		public override int Data => (int) Orientation.Value.Value;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Item);
			MetaRegistry.Add(Rotation);
		}

		public EntityMetadata<Slot> Item =
			new EntityMetadata<Slot>
			{
				Index = 7,
				DefaultValue = new Slot()
			};

		public EntityMetadata<VarInt> Rotation =
			new EntityMetadata<VarInt>
			{
				Index = 8,
				DefaultValue = 0
			};

	}
}