using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class AbstractVillager : AgeableMob
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(HeadShakeTimer);
		}

		/// <summary>
		/// Starts at 40, decrements each tick
		/// </summary>
		public EntityMetadata<VarInt> HeadShakeTimer =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};
	}
}