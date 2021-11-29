using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Utils;

namespace Redstone.Entities.Living.Mobs
{
    public class IronGolem : AbstractGolem
    {
        private byte _iron = 0;

        public bool IsPlayerCreated
        {
            get => FlagsHelper.IsSet(_iron, (byte) IronGolemFlag.PlayerCreated);
            set
            {
                if (value) FlagsHelper.Set(ref _iron, (byte) IronGolemFlag.PlayerCreated);
                else FlagsHelper.Unset(ref _iron, (byte) IronGolemFlag.PlayerCreated);
            }
        }
    }

    public enum IronGolemFlag : byte
    {
        PlayerCreated = 0x01
    }
}
