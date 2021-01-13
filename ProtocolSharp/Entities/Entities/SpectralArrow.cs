using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class SpectralArrow : AbstractArrow
	{
		public override EntityType Type => EntityType.SpectralArrow;

		public override float BoundingBoxX => 0.5f;

		public override float BoundingBoxY => 0.5f;

		public override Identifier ID => new Identifier("spectral_arrow");

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
	}
}