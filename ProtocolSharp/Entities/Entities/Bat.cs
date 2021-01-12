using ProtocolSharp.Types;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Entities.Entities
{
	public class Bat : AmbientCreature
	{
		public override EntityType Type => EntityType.Bat;

		public override float BoundingBoxX => 0.5f;

		public override float BoundingBoxY => 0.9f;

		public override Identifier ID => new Identifier("bat");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(BatInfo);
		}

		private byte _batInfo = 0;
		private const byte _isHanging = 0x01;

		public EntityMetaByte BatInfo =>
			new EntityMetaByte
			{
				Index = 15,
				DefaultValue = 0,
				Value = _batInfo
			};

		public bool IsHanging
		{
			get => FlagsHelper.IsSet(_batInfo, _isHanging);
			set
			{
				if (value) FlagsHelper.Set(ref _batInfo, _isHanging);
				else FlagsHelper.Unset(ref _batInfo, _isHanging);
			}
		}
	}
}