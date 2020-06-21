﻿using Redstone.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Network.Packets;

namespace Redstone.AppSystem
{
	/// <summary>
	/// An integer between -2147483648 and 2147483647.
	/// Variable-length data encoding a two's complement signed 32-bit
	/// integer.
	/// </summary>
	public sealed class VarInt : IEquatable<VarInt>
	{
		public const long MaxValue = 2147483647;
		public const long MinValue = -2147483648;
		public long Value;

		public VarInt(long value)
		{
			if (value < MinValue) throw new ArgumentOutOfRangeException();
			if (value > MaxValue) throw new ArgumentOutOfRangeException();
			Value = value;
		}

		public int Length
		{
			get
			{
				long _value = Value;
				uint value = (uint)_value;
				int length = 0;

				while (true)
				{
					length++;
					if ((value & 0xFFFFFF80u) == 0)
						break;
					value >>= 7;
				}

				return length;
			}
		}

        #region implicit operators

        public static implicit operator Packet(VarInt val)
        {
	        return (Packet) (byte) val.Value;
        }

        public static implicit operator VarInt(Packet val)
        {
	        return new VarInt((byte) val);
        }

        public static implicit operator int(VarInt val)
        {
	        return (int) val.Value;
        }

        public static implicit operator VarInt(int val)
        {
            return new VarInt(val);
        }

        public static implicit operator uint(VarInt val)
        {
	        return (uint) val.Value;
        }

        public static implicit operator VarInt(uint val)
        {
            return new VarInt(val);
        }

        public static implicit operator long(VarInt val)
        {
	        return val.Value;
        }

        public static implicit operator VarInt(long val)
        {
            return new VarInt(val);
        }

        public static implicit operator ulong(VarInt val)
        {
	        return (ulong) val.Value;
        }

        public static implicit operator VarInt(ulong val)
        {
            return new VarInt((long)val);
        }

        public static implicit operator short(VarInt val)
        {
	        return (short) val.Value;
        }

        public static implicit operator VarInt(short val)
        {
            return new VarInt(val);
        }

        public static implicit operator ushort(VarInt val)
        {
	        return (ushort) val.Value;
        }

        public static implicit operator VarInt(ushort val)
        {
            return new VarInt(val);
        }

        /*
         TODO - uncomment when VarLong implemented
        public static implicit operator VarInt(VarLong val)
        {
            return new VarInt(val);
        }
        */

        public static implicit operator sbyte(VarInt val)
        {
	        return (sbyte) val.Value;
        }

        public static implicit operator VarInt(sbyte val)
        {
            return new VarInt(val);
        }

        public static implicit operator byte(VarInt val)
        {
	        return (byte) val.Value;
        }

        public static implicit operator VarInt(byte val)
        {
            return new VarInt(val);
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

		#region Comparison Operators

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

        #endregion

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
