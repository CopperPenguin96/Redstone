namespace Redstone.Nbt.Tags
{
    /// <summary>
    /// An unofficial tag used to store boolean values as bytes. It is not part of the official NBT specification, but can be useful for certain applications.
    /// </summary>
    public class BoolTag : NbtTag
    {
        public override TagType Type => TagType.Boolean;

        public new bool Value
        {
            get => (bool)base.Value;
            set => base.Value = value;
        }

        public BoolTag() : base(null!, null!) { }

        public BoolTag(string name) : base(name, null!) { }

        public BoolTag(string name, bool value) : base(name, value) { }

        public override void WriteToStream(Stream stream, bool writeHeaders = true)
        {
            if (writeHeaders) WriteHeader(stream);
            stream.WriteByte(Value ? (byte)1:(byte)0);
        }

        public override BoolTag Read(Stream stream, bool readHeaders = true)
        {
            if (readHeaders) ReadHeader(stream);

            Value = _reader.ReadByte() == 1;
            return this;
        }
    }
}
