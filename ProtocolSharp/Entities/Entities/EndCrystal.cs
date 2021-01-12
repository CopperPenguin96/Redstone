using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class EndCrystal : Entity
	{
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