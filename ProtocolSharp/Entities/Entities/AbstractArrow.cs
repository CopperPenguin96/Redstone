using fNbt;
using ProtocolSharp.Utils;
using ProtocolSharp.Worlds.Blocks;

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

		public ArrowPickup ArrowPickupRule { get; set; }

		public byte Shake { get; set; }

		public short Life { get; set; }

		public double Damage { get; set; }

		private bool _cross;
		public bool ShotFromCrossbow
		{
			get => !OnGround && _cross;
			set => _cross = value;
		}

		public string SoundEvent { get; set; }

		public Block BlockStuckIn { get; set; }
		
		public override NbtCompound Nbt
		{
			get
			{
				NbtCompound bs = base.Nbt;
				
				bs.Add(new NbtByte("pickup", (byte) ArrowPickupRule));
				bs.Add(new NbtByte("shake", Shake));
				bs.Add(new NbtShort("life", Life));
				bs.Add(new NbtDouble("damage", Damage));
				bs.Add(new NbtByte("inGround", OnGround.ToByte()));
				bs.Add(new NbtByte("crit", IsCritical.ToByte()));
				bs.Add(new NbtByte("ShotFromCrossbow", ShotFromCrossbow.ToByte()));
				bs.Add(new NbtByte("PierceLevel", PiercingLevel.Value));
				bs.Add(new NbtString("SoundEvent", SoundEvent));

				NbtCompound inBlockState = new NbtCompound("inBlockState");
				inBlockState.Add(new NbtString("Name", BlockStuckIn.Id.ToString()));
				
				return bs;
			}
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

	public enum ArrowPickup : byte
	{
		/// <summary>
		/// When set, cannot be picked up by players
		/// </summary>
		NotAllowed = 0,

		/// <summary>
		/// When set, can be picked up by players in survival or creative
		/// </summary>
		Allowed = 1,

		/// <summary>
		/// When set, can be picked up by players ONLY in survival
		/// </summary>
		OnlyCreative = 2
	}
}