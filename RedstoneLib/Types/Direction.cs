using System;

namespace Redstone.Types
{
    /// <summary>
    /// Compass direction or up/down
    /// </summary>
    public sealed class Direction
    {
        public Direction()
        {
            Value = Down;
        }

        public Direction(VarInt value)
        {
            Value = value;
        }

        public VarInt Value { get; set; }

        public static readonly VarInt Down = 0;
        public static readonly VarInt Up = 1;
        public static readonly VarInt North = 2;
        public static readonly VarInt South = 3;
        public static readonly VarInt West = 4;
        public static readonly VarInt East = 5;

        public static implicit operator Direction(VarInt value)
        {
            if (value.Value is < 0 or > 5) throw new ArgumentOutOfRangeException(nameof(value));
            return new Direction {Value = value};
        }

        public static implicit operator Direction(int value)
        {
            if (value is < 0 or > 5) throw new ArgumentOutOfRangeException(nameof(value));
            return new Direction {Value = value};
        }

        public static implicit operator Direction(byte value)
        {
            if (value is < 0 or > 5) throw new ArgumentOutOfRangeException(nameof(value));
            return new Direction {Value = value};
        }
    }
}
