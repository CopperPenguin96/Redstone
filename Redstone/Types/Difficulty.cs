namespace Redstone.Types
{
    /// <summary>
    /// Minecraft's difficulty levels.
    /// </summary>
    public enum Difficulty : byte
    {
        /// <summary>
        /// Safest and easiest mode. There are no hostile mobs, with the
        /// exception of the Ender Dragon. Damage only comes from the
        /// physical world. Food is not required.
        /// </summary>
        Peaceful = 0,

        /// <summary>
        /// Easy mode has mobs. Food is depleted, however you don't die from
        /// starvation.
        /// </summary>
        Easy = 1,

        /// <summary>
        /// The standard mode of Minecraft. Damage is harder. Still cannot
        /// die from starvation.
        /// </summary>
        Normal = 2,

        /// <summary>
        /// The hardest mode of Minecraft. You may die from starvation and
        /// mobs are the hardest.
        /// </summary>
        Hard = 3
    }
}
