using ProtocolSharp.Utils;

namespace ProtocolSharp.Entities.Entities
{
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
}