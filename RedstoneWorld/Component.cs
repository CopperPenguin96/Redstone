using Redstone.Core.Types;

namespace Redstone.World
{
    public sealed class Component
    {
        public int Type { get; set; }

        public Identifier Identifier { get; set; }

        public object[] Data { get; set; } = Array.Empty<object>();

        public Component(int type)
        {
            Type = type;
            Identifier = SlotData.CompDefinitions[type];
        }
    }
}
