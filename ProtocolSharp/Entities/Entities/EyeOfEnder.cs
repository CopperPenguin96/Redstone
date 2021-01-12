using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class EyeOfEnder : Entity
	{
		public override EntityType Type => EntityType.EyeOfEnder;

		public override float BoundingBoxX => 0.25f;

		public override float BoundingBoxY => 0.25f;

		public override Identifier ID => new Identifier("eye_of_ender");

		public override bool UseWithSpawnObject => true;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Slot);
		}

		public EntityMetadata<Slot> Slot =
			new EntityMetadata<Slot>
			{
				Index = 7,
				DefaultValue = new Slot()
			};
	}
}