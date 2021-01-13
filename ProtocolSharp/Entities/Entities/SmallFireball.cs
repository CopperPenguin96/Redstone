using System;
using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class SmallFireball : Entity
	{
		public override EntityType Type => EntityType.SmallFireball;

		public override float BoundingBoxX => 0.3125f;

		public override float BoundingBoxY => 0.3125f;

		public override Identifier ID => new Identifier("small_fireball");

		public override bool UseWithSpawnObject => true;

		public override int Data { get; set; }

		public SmallFireball(VarInt shooterID)
		{
			if (shooterID == null) throw new ArgumentNullException(nameof(shooterID));
			Data = (int)shooterID.Value;
		}

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