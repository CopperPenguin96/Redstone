using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class PolarBear : Animal
	{
		public override EntityType Type => EntityType.PolarBear;

		public override float BoundingBoxX => 1.4f;

		public override float BoundingBoxY => 1.4f;

		public override Identifier ID => new Identifier("polar_bear");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsStandingUp);
		}

		public EntityMetaBool IsStandingUp =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};
	}
}