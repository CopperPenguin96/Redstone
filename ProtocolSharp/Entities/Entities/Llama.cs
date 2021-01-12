using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Llama : ChestedHorse
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Strength);
			MetaRegistry.Add(CarpetColor);
			MetaRegistry.Add(Variant);
		}

		/// <summary>
		/// Strength in relation to number of columns of 3 slots in the llama's inventory
		/// once a chest is equipped
		/// </summary>
		public EntityMetadata<VarInt> Strength =
			new EntityMetadata<VarInt>
			{
				Index = 19,
				DefaultValue = 0
			};

		/// <summary>
		/// Carpet color (a dye color, or -1 if no carpet equipped)
		/// </summary>
		public EntityMetadata<VarInt> CarpetColor =
			new EntityMetadata<VarInt>
			{
				Index = 20,
				DefaultValue = -1
			};

		/// <summary>
		/// Variant of lama;
		/// 0-3
		/// </summary>
		public EntityMetadata<VarInt> Variant =
			new EntityMetadata<VarInt>
			{
				Index = 21,
				DefaultValue = 0
			};
	}
}