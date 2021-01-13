using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Phantom : Flying
	{
		public override EntityType Type => EntityType.Phantom;

		public override float BoundingBoxX => 0.9f;

		public override float BoundingBoxY => 0.5f;

		public override Identifier ID => new Identifier("phantom");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Size);
		}

		/// <summary>
		/// Hitbox size is determined by horizontal = 0.9 + 0.2 * size and vertical = 0.5 + 0.1 * i
		/// </summary>
		public EntityMetadata<VarInt> Size =
			new EntityMetadata<VarInt>
			{
				Index = 15,
				DefaultValue = 0
			};
	}
}