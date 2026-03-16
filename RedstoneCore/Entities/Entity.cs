using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Core.Entities
{
    public class Entity
    {
        public byte Index { get; internal set; }

        public void WriteMetadataToStream(ref Stream stream)
        {

        }
    }
}
