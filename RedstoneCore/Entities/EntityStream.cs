using Redstone.Core.Types;
using Redstone.Nbt.Tags;
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
            vi.WriteToStream(_stream);
        }

        public VarInt ReadVarInt()
        {
            return VarInt.ReadFromStream(_stream);
        }

        public void WriteVarLong(VarLong vl)
        {
            vl.WriteToStream(_stream);
        }

        public VarLong ReadVarLong()
        {
            return VarLong.ReadFromStream(_stream);
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
            tag.WriteToStream(_stream);
        }

        public NbtTag ReadTag()
        {
            return NbtTag.ReadFromStream(_stream);
        }

        public void WriteOptionalTag(OptValue<NbtTag> tag)
        {
            WriteByte((byte)(tag.Enabled ? 1 : 0));
            if (tag.Enabled)
            {
                WriteTag(tag.Value);
            }
        }

        public OptValue<NbtTag> ReadOptionalTag()
        {
            byte enabled = ReadByte();
            if (enabled == 0)
                return new OptValue<NbtTag>(false, null);
            else
                return new OptValue<NbtTag>(true, ReadTag());
        }

        public void WriteSlotData(SlotData slot)
        {
            WriteVarInt(slot.Count);

            if (slot.ItemID.Enabled)
            {
                WriteByte(1);
                WriteVarInt(slot.ItemID.Value);
            }
            else
            {
                WriteByte(0);
            }

            // Write the list of component ids to remove: first the count as VarInt, then each id as VarInt
            WriteVarInt(slot.ToRemove.Count);
            foreach (VarInt rem in slot.ToRemove)
            {
                WriteVarInt(rem);
            }
        }

        public SlotData ReadSlotData()
        {
            SlotData slot = new SlotData();

            slot.Count = ReadVarInt();

            byte present = ReadByte();
            if (present == 0)
            {
                slot.ItemID = new OptValue<VarInt>(false, default(VarInt));
            }
            else
            {
                VarInt id = ReadVarInt();
                slot.ItemID = new OptValue<VarInt>(true, id);
            }

            VarInt removeCount = ReadVarInt();
            for (int i = 0; i < removeCount; i++)
            {
                VarInt comp = ReadVarInt();
                slot.ToRemove.Add(comp);
            }

            return slot;
        }
    }
}
