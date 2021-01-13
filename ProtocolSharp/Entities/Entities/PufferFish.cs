using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class PufferFish : AbstractFish
	{
		public override EntityType Type => EntityType.Pufferfish;

		public override float BoundingBoxX => 0.7f;

		public override float BoundingBoxY => 0.7f;

		public override Identifier ID => new Identifier("pufferfish");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(PuffState);
		}

		/// <summary>
		/// Puff State (varies from 0 to 2)
		/// </summary>
		public EntityMetadata<VarInt> PuffState =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};
	}
}