using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Horse : AbstractHorse
	{
		public override EntityType Type => EntityType.Horse;

		public override float BoundingBoxX => 1.39648f;

		public override float BoundingBoxY => 1.6f;

		public override Identifier ID => new Identifier("horse");

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