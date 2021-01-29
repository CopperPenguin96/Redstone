using System;
using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class WitherSkull : Entity
	{
		public override EntityType Type => EntityType.WitherSkull;

		public override float BoundingBoxX => 0.3125f;

		public override float BoundingBoxY => 0.3125f;

		public override Identifier ID => new Identifier("wither_skull");

		public override bool UseWithSpawnObject => true;

		public override int Data { get; set; }

		public WitherSkull(VarInt shooterID)
		{
			if (shooterID == null) throw new ArgumentNullException(nameof(shooterID));
			Data = (int)shooterID.Value;
		}

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsInvulnerable);
		}

		public EntityMetaBool IsInvulnerable =
			new EntityMetaBool
			{
				Index = 7,
				DefaultValue = false
			};

		public override bool Invulnerable => IsInvulnerable.Value;
	}
}