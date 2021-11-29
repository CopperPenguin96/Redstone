using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Mobs
{
    public class Dolphin : WaterAnimal
    {
        public Position TreasurePos { get; set; } = new(0, 0, 0);

        public bool CanFindTreasure { get; set; } = false;

        public bool HasFish { get; set; } = false;
    }
}
