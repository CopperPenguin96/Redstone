using ProtocolSharp.Types;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Entities.Entities
{
	public class ArmorStand : LivingEntity
	{
		public override float BoundingBoxX
		{
			get
			{
				if (IsSmall) return 0.25f;
				return IsMarker ? 0.0f : 0.5f;
			}
		}

		public override float BoundingBoxY
		{
			get
			{
				if (IsSmall) return 0.9875f;
				return IsMarker ? 0.0f : 1.975f;
			}
		}

		public override Identifier ID => new Identifier("armor_stand");

		public override bool UseWithSpawnObject => true;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(ArmorDetails);
			MetaRegistry.Add(HeadRotation);
			MetaRegistry.Add(BodyRotation);
			MetaRegistry.Add(LeftArmRotation);
			MetaRegistry.Add(RightArmRotation);
			MetaRegistry.Add(LeftLegRotation);
			MetaRegistry.Add(RightLegRotation);
		}

		private byte _armorDetails = 0;
		private const byte _isSmall = 0x01;
		private const byte _hasArms = 0x04;
		private const byte _hasNoBasePlate = 0x08;
		private const byte _isMarker = 0x10;

		public EntityMetaByte ArmorDetails =>
			new EntityMetaByte
			{
				Index = 14,
				DefaultValue = 0,
				Value = _armorDetails
			};


		public EntityMetadata<Rotation> HeadRotation =
			new EntityMetadata<Rotation>
			{
				Index = 15,
				DefaultValue = new Rotation(0.0f, 0.0f, 0.0f)
			};

		public EntityMetadata<Rotation> BodyRotation =
			new EntityMetadata<Rotation>
			{
				Index = 16,
				DefaultValue = new Rotation(0.0f, 0.0f, 0.0f)
			};

		public EntityMetadata<Rotation> LeftArmRotation =
			new EntityMetadata<Rotation>
			{
				Index = 17,
				DefaultValue = new Rotation(-10.0f, 0.0f, -10.0f)
			};

		public EntityMetadata<Rotation> RightArmRotation =
			new EntityMetadata<Rotation>
			{
				Index = 18,
				DefaultValue = new Rotation(-15.0f, 0.0f, 10.0f)
			};

		public EntityMetadata<Rotation> LeftLegRotation =
			new EntityMetadata<Rotation>
			{
				Index = 19,
				DefaultValue = new Rotation(-1.0f, 0.0f, -1.0f)
			};

		public EntityMetadata<Rotation> RightLegRotation =
			new EntityMetadata<Rotation>
			{
				Index = 20,
				DefaultValue = new Rotation(1.0f, 0.0f, 1.0f)
			};

		#region Armor Details

		public bool IsSmall
		{
			get => FlagsHelper.IsSet(_armorDetails, _isSmall);
			set
			{
				if (value) FlagsHelper.Set(ref _armorDetails, _isSmall);
				else FlagsHelper.Unset(ref _armorDetails, _isSmall);
			}
		}

		public bool HasArms
		{
			get => FlagsHelper.IsSet(_armorDetails, _hasArms);
			set
			{
				if (value) FlagsHelper.Set(ref _armorDetails, _hasArms);
				else FlagsHelper.Unset(ref _armorDetails, _hasArms);
			}
		}

		public bool HasNoBasePlate
		{
			get => FlagsHelper.IsSet(_armorDetails, _hasNoBasePlate);
			set
			{
				if (value) FlagsHelper.Set(ref _armorDetails, _hasNoBasePlate);
				else FlagsHelper.Unset(ref _armorDetails, _hasNoBasePlate);
			}
		}

		public bool IsMarker
		{
			get => FlagsHelper.IsSet(_armorDetails, _isMarker);
			set
			{
				if (value) FlagsHelper.Set(ref _armorDetails, _isMarker);
				else FlagsHelper.Unset(ref _armorDetails, _isMarker);
			}
		}

		#endregion
	}
}