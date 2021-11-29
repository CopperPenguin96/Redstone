using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Monsters
{
    public class Wither : Monster
    {
        public VarInt CenterHeadTarget { get; set; } = 0;

        public VarInt LeftHeadTarget { get; set; } = 0;

        public VarInt RightHeadTarget { get; set; } = 0;

        public VarInt InvulnerableTime { get; set; } = 0;
    }
}
