using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Utils;

namespace Redstone.Entities.Living.Monsters
{
    public class Vex : Monster
    {
        private byte _vex = 0;

        public bool IsAttacking
        {
            get => FlagsHelper.IsSet(_vex, (byte) VexFlag.Attacking);
            set
            {
                if (value) FlagsHelper.Set(ref _vex, (byte) VexFlag.Attacking);
                else FlagsHelper.Unset(ref _vex, (byte) VexFlag.Attacking);
            }
        }
    }

    public enum VexFlag
    {
        Attacking = 0x01
    }
}
