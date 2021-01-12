using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Pig : Animal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(HasSaddle);
			MetaRegistry.Add(CarrotBoostTime);
		}

		public EntityMetaBool HasSaddle =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};

		/// <summary>
		/// Total time to "boost" with a carrot on a stick for
		/// </summary>
		public EntityMetadata<VarInt> CarrotBoostTime =
			new EntityMetadata<VarInt>
			{
				Index = 17,
				DefaultValue = 0
			};
	}
}