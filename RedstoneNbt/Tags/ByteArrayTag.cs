using System.Collections;

namespace Redstone.Nbt.Tags
{
    public class ByteArrayTag : NbtTag, IEnumerable<byte>
    {
        public override TagType Type => TagType.ByteArray;

        public new byte[] Value
        {
            get => (byte[])base.Value;
            set => base.Value = value;
        }

        public ByteArrayTag() : base(null!, null!) { }

        public ByteArrayTag(string name) : base(name, null!) { }

        public ByteArrayTag(string name, byte[] value) : base(name, value) { }

        public override void WriteToStream(Stream stream, bool writeHeaders = true)
        {
            if (writeHeaders) WriteHeader(stream);

            byte[] length = BitConverter.GetBytes(Length);
            Array.Reverse(length);
            stream.Write(length);
            stream.Write(Value);
        }

        public override ByteArrayTag Read(Stream stream, bool readHeaders = true)
        {
            Value = [];
            if (readHeaders) ReadHeader(stream);

            int length = _reader.ReadInt();
            Value = _reader.ReadByteArray(length);
            return this;
        }

        public int Length => Value.Length;

        public byte this[int index]
        {
            get => Value[index];
            set => Value[index] = value;
        }

        public void Add(byte b)
        {
            Value = (byte[])Value.Append(b);
        }

        /// <summary>
        /// Removes the first element that matches the provided value.
        /// </summary>
        /// <param name="b"></param>
        public void Remove(byte b)
        {
            List<byte> newList = [.. Value];
            for (int x = 0; x < Value.Length; x++)
            {
                if (Value[x] == b)
                {
                    newList.RemoveAt(x);
                    break;
                }
            }

            Value = [.. newList];
        }

        public void RemoveAt(int index)
        {
            List<byte> newList = [.. Value];
            newList.RemoveAt(index);
            Value = [.. newList];
        }

        public IEnumerator<byte> GetEnumerator()
        {
            return ((IEnumerable<byte>)Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Value.GetEnumerator();
        }
    }
}
