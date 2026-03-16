using Redstone.Core.Types;

namespace Redstone.World
{
    public class ChunkSection
    {
        public sbyte Y { get; }
        public List<Block> Palette { get; } = new();
        public ushort[] BlockIndices { get; } = new ushort[4096]; // 16x16x16

        public ChunkSection(sbyte y)
        {
            Y = y;
            // Every section needs air at index 0
            Palette.Add(new Block(new Identifier("minecraft:air")));
        }

        public void SetBlock(int x, int y, int z, Block block)
        {
            // Block coordinate to index (0-4095)
            int index = (y << 8) | (z << 4) | x;

            // Find or add to palette
            int paletteIndex = Palette.IndexOf(block);
            if (paletteIndex == -1)
            {
                paletteIndex = Palette.Count;
                Palette.Add(block);
            }

            BlockIndices[index] = (ushort)paletteIndex;
        }
    }
}