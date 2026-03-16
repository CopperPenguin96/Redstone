namespace Redstone.Core.Types
{
    public readonly struct VarLong : IEquatable<VarLong>
    {
        private const int SegmentBits = 0x7F;
        private const int ContinueBit = 0x80;

        public readonly long Value { get; }

        public VarLong(long value)
        {
            if (GetLength(value) > 10)
                throw new RedstoneException(new ArgumentOutOfRangeException(nameof(value)));

            Value = value;
        }

        public VarLong(VarInt vi) : this((long)vi)
        {
        }

        public VarLong()
        {
            Value = 0;
        }

        public void WriteToStream(ref Stream stream)
        {
            Span<byte> buffer = stackalloc byte[10];
            int position = 0;
            ulong v = (ulong)Value;

            while (v >= 0x80)
            {
                buffer[position++] = (byte)((v & 0x7F) | 0x80);
                v >>= 7;
            }
            buffer[position++] = (byte)v;
            stream.Write(buffer[..position]);
        }

        public static VarLong ReadFromStream(ref Stream stream)
        {
            long value = 0;
            int position = 0;
            while (true)
            {
                int currentByte = stream.ReadByte();
                if (currentByte == -1) throw new RedstoneException(new EndOfStreamException("Unexpected end of stream while reading VarLong"));
                value |= ((long)(currentByte & SegmentBits)) << position;
                if ((currentByte & ContinueBit) == 0) break;
                position += 7;
                if (position >= 70) throw new RedstoneException(new FormatException("VarLong is too big"));
            }
            return new VarLong(value);
        }

        public static int GetLength(long value)
        {
            // Treat as ulong to handle negative numbers correctly in the bit-check
            ulong v = (ulong)value;
            int length = 1;
            while ((v >> 7) != 0)
            {
                length++;
                v >>= 7;
                if (length > 10) break;
            }

            return length;
        }

        public static VarLong Parse(ReadOnlySpan<byte> data, out int bytesRead)
        {
            long value = 0;
            int position = 0;
            int bytes = 0;

            while (true)
            {
                byte currentByte = data[bytes];
                value |= ((long)(currentByte & SegmentBits)) << position;
                bytes++;

                if ((currentByte & ContinueBit) == 0) break;

                position += 7;
                if (position >= 70) throw new FormatException("VarLong is too big");
            }

            bytesRead = bytes; // returns 1-10
            return new VarLong(value);
        }

        #region Operators

        public static implicit operator long(VarLong vl)
        {
            return vl.Value;
        }

        public static implicit operator VarLong(long l)
        {
            return new VarLong(l);
        }

        public static explicit operator VarInt(VarLong vl)
        {
            return new VarInt((int)vl.Value);
        }

        public static bool operator ==(VarLong v1, VarLong v2)
        {
            return v1.Value == v2.Value;
        }

        public static bool operator !=(VarLong v1, VarLong v2)
        {
            return v1.Value != v2.Value;
        }

        public static bool operator <(VarLong v1, VarLong v2)
        {
            return v1.Value < v2.Value;
        }

        public static bool operator >(VarLong v1, VarLong v2)
        {
            return v1.Value > v2.Value;
        }

        public static bool operator <=(VarLong v1, VarLong v2)
        {
            return v1.Value <= v2.Value;
        }

        public static bool operator >=(VarLong v1, VarLong v2)
        {
            return v1.Value >= v2.Value;
        }

        public override bool Equals(object? obj)
        {
            return obj is VarLong other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(VarLong other)
        {
            return Value == other.Value;
        }

        #endregion
    }
}
