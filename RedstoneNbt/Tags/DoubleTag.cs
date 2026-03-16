namespace Redstone.Nbt.Tags
{
    public class DoubleTag : NbtTag
    {
        public override TagType Type => TagType.Double;

        public new double Value
        {
            get => (double)base.Value;
            set => base.Value = value;
        }

        public DoubleTag() : base(null!, null!) { }

        public DoubleTag(string name) : base(name, null!) { }

        public DoubleTag(string name, double value) : base(name, value) { }

        public override void WriteToStream(Stream stream, bool writeHeaders = true)
        {
            if (writeHeaders) WriteHeader(stream);

            byte[] bts = BitConverter.GetBytes(Value);
            Array.Reverse(bts);
            stream.Write(bts);
        }

        public override DoubleTag Read(Stream stream, bool readHeaders = true)
        {
            if (readHeaders) ReadHeader(stream);

            Value = _reader.ReadDouble();
            return this;
        }
    }
}
