namespace Redstone.Nbt.Tags
{
    public class ShortTag : NbtTag
    {
        public override TagType Type => TagType.Short;

        public new short Value
        {
            get => (short)base.Value;
            set => base.Value = value;
        }

        public ShortTag() : base(null!, null!) { }

        public ShortTag(string name) : base(name, null!) { }

        public ShortTag(string name, short value) : base(name, value) { }

        public override void WriteToStream(Stream stream, bool writeHeaders = true)
        {
            if (writeHeaders) WriteHeader(stream);

            byte[] bts = BitConverter.GetBytes(Value);
            Array.Reverse(bts);
            stream.Write(bts);
        }

        public override ShortTag Read(Stream stream, bool readHeaders = true)
        {
            if (readHeaders) ReadHeader(stream);

            Value = _reader.ReadShort();
            return this;
        }
    }
}
