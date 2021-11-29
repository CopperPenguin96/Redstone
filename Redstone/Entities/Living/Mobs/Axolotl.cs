using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Entities.Living.Mobs
{
    public class Axolotl : Animal // This legit sounds like when I stuff a hot pizza roll in my mouth
    {
        public AxolotlVariant Variant { get; set; } = 0;

        public bool IsPlayingDead { get; set; } = false;

        public bool IsSpawnedFromBucket { get; set; } = false;
    }

    public enum AxolotlVariant
    {
        Lucy = 0,
        Wild = 1,
        Gold = 2,
        Cyan = 3,
        Blue = 4
    }
}
