using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Arrow : AbstractArrow
	{
		public override EntityType Type => EntityType.Arrow;

		public override float BoundingBoxX => 0.5f;

		public override float BoundingBoxY => 0.5f;

		public override Identifier ID => new Identifier("arrow");

		public override int Data => (int) ShooterID.Value + 1;

		public override bool UseWithSpawnObject => true;

		public VarInt ShooterID { get; private set; }

		/// <summary>
		/// Shoots the arrow
		/// </summary>
		/// <param name="eid">EID of the shooter</param>
		public void Shoot(VarInt eid)
		{
			ShooterID = eid;
		}

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