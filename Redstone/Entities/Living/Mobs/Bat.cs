using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Utils;

namespace Redstone.Entities.Living.Mobs
{
    public class Bat : AmbientCreature
    {
        private byte _hanging = 0;
        public bool IsHanging
        {
            get => FlagsHelper.IsSet(_hanging, (byte) BatFlag.IsHanging);
            set
            {
                if (value) FlagsHelper.Set(ref _hanging, (byte) BatFlag.IsHanging);
                else FlagsHelper.Unset(ref _hanging, (byte) BatFlag.IsHanging);
            }
        }
    }
}
