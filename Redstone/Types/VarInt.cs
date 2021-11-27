using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Network;

namespace Redstone.Types
{
    public sealed class VarInt : IEquatable<VarInt>
    {
        public const long MaxValue = 2147483647;
        public const long MinValue = -2147483648;
        public readonly long Value;

        public VarInt(long value)
        {
            if (value < MinValue) throw new ArgumentOutOfRangeException();
            if (value > MaxValue) throw new ArgumentOutOfRangeException();
            Value = value;
        }

        public int Length => GameStream.GetVarIntLength((int)Value);

        #region implicit operators

        public static implicit operator VarInt(int val)
        {
            return new VarInt(val);
        }

        public static implicit operator int(VarInt val)
        {
            return (int) val.Value;
        }

        public static implicit operator VarInt(uint val)
        {
            return new VarInt(val);
        }

        public static implicit operator uint(VarInt val)
        {
            return (uint) val.Value;
        }

        public static implicit operator VarInt(long val)
        {
            return new VarInt(val);
        }

        public static implicit operator long(VarInt val)
        {
            return val.Value;
        }

        public static implicit operator VarInt(ulong val)
        {
            return new VarInt((long)val);
        }

        public static implicit operator VarInt(short val)
        {
            return new VarInt(val);
        }

        public static implicit operator short(VarInt val)
        {
            return (short) val.Value;
        }

        public static implicit operator VarInt(ushort val)
        {
            return new VarInt(val);
        }

        public static implicit operator ushort(VarInt val)
        {
            return (ushort) val.Value;
        }

        /*
         TODO - uncomment when VarLong implemented
        public static implicit operator VarInt(VarLong val)
        {
            return new VarInt(val);
        }
        */

        public static implicit operator VarInt(sbyte val)
        {
            return new VarInt(val);
        }

        public static implicit operator VarInt(byte val)
        {
            return new VarInt(val);
        }

        public static implicit operator byte(VarInt val)
        {
            return (byte) val.Value;
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

        public static bool operator !=(VarInt first, VarInt second)
        {
            return first.Value != second.Value;
        }

        public static bool operator <(VarInt first, VarInt second)
        {
            return first.Value < second.Value;
        }

        public static bool operator >(VarInt first, VarInt second)
        {
            return first.Value > second.Value;
        }

        public static bool operator <=(VarInt first, VarInt second)
        {
            return first.Value <= second.Value;
        }

        public static bool operator >=(VarInt first, VarInt second)
        {
            return first.Value >= second.Value;
        }

        public override bool Equals(object o)
        {
            return this == (VarInt)o;
        }

        public bool Equals(VarInt other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
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
