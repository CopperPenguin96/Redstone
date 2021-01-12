using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class EndCrystal : Entity
	{
		public override EntityType Type => EntityType.EndCrystal;

		public override float BoundingBoxX => 2.0f;

		public override float BoundingBoxY => 2.0f;

		public override Identifier ID => new Identifier("end_crystal");

		public override bool UseWithSpawnObject => true;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(BeamTarget);
			MetaRegistry.Add(ShowBottom);
		}

		public EntityMetadata<OptBlockPos> BeamTarget =>
			new EntityMetadata<OptBlockPos>
			{
				Index = 7,
				DefaultValue = new OptBlockPos(false)
			};

		public EntityMetaBool ShowBottom =
			new EntityMetaBool
			{
				Index = 8,
				DefaultValue = true
			};
	}
}