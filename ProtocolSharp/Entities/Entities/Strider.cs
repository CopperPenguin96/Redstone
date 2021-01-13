using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Strider : Animal
	{
		public override EntityType Type => EntityType.Strider;

		public override float BoundingBoxX => 0.9f;

		public override float BoundingBoxY => 1.7f;

		public override Identifier ID => new Identifier("strider");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(BoostTimer);
			MetaRegistry.Add(IsShaking);
			MetaRegistry.Add(HasSaddle);
		}

		/// <summary>
		/// Total time to "boost" with warped fungus on a stick for
		/// </summary>
		public EntityMetadata<VarInt> BoostTimer =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};

		public EntityMetaBool IsShaking =
			new EntityMetaBool
			{
				Index = 17,
				DefaultValue = false
			};

		public EntityMetaBool HasSaddle =
			new EntityMetaBool
			{
				Index = 18,
				DefaultValue = false
			};
	}
}