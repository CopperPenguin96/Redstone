using Redstone.Core.Types;

namespace Redstone.World
{
    public static class BlockRegistry
    {
        private static readonly Dictionary<Identifier, Block> _blocksById = new();
        private static readonly Dictionary<int, Block> _blocksByLegacy = new();

        public static void Register(Block block)
        {
            _blocksById[block.Identifier] = block;

            // Map legacy ID (Shifted 4 bits to include meta)
            // This is how old Minecraft versions handled block states
            int globalLegacy = (block.LegacyId << 4) | (block.LegacyData & 15);
            _blocksByLegacy[globalLegacy] = block;
        }

        public static Block Get(Identifier id) => _blocksById.GetValueOrDefault(id, _blocksById["minecraft:air"]);

        public static Block GetLegacy(int id, byte meta) =>
            _blocksByLegacy.GetValueOrDefault((id << 4) | (meta & 15), _blocksByLegacy[0]);
    }
}