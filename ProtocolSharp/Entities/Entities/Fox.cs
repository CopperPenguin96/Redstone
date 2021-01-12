using ProtocolSharp.Types;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Entities.Entities
{
	public class Fox : Animal // What does a Fox say?
	{
		public override EntityType Type => EntityType.Fox;

		public override float BoundingBoxX => 0.6f;

		public override float BoundingBoxY => 0.7f;

		public override Identifier ID => new Identifier("fox");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(FurType);
			MetaRegistry.Add(FoxActions);
			MetaRegistry.Add(FirstUUID);
			MetaRegistry.Add(SecondUUID);
		}

		/// <summary>
		/// Set to 0 for red, set to 1 for snow.
		/// SetRed() and SetSnow() options available too
		/// </summary>
		public EntityMetadata<VarInt> FurType =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0 // Red
			};

		public EntityMetaByte FoxActions =>
			new EntityMetaByte
			{
				Index = 17,
				DefaultValue = 0,
				Value = _foxAction
			};

		public EntityMetadata<OptObject<JavaUUID>> FirstUUID =
			new EntityMetadata<OptObject<JavaUUID>>
			{
				Index = 18,
				DefaultValue = new OptObject<JavaUUID>(false)
			};

		public EntityMetadata<OptObject<JavaUUID>> SecondUUID =
			new EntityMetadata<OptObject<JavaUUID>>
			{
				Index = 19,
				DefaultValue = new OptObject<JavaUUID>(false)
			};

		private byte _foxAction = 0;
		private const byte _isSitting = 0x01;
		private const byte _isCrouching = 0x04;
		private const byte _isInterested = 0x08;
		private const byte _isPouncing = 0x10;
		private const byte _isSleeping = 0x20;
		private const byte _isFaceplanted = 0x40;
		private const byte _isDefending = 0x80;

		#region Fox Actions

		public bool IsSitting
		{
			get => FlagsHelper.IsSet(_foxAction, _isSitting);
			set
			{
				if (value) FlagsHelper.Set(ref _foxAction, _isSitting);
				else FlagsHelper.Unset(ref _foxAction, _isSitting);
			}
		}

		public bool IsCrouching
		{
			get => FlagsHelper.IsSet(_foxAction, _isCrouching);
			set
			{
				if (value) FlagsHelper.Set(ref _foxAction, _isCrouching);
				else FlagsHelper.Unset(ref _foxAction, _isCrouching);
			}
		}

		public bool IsInterested // Foxy
		{
			get => FlagsHelper.IsSet(_foxAction, _isInterested);
			set
			{
				if (value) FlagsHelper.Set(ref _foxAction, _isInterested);
				else FlagsHelper.Unset(ref _foxAction, _isInterested);
			}
		}

		public bool IsPouncing
		{
			get => FlagsHelper.IsSet(_foxAction, _isPouncing);
			set
			{
				if (value) FlagsHelper.Set(ref _foxAction, _isPouncing);
				else FlagsHelper.Unset(ref _foxAction, _isPouncing);
			}
		}

		public bool IsSleeping
		{
			get => FlagsHelper.IsSet(_foxAction, _isSleeping);
			set
			{
				if (value) FlagsHelper.Set(ref _foxAction, _isSleeping);
				else FlagsHelper.Unset(ref _foxAction, _isSleeping);
			}
		}

		public bool IsFaceplanted
		{
			get => FlagsHelper.IsSet(_foxAction, _isFaceplanted);
			set
			{
				if (value) FlagsHelper.Set(ref _foxAction, _isFaceplanted);
				else FlagsHelper.Unset(ref _foxAction, _isFaceplanted);
			}
		}

		public bool IsDefending
		{
			get => FlagsHelper.IsSet(_foxAction, _isDefending);
			set
			{
				if (value) FlagsHelper.Set(ref _foxAction, _isDefending);
				else FlagsHelper.Unset(ref _foxAction, _isDefending);
			}
		}

		#endregion

		public void SetRed()
		{
			FurType.Value = 0;
		}

		public void SetSnow()
		{
			FurType.Value = 1;
		}

	}
}