using Redstone.Core;
using Redstone.Core.Types;
using Redstone.Nbt.Tags;
using System.Text;

namespace Redstone.Server.Net
{
    public sealed class MinecraftStream(Stream baseStream) : Stream
    {
        private readonly Stream _baseStream = baseStream ?? throw new RedstoneException(new ArgumentNullException(nameof(baseStream)));

        public override bool CanRead => _baseStream.CanRead;

        public override bool CanSeek => _baseStream.CanSeek;

        public override bool CanWrite => _baseStream.CanWrite;

        public override long Length => _baseStream.Length;

        public override long Position
        {
            get => _baseStream.Position;
            set => _baseStream.Position = value;
        }

        public override void Flush() => _baseStream.Flush();

        public override int Read(byte[] buffer, int offset, int count) => _baseStream.Read(buffer, offset, count);

        public override long Seek(long offset, SeekOrigin origin) => _baseStream.Seek(offset, origin);

        public override void SetLength(long value) => _baseStream.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count) => _baseStream.Write(buffer, offset, count);

        public void WriteBool(bool b)
        {
            WriteByte((byte)(b ? 1 : 0));
        }

        public bool ReadBool()
        {
            return ReadByte() != 0;
        }

        public void WriteSignedByte(sbyte b)
        {
            WriteByte((byte)b);
        }

        public sbyte ReadSignedByte()
        {
            return (sbyte)ReadByte();
        }

        public void WriteUnsignedByte(byte b)
        {
            WriteByte(b);
        }

        public byte ReadUnsignedByte()
        {
            return (byte)ReadByte();
        }   

        public void WriteShort(short s)
        {
            WriteByte((byte)(s >> 8));
            WriteByte((byte)(s & 0xFF));
        }

        public short ReadShort()
        {
            int high = ReadByte();
            int low = ReadByte();
            return (short)((high << 8) | low);
        }

        public void WriteUShort(ushort s)
        {
            WriteByte((byte)(s >> 8));
            WriteByte((byte)(s & 0xFF));
        }

        public ushort ReadUShort()
        {
            int high = ReadByte();
            int low = ReadByte();
            return (ushort)((high << 8) | low);
        }

        public void WriteInt(int i)
        {
            WriteByte((byte)(i >> 24));
            WriteByte((byte)((i >> 16) & 0xFF));
            WriteByte((byte)((i >> 8) & 0xFF));
            WriteByte((byte)(i & 0xFF));
        }

        public int ReadInt()
        {
            int b1 = ReadByte();
            int b2 = ReadByte();
            int b3 = ReadByte();
            int b4 = ReadByte();
            return (b1 << 24) | (b2 << 16) | (b3 << 8) | b4;
        }

        public void WriteLong(long l)
        {
            WriteByte((byte)(l >> 56));
            WriteByte((byte)((l >> 48) & 0xFF));
            WriteByte((byte)((l >> 40) & 0xFF));
            WriteByte((byte)((l >> 32) & 0xFF));
            WriteByte((byte)((l >> 24) & 0xFF));
            WriteByte((byte)((l >> 16) & 0xFF));
            WriteByte((byte)((l >> 8) & 0xFF));
            WriteByte((byte)(l & 0xFF));
        }

        public long ReadLong()
        {
            long b1 = ReadByte();
            long b2 = ReadByte();
            long b3 = ReadByte();
            long b4 = ReadByte();
            long b5 = ReadByte();
            long b6 = ReadByte();
            long b7 = ReadByte();
            long b8 = ReadByte();
            return (b1 << 56) | (b2 << 48) | (b3 << 40) | (b4 << 32) | (b5 << 24) | (b6 << 16) | (b7 << 8) | b8;
        }

        public void WriteFloat(float f)
        {
            byte[] bytes = BitConverter.GetBytes(f);
            if (!Global.IsBigEndian)
                Array.Reverse(bytes);
            Write(bytes, 0, 4);
        }

        public float ReadFloat()
        {
            byte[] bytes = new byte[4];
            ReadExactly(bytes, 0, 4);
            if (!Global.IsBigEndian)
                Array.Reverse(bytes);
            return BitConverter.ToSingle(bytes, 0);
        }

        public void WriteDouble(double d)
        {
            byte[] bytes = BitConverter.GetBytes(d);
            if (!Global.IsBigEndian)
                Array.Reverse(bytes);
            Write(bytes, 0, 8);
        }

        public double ReadDouble()
        {
            byte[] data = new byte[8];
            ReadExactly(data, 0, 8);
            if (!Global.IsBigEndian)
                Array.Reverse(data);
            
            return BitConverter.ToDouble(data, 0);
        }
        
        public void WriteVarInt(VarInt value)
        {
            value.WriteToStream(this);
        }

        public VarInt ReadVarInt()
        {
            return VarInt.ReadFromStream(this);
        }

        public void WriteVarLong(VarLong value)
        {
            value.WriteToStream(this);
        } 

        public VarLong ReadVarLong()
        {
            return VarLong.ReadFromStream(this);
        }

        public void WriteString(string s)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            WriteVarInt(bytes.Length);
            Write(bytes, 0, bytes.Length);
        }

        public string ReadString()
        {
            VarInt length = ReadVarInt();
            byte[] bytes = new byte[length];

            ReadExactly(bytes, 0, length);
            return Encoding.UTF8.GetString(bytes);
        }

        public void WriteTag(NbtTag tag)
        {
            tag.WriteToStream(_baseStream);
        }

        public NbtTag ReadTag()
        {
            return NbtTag.ReadFromStream(_baseStream);
        }
    }
}
