using Redstone.Types;

namespace Redstone.Entities.Living.Ageable
{
    public class Pig : Animal
    {
        public bool HasSaddle { get; set; } = false;

        /// <summary>
        /// Total time to boost with a carrot on a stick for
        /// </summary>
        public VarInt TimeToBoost { get; set; } = 0;
    }
}
