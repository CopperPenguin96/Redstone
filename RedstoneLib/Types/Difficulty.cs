namespace Redstone.Types
{
    /// <summary>
    /// Difficulty setting of Minecraft
    /// </summary>
    public enum Difficulty : byte
    {
        /// <summary>
        /// The easiest of all the difficulties.
        /// Hunger does not deplete, and there are no monsters.
        /// Death can still happen by natural causes.
        /// Health regenerates.
        /// </summary>
        Peaceful = 0,

        /// <summary>
        /// Hunger slowly depletes, and monsters are easiest.
        /// Health does not regenerate.
        /// </summary>
        Easy = 1,

        /// <summary>
        /// Slightly more difficult, plus monsters have armor.
        /// </summary>
        Normal = 2,

        /// <summary>
        /// The hardest. You will not survive.
        /// </summary>
        Hard = 3,
    }
}
