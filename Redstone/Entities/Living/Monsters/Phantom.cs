using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Monsters
{
    public class Phantom : Flying
    {
        public VarInt Size { get; set; } = 0;
    }
}
