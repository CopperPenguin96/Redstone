using ProtocolSharp.Types;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Entities.Entities
{
	public class Blaze : Monster
	{
		public override EntityType Type => EntityType.Blaze;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 1.8f;

		public override Identifier ID => new Identifier("blaze");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsOnFire);
		}

		private byte _onFire = 0;
		private const byte _fire = 0x01;

		public EntityMetaByte IsOnFire =>
			new EntityMetaByte
			{
				Index = 15,
				DefaultValue = 0,
				Value = _onFire
			};

		public bool OnFire
		{
			get => FlagsHelper.IsSet(_onFire, _fire);
			set
			{
				if (value) FlagsHelper.Set(ref _onFire, _fire);
				else FlagsHelper.Unset(ref _onFire, _fire);
			}
		}
	}
}