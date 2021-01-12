using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Enderman : Monster
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(CarriedBlock);
			MetaRegistry.Add(IsScreaming);
			MetaRegistry.Add(IsStaring);
		}

		public EntityMetadata<OptObject<VarInt>> CarriedBlock =
			new EntityMetadata<OptObject<VarInt>>
			{
				Index = 15,
				DefaultValue = new OptObject<VarInt>(false)
			};

		public EntityMetaBool IsScreaming =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};

		public EntityMetaBool IsStaring =
			new EntityMetaBool
			{
				Index = 17,
				DefaultValue = false
			};
	}
}