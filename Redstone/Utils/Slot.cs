using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;
using SmartNbt.Tags;

namespace Redstone.Utils
{
    public class Slot
    {
        /// <summary>
        /// True if there is an item in this position;
        /// False if empty.
        /// </summary>
        public bool Present { get; set; }
        
        /// <summary>
        /// The Item ID. Omitted if Present is false.
        /// Item IDs are distinct from block IDs.
        /// </summary>
        public VarInt ItemId { get; set; }

        /// <summary>
        /// Omitted if present is false.
        /// </summary>
        public byte ItemCount { get; set; }

        /// <summary>
        /// Omitted if present is false. If 0 (TAG_END),
        /// there is no NBT data, and no further data follows.
        /// Otherwise the byte is the start of an NBT blob.
        /// </summary>
        public NbtCompound NBT { get; set; }
    }
}
