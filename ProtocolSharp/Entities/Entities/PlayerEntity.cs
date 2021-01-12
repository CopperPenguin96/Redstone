using fNbt;
using ProtocolSharp.Types;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Entities.Entities
{
	public class PlayerEntity : LivingEntity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(AdditionalHearts);
			MetaRegistry.Add(Score);
			MetaRegistry.Add(DisplayedParts);
			MetaRegistry.Add(MainHand);
			MetaRegistry.Add(LeftShoulderData);
			MetaRegistry.Add(RightShoulderData);
		}

		public EntityMetaFloat AdditionalHearts =
			new EntityMetaFloat
			{
				Index = 14,
				DefaultValue = 0.0f
			};

		public EntityMetadata<VarInt> Score =
			new EntityMetadata<VarInt>
			{
				Index = 15,
				DefaultValue = 0
			};

		private byte _displayedParts = 0;
		private byte _cape = 0x01;
		private byte _jacket = 0x02;
		private byte _leftSleeve = 0x04;
		private byte _rightSleeve = 0x08;
		private byte _leftPant = 0x10;
		private byte _rightPant = 0x20;
		private byte _hat = 0x40;

		public EntityMetaByte DisplayedParts =>
			new EntityMetaByte
			{
				Index = 16,
				DefaultValue = 0,
				Value = _displayedParts
			};

		/// <summary>
		/// Set to 0 for Left, Set to 1 for Right
		/// </summary>
		public EntityMetaByte MainHand =
			new EntityMetaByte
			{
				Index = 17,
				DefaultValue = 1
			};

		/// <summary>
		/// Entity data for parrots
		/// </summary>
		public EntityMetadata<NbtCompound> LeftShoulderData =
			new EntityMetadata<NbtCompound>
			{
				Index = 18,
				DefaultValue = new NbtCompound()
			};

		/// <summary>
		/// Entity data for parrots
		/// </summary>
		public EntityMetadata<NbtCompound> RightShoulderData =
			new EntityMetadata<NbtCompound>
			{
				Index = 19,
				DefaultValue = new NbtCompound()
			};

		#region Displayed Parts

		public bool CapeEnabled
		{
			get => FlagsHelper.IsSet(_displayedParts, _cape);
			set
			{
				if (value) FlagsHelper.Set(ref _displayedParts, _cape);
				else FlagsHelper.Unset(ref _displayedParts, _cape);
			}
		}

		public bool JacketEnabled
		{
			get => FlagsHelper.IsSet(_displayedParts, _jacket);
			set
			{
				if (value) FlagsHelper.Set(ref _displayedParts, _jacket);
				else FlagsHelper.Unset(ref _displayedParts, _jacket);
			}
		}

		public bool LeftSleeveEnabled
		{
			get => FlagsHelper.IsSet(_displayedParts, _leftSleeve);
			set
			{
				if (value) FlagsHelper.Set(ref _displayedParts, _leftSleeve);
				else FlagsHelper.Unset(ref _displayedParts, _leftSleeve);
			}
		}

		public bool RightSleeveEnabled
		{
			get => FlagsHelper.IsSet(_displayedParts, _rightSleeve);
			set
			{
				if (value) FlagsHelper.Set(ref _displayedParts, _rightSleeve);
				else FlagsHelper.Unset(ref _displayedParts, _rightSleeve);
			}
		}

		public bool LeftPantEnabled
		{
			get => FlagsHelper.IsSet(_displayedParts, _leftPant);
			set
			{
				if (value) FlagsHelper.Set(ref _displayedParts, _leftPant);
				else FlagsHelper.Unset(ref _displayedParts, _leftPant);
			}
		}

		public bool RightPantEnabled
		{
			get => FlagsHelper.IsSet(_displayedParts, _rightPant);
			set
			{
				if (value) FlagsHelper.Set(ref _displayedParts, _rightPant);
				else FlagsHelper.Unset(ref _displayedParts, _rightPant);
			}
		}

		public bool HatEnabled
		{
			get => FlagsHelper.IsSet(_displayedParts, _hat);
			set
			{
				if (value) FlagsHelper.Set(ref _displayedParts, _hat);
				else FlagsHelper.Unset(ref _displayedParts, _hat);
			}
		}

		#endregion
	}
}