using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Entities.Living.Monsters
{
    public class Piglin : BasePiglin
    {
        public bool IsBaby { get; set; } = false;

        public bool IsChargingCrossbow { get; set; } = false;

        public bool IsDancing { get; set; } = false;
    }
}
