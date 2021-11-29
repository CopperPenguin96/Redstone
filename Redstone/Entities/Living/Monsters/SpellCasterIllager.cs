using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Entities.Living.Monsters
{
    public class SpellCasterIllager : AbstractIllager
    {
        public IllagerSpell Spell { get; set; } = 0;
    }

    public enum IllagerSpell : byte
    {
        None = 0,
        SummonVex = 1,
        Attack = 2,
        Wololo = 3,
        Disappear = 4,
        Blindness = 5
    }
}
