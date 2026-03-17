using System.Text;

namespace Redstone.Nbt.Tags
{
    public abstract class NbtTag
    {
        public NbtTag Parent { get; internal set; }

        public abstract TagType Type { get; }

        public string Name { get; set; }

        public virtual object Value { get; set; }

        protected NbtTag(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public abstract void WriteToStream(Stream stream, bool writeHeaders = true);

        public abstract NbtTag Read(Stream stream, bool readHeaders = true);

        protected NbtReader _reader;
        protected TagType _readType;
        protected void ReadHeader(Stream stream, bool readName = true)
        {
            _reader = new NbtReader(stream);

            _readType = (TagType)_reader.ReadByte();
            if (_readType != Type) throw new NbtException("NBT Tag Type mix-match");

            if (_readType == TagType.End) return;

            if (readName)
            {
                Name = _reader.ReadString();
            }
        }

        public NbtTag ReadTag(Stream stream, bool readHeaders = true)
        {
            ReadHeader(stream);

            return this;
        }

        public static NbtTag ReadFromStream(Stream stream, bool readHeaders = true)
        {
            NbtReader reader = new(stream);
            TagType type = (TagType)reader.ReadByte();
            if (type == TagType.End) return new EndTag();
            string name = reader.ReadString();
            NbtTag tag = type switch
            {
                TagType.Byte => new ByteTag(name, 0),
                TagType.Short => new ShortTag(name, 0),
                TagType.Int => new IntTag(name, 0),
                TagType.Long => new LongTag(name, 0L),
                TagType.Float => new FloatTag(name, 0f),
                TagType.Double => new DoubleTag(name, 0d),
                TagType.ByteArray => new ByteArrayTag(name, []),
                TagType.String => new StringTag(name, string.Empty),
                TagType.List => new ListTag(name, TagType.End), // List type will be read in the constructor
                TagType.Compound => new CompoundTag(name),
                TagType.IntArray => new IntArrayTag(name, []),
                TagType.LongArray => new LongArrayTag(name, []),
                _ => throw new NbtException($"Unknown NBT tag type: {type}")
            };
            tag.Read(stream, false);
            return tag;
        }


        public void WriteHeader(Stream stream)
        {
            stream.WriteByte((byte)Type);

            if (Type == TagType.End) return;

            if (Name != null)
            {
                byte[] nameLengthBytes = BitConverter.GetBytes((ushort)Name.Length);
                if (NbtReader.IsBigEndian) Array.Reverse(nameLengthBytes);
                byte[] nameBytes = Encoding.UTF8.GetBytes(Name);

                stream.Write(nameLengthBytes);
                stream.Write(nameBytes);
            }
        }

        public string GetTagName() => Type switch
        {
            TagType.End => "TAG_End",
            TagType.Byte => "TAG_Byte",
            TagType.Short => "TAG_Short",
            TagType.Int => "TAG_Int",
            TagType.Long => "TAG_Long",
            TagType.Float => "TAG_Float",
            TagType.Double => "TAG_Double",
            TagType.ByteArray => "TAG_Byte_Array",
            TagType.String => "TAG_String",
            TagType.List => "TAG_List",
            TagType.Compound => "TAG_Compound",
            TagType.IntArray => "TAG_Int_Array",
            TagType.LongArray => "TAG_Long_Array",
            _ => "TAG_Unknown"
        };

        public string PrettyPrint()
        {
            string header = $"{GetTagName()}('{Name}'):";

            if (Type == TagType.Compound || Type == TagType.List)
            {
                List<NbtTag> val = (List<NbtTag>)Value;

                header += " " + val.Count + " entries\n";
                header += "{\n";
                foreach (NbtTag tag in val)
                {
                    string[] lines = tag.PrettyPrint().Split('\n');
                    foreach (string line in lines)
                    {
                        header += "  " + line + "\n";
                    }
                }
                header += "}\n";
            }
            else
            {
                switch (Type)
                {
                    case TagType.Byte:
                    case TagType.Short:
                    case TagType.Int:
                    case TagType.Long:
                    case TagType.Float:
                    case TagType.Double:
                    case TagType.String:
                        header += " " + Value.ToString();
                        break;
                    case TagType.ByteArray:
                        header += " [" + ((byte[])Value).Length + " bytes]";
                        break;
                    case TagType.IntArray:
                        header += " [" + ((int[])Value).Length + " ints]";
                        break;
                    case TagType.LongArray:
                        header += " [" + ((long[])Value).Length + " longs]";
                        break;
                }
            }

            return header;
        }

        /// <summary>
        /// Return the NBT path string for this tag, relative to the root ancestor.
        /// Uses dot-separated compound keys and list index selectors (e.g. "level.Entities[0].Pos").
        /// Names that contain characters that would need quoting are quoted with double-quotes
        /// and backslashes/quotes are escaped.
        /// </summary>
        public string NbtPath
        {
            get
            {
                var parts = new List<string>();

                for (NbtTag? current = this; current != null && current.Parent != null; current = current.Parent)
                {
                    var parent = current.Parent;
                    if (parent is ListTag listParent)
                    {
                        int idx = listParent.IndexOf(current);
                        parts.Add($"[{idx}]");
                    }
                    else if (parent is CompoundTag)
                    {
                        var name = current.Name ?? string.Empty;
                        bool needQuote = string.IsNullOrEmpty(name) || name.Any(c => char.IsWhiteSpace(c) || c == ':' || c == ',' || c == '{' || c == '}' || c == '[' || c == ']' || c == '.');
                        if (needQuote)
                        {
                            name = '"' + EscapePathString(name) + '"';
                        }
                        parts.Add('.' + name);
                    }
                    else
                    {
                        // Generic parent: fallback to name if present
                        if (!string.IsNullOrEmpty(current.Name)) parts.Add('.' + current.Name);
                    }
                }

                parts.Reverse();
                var path = string.Concat(parts);
                if (path.StartsWith('.')) path = path.Substring(1);
                return path;
            }
        }

        private static string EscapePathString(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            var sb = new StringBuilder();
            foreach (var c in s)
            {
                if (c == '\\' || c == '"') sb.Append('\\');
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
