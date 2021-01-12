using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Arrow : AbstractArrow
	{
		public override float BoundingBoxX => 0.5f;

		public override float BoundingBoxY => 0.5f;

		public override Identifier ID => new Identifier("arrow");

		public override bool UseWithSpawnObject => true;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Color);
		}

		/// <summary>
		/// Used for both tipped and regular arrows. If not tipped, then color is set to -1
		/// and no tipped arrow particles are used.
		/// </summary>
		public EntityMetadata<VarInt> Color =
			new EntityMetadata<VarInt>
			{
				Index = 9,
				DefaultValue = -1
			};
	}
}