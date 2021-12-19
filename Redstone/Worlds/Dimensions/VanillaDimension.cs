using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Worlds.Dimensions
{
    public class VanillaDimension : NoiseDimension
    {
        public override string BiomeSourceType => BiomeSourceTypes.VanillaLayered;

        public bool LargeBiomes { get; set; }
    }
}
