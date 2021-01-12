using ProtocolSharp.Utils;

namespace ProtocolSharp.Entities.Entities
{
	public class AbstractArrow : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(CriticalNoClip);
			MetaRegistry.Add(PiercingLevel);
		}

		private byte _critNoClip = 0;

		public EntityMetaByte CriticalNoClip =>
			new EntityMetaByte
			{
				Index = 7,
				DefaultValue = 0,
				Value = _critNoClip
			};

		public EntityMetaByte PiercingLevel =
			new EntityMetaByte
			{
				Index = 8,
				DefaultValue = 0
			};

		private const byte _crit = 0x01;
		private const byte _noClip = 0x02;

		public bool IsCritical
		{
			get => FlagsHelper.IsSet(_critNoClip, _crit);
			set
			{
				if (value)
				{
					FlagsHelper.Set(ref _critNoClip, _crit);
				}
				else
				{
					FlagsHelper.Unset(ref _critNoClip, _crit);
				}
			}
		}

		public bool IsNoClip
		{
			get => FlagsHelper.IsSet(_critNoClip, _noClip);
			set
			{
				if (value)
				{
					FlagsHelper.Set(ref _critNoClip, _noClip);
				}
				else
				{
					FlagsHelper.Unset(ref _critNoClip, _noClip);
				}
			}
		}

	}
}