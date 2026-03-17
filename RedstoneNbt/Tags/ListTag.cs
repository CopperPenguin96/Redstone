using System.Collections;

namespace Redstone.Nbt.Tags
{
    public class ListTag : NbtTag, IList<NbtTag>
    {
        public override TagType Type => TagType.List;

        public TagType ListType { get; private set; }

        public new List<NbtTag> Value
        {
            get => (List<NbtTag>)base.Value;
            set => base.Value = value;
        }

        public ListTag(TagType listType) : base(null!, null!) 
        {
            ListType = listType;
        }

        public ListTag(string name, TagType listType) : base(name, null!) 
        {
            ListType = listType;
        }

        public ListTag(string name, List<NbtTag> value, TagType listType) : base(name, value) 
        {
            ListType = listType;
        }

        public override void WriteToStream(Stream stream, bool writeHeaders = true)
        {
            if (writeHeaders) WriteHeader(stream);

            if (Count < 1) // empty list
            {
                stream.WriteByte(0);
                return;
            }
            
            if (ListType == TagType.End)
            {
                throw new NbtException("A List Type of End Tag cannot contain any elements.");
            }

            stream.WriteByte((byte)ListType); // prefixed id of the list's type

            byte[] lengthArray = BitConverter.GetBytes(Count);
            if (NbtReader.IsBigEndian) Array.Reverse(lengthArray);
            stream.Write(lengthArray); // length of the list

            foreach (NbtTag tag in Value)
            {
                if (tag.Type != ListType)
                {
                    throw new NbtException($"All tags in a List Tag must be of the same type. Expected {ListType}, got {tag.Type}.");
                }

                tag.WriteToStream(stream, false); // false to not writing headers
            }
        }

        public override ListTag Read(Stream stream, bool readHeaders = true)
        {
            if (readHeaders) ReadHeader(stream);

            TagType tagType = (TagType)_reader.ReadByte();
            int length = _reader.ReadInt();

            ListType = tagType;

            if (ListType == TagType.End)
            {
                if (length > 0) throw new NbtException("Invalid NBT: List of type End Tag cannot contain elements.");
                return new ListTag(TagType.End);
            }

            for (int i = 0; i < length; i++)
            {
                switch (tagType)
                {
                    case TagType.Byte:
                        Value.Add(new ByteTag().Read(stream, false));
                        break;
                    case TagType.Short:
                        Value.Add(new ShortTag().Read(stream, false));
                        break;
                    case TagType.Int:
                        Value.Add(new IntTag().Read(stream, false));
                        break;
                    case TagType.Long:
                        Value.Add(new LongTag().Read(stream, false));
                        break;
                    case TagType.Float:
                        Value.Add(new FloatTag().Read(stream, false));
                        break;
                    case TagType.Double:
                        Value.Add(new DoubleTag().Read(stream, false));
                        break;
                    case TagType.ByteArray:
                        Value.Add(new ByteArrayTag().Read(stream, false));
                        break;
                    case TagType.String:
                        Value.Add(new StringTag().Read(stream, false));
                        break;
                    case TagType.List:
                        Value.Add(new ListTag(TagType.End).Read(stream, false)); // type doesn't matter since the list will read its own type
                        break;
                    case TagType.Compound:
                        Value.Add(new CompoundTag().Read(stream, false));
                        break;
                    case TagType.IntArray:
                        Value.Add(new IntArrayTag().Read(stream, false));
                        break;
                    case TagType.LongArray:
                        Value.Add(new LongArrayTag().Read(stream, false));
                        break;
                    default:
                        throw new NbtException($"Invalid NBT: Unknown tag type {tagType} in List Tag.");   
                }
            }

            return this;
        }

        public int Count => Value.Count;

        public bool IsReadOnly => false;

        public NbtTag this[int index]
        {
            get => Value[index];
            set => Value[index] = value;
        }

        public void Add(NbtTag item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            // Prevent creating a cycle by adding an ancestor as a child
            for (NbtTag? p = this; p != null; p = p.Parent)
            {
                if (p == item) throw new NbtException("Cannot add an ancestor as a child.");
            }

            // Count how many ListTag ancestors this list already has (including this)
            int ancestorListCount = 0;
            for (NbtTag? p = this; p != null; p = p.Parent)
            {
                if (p is ListTag) ancestorListCount++;
            }

            // Determine the maximum nested list depth inside the item being added
            int itemListDepth = GetMaxNestedListDepth(item);

            // If adding the item would make the total list nesting exceed 5, reject it
            if (ancestorListCount + itemListDepth > 5)
            {
                throw new NbtException("A list tag cannot be nested more than 5 levels deep.");
            }

            item.Parent = this;
            Value.Add(item);
        }

        private static int GetMaxNestedListDepth(NbtTag tag)
        {
            if (tag is not ListTag lt) return 0;

            int maxChildDepth = 0;
            if (lt.Value != null)
            {
                foreach (var child in lt.Value)
                {
                    maxChildDepth = Math.Max(maxChildDepth, GetMaxNestedListDepth(child));
                }
            }

            return 1 + maxChildDepth;
        }

        /// <summary>
        /// Removes the first element that matches the provided value.
        /// </summary>
        /// <param name="b"></param>
        public bool Remove(NbtTag item)
        {
            return Value.Remove(item);
        }

        public void RemoveAt(int index)
        {
            Value.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Value.GetEnumerator();
        }

        public int IndexOf(NbtTag item)
        {
            return Value.IndexOf(item); 
        }

        public void Insert(int index, NbtTag item)
        {
            Value.Insert(index, item);
        }

        public void Clear()
        {
            Value.Clear();
        }

        public bool Contains(NbtTag item)
        {
            return Value.Contains(item);
        }

        public void CopyTo(NbtTag[] array, int arrayIndex)
        {
            Value.CopyTo(array, arrayIndex);
        }

        IEnumerator<NbtTag> IEnumerable<NbtTag>.GetEnumerator()
        {
            return Value.GetEnumerator();
        }
    }
}
