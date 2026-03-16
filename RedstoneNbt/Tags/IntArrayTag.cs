using System.Collections;

namespace Redstone.Nbt.Tags
{
    public class IntArrayTag : NbtTag, IEnumerable<int>
    {
        public override TagType Type => TagType.IntArray;

        public new int[] Value
        {
            get => (int[])base.Value;
            set => base.Value = value;
        }

        public IntArrayTag() : base(null!, null!) { }

        public IntArrayTag(string name) : base(name, null!) { }

        public IntArrayTag(string name, int[] value) : base(name, value) { }

        public override void WriteToStream(Stream stream, bool writeHeaders = true)
        {
            if (writeHeaders) WriteHeader(stream);

            byte[] length = BitConverter.GetBytes(Length);
            Array.Reverse(length);
            stream.Write(length);

            foreach (int i in Value)
            {
                byte[] bts = BitConverter.GetBytes(i);
                Array.Reverse(bts);
                stream.Write(bts);
            }
        }

        public override IntArrayTag Read(Stream stream, bool readHeaders = true)
        {
            Value = [];
            if (readHeaders) ReadHeader(stream);

            int length = _reader.ReadInt();
            for (int i = 0; i < length; i++)
            {
                byte[] bytes = _reader.ReadBytes(4);
                Array.Reverse(bytes);
                int foundInt = BitConverter.ToInt32(bytes);
                Value = [.. Value, foundInt];
            }

            return this;
        }

        public int Length => Value.Length;

        public int this[int index]
        {
            get => Value[index];
            set => Value[index] = value;
        }

        public void Add(int i)
        {
            Value = (int[])Value.Append(i);
        }

        /// <summary>
        /// Removes the first element that matches the provided value.
        /// </summary>
        /// <param name="b"></param>
        public void Remove(int i)
        {
            List<int> newList = [.. Value];
            for (int x = 0; x < Value.Length; x++)
            {
                if (Value[x] == i)
                {
                    newList.RemoveAt(x);
                    break;
                }
            }

            Value = [.. newList];
        }

        public void RemoveAt(int index)
        {
            List<int> newList = [.. Value];
            newList.RemoveAt(index);
            Value = [.. newList];
        }

        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Value.GetEnumerator();
        }
    }
}
