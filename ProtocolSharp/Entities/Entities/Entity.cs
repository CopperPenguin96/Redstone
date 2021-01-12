using ProtocolSharp.Chat;
using ProtocolSharp.Types;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Entities.Entities
{
	/// <summary>
	/// Base entity
	/// </summary>
	public class Entity : IEntity
	{
		public MetaRegistry MetaRegistry = new MetaRegistry();

		public VarInt EID { get; set; }

		public JavaUUID UniqueID { get; internal set; }

		/// <summary>
		/// Same value as z
		/// </summary>
		public virtual float BoundingBoxX { get; set; }

		public virtual float BoundingBoxY { get; set; }

		public virtual bool UseWithSpawnObject { get; set; }

		public virtual Identifier ID { get; set; }

		public virtual EntityType Type { get; set; }

		public Position Position { get; set; }

		public Entity()
		{
			UniqueID = new JavaUUID(ID.ToString());
		}

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
}