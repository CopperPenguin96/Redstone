using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProtocolSharp.Types
{
    public enum PaintingDirection
    {
        North = 2,
        South = 0,
        West = 1,
        East = 3
    }

    public sealed class Direction
    {
        public VarInt Value { get; set; }
        public static readonly VarInt Down = 0;
        public static readonly VarInt Up = 1;
        public static readonly VarInt North = 2;
        public static readonly VarInt South = 3;
        public static readonly VarInt West = 4;
        public static readonly VarInt East = 5;

        public static implicit operator Direction(VarInt value)
        {
            if (value < 0 || value > 5) throw new ArgumentOutOfRangeException(nameof(value));
            Direction direction = new Direction { Value = value };
            return direction;
        }

        public static implicit operator Direction(int value)
        {
            if (value < 0 || value > 5) throw new ArgumentOutOfRangeException(nameof(value));
            Direction direction = new Direction { Value = value };
            return direction;
        }

        public static implicit operator Direction(byte val)
        {
            if (val < 0 || val > 5) throw new ArgumentOutOfRangeException(nameof(val));
            Direction direction = new Direction { Value = val };
            return direction;
        }
    }
}