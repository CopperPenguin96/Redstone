using MinecraftTypes;

namespace Redstone.Players
{
    public class Inventory
    {
        public string PlayerUniqueId { get; set; }

        public string WorldUniqueId { get; set; }

        public Slot[] Slots { get; set; }

    }
}
