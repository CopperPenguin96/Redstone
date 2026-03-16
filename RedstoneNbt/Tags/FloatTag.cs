namespace Redstone.Nbt.Tags
{
    public class FloatTag : NbtTag
    {
        public override TagType Type => TagType.Float;

        public new float Value
        {
            get => (float)base.Value;
            set => base.Value = value;
        }

        public FloatTag() : base(null!, null!) { }

        public FloatTag(string name) : base(name, null!) { }

        public FloatTag(string name, float value) : base(name, value) { }

        public override void WriteToStream(Stream stream, bool writeHeaders = true)
        {
            if (writeHeaders) WriteHeader(stream);

            byte[] bts = BitConverter.GetBytes(Value);
            Array.Reverse(bts);
            stream.Write(bts);
        }

        public override FloatTag Read(Stream stream, bool readHeaders = true)
        {
            if (readHeaders) ReadHeader(stream);

            Value = _reader.ReadFloat();
            return this;
        }
    }
}
