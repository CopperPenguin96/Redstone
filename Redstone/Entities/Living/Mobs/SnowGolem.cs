using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Utils;

namespace Redstone.Entities.Living.Mobs
{
    public class SnowGolem : AbstractGolem
    {
        private byte _hat = 0x10;

        public bool HasPumpkinHat
        {
            get => FlagsHelper.IsSet(_hat, (byte) SnowGolemFlag.HasHat);
            set
            {
                if (value) FlagsHelper.Set(ref _hat, (byte) SnowGolemFlag.HasHat);
                else FlagsHelper.Unset(ref _hat, (byte) SnowGolemFlag.HasHat);
            }
        }
    }

    public enum SnowGolemFlag : byte
    {
        NoHat = 0x00,
        HasHat = 0x10
    }
}
