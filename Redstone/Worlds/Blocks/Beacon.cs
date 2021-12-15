using Redstone.ChatSystem;
using Redstone.Types;

namespace Redstone.Worlds.Blocks
{
    public class Beacon : Block
    {
        public override string Name => "Beacon";

        public override Identifier Id => "beacon";

        public override int Type => 138;

        public override int Meta => 0;

        private string _customName;

        public string CustomName
        {
            get => Chat.Format(_customName, null);
            set => _customName = value;
        }

        public string Lock { get; set; }

        public int Levels { get; set; }

        public int Primary { get; set; }

        public int Secondary { get; set; }

    }
}
