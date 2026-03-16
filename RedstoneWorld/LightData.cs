using System.Collections;

namespace Redstone.World
{
    public class LightData
    {
        // 26 sections (24 world sections + 2 for neighbors)
        private const int TotalSections = 26;
        private const int ArraySize = 2048; // (16x16x16) / 2

        // The raw light data stored in nibble arrays
        public byte[][] SkyLightArrays { get; } = new byte[TotalSections][];
        public byte[][] BlockLightArrays { get; } = new byte[TotalSections][];

        // Masks used by the Packet 0x27 (Chunk Data and Update Light)
        public BitArray SkyLightMask { get; } = new BitArray(TotalSections);
        public BitArray BlockLightMask { get; } = new BitArray(TotalSections);
        public BitArray EmptySkyLightMask { get; } = new BitArray(TotalSections);
        public BitArray EmptyBlockLightMask { get; } = new BitArray(TotalSections);

        public LightData()
        {
            // Initialize masks. By default, assume everything is empty/dark.
            EmptySkyLightMask.SetAll(true);
            EmptyBlockLightMask.SetAll(true);
        }

        public void SetLight(int sectionIndex, int x, int y, int z, byte level, bool isSkyLight)
        {
            byte[][] targetArrays = isSkyLight ? SkyLightArrays : BlockLightArrays;
            BitArray mask = isSkyLight ? SkyLightMask : BlockLightMask;
            BitArray emptyMask = isSkyLight ? EmptySkyLightMask : EmptyBlockLightMask;

            // Initialize the array if it's the first time light is entering this section
            if (targetArrays[sectionIndex] == null)
            {
                targetArrays[sectionIndex] = new byte[ArraySize];
                mask.Set(sectionIndex, true);
                emptyMask.Set(sectionIndex, false);
            }

            int blockIndex = (y << 8) | (z << 4) | x;
            int byteIndex = blockIndex >> 1;
            level &= 0x0F; // Clamp to 4 bits

            if ((blockIndex & 1) == 0) // Even index
            {
                targetArrays[sectionIndex][byteIndex] = (byte)((targetArrays[sectionIndex][byteIndex] & 0xF0) | level);
            }
            else // Odd index
            {
                targetArrays[sectionIndex][byteIndex] = (byte)((targetArrays[sectionIndex][byteIndex] & 0x0F) | (level << 4));
            }
        }

        public byte GetLight(int sectionIndex, int x, int y, int z, bool isSkyLight)
        {
            byte[][] targetArrays = isSkyLight ? SkyLightArrays : BlockLightArrays;
            if (targetArrays[sectionIndex] == null) return 0;

            int blockIndex = (y << 8) | (z << 4) | x;
            int byteIndex = blockIndex >> 1;
            byte b = targetArrays[sectionIndex][byteIndex];

            return (byte)((blockIndex & 1) == 0 ? (b & 0x0F) : ((b >> 4) & 0x0F));
        }

        public long[] GetMaskAsLongArray(BitArray mask)
        {
            // Minecraft packets expect BitSets to be sent as an array of longs.
            // Since we only have 26-28 sections, it will usually fit in 1 long (64 bits).
            int longCount = (mask.Length + 63) / 64;
            long[] result = new long[longCount];
            mask.CopyTo(result, 0);
            return result;
        }
    }
}