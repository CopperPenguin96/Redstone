using Redstone.Nbt.Tags;

namespace Redstone.World
{
    public class ChunkData
    {
        public int X { get; }
        public int Z { get; }

        public ChunkSection[] Sections { get; } = new ChunkSection[24];

        public ChunkData(int x, int z)
        {
            X = x;
            Z = z;
            for (int i = 0; i < Sections.Length; i++)
            {
                Sections[i] = new ChunkSection((sbyte)(i - 4));
            }
        }

        public CompoundTag Serialize()
        {
            CompoundTag root = new("")
            {
                new IntTag("xPos", X),
                new IntTag("zPos", Z),
                new IntTag("yPos", -4)
            };

            ListTag sectionsList = new("sections", TagType.Compound);

            foreach (var section in Sections)
            {
                if (section == null) continue;

                CompoundTag sTag = new("");
                sTag.Add(new ByteTag("Y", (byte)section.Y));

                // Container for palette and data
                CompoundTag blockStates = new("block_states");

                // Create the Palette
                ListTag paletteTag = new("palette", TagType.Compound);
                foreach (var block in section.Palette)
                {
                    CompoundTag bEntry = new("");
                    bEntry.Add(new StringTag("Name", block.Identifier.ToString()));

                    if (block.States.Count > 0)
                    {
                        CompoundTag props = new("Properties");
                        foreach (var state in block.States)
                            props.Add(new StringTag(state.Key, state.Value));
                        bEntry.Add(props);
                    }
                    paletteTag.Add(bEntry);
                }

                blockStates.Add(paletteTag);

                blockStates.Add(new LongArrayTag("data", []));

                sTag.Add(blockStates);
                sectionsList.Add(sTag);
            }

            root.Add(sectionsList);
            return root;
        }
    }
}