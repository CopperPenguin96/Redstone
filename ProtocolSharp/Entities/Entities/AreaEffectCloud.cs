using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class AreaEffectCloud : Entity
	{
		public override float BoundingBoxX => 2.0f * Radius.Value;

		public override float BoundingBoxY => 0.5f;

		public override Identifier ID => new Identifier("area_effect_cloud");

		public override bool UseWithSpawnObject => true;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Radius);
			MetaRegistry.Add(Color);
			MetaRegistry.Add(IgnoreRadius);
			MetaRegistry.Add(Particle);
		}

		public EntityMetaFloat Radius =
			new EntityMetaFloat
			{
				Index = 7,
				DefaultValue = 0.5f
			};

		/// <summary>
		/// Only for mob spell particle
		/// </summary>
		public EntityMetadata<VarInt> Color =
			new EntityMetadata<VarInt>
			{
				Index = 8,
				DefaultValue = 0
			};

		/// <summary>
		/// When set to true, the client will ignore the radius and
		/// just show the effect as single point, not area
		/// </summary>
		public EntityMetaBool IgnoreRadius =
			new EntityMetaBool
			{
				Index = 9,
				DefaultValue = false
			};

		public EntityMetadata<Particle<object>> Particle =
			new EntityMetadata<Particle<object>>
			{
				Index = 10,
				DefaultValue = Particle<object>.Effect
			};
	}
}