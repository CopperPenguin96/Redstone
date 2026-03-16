namespace Redstone.Nbt.Tags
{
    public class LongTag : NbtTag
    {
        public override TagType Type => TagType.Long;

        public new long Value
        {
            get => (long)base.Value;
            set => base.Value = value;
        }

        public LongTag() : base(null!, null!) { }

        public LongTag(string name) : base(name, null!) { }

        public LongTag(string name, long value) : base(name, value) { }

        public override void WriteToStream(Stream stream, bool writeHeaders = true)
        {
            if (writeHeaders) WriteHeader(stream);

            byte[] bts = BitConverter.GetBytes(Value);
            Array.Reverse(bts);
            stream.Write(bts);
        }

        public override LongTag Read(Stream stream, bool readHeaders = true)
        {
            if (readHeaders) ReadHeader(stream);

            Value = _reader.ReadLong();
            return this;
        }
    }
}
