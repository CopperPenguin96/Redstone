using Redstone.Types;

namespace Redstone.Entities.Living.Ageable
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
