using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class ItemFrame : Entity
	{
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