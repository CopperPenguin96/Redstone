using System;
using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class DragonFireball : Entity
	{
		public override EntityType Type => EntityType.DragonFireball;

		public override float BoundingBoxX => 1.0f;

		public override float BoundingBoxY => 1.0f;

		public override Identifier ID => new Identifier("dragon_fireball");

		public override bool UseWithSpawnObject => true;

		public override int Data { get; set; }

		public DragonFireball(VarInt shooterID)
		{
			if (shooterID == null) throw new ArgumentNullException(nameof(shooterID));
			Data = (int)shooterID.Value;
		}
	}
}