using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class ThrownEnderPearl : Entity
	{
		public override EntityType Type => EntityType.ThrownEnderPearl;

		public override float BoundingBoxX => 0.25f;

		public override float BoundingBoxY => 0.25f;

		public override Identifier ID => new Identifier("ender_pearl");

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