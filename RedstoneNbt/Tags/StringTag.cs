using System.Text;

namespace Redstone.Nbt.Tags
{
    public class StringTag : NbtTag
    {
        public override TagType Type => TagType.String;

        public new string Value
        {
            get => base.Value.ToString()!;
            set => base.Value = value;
        }

        public StringTag() : base(null!, null!) { }

        public StringTag(string name) : base(name, null!) { }

        public StringTag(string name, string value) : base(name, value) { }

        public override void WriteToStream(Stream stream, bool writeHeaders = true)
        {
            if (writeHeaders) WriteHeader(stream);

            byte[] length = BitConverter.GetBytes(Length);
            Array.Reverse(length);
            stream.Write(length);
            stream.Write(Encoding.UTF8.GetBytes(Value));
        }

        public override StringTag Read(Stream stream, bool readHeaders = true)
        {
            if (readHeaders) ReadHeader(stream);

            Value = _reader.ReadString();
            return this;
        }

        public ushort Length => (ushort)Value.Length;

        public char this[int index]
        {
            get => Value[index];
        }

    }
}
