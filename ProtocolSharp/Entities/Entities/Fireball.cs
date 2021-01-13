using System;
using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Fireball : Entity
	{
		public override EntityType Type => EntityType.Fireball;

		public override float BoundingBoxX => 1.0f;

		public override float BoundingBoxY => 1.0f;

		public override Identifier ID => new Identifier("fireball");

		public override bool UseWithSpawnObject => true;

		public override int Data { get; set; }

		public Fireball(VarInt shooterID)
		{
			if (shooterID == null) throw new ArgumentNullException(nameof(shooterID));
			Data = (int) shooterID.Value;
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