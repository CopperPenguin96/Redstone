namespace Redstone.Nbt.Tags
{
    public class IntTag : NbtTag
    {
        public override TagType Type => TagType.Int;

        public new int Value
        {
            get => (int)base.Value;
            set => base.Value = value;
        }

        public IntTag() : base(null!, null!) { }

        public IntTag(string name) : base(name, null!) { }

        public IntTag(string name, int value) : base(name, value) { }

        public override void WriteToStream(Stream stream, bool writeHeaders = true)
        {
            if (writeHeaders) WriteHeader(stream);

            byte[] bts = BitConverter.GetBytes(Value);
            Array.Reverse(bts);
            stream.Write(bts);
        }

        public override IntTag Read(Stream stream, bool readHeaders = true)
        {
            if (readHeaders) ReadHeader(stream);

            Value = _reader.ReadInt();
            return this;
        }
    }
}
