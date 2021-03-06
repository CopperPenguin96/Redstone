﻿using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Shulker : AbstractGolem
	{
		public override EntityType Type => EntityType.Shulker;

		public override float BoundingBoxX => 1.0f;

		public override float BoundingBoxY => 1.0f;

		public override Identifier ID => new Identifier("shulker");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(AttachFace);
			MetaRegistry.Add(AttachmentPos);
			MetaRegistry.Add(ShieldHeight);
			MetaRegistry.Add(Color);
		}

		public EntityMetadata<Direction> AttachFace =
			new EntityMetadata<Direction>
			{
				Index = 15,
				DefaultValue = Direction.Down
			};

		public EntityMetadata<OptObject<Position>> AttachmentPos =
			new EntityMetadata<OptObject<Position>>
			{
				Index = 16,
				DefaultValue = new OptObject<Position>(false)
			};

		public EntityMetaByte ShieldHeight =
			new EntityMetaByte
			{
				Index = 17,
				DefaultValue = 0
			};

		public EntityMetaByte Color =
			new EntityMetaByte
			{
				Index = 18,
				DefaultValue = (byte) SheepColor.Purple
			};
	}
}