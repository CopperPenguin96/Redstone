using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Horse : AbstractHorse
	{
		public override EntityType Type => EntityType.Horse;

		public override float BoundingBoxX => 0.5f;

		public override float BoundingBoxY => 0.9f;

		public override Identifier ID => new Identifier("bat");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Variant);
		}

		/// <summary>
		/// Variant of horse (Color & Style)
		/// </summary>
		public EntityMetadata<VarInt> Variant =
			new EntityMetadata<VarInt>
			{
				Index = 18,
				DefaultValue = 0
			};
	}
}