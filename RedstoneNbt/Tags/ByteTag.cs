namespace Redstone.Nbt.Tags
{
    public class ByteTag : NbtTag
    {
        public override TagType Type => TagType.Byte;

        public new byte Value
        {
            get => (byte)base.Value;
            set => base.Value = value;
        }

        public ByteTag() : base(null!, null!) { }

        public ByteTag(string name) : base(name, null!) { }

        public ByteTag(string name, byte value) : base(name, value) { }

        public override void WriteToStream(Stream stream, bool writeHeaders = true)
        {
            if (writeHeaders) WriteHeader(stream);
            stream.WriteByte(Value);
        }

        public override ByteTag Read(Stream stream, bool readHeaders = true)
        {
            if (readHeaders) ReadHeader(stream);

            Value = _reader.ReadByte();
            return this;
        }
    }
}
