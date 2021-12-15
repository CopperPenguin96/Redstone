using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds
{
    /// <summary>
    /// Object used for "End" worlds
    /// </summary>
    public class TheEnd : World
    {
        public Position ExitPortalLocation { get; set; }

        private List<int> Gateways { get; set; }

        public bool DragonKilled { get; set; }

        public string DragonUuid { get; set; }

        public bool PreviouslyKilled { get; set; }
    }
}
