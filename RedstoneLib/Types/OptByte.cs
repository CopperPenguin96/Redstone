using System.Runtime.InteropServices;

namespace Redstone.Types
{
    /// <summary>
    /// Optional VarInt
    /// </summary>
    public class OptByte : OptObject<VarInt>
    {
        public OptByte(bool enabled, [Optional] byte value) : base(enabled, value)
        {
        }
    }
}
