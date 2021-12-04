using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Worlds
{
    public abstract class Block
    {
        public VarInt State { get; set; }

        public World World { get; set; }

        public Position Position { get; set; }

        public virtual string Name { get; set; }

        public virtual int Type { get; set; }

        public virtual int Meta { get; set; }

        public virtual Identifier Id { get; set; }
    }
}
