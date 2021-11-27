namespace Redstone.Types
{
    public sealed class Direction
    {
        public bool IsPainting { get; private set; }

        private VarInt? _value;
        public VarInt Value
        {
            get
            {
                if (IsPainting)
                {
                    return (int)_value! switch
                    {
                        2 => North,
                        0 => South,
                        1 => West,
                        3 => East,
                        _ => throw new Exception("Not a valid painting direction. " + _value),
                    };
                }
                else
                {
                    return _value!;
                }
            }
            set => _value = value;
        }

        public static VarInt Down => 0;
        public static VarInt Up => 1;
        public static VarInt North => 2;
        public static VarInt South => 3;
        public static VarInt West => 4;
        public static VarInt East => 5;

        public Direction(bool isPainting = false)
        {
            IsPainting = isPainting;
        }

        public static implicit operator Direction(VarInt value)
        {
            if (value < 0 || value > 5)
                throw new ArgumentOutOfRangeException(nameof(value));

            Direction direction = new() { Value = value };
            return direction;
        }

        public static implicit operator Direction(int value)
        {
            if (value is < 0 or > 5)
                throw new ArgumentOutOfRangeException(nameof(value));

            Direction direction = new Direction { Value = value };
            return direction;
        }

        public static implicit operator Direction(byte val)
        {
            if (val is < 0 or > 5)
                throw new ArgumentOutOfRangeException(nameof(val));

            Direction direction = new Direction { Value = val };
            return direction;
        }
    }
}
