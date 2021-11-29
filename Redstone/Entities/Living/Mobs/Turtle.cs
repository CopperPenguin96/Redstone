using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Mobs
{
    public class Turtle : Animal
    {
        public Position HomePos { get; set; } = new(0, 0, 0);

        public bool HasEgg { get; set; } = false;

        public bool IsLayingEgg { get; set; } = false;

        public Position TravelPos { get; set; } = new(0, 0, 0);

        public bool IsGoingHome { get; set; } = false;

        public bool IsTraveling { get; set; } = false;
    }
}
