using System;
using Redstone.Network;

namespace Redstone.Types
{
    public sealed class VarInt : IEquatable<VarInt>
    {
        public const long MaxValue = 2147483647;
        public const long MinValue = -21447483647;
        public readonly long Value;

        public VarInt(long value)
        {
            Value = value switch
            {
                < MinValue => throw new ArgumentException(nameof(value)),
                > MaxValue => throw new ArgumentException(nameof(value)),
                _ => value
            };
        }

        public int Length => GameStream.GetVarIntLength((int) Value);

        //public int Length => GameStream.GetVarIntLength((int) Value);

        #region Implicit Operators

        public static implicit operator VarInt(int value)
        {
            return new VarInt(value);
        }

        public static implicit operator VarInt(uint value)
        {
            return new VarInt(value);
        }

        public static implicit operator VarInt(long value)
        {
            return new VarInt(value);
        }

        public static implicit operator VarInt(ulong value)
        {
            return new VarInt((long) value);
        }

        public static implicit operator VarInt(short value)
        {
            return new VarInt(value);
        }

        public static implicit operator VarInt(ushort value)
        {
            return new VarInt(value);
        }

        /*public static implicit operator VarInt(VarLong value)
        {
            return new VarInt(value);
        }*/

        public static implicit operator VarInt(sbyte value)
        {
            return new VarInt(value);
        }

        public static implicit operator VarInt(byte value)
        {
            return new VarInt(value);
        }

        #endregion

        #region + Operator

        public static VarInt operator +(VarInt first, VarInt second)
        {
            return new VarInt(first.Value + second.Value);
        }

        public static VarInt operator +(int first, VarInt second)
        {
            return new VarInt(first + second.Value);
        }

        public static VarInt operator +(VarInt first, int second)
        {
            return new VarInt(first.Value + second);
        }

        #endregion

        #region - Operator

        public static VarInt operator -(VarInt first, VarInt second)
        {
            return new VarInt(first.Value - second.Value);
        }

        public static VarInt operator -(int first, VarInt second)
        {
            return new VarInt(first - second.Value);
        }

        public static VarInt operator -(VarInt first, int second)
        {
            return new VarInt(first.Value - second);
        }

        #endregion

        public static bool operator ==(VarInt first, VarInt second)
        {
            return first.Value == second.Value;
        }

        public static bool operator ==(int first, VarInt second)
        {
            return first == second.Value;
        }

        public static bool operator ==(VarInt first, int second)
        {
            return first.Value == second;
        }

        public static bool operator !=(VarInt first, VarInt second)
        {
            return first.Value != second.Value;
        }

        public static bool operator !=(int first, VarInt second)
        {
            return first != second.Value;
        }

        public static bool operator !=(VarInt first, int second)
        {
            return first.Value != second;
        }

        public static bool operator <(VarInt first, VarInt second)
        {
            return first.Value < second.Value;
        }
        public static bool operator <(int first, VarInt second)
        {
            return first < second.Value;
        }

        public static bool operator <(VarInt first, int second)
        {
            return first.Value < second;
        }

        public static bool operator >(VarInt first, VarInt second)
        {
            return first.Value > second.Value;
        }

        public static bool operator >(int first, VarInt second)
        {
            return first > second.Value;
        }

        public static bool operator >(VarInt first, int second)
        {
            return first.Value > second;
        }

        public static bool operator <=(VarInt first, VarInt second)
        {
            return first.Value <= second.Value;
        }

        public static bool operator <=(int first, VarInt second)
        {
            return first <= second.Value;
        }

        public static bool operator <=(VarInt first, int second)
        {
            return first.Value <= second;
        }

        public static bool operator >=(VarInt first, VarInt second)
        {
            return first.Value >= second.Value;
        }
        public static bool operator >=(int first, VarInt second)
        {
            return first >= second.Value;
        }

        public static bool operator >=(VarInt first, int second)
        {
            return first.Value >= second;
        }

        public override bool Equals(object o)
        {
            return this == o;
        }

        public bool Equals(VarInt other)
        {
            if (this == other) return true;
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
