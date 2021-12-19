using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds.Dimensions
{
    public abstract class FlatDimension : IDimension
    {
        public Identifier Type { get; set; }

        public Identifier Id => "flat";
        
        public List<SuperflatLayer> Layers { get; set; }

        public Biome Biome { get; set; }

        public bool Lakes { get; set; }

        public bool Features { get; set; }

        public string BiomeSourceType { get; set; }
    }

}