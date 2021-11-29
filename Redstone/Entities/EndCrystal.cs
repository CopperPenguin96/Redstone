using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities
{
    public class EndCrystal : Entity
    {
        public OptBlockPos BeamTarget { get; set; } = new(false);

        public bool ShowBottom { get; set; } = true;
    }
}
