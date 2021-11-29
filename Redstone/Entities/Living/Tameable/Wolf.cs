using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Tameable
{
    public class Wolf : TameableAnimal
    {
        public bool IsBegging { get; set; }

        public VarInt CollarColor { get; set; } = 14;

        public VarInt AngerTime { get; set; } = 0;
    }
}
