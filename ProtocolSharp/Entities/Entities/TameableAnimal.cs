using ProtocolSharp.Types;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Entities.Entities
{
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
}