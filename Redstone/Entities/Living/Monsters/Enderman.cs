using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Monsters
{
    public class Enderman : Monster
    {
        public OptObject<VarInt> CarriedBlock { get; set; }

        public bool IsScreaming { get; set; } = false;

        public bool IsStaring { get; set; } = false;
    }
}
