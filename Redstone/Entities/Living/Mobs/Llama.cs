using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;

namespace Redstone.Entities.Living.Mobs
{
    public class Llama : ChestedHorse
    {
        /// <summary>
        /// Number of columns of 3 slots in the llama's inventory
        /// once a chest is equipped
        /// </summary>
        public VarInt Strength { get; set; } = 0;

        /// <summary>
        /// A dye color, or -1 if no carpet equipped
        /// </summary>
        public VarInt CarpetColor { get; set; } = -1;

        public LlamaVariant Variant { get; set; } = 0;
    }

    public enum LlamaVariant
    {
        Creamy = 0,
        White = 1, 
        Brown = 2, 
        Gray = 3
    }
}
