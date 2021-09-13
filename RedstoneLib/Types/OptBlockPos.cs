namespace Redstone.Types
{
    /// <summary>
    /// Optional variable indicating block position
    /// </summary>
    public class OptBlockPos : OptObject<Position>
    {
        public Position Position
        {
            get => Value!;
            set => Value = value;
        }

        public OptBlockPos(bool enabled, Position value = null!) : base(enabled)
        {
        }
    }
}
