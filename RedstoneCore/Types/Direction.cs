using System;
using System.IO;

namespace Redstone.Core.Types
{
    public readonly struct Direction : IEquatable<Direction>
    {
        public readonly int Value;

        private Direction(int value)
        {
            Value = value;
        }

        public static readonly Direction Down = new(0);
        public static readonly Direction Up = new(1);
        public static readonly Direction North = new(2);
        public static readonly Direction South = new(3);
        public static readonly Direction West = new(4);
        public static readonly Direction East = new(5);

        public static Direction FromInt(int v) => new(v);

        public void WriteToStream(Stream stream)
        {
            VarInt vi = Value;
            vi.WriteToStream(stream);
        }

        public static Direction ReadFromStream(Stream stream)
        {
            VarInt vi = VarInt.ReadFromStream(stream);
            return new Direction(vi);
        }

        public static Direction Parse(ReadOnlySpan<byte> data, out int bytesRead)
        {
            VarInt vi = VarInt.Parse(data, out bytesRead);
            return new Direction(vi);
        }

        public override string ToString()
        {
            return Value switch
            {
                0 => nameof(Down),
                1 => nameof(Up),
                2 => nameof(North),
                3 => nameof(South),
                4 => nameof(West),
                5 => nameof(East),
                _ => throw new RedstoneException("Invalid Direction Value")
            };
        }

        #region Operators/Conversions

        public static implicit operator int(Direction d) => d.Value;

        public static implicit operator Direction(int i) => new(i);

        public static implicit operator VarInt(Direction d) => new(d.Value);

        public static implicit operator Direction(VarInt vi) => new(vi);

        public bool Equals(Direction other) => this.Value == other.Value;

        public override bool Equals(object? obj) => obj is Direction d && Equals(d);

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(Direction a, Direction b) => a.Value == b.Value;

        public static bool operator !=(Direction a, Direction b) => a.Value != b.Value;

        #endregion
    }
}
