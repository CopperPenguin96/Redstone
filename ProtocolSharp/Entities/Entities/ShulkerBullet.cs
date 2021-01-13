using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class ShulkerBullet : Entity
	{
		public override EntityType Type => EntityType.ShulkerBullet;

		public override float BoundingBoxX => 0.3125f;

		public override float BoundingBoxY => 0.3125f;

		public override Identifier ID => new Identifier("shulker_bullet");

		public override bool UseWithSpawnObject => true;

		public override int Data => 0;
	}
}