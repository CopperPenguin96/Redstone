using ProtocolSharp.Types;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Entities.Entities
{
	public class IronGolem : AbstractGolem
	{
		public override EntityType Type => EntityType.IronGolem;

		public override float BoundingBoxX => 1.4f;

		public override float BoundingBoxY => 2.7f;

		public override Identifier ID => new Identifier("iron_golem");

		public override bool UseWithSpawnObject => true;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(GolemDetails);
		}

		private byte _golemDetails = 0;
		private const byte _playerMade = 0x01;

		public EntityMetaByte GolemDetails =>
			new EntityMetaByte
			{
				Index = 15,
				DefaultValue = 0,
				Value = _golemDetails
			};

		public bool IsPlayerCreated
		{
			get => FlagsHelper.IsSet(_golemDetails, _playerMade);
			set
			{
				if (value) FlagsHelper.Set(ref _golemDetails, _playerMade);
				else FlagsHelper.Unset(ref _golemDetails, _playerMade);
			}
		}
	}
}