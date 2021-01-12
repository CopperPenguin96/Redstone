using ProtocolSharp.Types;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Entities.Entities
{
	public class AbstractHorse : Animal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(HorseDetails);
			MetaRegistry.Add(OwnerUUID);
		}

		private byte _horseDetails = 0;
		private const byte _isTame = 0x02;
		private const byte _isSaddled = 0x04;
		private const byte _hasBred = 0x08;
		private const byte _isEating = 0x10;
		private const byte _isRearing = 0x20;
		private const byte _mouthOpen = 0x40;

		public EntityMetaByte HorseDetails =>
			new EntityMetaByte
			{
				Index = 16,
				DefaultValue = 0,
				Value = _horseDetails
			};

		public EntityMetadata<OptObject<JavaUUID>> OwnerUUID =
			new EntityMetadata<OptObject<JavaUUID>>
			{
				Index = 17,
				DefaultValue = new OptObject<JavaUUID>(false)
			};

		#region Horse Details

		public bool IsTame
		{
			get => FlagsHelper.IsSet(_horseDetails, _isTame);
			set
			{
				if (value) FlagsHelper.Set(ref _horseDetails, _isTame);
				else FlagsHelper.Unset(ref _horseDetails, _isTame);
			}
		}

		public bool IsSaddled
		{
			get => FlagsHelper.IsSet(_horseDetails, _isSaddled);
			set
			{
				if (value) FlagsHelper.Set(ref _horseDetails, _isSaddled);
				else FlagsHelper.Unset(ref _horseDetails, _isSaddled);
			}
		}

		public bool HasBred
		{
			get => FlagsHelper.IsSet(_horseDetails, _hasBred);
			set
			{
				if (value) FlagsHelper.Set(ref _horseDetails, _hasBred);
				else FlagsHelper.Unset(ref _horseDetails, _hasBred);
			}
		}

		public bool IsEating
		{
			get => FlagsHelper.IsSet(_horseDetails, _isEating);
			set
			{
				if (value) FlagsHelper.Set(ref _horseDetails, _isEating);
				else FlagsHelper.Unset(ref _horseDetails, _isEating);
			}
		}

		public bool IsRearing
		{
			get => FlagsHelper.IsSet(_horseDetails, _isRearing);
			set
			{
				if (value) FlagsHelper.Set(ref _horseDetails, _isRearing);
				else FlagsHelper.Unset(ref _horseDetails, _isRearing);
			}
		}

		public bool HasMouthOpen
		{
			get => FlagsHelper.IsSet(_horseDetails, _mouthOpen);
			set
			{
				if (value) FlagsHelper.Set(ref _horseDetails, _mouthOpen);
				else FlagsHelper.Unset(ref _horseDetails, _mouthOpen);
			}
		}

		#endregion
	}
}