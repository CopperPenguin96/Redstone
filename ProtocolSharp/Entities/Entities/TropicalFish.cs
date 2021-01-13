using System;
using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class TropicalFish : AbstractFish
	{
		public override EntityType Type => EntityType.TropicalFish;

		public override float BoundingBoxX => 0.5f;

		public override float BoundingBoxY => 0.4f;

		public override Identifier ID => new Identifier("tropical_fish");

		public override bool UseWithSpawnObject => false;

		public override int Data { get; set; }

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Variant);
		}

		/// <summary>
		/// EID of the owner
		/// </summary>
		/// <param name="eid"></param>
		public TropicalFish(VarInt eid)
		{
			if (eid == null) throw new ArgumentNullException(nameof(eid));

			Data = (int) eid.Value;
		}

		public EntityMetadata<VarInt> Variant =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};
	}
}