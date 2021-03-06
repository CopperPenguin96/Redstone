﻿using System.Linq;
using fNbt;
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
		/// <summary>
		/// Basic Entity object
		/// </summary>
		public static readonly Entity Basic = new Entity();

		/// <summary>
		/// Registry for all Entity Metadata
		/// </summary>
		public MetaRegistry MetaRegistry = new MetaRegistry();

		/// <summary>
		/// Entity ID
		/// </summary>
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

		public Position Velocity { get; set; }

		public virtual int Data { get; set; }

		/// <summary>
		/// Distance the entity has fallen. Larger values cause more damage when the entity lands
		/// </summary>
		public float FallDistance { get; set; }

		/// <summary>
		/// Number of ticks before the fire is put out. Negative values reflect how long the
		/// entity can stand in fire before burning. Default -20 when not on fire
		/// </summary>
		public short FireTicks { get; set; } = -20;

		public bool OnGround { get; set; }

		public virtual bool Invulnerable { get; set; }

		public int PortalCooldown { get; set; } = 300;

		public Entity Rider { get; set; }

		public NbtList ScoreboardTags { get; set; }

		private NbtCompound _nbt = new NbtCompound();
		public virtual NbtCompound Nbt
		{
			get
			{
				_nbt = new NbtCompound
				{
					new NbtString("id", EID.Value.ToString()),
					new NbtList("Pos",
						new []
						{
							new NbtDouble("X", Position.X), 
							new NbtDouble("Y", Position.Y),
							new NbtDouble("Z", Position.Z)
						}),
					new NbtList("Motion",
						new []
						{
							new NbtDouble("dX", Velocity.X),
							new NbtDouble("dY", Velocity.Y),
							new NbtDouble("dZ", Velocity.Z)
						}),
					new NbtList("Rotation",
						new[]
						{
							new NbtFloat("yaw", Position.Yaw),
							new NbtFloat("pitch", Position.Pitch)
						}),
					new NbtFloat("FallDistance", FallDistance),
					new NbtShort("Fire", FireTicks),
					new NbtShort("Air", (short) AirTicks.Value.Value),
					new NbtByte("OnGround", OnGround.ToByte()),
					new NbtByte("NoGravity", HasNoGravity.Value.ToByte()),
					new NbtByte("Invulnerable", Invulnerable.ToByte()),
					new NbtIntArray("UUID", UniqueID.Get()),
					new NbtByte("Silent", IsSilent.Value.ToByte()),
					new NbtByte("Glowing", HasGlowingEffect.ToByte()),
					ScoreboardTags
				};

				if (CustomNameVisible())
				{
					_nbt.Add(new NbtString("CustomName",
						CustomName.Value.Chat.FullObject.ToString()));
					_nbt.Add(new NbtByte("CustomNameVisible", 1));
				}
				else
				{
					_nbt.Add(new NbtByte("CustomNameVisible", 0));
				}

				if (Rider != null)
				{
					NbtList riderData = new NbtList("Passengers");
					foreach (NbtTag tag in Rider.Nbt)
					{
						riderData.Add(tag);
					}

					_nbt.Add(riderData);
				}

				return _nbt;
			}
		}

		public bool HasSpecialUsePacket()
		{
			EntityType[] types =
			{
				EntityType.ExperienceOrb, EntityType.Painting,
				EntityType.PrimedExplosive, EntityType.Player
			};

			return types.Contains(Type);
		}

		public Entity()
		{
			UniqueID = new JavaUUID();
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