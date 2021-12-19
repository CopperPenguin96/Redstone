using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Worlds
{
    public class SuperflatLayer
    {
        /// <summary>
        /// The number of blocks in the layer
        /// </summary>
        public int Height { get; set; }

        public Block Block { get; set; }

        public StrongholdSettings StrongholdSettings { get; set; }

        public List<Structure> Structures { get; set; }
    }
}
