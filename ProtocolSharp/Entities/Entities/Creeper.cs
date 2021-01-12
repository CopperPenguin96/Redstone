using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Creeper : Monster
	{
		public override EntityType Type => EntityType.Creeper;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.7f;

		public override Identifier ID => new Identifier("creeper");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(State);
			MetaRegistry.Add(IsCharged);
			MetaRegistry.Add(IsIgnited);
		}

		/// <summary>
		/// -1 for idle and 1 for fuse
		/// </summary>
		public EntityMetadata<VarInt> State =
			new EntityMetadata<VarInt>
			{
				Index = 15,
				DefaultValue = -1
			};

		public EntityMetaBool IsCharged =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};

		public EntityMetaBool IsIgnited =
			new EntityMetaBool
			{
				Index = 17,
				DefaultValue = false
			};
	}
}