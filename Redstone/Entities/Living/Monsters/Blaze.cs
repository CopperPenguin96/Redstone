using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Utils;

namespace Redstone.Entities.Living.Monsters
{
    public class Blaze : Monster
    {
        private byte _blaze;

        public bool IsOnFire
        {
            get => FlagsHelper.IsSet(_blaze, (byte) BlazeFlag.OnFire);
            set
            {
                if (value) FlagsHelper.Set(ref _blaze, (byte) BlazeFlag.OnFire);
                else FlagsHelper.Unset(ref _blaze, (byte) BlazeFlag.OnFire);
            }
        }
    }

    public enum BlazeFlag
    {
        OnFire = 0x01
    }
}
