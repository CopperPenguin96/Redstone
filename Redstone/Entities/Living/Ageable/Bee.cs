using Redstone.Entities.Living.Mobs;
using Redstone.Types;
using Redstone.Utils;

namespace Redstone.Entities.Living.Ageable
{
    public class Bee : Animal
    {
        private byte _beeFlags = 0;

        public bool IsAngry
        {
            get => FlagsHelper.IsSet(_beeFlags, (byte) BeeFlag.Angry);
            set
            {
                if (value) FlagsHelper.Set(ref _beeFlags, (byte) BeeFlag.Angry);
                else FlagsHelper.Unset(ref _beeFlags, (byte) BeeFlag.Angry);
            }
        }

        public bool HasStung
        {
            get => FlagsHelper.IsSet(_beeFlags, (byte) BeeFlag.Stung);
            set
            {
                if (value) FlagsHelper.Set(ref _beeFlags, (byte) BeeFlag.Stung);
                else FlagsHelper.Unset(ref _beeFlags, (byte) BeeFlag.Stung);
            }
        }

        public bool HasNectar
        {
            get => FlagsHelper.IsSet(_beeFlags, (byte) BeeFlag.Nectar);
            set
            {
                if (value) FlagsHelper.Set(ref _beeFlags, (byte) BeeFlag.Nectar);
                else FlagsHelper.Unset(ref _beeFlags, (byte) BeeFlag.Nectar);
            }
        }

        public VarInt AngerTimeTicks { get; set; } = 0;
    }
}
