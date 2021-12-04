using Redstone.Types;

namespace Redstone.Worlds.Blocks
{
    public class IronBlock : Block
    {
        public override string Name => "Block of Iron";

        public override Identifier Id => "iron_block";

        public override int Type => 42;

        public override int Meta => 0;
    }
}
