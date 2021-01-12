using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Hoglin : Animal
	{
		public override EntityType Type => EntityType.Hoglin;

		public override float BoundingBoxX => 1.39648f;

		public override float BoundingBoxY => 1.4f;

		public override Identifier ID => new Identifier("hoglin");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsImmuneToZombification);
		}

		public EntityMetaBool IsImmuneToZombification =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};
	}
}