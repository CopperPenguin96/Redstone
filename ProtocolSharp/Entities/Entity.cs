using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using fNbt;
using ProtocolSharp.Chat;
using ProtocolSharp.Entities;
using ProtocolSharp.Types;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Entities
{
	/// <summary>
	/// Base entity
	/// </summary>
	public class Entity
	{
		public MetaRegistry MetaRegistry = new MetaRegistry();

		/// <summary>
		/// Must be called before sending ANY metadata info to the client
		/// EACH time
		/// Each entity class will need to override this and call the base() method
		/// to register any new items
		/// </summary>
		public virtual void RegisterMetadata()
		{
			MetaRegistry.Clear();
			MetaRegistry.Add(MotionEffects);
			MetaRegistry.Add(AirTicks);
			MetaRegistry.Add(CustomName);
			MetaRegistry.Add(IsCustomNameVisible);
			MetaRegistry.Add(IsSilent);
			MetaRegistry.Add(HasNoGravity);
			MetaRegistry.Add(Pose);
		}

		private byte _motionEffects = 0;

		public EntityMetaByte MotionEffects =>
			new EntityMetaByte
			{
				Index = 0,
				DefaultValue = 0,
				Value = _motionEffects
			};

		public EntityMetadata<VarInt> AirTicks =
			new EntityMetadata<VarInt>
			{
				Index = 1,
				DefaultValue = 300
			};

		public void SetAirTicks(VarInt ticks)
		{
			AirTicks.Value = ticks;
		}

		public EntityMetadata<OptChatBuilder> CustomName =
			new EntityMetadata<OptChatBuilder>
			{
				Index = 2,
				DefaultValue = new OptChatBuilder
				{
					IsDisplayed = false
				}
			};

		public void ResetCustomName()
		{
			CustomName.Value = CustomName.DefaultValue;
		}

		/// <summary>
		/// Set null to reset custom name or use ResetCustomName()
		/// </summary>
		/// <param name="custom"></param>
		public void SetCustomName(ChatBuilder custom)
		{
			if (custom == null) ResetCustomName();
			else
			{
				CustomName.Value.IsDisplayed = true;
				CustomName.Value.Chat = custom;
			}
		}

		/// <summary>
		/// Set null to reset custom name or use ResetCustomName()
		/// </summary>
		/// <param name="raw"></param>
		public void SetCustomName(string raw)
		{
			if (raw == null) ResetCustomName();
			else
			{
				CustomName.Value.IsDisplayed = true;
				ChatBuilder builder = new ChatBuilder();
				builder.Add(new ChatPart {Text = raw});
				CustomName.Value.Chat = builder;
			}
		}

		public EntityMetaBool IsCustomNameVisible =>
			new EntityMetaBool
			{
				Index = 3,
				DefaultValue = false,
				Value = CustomName.Value.IsDisplayed
			};

		public bool CustomNameVisible()
		{
			return IsCustomNameVisible.Value;
		}

		public EntityMetaBool IsSilent =
			new EntityMetaBool
			{
				Index = 4,
				DefaultValue = false
			};

		public void SetSilent(bool silent)
		{
			IsSilent.Value = silent;
		}

		public EntityMetaBool HasNoGravity =
			new EntityMetaBool
			{
				Index = 5,
				DefaultValue = false
			};

		public void SetGravity(bool gravity)
		{
			HasNoGravity.Value = !gravity; // Set not because original is has NO gravity
		}

		public EntityMetaPose Pose =
			new EntityMetaPose
			{
				Index = 6,
				DefaultValue = EntityPose.Standing
			};

		public void SetPose(EntityPose pose)
		{
			Pose.Value = pose;
		}

		#region Motion Effects Flags

		private const byte FireFlag = 0x01;
		private const byte CrouchFlag = 0x02;
		private const byte UnusedFlag = 0x04; // Previously Riding
		private const byte SprintFlag = 0x08;
		private const byte SwimFlag = 0x10;
		private const byte InvisibleFlag = 0x20;
		private const byte GlowingFlag = 0x40;
		private const byte FlyingElytraFlag = 0x80;

		public bool IsOnFire
		{
			get => FlagsHelper.IsSet(_motionEffects, FireFlag);
			set
			{
				if (value == true)
				{
					FlagsHelper.Set(ref _motionEffects, FireFlag);
				}
				else
				{
					FlagsHelper.Unset(ref _motionEffects, FireFlag);
				}
			}
		}

		public bool IsCrouching
		{
			get => FlagsHelper.IsSet(_motionEffects, CrouchFlag);
			set
			{
				if (value == true)
				{
					FlagsHelper.Set(ref _motionEffects, CrouchFlag);
				}
				else
				{
					FlagsHelper.Unset(ref _motionEffects, CrouchFlag);
				}
			}
		}

		public bool Unused
		{
			get => FlagsHelper.IsSet(_motionEffects, UnusedFlag);
			set
			{
				if (value == true)
				{
					FlagsHelper.Set(ref _motionEffects, UnusedFlag);
				}
				else
				{
					FlagsHelper.Unset(ref _motionEffects, UnusedFlag);
				}
			}
		}

		public bool IsSprinting
		{
			get => FlagsHelper.IsSet(_motionEffects, SprintFlag);
			set
			{
				if (value == true)
				{
					FlagsHelper.Set(ref _motionEffects, SprintFlag);
				}
				else
				{
					FlagsHelper.Unset(ref _motionEffects, SprintFlag);
				}
			}
		}

		public bool IsSwimming
		{
			get => FlagsHelper.IsSet(_motionEffects, SwimFlag);
			set
			{
				if (value == true)
				{
					FlagsHelper.Set(ref _motionEffects, SwimFlag);
				}
				else
				{
					FlagsHelper.Unset(ref _motionEffects, SwimFlag);
				}
			}
		}

		public bool IsInvisible
		{
			get => FlagsHelper.IsSet(_motionEffects, InvisibleFlag);
			set
			{
				if (value == true)
				{
					FlagsHelper.Set(ref _motionEffects, InvisibleFlag);
				}
				else
				{
					FlagsHelper.Unset(ref _motionEffects, InvisibleFlag);
				}
			}
		}

		public bool HasGlowingEffect
		{
			get => FlagsHelper.IsSet(_motionEffects, CrouchFlag);
			set
			{
				if (value == true)
				{
					FlagsHelper.Set(ref _motionEffects, GlowingFlag);
				}
				else
				{
					FlagsHelper.Unset(ref _motionEffects, GlowingFlag);
				}
			}
		}

		public bool IsFlyingWithElytra
		{
			get => FlagsHelper.IsSet(_motionEffects, FlyingElytraFlag);
			set
			{
				if (value == true)
				{
					FlagsHelper.Set(ref _motionEffects, FlyingElytraFlag);
				}
				else
				{
					FlagsHelper.Unset(ref _motionEffects, FlyingElytraFlag);
				}
			}
		}

		#endregion
	}

	public class ThrownEgg : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Slot);
		}

		public EntityMetadata<Slot> Slot =
			new EntityMetadata<Slot>
			{
				Index = 7,
				DefaultValue = new Slot()
			};
	}

	public class ThrownEnderPearl : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Slot);
		}

		public EntityMetadata<Slot> Slot =
			new EntityMetadata<Slot>
			{
				Index = 7,
				DefaultValue = new Slot()
			};
	}

	public class ThrownExperienceBottle : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Slot);
		}

		public EntityMetadata<Slot> Slot =
			new EntityMetadata<Slot>
			{
				Index = 7,
				DefaultValue = new Slot()
			};
	}

	public class ThrownPotion : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Slot);
		}

		public EntityMetadata<Slot> Slot =
			new EntityMetadata<Slot>
			{
				Index = 7,
				DefaultValue = new Slot()
			};
	}


	public class Snowball : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Slot);
		}

		public EntityMetadata<Slot> Slot =
			new EntityMetadata<Slot>
			{
				Index = 7,
				DefaultValue = new Slot()
			};
	}

	public class EyeOfEnder : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Slot);
		}

		public EntityMetadata<Slot> Slot =
			new EntityMetadata<Slot>
			{
				Index = 7,
				DefaultValue = new Slot()
			};
	}

	public class FallingBlock : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(SpawnPosition);
		}

		public EntityMetadata<Position> SpawnPosition =
			new EntityMetadata<Position>
			{
				Index = 7,
				DefaultValue = new Position(0, 0, 0)
			};
	}

	public class AreaEffectCloud : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Radius);
			MetaRegistry.Add(Color);
			MetaRegistry.Add(IgnoreRadius);
			MetaRegistry.Add(Particle);
		}

		public EntityMetaFloat Radius =
			new EntityMetaFloat
			{
				Index = 7,
				DefaultValue = 0.5f
			};

		/// <summary>
		/// Only for mob spell particle
		/// </summary>
		public EntityMetadata<VarInt> Color =
			new EntityMetadata<VarInt>
			{
				Index = 8,
				DefaultValue = 0
			};

		/// <summary>
		/// When set to true, the client will ignore the radius and
		/// just show the effect as single point, not area
		/// </summary>
		public EntityMetaBool IgnoreRadius =
			new EntityMetaBool
			{
				Index = 9,
				DefaultValue = false
			};

		public EntityMetadata<Particle<object>> Particle =
			new EntityMetadata<Particle<object>>
			{
				Index = 10,
				DefaultValue = Particle<object>.Effect
			};
	}

	public class FishingHook : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(HookedID);
			MetaRegistry.Add(IsCatchable);
		}

		/// <summary>
		/// Hooked entity ID + 1, or 0 if there is no hooked entity
		/// </summary>
		public EntityMetadata<VarInt> HookedID =
			new EntityMetadata<VarInt>
			{
				Index = 7,
				DefaultValue = 0
			};

		public EntityMetaBool IsCatchable =
			new EntityMetaBool
			{
				Index = 8,
				DefaultValue = false
			};
	}

	#region Arrows/Tridents

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

	public class Arrow : AbstractArrow
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Color);
		}

		/// <summary>
		/// Used for both tipped and regular arrows. If not tipped, then color is set to -1
		/// and no tipped arrow particles are used.
		/// </summary>
		public EntityMetadata<VarInt> Color =
			new EntityMetadata<VarInt>
			{
				Index = 9,
				DefaultValue = -1
			};
	}

	public class SpectralArrow : AbstractArrow
	{
		// Does not add anything new
	}

	public class ThrownTrident : AbstractArrow
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(LoyaltyLevel);
			MetaRegistry.Add(HasEnchantmentGlint);
		}

		public EntityMetadata<VarInt> LoyaltyLevel =
			new EntityMetadata<VarInt>
			{
				Index = 9,
				DefaultValue = 0
			};

		public EntityMetaBool HasEnchantmentGlint =
			new EntityMetaBool
			{
				Index = 10,
				DefaultValue = false
			};
	}

	#endregion

	public class Boat : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(TimeSinceLastHit);
			MetaRegistry.Add(ForwardDirection);
			MetaRegistry.Add(DamageTaken);
			MetaRegistry.Add(Type);
			MetaRegistry.Add(LeftPaddleTurning);
			MetaRegistry.Add(RightPaddleTurning);
			MetaRegistry.Add(SplashTimer);
		}

		public EntityMetadata<VarInt> TimeSinceLastHit =
			new EntityMetadata<VarInt>
			{
				Index = 7,
				DefaultValue = 0
			};

		public EntityMetadata<VarInt> ForwardDirection =
			new EntityMetadata<VarInt>
			{
				Index = 8,
				DefaultValue = 1
			};

		public EntityMetaFloat DamageTaken =
			new EntityMetaFloat
			{
				Index = 9,
				DefaultValue = 0.0f
			};

		public EntityMetadata<VarInt> Type =
			new EntityMetadata<VarInt>
			{
				Index = 10,
				DefaultValue = (int) BoatType.Oak
			};

		public EntityMetaBool LeftPaddleTurning =
			new EntityMetaBool
			{
				Index = 11,
				DefaultValue = false
			};

		public EntityMetaBool RightPaddleTurning =
			new EntityMetaBool
			{
				Index = 12,
				DefaultValue = false
			};

		public EntityMetadata<VarInt> SplashTimer =
			new EntityMetadata<VarInt>
			{
				Index = 13,
				DefaultValue = 0
			};
	}

	public class EndCrystal : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(BeamTarget);
			MetaRegistry.Add(ShowBottom);
		}

		public EntityMetadata<OptBlockPos> BeamTarget =>
			new EntityMetadata<OptBlockPos>
			{
				Index = 7,
				DefaultValue = new OptBlockPos(false)
			};

		public EntityMetaBool ShowBottom =
			new EntityMetaBool
			{
				Index = 8,
				DefaultValue = true
			};
	}


	public class DragonFireball : Entity
	{
		// Adds nothing new
	}

	public class SmallFireball : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Item);
		}

		public EntityMetadata<Slot> Item =
			new EntityMetadata<Slot>
			{
				Index = 7,
				DefaultValue = new Slot()
			};
	}

	public class Fireball : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Item);
		}

		public EntityMetadata<Slot> Item =
			new EntityMetadata<Slot>
			{
				Index = 7,
				DefaultValue = new Slot()
			};
	}

	public class WitherSkull : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsInvulnerable);
		}

		public EntityMetaBool IsInvulnerable =
			new EntityMetaBool
			{
				Index = 7,
				DefaultValue = false
			};

	}

	public class FireworkRocketEntity : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(FireworkInfo);
			MetaRegistry.Add(FireworkBoosterEntityID);
			MetaRegistry.Add(IsShotAtAngle);
		}

		public EntityMetadata<Slot> FireworkInfo =
			new EntityMetadata<Slot>
			{
				Index = 7,
				DefaultValue = new Slot()
			};

		/// <summary>
		/// Entity ID of entity which used firework (for elytra boosting)
		/// </summary>
		public EntityMetadata<OptVarInt> FireworkBoosterEntityID =
			new EntityMetadata<OptVarInt>
			{
				Index = 8,
				DefaultValue = new OptVarInt(false)
			};

		/// <summary>
		/// True if shot at an angle (from a crossbow)
		/// </summary>
		public EntityMetaBool IsShotAtAngle =
			new EntityMetaBool
			{
				Index = 9,
				DefaultValue = false
			};
	}

	public class ItemFrame : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Item);
			MetaRegistry.Add(Rotation);
		}

		public EntityMetadata<Slot> Item =
			new EntityMetadata<Slot>
			{
				Index = 7,
				DefaultValue = new Slot()
			};

		public EntityMetadata<VarInt> Rotation =
			new EntityMetadata<VarInt>
			{
				Index = 8,
				DefaultValue = 0
			};

	}

	public class ItemEntity : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Item);
		}

		public EntityMetadata<Slot> Item =
			new EntityMetadata<Slot>
			{
				Index = 7,
				DefaultValue = new Slot()
			};
	}

	#region Living Entities

	public class LivingEntity : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(HandStates);
			MetaRegistry.Add(Health);
			MetaRegistry.Add(PotionEffectColor);
			MetaRegistry.Add(IsPotionEffectAmbient);
			MetaRegistry.Add(ArrowsStabbed);
			MetaRegistry.Add(HealthAddedByAbsorption);
			MetaRegistry.Add(SleepingLocation);
		}

		private byte _handState = 0;
		private const byte _isHandActive = 0x01;
		private const byte _activeHand = 0x02; // Unset for main, set for offhand
		private const byte _riptide = 0x04;

		public EntityMetaByte HandStates =>
			new EntityMetaByte
			{
				Index = 7,
				DefaultValue = 0,
				Value = _handState
			};

		public EntityMetaFloat Health =
			new EntityMetaFloat
			{
				Index = 8,
				DefaultValue = 1.0f
			};

		/// <summary>
		/// Set to 0 if there is no effect
		/// </summary>
		public EntityMetadata<VarInt> PotionEffectColor =
			new EntityMetadata<VarInt>
			{
				Index = 9,
				DefaultValue = 0
			};

		/// <summary>
		/// If true, reduces the number of particles generated by
		/// potions to 1/5 the normal amount
		/// </summary>
		public EntityMetaBool IsPotionEffectAmbient =
			new EntityMetaBool
			{
				Index = 10,
				DefaultValue = false
			};

		public EntityMetadata<VarInt> ArrowsStabbed =
			new EntityMetadata<VarInt>
			{
				Index = 11,
				DefaultValue = 0
			};

		public EntityMetadata<VarInt> HealthAddedByAbsorption =
			new EntityMetadata<VarInt>
			{
				Index = 12,
				DefaultValue = 0
			};

		public EntityMetadata<OptBlockPos> SleepingLocation =
			new EntityMetadata<OptBlockPos>
			{
				Index = 13,
				DefaultValue = new OptBlockPos(false)
			};

		public bool IsHandActive
		{
			get => FlagsHelper.IsSet(_handState, _isHandActive);
			set
			{
				if (value)
				{
					FlagsHelper.Set(ref _handState, _isHandActive);
				}
				else
				{
					FlagsHelper.Unset(ref _handState, _isHandActive);
				}
			}
		}

		public void SetMainHand()
		{
			FlagsHelper.Unset(ref _handState, _activeHand);
		}

		public void SetOffHand()
		{
			FlagsHelper.Set(ref _handState, _activeHand);
		}

		public bool IsInRiptide
		{
			get => FlagsHelper.IsSet(_handState, _riptide);
			set
			{
				if (value)
				{
					FlagsHelper.Set(ref _handState, _riptide);
				}
				else
				{
					FlagsHelper.Unset(ref _handState, _riptide);
				}
			}
		}
	}

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

	public class ArmorStand : LivingEntity
	{
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

	public class AmbientCreature : Mob
	{
		// Adds nothing new
	}

	public class Bat : AmbientCreature
	{
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

	public class PathfinderMob : Mob
	{
		// Adds nothing new
	}

	public class WaterAnimal : PathfinderMob
	{
		// Adds nothing new
	}

	public class Squid : WaterAnimal
	{
		// Adds nothing new
	}

	public class Dolphin : WaterAnimal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(TreasurePosition);
			MetaRegistry.Add(CanFindTreasure);
			MetaRegistry.Add(HasFish);
		}

		public EntityMetadata<Position> TreasurePosition =
			new EntityMetadata<Position>
			{
				Index = 15,
				DefaultValue = new Position(0, 0, 0)
			};

		public EntityMetaBool CanFindTreasure =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};

		public EntityMetaBool HasFish =
			new EntityMetaBool
			{
				Index = 17,
				DefaultValue = false
			};
	}

	public class AbstractFish : WaterAnimal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(FromBucket);
		}

		public EntityMetaBool FromBucket =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};
	}

	public class Cod : AbstractFish
	{
		// Nothing new here to see
	}

	public class PufferFish : AbstractFish
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(PuffState);
		}

		/// <summary>
		/// Puff State (varies from 0 to 2)
		/// </summary>
		public EntityMetadata<VarInt> PuffState =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};
	}

	public class Salmon : AbstractFish
	{
		// Nothing new
	}

	public class TropicalFish : AbstractFish
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Variant);
		}

		public EntityMetadata<VarInt> Variant =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};
	}

	public class AgeableMob : PathfinderMob
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsBaby);
		}

		public EntityMetaBool IsBaby =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};
	}

	public class Animal : AgeableMob
	{
		// What an animal... doesn't add anything else
	}

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

	public class Horse : AbstractHorse
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Variant);
		}

		/// <summary>
		/// Variant of horse (Color & Style)
		/// </summary>
		public EntityMetadata<VarInt> Variant =
			new EntityMetadata<VarInt>
			{
				Index = 18,
				DefaultValue = 0
			};
	}

	public class ZombieHorse : AbstractHorse
	{
		// Does this really classify as living?
	}

	public class SkeletonHorse : AbstractHorse
	{

	}

	public class ChestedHorse : AbstractHorse
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(HasChest);
		}

		public EntityMetaBool HasChest =
			new EntityMetaBool
			{
				Index = 18,
				DefaultValue = false
			};
	}

	public class Donkey : ChestedHorse
	{

	}

	public class Llama : ChestedHorse
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Strength);
			MetaRegistry.Add(CarpetColor);
			MetaRegistry.Add(Variant);
		}

		/// <summary>
		/// Strength in relation to number of columns of 3 slots in the llama's inventory
		/// once a chest is equipped
		/// </summary>
		public EntityMetadata<VarInt> Strength =
			new EntityMetadata<VarInt>
			{
				Index = 19,
				DefaultValue = 0
			};

		/// <summary>
		/// Carpet color (a dye color, or -1 if no carpet equipped)
		/// </summary>
		public EntityMetadata<VarInt> CarpetColor =
			new EntityMetadata<VarInt>
			{
				Index = 20,
				DefaultValue = -1
			};

		/// <summary>
		/// Variant of lama;
		/// 0-3
		/// </summary>
		public EntityMetadata<VarInt> Variant =
			new EntityMetadata<VarInt>
			{
				Index = 21,
				DefaultValue = 0
			};
	}

	public class TraderLlama : Llama
	{

	}

	public class Mule : ChestedHorse
	{

	}

	public class Bee : Animal
	{

	}

	public class Fox : Animal // What does a Fox say?
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Type);
			MetaRegistry.Add(FoxActions);
			MetaRegistry.Add(FirstUUID);
			MetaRegistry.Add(SecondUUID);
		}

		/// <summary>
		/// Set to 0 for red, set to 1 for snow.
		/// SetRed() and SetSnow() options available too
		/// </summary>
		public EntityMetadata<VarInt> Type =
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
			Type.Value = 0;
		}

		public void SetSnow()
		{
			Type.Value = 1;
		}

	}

	public class Ocelot : Animal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsTrusting);
		}

		public EntityMetaBool IsTrusting =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};
	}

	public class Panda : Animal // Express?
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(BreedTimer);
			MetaRegistry.Add(SneezeTimer);
			MetaRegistry.Add(EatTimer);
			MetaRegistry.Add(MainGene);
			MetaRegistry.Add(HiddenGene);
			MetaRegistry.Add(PandaAction);
		}

		/// <summary>
		/// Set to 32 when something happens, and then count down to 0 again.
		/// At 29 and 14 (before counting down), will play the
		/// entity.panda.cant_breed sound event
		/// </summary>
		public EntityMetaInt BreedTimer =
			new EntityMetaInt
			{
				Index = 16,
				DefaultValue = 0
			};

		/// <summary>
		/// Counts up from 0; when it hits 1 the entity.panda.pre_sneeze event plays
		/// and when it hits 21 the entity.panda.sneeze event plays
		/// (then sets back to 0 and the sneeze flag is cleared)
		/// </summary>
		public EntityMetaInt SneezeTimer =
			new EntityMetaInt
			{
				Index = 17,
				DefaultValue = 0
			};

		/// <summary>
		/// If non-zero, counts upwards
		/// </summary>
		public EntityMetaInt EatTimer =
			new EntityMetaInt
			{
				Index = 18,
				DefaultValue = 0
			};

		public EntityMetaByte MainGene =
			new EntityMetaByte
			{
				Index = 19,
				DefaultValue = 0
			};

		public EntityMetaByte HiddenGene =
			new EntityMetaByte
			{
				Index = 20,
				DefaultValue = 0
			};

		private byte _pandaAction = 0;
		private const byte _isSneezing = 0x02;
		private const byte _isRolling = 0x04;
		private const byte _isSitting = 0x08;
		private const byte _isOnBack = 0x10;

		public EntityMetaByte PandaAction =>
			new EntityMetaByte
			{
				Index = 21,
				DefaultValue = 0,
				Value = _pandaAction
			};

		#region Panda Actions 

		public bool IsSneezing
		{
			get => FlagsHelper.IsSet(_pandaAction, _isSneezing);
			set
			{
				if (value) FlagsHelper.Set(ref _pandaAction, _isSneezing);
				else FlagsHelper.Unset(ref _pandaAction, _isSneezing);
			}
		}

		public bool IsRolling
		{
			get => FlagsHelper.IsSet(_pandaAction, _isRolling);
			set
			{
				if (value) FlagsHelper.Set(ref _pandaAction, _isRolling);
				else FlagsHelper.Unset(ref _pandaAction, _isRolling);
			}
		}

		public bool IsSitting
		{
			get => FlagsHelper.IsSet(_pandaAction, _isSitting);
			set
			{
				if (value) FlagsHelper.Set(ref _pandaAction, _isSitting);
				else FlagsHelper.Unset(ref _pandaAction, _isSitting);
			}
		}

		public bool IsOnBack
		{
			get => FlagsHelper.IsSet(_pandaAction, _isOnBack);
			set
			{
				if (value) FlagsHelper.Set(ref _pandaAction, _isOnBack);
				else FlagsHelper.Unset(ref _pandaAction, _isOnBack);
			}
		}

		#endregion
	}

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

	public class Rabbit : Animal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Type);
		}

		public EntityMetadata<VarInt> Type =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};
	}

	public class Turtle : Animal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(HomePos);
			MetaRegistry.Add(HasEgg);
			MetaRegistry.Add(IsLayingEgg);
			MetaRegistry.Add(TravelPos);
			MetaRegistry.Add(IsGoingHome);
			MetaRegistry.Add(IsTraveling);
		}

		public EntityMetadata<Position> HomePos =
			new EntityMetadata<Position>
			{
				Index = 16,
				DefaultValue = new Position(0, 0, 0)
			};

		public EntityMetaBool HasEgg =
			new EntityMetaBool
			{
				Index = 17,
				DefaultValue = false
			};

		public EntityMetaBool IsLayingEgg =
			new EntityMetaBool
			{
				Index = 18,
				DefaultValue = false
			};

		public EntityMetadata<Position> TravelPos =
			new EntityMetadata<Position>
			{
				Index = 19,
				DefaultValue = new Position(0, 0, 0)
			};

		public EntityMetaBool IsGoingHome =
			new EntityMetaBool
			{
				Index = 20,
				DefaultValue = false
			};

		public EntityMetaBool IsTraveling =
			new EntityMetaBool
			{
				Index = 21,
				DefaultValue = false
			};
	}

	public class PolarBear : Animal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsStandingUp);
		}

		public EntityMetaBool IsStandingUp =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};
	}

	public class Chicken : Animal // https://www.youtube.com/watch?v=W4WGQmWcrbs
	{

	}

	public class Cow : Animal
	{

	}

	public class Hoglin : Animal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsImmuneToZombification);
		}

		public EntityMetaBool IsImmuneToZombification =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};
	}

	public class Mooshroom : Cow
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Variant);
		}

		/// <summary>
		/// Either red or brown
		/// </summary>
		public EntityMetadata<string> Variant =
			new EntityMetadata<string>
			{
				Index = 16,
				DefaultValue = "red"
			};

		public void SetRed()
		{
			Variant.Value = "red";
		}

		public void SetBrown()
		{
			Variant.Value = "brown";
		}

	}

	public class Sheep : Animal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(SheepData);
		}

		private byte _sheepData = 0;
		private const byte _colorId = 0x0F;
		private const byte _isSheared = 0x10;

		public EntityMetaByte SheepData =>
			new EntityMetaByte
			{
				Index = 16,
				DefaultValue = 0,
				Value = _sheepData
			};

		public void SetColor(SheepColor color)
		{
			byte c = 0x0F;
			FlagsHelper.Set(ref c, (byte) color);
			FlagsHelper.Set(ref _sheepData, c);
			// TODO ? Is this correct for changing sheep color?
		}

		public bool IsSheared
		{
			get => FlagsHelper.IsSet(_sheepData, _isSheared);
			set
			{
				if (value) FlagsHelper.Set(ref _sheepData, _isSheared);
				else FlagsHelper.Unset(ref _sheepData, _isSheared);
			}
		}
	}

	public enum SheepColor : byte
	{
		White = 0,
		Orange = 1,
		Magenta = 2,
		LightBlue = 3,
		Yellow = 4,
		Lime = 5,
		Pink = 6,
		Gray = 7,
		LightGray = 8,
		Cyan = 9,
		Purple = 10,
		Blue = 11,
		Brown = 12,
		Green = 13,
		Red = 14,
		Black = 15
	}

	public class Strider : Animal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(BoostTimer);
			MetaRegistry.Add(IsShaking);
			MetaRegistry.Add(HasSaddle);
		}

		/// <summary>
		/// Total time to "boost" with warped fungus on a stick for
		/// </summary>
		public EntityMetadata<VarInt> BoostTimer =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};

		public EntityMetaBool IsShaking =
			new EntityMetaBool
			{
				Index = 17,
				DefaultValue = false
			};

		public EntityMetaBool HasSaddle =
			new EntityMetaBool
			{
				Index = 18,
				DefaultValue = false
			};
	}

	public class TameableAnimal : Animal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(AnimalData);
			MetaRegistry.Add(Owner);
		}

		private byte _animalData = 0;
		private const byte _isSitting = 0x01;
		private const byte _isTamed = 0x04;

		public EntityMetaByte AnimalData =>
			new EntityMetaByte
			{
				Index = 16,
				DefaultValue = 0,
				Value = _animalData
			};

		public EntityMetadata<OptObject<JavaUUID>> Owner =
			new EntityMetadata<OptObject<JavaUUID>>
			{
				Index = 17,
				DefaultValue = new OptObject<JavaUUID>(false)
			};

		public bool IsSitting
		{
			get => FlagsHelper.IsSet(_animalData, _isSitting);
			set
			{
				if (value) FlagsHelper.Set(ref _animalData, _isSitting);
				else FlagsHelper.Unset(ref _animalData, _isSitting);
			}
		}

		public bool IsTamed
		{
			get => FlagsHelper.IsSet(_animalData, _isTamed);
			set
			{
				if (value) FlagsHelper.Set(ref _animalData, _isTamed);
				else FlagsHelper.Unset(ref _animalData, _isTamed);
			}
		}
	}

	public enum CatType
	{
		Tabby = 0,
		Black = 1,
		Red = 2,
		Siamese = 3,
		BritishShorthair = 4,
		Calico = 5,
		Persian = 6,
		Ragdoll = 7,
		White = 8,
		AllBlack = 9
	}

	public class Cat : TameableAnimal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Type);
			MetaRegistry.Add(IsLying);
			MetaRegistry.Add(IsRelaxed);
			MetaRegistry.Add(CollarColor);
		}

		public EntityMetadata<VarInt> Type =
			new EntityMetadata<VarInt>
			{
				Index = 18,
				DefaultValue = 1
			};

		public EntityMetaBool IsLying =
			new EntityMetaBool
			{
				Index = 19,
				DefaultValue = false
			};

		public EntityMetaBool IsRelaxed =
			new EntityMetaBool
			{
				Index = 20,
				DefaultValue = false
			};

		public EntityMetadata<VarInt> CollarColor =
			new EntityMetadata<VarInt>
			{
				Index = 21,
				DefaultValue = 14
			};
	}

	public class Wolf : TameableAnimal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsBegging);
			MetaRegistry.Add(CollarColor);
			MetaRegistry.Add(AngerTime);
		}

		public EntityMetaBool IsBegging =
			new EntityMetaBool
			{
				Index = 18,
				DefaultValue = false
			};

		public EntityMetadata<VarInt> CollarColor =
			new EntityMetadata<VarInt>
			{
				Index = 19,
				DefaultValue = 14
			};

		public EntityMetadata<VarInt> AngerTime =
			new EntityMetadata<VarInt>
			{
				Index = 20,
				DefaultValue = 0
			};
	}

	public class Parrot : TameableAnimal
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Variant);
		}

		public EntityMetadata<VarInt> Variant =
			new EntityMetadata<VarInt>
			{
				Index = 18,
				DefaultValue = (int) ParrotType.RedBlue
			};

		public void SetType(ParrotType type)
		{
			Variant.Value = (int) type;
		}
	}

	public enum ParrotType
	{
		RedBlue = 0,
		Blue = 1,
		Green = 2,
		YellowBlue = 3,
		Grey = 4
	}

	public class AbstractVillager : AgeableMob
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(HeadShakeTimer);
		}

		/// <summary>
		/// Starts at 40, decrements each tick
		/// </summary>
		public EntityMetadata<VarInt> HeadShakeTimer =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};
	}

	public class Villager : AbstractVillager
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(VillagerData);
		}

		public EntityMetadata<VillagerData> VillagerData =
			new EntityMetadata<VillagerData>
			{
				Index = 17,
				DefaultValue = new VillagerData(VillagerType.Plains, VillagerJob.None, 1)
			};
	}

	public class VillagerData
	{
		public VillagerType Type { get; set; }
		public VillagerJob Job { get; set; }
		public VarInt Level { get; set; }

		public VillagerData(VillagerType type, VillagerJob job, VarInt level)
		{
			Type = type;
			Job = job;
			Level = level;
		}
	}

	public enum VillagerType
	{
		Desert = 0,
		Jungle = 1,
		Plains = 2,
		Savanna = 3,
		Snow = 4,
		Swamp = 5,
		Taiga = 6
	}

	public enum VillagerJob
	{
		None = 0,
		Armorer = 1,
		Butcher = 2,
		Cartographer = 3,
		Cleric = 4,
		Farmer = 5,
		Fisherman = 6,
		Fletcher = 7,
		Leatherworker = 8,
		Librarian = 9,
		Mason = 10,
		Nitwit = 11,
		Shephard = 12,
		Toolsmith = 13,
		Weaponsmith = 14
	}

	public class WanderingTrader : AbstractVillager
	{

	}

	public class AbstractGolem : PathfinderMob
	{

	}

	public class IronGolem : AbstractGolem
	{
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

	public class Shulker : AbstractGolem
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(AttachFace);
			MetaRegistry.Add(AttachmentPos);
			MetaRegistry.Add(ShieldHeight);
			MetaRegistry.Add(Color);
		}

		public EntityMetadata<Direction> AttachFace =
			new EntityMetadata<Direction>
			{
				Index = 15,
				DefaultValue = Direction.Down
			};

		public EntityMetadata<OptObject<Position>> AttachmentPos =
			new EntityMetadata<OptObject<Position>>
			{
				Index = 16,
				DefaultValue = new OptObject<Position>(false)
			};

		public EntityMetaByte ShieldHeight =
			new EntityMetaByte
			{
				Index = 17,
				DefaultValue = 0
			};

		public EntityMetaByte Color =
			new EntityMetaByte
			{
				Index = 18,
				DefaultValue = (byte) SheepColor.Purple
			};
	}

	public class Monster : PathfinderMob
	{

	}

	public class BasePiglin : Monster
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsImmuneToZombification);
		}

		public EntityMetaBool IsImmuneToZombification =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};
	}

	public class Piglin : BasePiglin
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsBaby);
			MetaRegistry.Add(IsChargingCrossbow);
			MetaRegistry.Add(IsDancing);
		}

		public EntityMetaBool IsBaby =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};

		public EntityMetaBool IsChargingCrossbow =
			new EntityMetaBool
			{
				Index = 17,
				DefaultValue = false
			};

		public EntityMetaBool IsDancing =
			new EntityMetaBool
			{
				Index = 18,
				DefaultValue = false
			};
	}

	public class PiglinBrute : BasePiglin
	{

	}

	public class Blaze : Monster
	{
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

	public class Creeper : Monster
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(State);
			MetaRegistry.Add(IsCharged);
			MetaRegistry.Add(IsIgnited);
		}

		/// <summary>
		/// -1 for idle and 1 for fuse
		/// </summary>
		public EntityMetadata<VarInt> State =
			new EntityMetadata<VarInt>
			{
				Index = 15,
				DefaultValue = -1
			};

		public EntityMetaBool IsCharged =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};

		public EntityMetaBool IsIgnited =
			new EntityMetaBool
			{
				Index = 17,
				DefaultValue = false
			};
	}

	public class Endermite : Monster
	{

	}

	public class Giant : Monster
	{

	}

	public class Guardian : Monster
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsRetractingSpikes);
			MetaRegistry.Add(TargetEID);
		}

		public EntityMetaBool IsRetractingSpikes =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};

		public EntityMetadata<VarInt> TargetEID =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};
	}

	public class ElderGuardian : Guardian
	{
	}

	public class Silverfish : Monster
	{
	}

	public class Raider : Monster
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsCelebrating);
		}

		public EntityMetaBool IsCelebrating =
			new EntityMetaBool
			{
				Index = 15, // Celebrate good times come on!
				DefaultValue = false
			};
	}

	public class AbstractIllager : Raider
	{

	}

	public class Vindicator : AbstractIllager
	{

	}

	public class Pillager : AbstractIllager
	{
	}

	public enum IllagerSpell
	{
		None = 0,
		SummonVex = 1,
		Attack = 2,
		Wololo = 3,
		Disappear = 4,
		Blindess = 5
	}

	public class SpellcasterIllager : AbstractIllager
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Spell);
		}

		public EntityMetaByte Spell =
			new EntityMetaByte
			{
				Index = 16,
				DefaultValue = (byte) IllagerSpell.None
			};
	}

	public class Evoker : SpellcasterIllager
	{}

	public class Illusioner : SpellcasterIllager
	{
	}

	public class Ravager : Raider
	{
	}

	public class Witch : Raider
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsDrinkingPotion);
		}

		public EntityMetaBool IsDrinkingPotion =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};
	}

	public class EvokerFangs : Entity
	{

	}

	public class Vex : Monster
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(VexAction);
		}

		private byte _vexAction = 0;
		private const byte _isAttacking = 0x01;

		public EntityMetaByte VexAction =>
			new EntityMetaByte
			{
				Index = 15,
				DefaultValue = 0,
				Value = _vexAction
			};

		public bool IsAttacking
		{
			get => FlagsHelper.IsSet(_vexAction, _isAttacking);
			set
			{
				if (value) FlagsHelper.Set(ref _vexAction, _isAttacking);
				else FlagsHelper.Unset(ref _vexAction, _isAttacking);
			}
		}
	}

	public class AbstractSkeleton : Monster
	{

	}

	public class Skeleton : AbstractSkeleton
	{
	}

	public class WitherSkeleton : AbstractSkeleton
	{
	}

	public class Stray : AbstractSkeleton
	{
	}

	public class Spider : Monster
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(SpiderAction);
		}

		private byte _spiderAction = 0;
		private const byte _isClimbing = 0x01;

		public EntityMetaByte SpiderAction =>
			new EntityMetaByte
			{
				Index = 15,
				DefaultValue = 0,
				Value = _spiderAction
			};

		public bool IsClimbing
		{
			get => FlagsHelper.IsSet(_spiderAction, _isClimbing);
			set
			{
				if (value) FlagsHelper.Set(ref _spiderAction, _isClimbing);
				else FlagsHelper.Unset(ref _spiderAction, _isClimbing);
			}
		}
	}

	public class Wither : Monster
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(CenterHeadTarget);
			MetaRegistry.Add(LeftHeadTarget);
			MetaRegistry.Add(RightHeadTarget);
			MetaRegistry.Add(InvulnerableTime);
		}

		public EntityMetadata<VarInt> CenterHeadTarget =
			new EntityMetadata<VarInt>
			{
				Index = 15,
				DefaultValue = 0
			};

		public EntityMetadata<VarInt> LeftHeadTarget =
			new EntityMetadata<VarInt>
			{
				Index = 16,
				DefaultValue = 0
			};

		public EntityMetadata<VarInt> RightHeadTarget =
			new EntityMetadata<VarInt>
			{
				Index = 17,
				DefaultValue = 0
			};

		public EntityMetadata<VarInt> InvulnerableTime =
			new EntityMetadata<VarInt>
			{
				Index = 18,
				DefaultValue = 0
			};
	}

	public class Zoglin : Monster
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsBaby);
		}

		public EntityMetaBool IsBaby =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};

	}

	public class Zombie : Monster // Like some of you in the morning
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsBaby);
			MetaRegistry.Add(IsBecomingDrowned);
		}

		public EntityMetaBool IsBaby =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};

		public EntityMetaBool IsBecomingDrowned =
			new EntityMetaBool
			{
				Index = 17,
				DefaultValue = false
			};
	}

	public class ZombieVillager : Zombie
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsConverting);
			MetaRegistry.Add(VillagerData);
		}

		public EntityMetaBool IsConverting =
			new EntityMetaBool
			{
				Index = 18,
				DefaultValue = false
			};

		public EntityMetadata<VillagerData> VillagerData =
			new EntityMetadata<VillagerData>
			{
				Index = 19,
				DefaultValue = new VillagerData(VillagerType.Plains, VillagerJob.None, 1)
			};
	}

	public class Husk : Zombie
	{
	}

	public class Drowned : Zombie
	{
	}

	public class ZombifiedPiglin : Zombie
	{
	}

	public class Enderman : Monster
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(CarriedBlock);
			MetaRegistry.Add(IsScreaming);
			MetaRegistry.Add(IsStaring);
		}

		public EntityMetadata<OptObject<VarInt>> CarriedBlock =
			new EntityMetadata<OptObject<VarInt>>
			{
				Index = 15,
				DefaultValue = new OptObject<VarInt>(false)
			};

		public EntityMetaBool IsScreaming =
			new EntityMetaBool
			{
				Index = 16,
				DefaultValue = false
			};

		public EntityMetaBool IsStaring =
			new EntityMetaBool
			{
				Index = 17,
				DefaultValue = false
			};
	}

	public enum DragonPhase
	{
		Circling = 0,
		Strafing = 1, // Preparing to shoot a fireball
		FlyingToThePortalToLand = 2, // Part of transition to landed state
		LandingOnPortal = 3,
		TakingOffFromPortal = 4,
		LandedBreathAttack = 5,
		LandedLookingForPlayer = 6,
		LandedRoar = 7,
		ChargingPlayer = 8,
		FlyingToPortalToDie = 9,
		HoveringNoAI = 10 // Default when using the /summon command
	}

	public class EnderDragon : Mob
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(DragonPhase);
		}

		public EntityMetadata<VarInt> DragonPhase =
			new EntityMetadata<VarInt>
			{
				Index = 15,
				DefaultValue = (int) Entities.DragonPhase.HoveringNoAI
			};
	}

	public class Flying : Monster
	{
	}

	public class Ghast : Flying
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(IsAttacking);
		}

		public EntityMetaBool IsAttacking =
			new EntityMetaBool
			{
				Index = 15,
				DefaultValue = false
			};
	}

	public class Phantom : Flying
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Size);
		}

		/// <summary>
		/// Hitbox size is determined by horizontal = 0.9 + 0.2 * size and vertical = 0.5 + 0.1 * i
		/// </summary>
		public EntityMetadata<VarInt> Size =
			new EntityMetadata<VarInt>
			{
				Index = 15,
				DefaultValue = 0
			};
	}

	public class Slime : Mob
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Size);
		}

		public EntityMetadata<VarInt> Size =
			new EntityMetadata<VarInt>
			{
				Index = 15,
				DefaultValue = 1
			};
	}

	#endregion

	public class LlamaSpit : Entity
	{
	} // Why tf?

	public class AbstractMinecart : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(ShakingPower);
			MetaRegistry.Add(ShakingDirection);
			MetaRegistry.Add(ShakingMultiplier);
			MetaRegistry.Add(CustomBlockIDAndDamage);
			MetaRegistry.Add(BlockYPos);
			MetaRegistry.Add(ShowCustomBlock);
		}

		public EntityMetadata<VarInt> ShakingPower =
			new EntityMetadata<VarInt>
			{
				Index = 7,
				DefaultValue = 0
			};

		public EntityMetadata<VarInt> ShakingDirection =
			new EntityMetadata<VarInt>
			{
				Index = 8,
				DefaultValue = 1
			};

		public EntityMetaFloat ShakingMultiplier =
			new EntityMetaFloat
			{
				Index = 9,
				DefaultValue = 0.0f
			};

		public EntityMetadata<VarInt> CustomBlockIDAndDamage =
			new EntityMetadata<VarInt>
			{
				Index = 10,
				DefaultValue = 0
			};

		/// <summary>
		/// Custom Y POS (in 16ths of a block)
		/// </summary>
		public EntityMetadata<VarInt> BlockYPos =
			new EntityMetadata<VarInt>
			{
				Index = 11,
				DefaultValue = 6
			};

		public EntityMetaBool ShowCustomBlock =
			new EntityMetaBool
			{
				Index = 12,
				DefaultValue = false
			};
	}

	public class Minecart : AbstractMinecart
	{
	}

	public class AbstractMinecartContainer : AbstractMinecart
	{
	}

	public class MinecartHopper : AbstractMinecartContainer
	{
	}

	public class MinecartCheset : AbstractMinecartContainer
	{
	}

	public class MinecartFurnace : AbstractMinecart
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(HasFuel);
		}

		public EntityMetaBool HasFuel =
			new EntityMetaBool
			{
				Index = 13,
				DefaultValue = false
			};
	}

	public class MinecartWithExplosive : AbstractMinecart
	{
	}

	public class MinecartSpawner : AbstractMinecart
	{
	}

	public class MinecartCommandBlock : AbstractMinecart
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Command);
			MetaRegistry.Add(LastOutput);
		}

		public EntityMetadata<string> Command =
			new EntityMetadata<string>
			{
				Index = 13,
				DefaultValue = ""
			};

		public EntityMetadata<ChatBuilder> LastOutput =
			new EntityMetadata<ChatBuilder>
			{
				Index = 14,
				DefaultValue = ChatMessage.BlankMessage
			};
	}

	public class PrimedExplosive : Entity
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(FuseTime);
		}

		public EntityMetadata<VarInt> FuseTime =
			new EntityMetadata<VarInt>
			{
				Index = 7,
				DefaultValue = 80
			};
	}
}

