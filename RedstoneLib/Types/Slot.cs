namespace Redstone.Types
{
    public class Slot
    {
        /// <summary>
        /// True if there is an item in this position, false if empty
        /// </summary>
        public bool IsPresent { get; set; }

        /// <summary>
        /// The Item's ID
        /// </summary>
        public OptVarInt ItemID { get; set; }

        /// <summary>
        /// Size of the stack
        /// </summary>
        public OptByte ItemCount { get; set; }

        
    }
}
