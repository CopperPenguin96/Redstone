using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Utils;

namespace Redstone.Entities.Living.Monsters
{
    public class Spider : Monster
    {
        private byte _spider = 0;

        public bool IsClimbing
        {
            get => FlagsHelper.IsSet(_spider, (byte) SpiderFlag.Climbing);
            set
            {
                if (value) FlagsHelper.Set(ref _spider, (byte) SpiderFlag.Climbing);
                else FlagsHelper.Unset(ref _spider, (byte) SpiderFlag.Climbing);
            }
        }
    }

    public enum SpiderFlag : byte
    {
        Climbing = 0x01
    }
}
