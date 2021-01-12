using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Horse : AbstractHorse
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Variant);
		}

		/// <summary>
		/// Variant of horse (Color & Style)
		/// </summary>
		public EntityMetadata<VarInt> Variant =
			new EntityMetadata<VarInt>
			{
				Index = 18,
				DefaultValue = 0
			};
	}
}