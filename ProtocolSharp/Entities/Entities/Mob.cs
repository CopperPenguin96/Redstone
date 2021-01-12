using ProtocolSharp.Utils;

namespace ProtocolSharp.Entities.Entities
{
	public class Mob : LivingEntity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(MobDetails);
		}

		private byte _mobDetails = 0;
		private const byte _noAi = 0x01;
		private const byte _isLeftHanded = 0x02;
		private const byte _isAgressive = 0x04;

		public EntityMetaByte MobDetails =>
			new EntityMetaByte
			{
				Index = 14,
				DefaultValue = 0,
				Value = _mobDetails
			};

		public bool NoAI
		{
			get => FlagsHelper.IsSet(_mobDetails, _noAi);
			set
			{
				if (value) FlagsHelper.Set(ref _mobDetails, _noAi);
				else FlagsHelper.Unset(ref _mobDetails, _noAi);
			}
		}

		public bool IsLeftHanded
		{
			get => FlagsHelper.IsSet(_mobDetails, _isLeftHanded);
			set
			{
				if (value) FlagsHelper.Set(ref _mobDetails, _isLeftHanded);
				else FlagsHelper.Unset(ref _mobDetails, _isLeftHanded);
			}
		}

		public bool IsAgressive
		{
			get => FlagsHelper.IsSet(_mobDetails, _isAgressive);
			set
			{
				if (value) FlagsHelper.Set(ref _mobDetails, _isAgressive);
				else FlagsHelper.Unset(ref _mobDetails, _isAgressive);
			}
		}
	}
}