using Redstone.Types;

namespace Redstone.Entities.Living.Ageable
{
    public class Mooshroom : Cow
    {
        public override string Name => "Mooshroom";
        
        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.9, 1.4, 0.9);

        public override Identifier Identifier => new("mooshroom");

        public string Variant { get; set; } = "red";
    }
}
