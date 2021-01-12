using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class FireworkRocketEntity : Entity
	{
		public override EntityType Type => EntityType.FireworkRocketEntity;

		public override float BoundingBoxX => 0.25f;

		public override float BoundingBoxY => 0.25f;

		public override Identifier ID => new Identifier("firework_rocket");

		public override bool UseWithSpawnObject => true;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(FireworkInfo);
			MetaRegistry.Add(FireworkBoosterEntityID);
			MetaRegistry.Add(IsShotAtAngle);
		}

		public EntityMetadata<Slot> FireworkInfo =
			new EntityMetadata<Slot>
			{
				Index = 7,
				DefaultValue = new Slot()
			};

		/// <summary>
		/// Entity ID of entity which used firework (for elytra boosting)
		/// </summary>
		public EntityMetadata<OptVarInt> FireworkBoosterEntityID =
			new EntityMetadata<OptVarInt>
			{
				Index = 8,
				DefaultValue = new OptVarInt(false)
			};

		/// <summary>
		/// True if shot at an angle (from a crossbow)
		/// </summary>
		public EntityMetaBool IsShotAtAngle =
			new EntityMetaBool
			{
				Index = 9,
				DefaultValue = false
			};
	}
}