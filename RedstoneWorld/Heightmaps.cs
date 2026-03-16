using Redstone.Nbt;
using Redstone.Nbt.Tags;

namespace Redstone.World
{
    internal class Heightmaps(int minY) : ITagProvider
    {
        private readonly Dictionary<string, long[]> _packedHeightData = [];

        public int[,] MotionBlockHeights { get; private set; } = new int[16, 16];

        public void EncodeAndPack(int[] rawYValues, string mapName)
        {
            long[] packed = Pack(rawYValues, 9);
            _packedHeightData[mapName] = packed;
        }

        private const int TotalHeightmapEntries = 256;
        public static long[] Pack(int[] rawValues, int bitsPerEntry)
        {
            if (rawValues.Length != TotalHeightmapEntries)
            {
                throw new ArgumentException($"Expected {TotalHeightmapEntries} values.", nameof(rawValues));
            }

            // Calculate total bits needed and the final size of the long array
            long totalBits = (long)TotalHeightmapEntries * bitsPerEntry;
            int numLongs = (int)Math.Ceiling((double)totalBits / 64.0);

            long[] packedArray = new long[numLongs];

            long currentLong = 0;
            int currentLongIndex = 0;
            int currentBitOffset = 0;

            long valueMask = (1L << bitsPerEntry) - 1;

            foreach (int rawValue in rawValues)
            {
                long maskedValue = (long)rawValue & valueMask;

                packedArray[currentLongIndex] |= (maskedValue << currentBitOffset);
                currentBitOffset += bitsPerEntry;

                if (currentBitOffset >= 64)
                {
                    int bitsOverflow = currentBitOffset - 64;

                    currentLongIndex++;

                    if (currentLongIndex < numLongs)
                    {
                        packedArray[currentLongIndex] |= (maskedValue >> (bitsPerEntry - bitsOverflow));
                    }

                    currentBitOffset = bitsOverflow;
                }
            }

            return packedArray;
        }

        public string NbtString()
        {
            return Nbt.ToString()!;
        }

        public NbtTag Nbt
        {
            get
            {
                var rootTag = new CompoundTag("Heightmaps");

                foreach (var kvp in _packedHeightData)
                {
                    rootTag.Add(new LongArrayTag(kvp.Key, kvp.Value));
                }

                return rootTag;
            }
        }
    }
}
