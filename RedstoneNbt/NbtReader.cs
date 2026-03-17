using System.Text;

namespace Redstone.Nbt
{
    public class NbtReader : BinaryReader
    {
        public static bool IsBigEndian { get; set; } = true;

        public NbtReader(Stream input) : base(input)
        {
        }

        public NbtReader(Stream input, Encoding encoding) : base(input, encoding)
        {
        }

        public NbtReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
        {
        }

        public new byte ReadByte()
        {
            return base.ReadByte();
        }

        public short ReadShort()
        {
            byte[] data = base.ReadBytes(2);
            if (IsBigEndian) Array.Reverse(data);
            return BitConverter.ToInt16(data, 0);
        }

        public ushort ReadUShort()
        {
            byte[] data = base.ReadBytes(2);
            if (IsBigEndian) Array.Reverse(data);
            return BitConverter.ToUInt16(data, 0);
        }

        public int ReadInt()
        {
            byte[] data = base.ReadBytes(4);
            if (IsBigEndian) Array.Reverse(data);
            return BitConverter.ToInt32(data, 0);
        }

        public long ReadLong()
        {
            byte[] data = base.ReadBytes(8);
            if (IsBigEndian) Array.Reverse(data);
            return BitConverter.ToInt64(data, 0);
        }

        public float ReadFloat()
        {
            byte[] data = base.ReadBytes(4);
            if (IsBigEndian) Array.Reverse(data);
            return BitConverter.ToSingle(data, 0);
        }

        public override double ReadDouble()
        {
            byte[] data = base.ReadBytes(8);
            if (IsBigEndian) Array.Reverse(data);
            return BitConverter.ToDouble(data, 0);
        }

        public byte[] ReadByteArray(int length)
        {
            return base.ReadBytes(length);
        }

        public byte[] ReadByteArray()
        {
            byte length = ReadByte();
            return ReadByteArray(length);
        }

        public override string ReadString()
        {
            byte[] ushortLength = ReadByteArray(2);
            if (IsBigEndian) Array.Reverse(ushortLength);
            ushort length = BitConverter.ToUInt16(ushortLength);
            byte[] strBytes = ReadBytes(length);
            return Encoding.UTF8.GetString(strBytes);
        }

        public int[] ReadIntArray(int length)
        {
            int[] returnArray = new int[length];
            for (int i = 0; i < length; i++)
            {
                returnArray[i] = ReadInt();
            }

            return returnArray;
        }

        public long[] ReadLongArray(int length)
        {
            long[] returnArray = new long[length];
            for (int i = 0; i < length; i++)
            {
                returnArray[i] = ReadLong();
            }

            return returnArray;
        }
    }

}
