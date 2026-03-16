using Redstone.Core.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Core.Entities
{
    internal class EntityStream : Stream
    {
        private Stream _stream;

        public EntityStream(Stream stream)
        {
            _stream = stream;
        }

        public override bool CanRead => _stream.CanRead;

        public override bool CanSeek => _stream.CanSeek;

        public override bool CanWrite => _stream.CanWrite;

        public override long Length => _stream.Length;

        public override long Position
        {
            get => _stream.Position;
            set => _stream.Position = value;
        }

        public override void Flush() => _stream.Flush();

        public override int Read(byte[] buffer, int offset, int count) => _stream.Read(buffer, offset, count);

        public override long Seek(long offset, SeekOrigin origin) => _stream.Seek(offset, origin);

        public override void SetLength(long value) => _stream.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count) => _stream.Write(buffer, offset, count);

        public override void WriteByte(byte value) => _stream.WriteByte(value);

        public new byte ReadByte() => (byte)_stream.ReadByte();

        public void WriteVarInt(VarInt vi)
        {
            vi.WriteToStream(ref _stream);
        }

        public VarInt ReadVarInt()
        {
            return VarInt.ReadFromStream(ref _stream);
        }

        public void WriteVarLong(VarLong vl)
        {
            vl.WriteToStream(ref _stream);
        }

        public VarLong ReadVarLong()
        {
            return VarLong.ReadFromStream(ref _stream);
        }

        public void WriteBytes(Span<byte> buffer)
        {
            if (Global.IsBigEndian) buffer.Reverse();
            _stream.Write(buffer);
        }

        public Span<byte> ReadBytes(int count)
        {
            Span<byte> buffer = new byte[count];
            _stream.ReadExactly(buffer);
            if (Global.IsBigEndian) buffer.Reverse();
            return buffer;
        }

        public void WriteFloat(float f)
        {
            Span<byte> buffer = new(BitConverter.GetBytes(f));
            WriteBytes(buffer);
        }

        public float ReadFloat()
        {
            Span<byte> buffer = ReadBytes(4);
            return BitConverter.ToSingle(buffer);
        }    

        public void WriteString(string s)
        {
            if (s.Length > 32767) throw new RedstoneException(new ArgumentException("String length cannot be greater than 32767."));


        }
    }
}
