namespace Redstone.Types
{
    /// <summary>
    /// Optional VarInt
    /// </summary>
    public class OptVarInt : OptObject<VarInt>
    {
        public OptVarInt(bool enabled, VarInt value = null!) : base(enabled, value)
        {
        }
    }
}
