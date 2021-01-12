using ProtocolSharp.Utils;

namespace ProtocolSharp.Entities.Entities
{
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
}