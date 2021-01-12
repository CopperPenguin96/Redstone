using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Phantom : Flying
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Size);
		}

		/// <summary>
		/// Hitbox size is determined by horizontal = 0.9 + 0.2 * size and vertical = 0.5 + 0.1 * i
		/// </summary>
		public EntityMetadata<VarInt> Size =
			new EntityMetadata<VarInt>
			{
				Index = 15,
				DefaultValue = 0
			};
	}
}