namespace Redstone.Nbt.Tags
{
    public class EndTag : NbtTag
    {
        public override TagType Type => TagType.End;

        public new byte Value { get; set; }

        public EndTag() : base(null!, null!) { }

        public override void WriteToStream(Stream stream, bool writeHeaders = true)
        {
            if (writeHeaders) WriteHeader(stream);
        }

        public override EndTag Read(Stream stream, bool readHeaders = true)
        {
            return new EndTag();
        }
    }
}
