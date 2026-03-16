using System.Collections;

namespace Redstone.Core.Utils
{
    public static class NetUtils
    {
        /// <summary>
        /// Converts a BitArray (like your Light Masks) into a long array 
        /// formatted for the Minecraft Packet BitSet.
        /// </summary>
        public static long[] ToProtocolBitSet(BitArray bits)
        {
            // Calculate how many 64-bit longs we need to hold the bits
            int longCount = (bits.Count + 63) / 64;
            long[] longs = new long[longCount];

            for (int i = 0; i < bits.Count; i++)
            {
                if (bits.Get(i))
                {
                    // Set the specific bit within the specific long
                    longs[i / 64] |= (1L << (i % 64));
                }
            }
            return longs;
        }
    }
}