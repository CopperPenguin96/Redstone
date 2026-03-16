using System.Collections;

namespace Redstone.Nbt.Tags
{
    public class LongArrayTag : NbtTag, IEnumerable<long>
    {
        public override TagType Type => TagType.LongArray;

        public new long[] Value
        {
            get => (long[])base.Value;
            set => base.Value = value;
        }

        public LongArrayTag() : base(null!, null!) { }

        public LongArrayTag(string name) : base(name, null!) { }

        public LongArrayTag(string name, long[] value) : base(name, value) { }

        public override void WriteToStream(Stream stream, bool writeHeaders = true)
        {
            if (writeHeaders) WriteHeader(stream);

            byte[] length = BitConverter.GetBytes(Length);
            Array.Reverse(length);
            stream.Write(length);

            foreach (long l in Value)
            {
                byte[] bts = BitConverter.GetBytes(l);
                Array.Reverse(bts);
                stream.Write(bts);
            }
        }

        public override LongArrayTag Read(Stream stream, bool readHeaders = true)
        {
            Value = [];
            if (readHeaders) ReadHeader(stream);

            long length = _reader.ReadLong();
            for (int i = 0; i < length; i++)
            {
                byte[] bytes = _reader.ReadBytes(8);
                Array.Reverse(bytes);
                long foundLong = BitConverter.ToInt64(bytes);
                Value = [.. Value, foundLong];
            }

            return this;
        }

        public int Length => Value.Length;

        public long this[int index]
        {
            get => Value[index];
            set => Value[index] = value;
        }

        public void Add(long l)
        {
            Value = (long[])Value.Append(l);
        }

        /// <summary>
        /// Removes the first element that matches the provided value.
        /// </summary>
        /// <param name="b"></param>
        public void Remove(long l)
        {
            List<long> newList = [.. Value];
            for (int x = 0; x < Value.Length; x++)
            {
                if (Value[x] == l)
                {
                    newList.RemoveAt(x);
                    break;
                }
            }

            Value = [.. newList];
        }

        public void RemoveAt(int index)
        {
            List<long> newList = [.. Value];
            newList.RemoveAt(index);
            Value = [.. newList];
        }

        public IEnumerator<long> GetEnumerator()
        {
            return ((IEnumerable<long>)Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Value.GetEnumerator();
        }
    }
}
