namespace Redstone.Core.Types
{
    public readonly struct VarInt : IEquatable<VarInt>
    {
        private const int SegmentBits = 0x7F;
        private const int ContinueBit = 0x80;

        public readonly int Value { get; }

        public VarInt(int value)
        {
            if (GetLength(value) > 5)
                throw new RedstoneException(new ArgumentOutOfRangeException(nameof(value)));

            Value = value;
        }

        public void WriteToStream(Stream stream)
        {
            Span<byte> buffer = stackalloc byte[5];
            int position = 0;

            uint v = (uint)Value;

            while (v >= 0x80)
            {
                buffer[position++] = (byte)(v | 0x80);
                v >>= 7;
            }
            buffer[position++] = (byte)v;

            stream.Write(buffer[..position]);
        }

        public static VarInt ReadFromStream(Stream stream)
        {
            int value = 0;
            int position = 0;
            while (true)
            {
                int currentByte = stream.ReadByte();
                if (currentByte == -1) throw new RedstoneException(new EndOfStreamException("Unexpected end of stream while reading VarInt"));
                value |= (currentByte & SegmentBits) << position;
                if ((currentByte & ContinueBit) == 0) break;
                position += 7;
                if (position >= 35) throw new RedstoneException(new FormatException("VarInt is too big"));
            }
            return new VarInt(value);
        }

        public VarInt()
        {
            Value = 0;
        }

        public static int GetLength(int value)
        {
            // Treat as uint to handle negative numbers correctly in the bit-check
            uint v = (uint)value;
            if ((v & ~0x7F) == 0) return 1;
            if ((v & ~0x3FFF) == 0) return 2;
            if ((v & ~0x1FFFFF) == 0) return 3;
            if ((v & ~0xFFFFFFF) == 0) return 4;
            return 5;
        }

        public static VarInt Parse(ReadOnlySpan<byte> data, out int bytesRead)
        {
            int value = 0;
            int position = 0;
            int bytes = 0;

            while (true)
            {
                byte currentByte = data[bytes];
                value |= (currentByte & SegmentBits) << position;
                bytes++;

                if ((currentByte & ContinueBit) == 0) break;

                position += 7;
                if (position >= 35) throw new FormatException("VarInt is too big");
            }

            bytesRead = bytes; // Now returns 1-5, not 0-28
            return new VarInt(value);
        }

        #region Operators

        public static implicit operator int(VarInt vi)
        {
            return vi.Value;
        }

        public static implicit operator VarInt(int i)
        {
            return new VarInt(i);
        }

        public static explicit operator VarLong(VarInt vi)
        {
            return new VarLong(vi);
        }

        public static bool operator ==(VarInt v1, VarInt v2)
        {
            return v1.Value == v2.Value;
        }

        public static bool operator !=(VarInt v1, VarInt v2)
        {
            return v1.Value != v2.Value;
        }

        public static bool operator <(VarInt v1, VarInt v2)
        {
            return v1.Value < v2.Value;
        }

        public static bool operator >(VarInt v1, VarInt v2)
        {
            return v1.Value > v2.Value;
        }

        public static bool operator <=(VarInt v1, VarInt v2)
        {
            return v1.Value <= v2.Value;
        }

        public static bool operator >=(VarInt v1, VarInt v2)
        {
            return v1.Value >= v2.Value;
        }

        public override bool Equals(object? obj)
        {
            return ((VarInt)obj!).Value == this.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(VarInt other) => this.Value == other.Value;

        #endregion
    }
}
