using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Worlds.Generators
{
    public abstract class Generator
    {
        public World World { get; set; }

        public abstract void Generate(string name, long seed);
    }
}
