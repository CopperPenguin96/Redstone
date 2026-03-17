using System.Collections;
using System.Text;
using System.Globalization;

namespace Redstone.Nbt.Tags
{
    public class CompoundTag : NbtTag, IList<NbtTag>
    {
        public override TagType Type => TagType.Compound;

        public new List<NbtTag> Value
        {
            get => (List<NbtTag>)base.Value;
            set => base.Value = value;
        }

        public CompoundTag() : base(null!, null!) { }

        public CompoundTag(string name) : base(name, null!) { }

        public CompoundTag(string name, List<NbtTag> value) : base(name, value) { }

        public CompoundTag(string name, CompoundTag value) : base(name, value.Value) { }

        public override void WriteToStream(Stream stream, bool writeHeaders = true)
        {
            if (writeHeaders) WriteHeader(stream);

            foreach (NbtTag tag in Value)
            {
                tag.WriteToStream(stream);
            }

            new EndTag().WriteToStream(stream); // End tag to signify end of compound
        }

        public override CompoundTag Read(Stream stream, bool readHeaders = true)
        {
            Value = new List<NbtTag>();
            if (readHeaders) ReadHeader(stream);

            bool endReached = false;

            while (!endReached)
            {
                NbtTag tag = ReadTag(stream);
                if (tag is EndTag)
                {
                    endReached = true;
                }
                else
                {
                    Value.Add(tag);
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
            item.Parent = this;
            Value.Add(item);
        }

        public void Add(string name, byte b)
        {
            Add(new ByteTag(name, b));
        }

        public void Add(string name, bool b)
        {
            Add(new BoolTag(name, b));
        }

        public void Add(string name, short s)
        {
            Add(new ShortTag(name, s));
        }

        public void Add(string name, int i)
        {
            Add(new IntTag(name, i));
        }

        public void Add(string name, long l)
        {
            Add(new LongTag(name, l));
        }

        public void Add(string name, float f)
        {
            Add(new FloatTag(name, f));
        }

        public void Add(string name, double d)
        {
            Add(new DoubleTag(name, d));
        }

        public void Add(string name, string s)
        {
            Add(new StringTag(name, s));
        }

        public void Add(string name, List<NbtTag> l)
        {
            Add(new CompoundTag(name, l));
        }

        public void Add(string name, CompoundTag c)
        {
            Add(new CompoundTag(name, c));
        }

        public void Add(string name, byte[] bArr)
        {
            Add(new ByteArrayTag(name, bArr));
        }

        public void Add(string name, int[] iArr)
        {
            Add(new IntArrayTag(name, iArr));
        }

        public void Add(string name, long[] lArr)
        {
            Add(new LongArrayTag(name, lArr));
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

        /// <summary>
        /// Parse SNBT into a CompoundTag. Accepts a SNBT string that represents a compound (root must be a compound).
        /// </summary>
        public static CompoundTag ParseSnbt(string snbt, string? name = null)
        {
            var p = new SnbtParser(snbt);
            var comp = p.ParseCompound();
            if (!string.IsNullOrEmpty(name)) comp.Name = name!;
            return comp;
        }

        private class SnbtParser
        {
            private readonly string _s;
            private int _i;

            public SnbtParser(string s)
            {
                _s = s ?? string.Empty;
                _i = 0;
            }

            private void SkipWhitespace()
            {
                while (_i < _s.Length && char.IsWhiteSpace(_s[_i])) _i++;
            }

            private char Peek() => _i < _s.Length ? _s[_i] : '\0';
            private char Next() => _i < _s.Length ? _s[_i++] : '\0';
            private bool TryConsume(char c)
            {
                SkipWhitespace();
                if (Peek() == c) { _i++; return true; }
                return false;
            }

            public CompoundTag ParseCompound()
            {
                SkipWhitespace();
                if (!TryConsume('{')) throw new NbtException(new FormatException("Expected '{' at start of compound"));

                var comp = new CompoundTag();
                comp.Value = new List<NbtTag>();

                SkipWhitespace();
                if (TryConsume('}')) return comp; // empty

                while (true)
                {
                    SkipWhitespace();
                    string key = ParseKey();
                    SkipWhitespace();
                    if (!TryConsume(':')) throw new NbtException(new FormatException("Expected ':' after key in compound"));
                    SkipWhitespace();
                    var tag = ParseElement();
                    tag.Name = key;
                    comp.Value.Add(tag);

                    SkipWhitespace();
                    if (TryConsume(',')) { continue; }
                    if (TryConsume('}')) break;
                    throw new NbtException(new FormatException("Expected ',' or '}' in compound"));
                }

                return comp;
            }

            private string ParseKey()
            {
                SkipWhitespace();
                if (Peek() == '"') return ParseString();

                // unquoted key: read until whitespace or ':' or ',' or '}'
                var sb = new StringBuilder();
                while (_i < _s.Length)
                {
                    char c = Peek();
                    if (char.IsWhiteSpace(c) || c == ':' || c == ',' || c == '}') break;
                    sb.Append(Next());
                }
                return sb.ToString();
            }

            private string ParseString()
            {
                if (Next() != '"') throw new NbtException(new FormatException("Expected '" + '"' + " to start string"));
                var sb = new StringBuilder();
                while (_i < _s.Length)
                {
                    char c = Next();
                    if (c == '\\')
                    {
                        if (_i >= _s.Length) break;
                        char esc = Next();
                        switch (esc)
                        {
                            case '"': sb.Append('"'); break;
                            case '\\': sb.Append('\\'); break;
                            case 'n': sb.Append('\n'); break;
                            case 'r': sb.Append('\r'); break;
                            case 't': sb.Append('\t'); break;
                            default: sb.Append(esc); break;
                        }
                    }
                    else if (c == '"')
                    {
                        return sb.ToString();
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                throw new NbtException(new FormatException("Unterminated string"));
            }

            private NbtTag ParseElement()
            {
                SkipWhitespace();
                char c = Peek();
                if (c == '"')
                {
                    var s = ParseString();
                    return new StringTag(null, s);
                }
                if (c == '{')
                {
                    return ParseCompound();
                }
                if (c == '[')
                {
                    // could be typed array or list
                    int save = _i;
                    _i++; // consume '['
                    SkipWhitespace();
                    char t = Peek();
                    if ((t == 'B' || t == 'I' || t == 'L' || t == 'b' || t == 'i' || t == 'l') && _i + 1 < _s.Length && _s[_i + 1] == ';')
                    {
                        // typed array
                        char typeChar = Next(); // B/I/L
                        _i++; // consume ';'
                        SkipWhitespace();
                        if (typeChar == 'B' || typeChar == 'b')
                        {
                            var list = new List<byte>();
                            if (TryConsume(']')) return new ByteArrayTag(null, list.ToArray());
                            while (true)
                            {
                                SkipWhitespace();
                                string numToken = ParseBareToken();
                                // allow suffix 'b'
                                if (numToken.EndsWith("b", StringComparison.OrdinalIgnoreCase)) numToken = numToken[..^1];
                                if (byte.TryParse(numToken, NumberStyles.Integer, CultureInfo.InvariantCulture, out var bv)) list.Add(bv);
                        else throw new NbtException(new FormatException("Invalid byte in byte array"));
                                SkipWhitespace();
                                if (TryConsume(',')) continue;
                                if (TryConsume(']')) break;
                        throw new NbtException(new FormatException("Expected ',' or ']' in byte array"));
                            }
                            return new ByteArrayTag(null, list.ToArray());
                        }
                        else if (typeChar == 'I' || typeChar == 'i')
                        {
                            var list = new List<int>();
                            if (TryConsume(']')) return new IntArrayTag(null, list.ToArray());
                            while (true)
                            {
                                SkipWhitespace();
                                string numToken = ParseBareToken();
                                if (int.TryParse(numToken, NumberStyles.Integer, CultureInfo.InvariantCulture, out var iv)) list.Add(iv);
                                else throw new NbtException(new FormatException("Invalid int in int array"));
                                SkipWhitespace();
                                if (TryConsume(',')) continue;
                                if (TryConsume(']')) break;
                                throw new NbtException(new FormatException("Expected ',' or ']' in int array"));
                            }
                            return new IntArrayTag(null, list.ToArray());
                        }
                        else // L
                        {
                            var list = new List<long>();
                            if (TryConsume(']')) return new LongArrayTag(null, list.ToArray());
                            while (true)
                            {
                                SkipWhitespace();
                                string numToken = ParseBareToken();
                                if (numToken.EndsWith("L", StringComparison.OrdinalIgnoreCase)) numToken = numToken[..^1];
                                if (long.TryParse(numToken, NumberStyles.Integer, CultureInfo.InvariantCulture, out var lv)) list.Add(lv);
                                else throw new NbtException(new FormatException("Invalid long in long array"));
                                SkipWhitespace();
                                if (TryConsume(',')) continue;
                                if (TryConsume(']')) break;
                                throw new NbtException(new FormatException("Expected ',' or ']' in long array"));
                            }
                            return new LongArrayTag(null, list.ToArray());
                        }
                    }
                    else
                    {
                        // reset and parse as list
                        _i = save;
                        return ParseList();
                    }
                }

                // number, boolean? treat as number
                string token = ParseBareToken();
                // check suffix
                if (token.EndsWith("b", StringComparison.OrdinalIgnoreCase) && byte.TryParse(token[..^1], NumberStyles.Integer, CultureInfo.InvariantCulture, out var bb))
                {
                    return new ByteTag(null, bb);
                }
                if (token.EndsWith("s", StringComparison.OrdinalIgnoreCase) && short.TryParse(token[..^1], NumberStyles.Integer, CultureInfo.InvariantCulture, out var ss))
                {
                    return new ShortTag(null, ss);
                }
                if ((token.EndsWith("l", StringComparison.OrdinalIgnoreCase) && long.TryParse(token[..^1], NumberStyles.Integer, CultureInfo.InvariantCulture, out var ll)) )
                {
                    return new LongTag(null, ll);
                }
                if (token.EndsWith("f", StringComparison.OrdinalIgnoreCase) && float.TryParse(token[..^1], NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var ff))
                {
                    return new FloatTag(null, ff);
                }
                if (token.EndsWith("d", StringComparison.OrdinalIgnoreCase) && double.TryParse(token[..^1], NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var dd))
                {
                    return new DoubleTag(null, dd);
                }

                // no suffix: determine if float/double by '.' or exponent
                if (token.IndexOfAny(new[] {'.','e','E'}) >= 0)
                {
                    if (double.TryParse(token, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var dval))
                        return new DoubleTag(null, dval);
                }
                else
                {
                    if (int.TryParse(token, NumberStyles.Integer, CultureInfo.InvariantCulture, out var ival))
                        return new IntTag(null, ival);
                }

                throw new NbtException(new FormatException($"Unrecognized token: {token}"));
            }

            private NbtTag ParseList()
            {
                if (!TryConsume('[')) throw new NbtException(new FormatException("Expected '[' to start list"));
                var items = new List<NbtTag>();
                SkipWhitespace();
                if (TryConsume(']')) return new ListTag(TagType.End) { Value = items }; // empty

                while (true)
                {
                    var el = ParseElement();
                    // elements in list should not have names
                    el.Name = null!;
                    items.Add(el);
                    SkipWhitespace();
                    if (TryConsume(',')) continue;
                    if (TryConsume(']')) break;
                    throw new NbtException(new FormatException("Expected ',' or ']' in list"));
                }

                // Determine list type
                TagType listType = items.Count > 0 ? items[0].Type : TagType.End;
                var listTag = new ListTag(listType) { Value = items };
                return listTag;
            }

            private string ParseBareToken()
            {
                SkipWhitespace();
                var sb = new StringBuilder();
                while (_i < _s.Length)
                {
                    char c = Peek();
                    if (char.IsWhiteSpace(c) || c == ',' || c == ']' || c == '}' || c == ':') break;
                    sb.Append(Next());
                }
                return sb.ToString();
            }
        }

        public override string ToString()
        {
            // Return SNBT representation for this compound. If the compound has a name, include it.
            string snbt = FormatTag(this);
            if (!string.IsNullOrEmpty(Name))
            {
                return $"\"{EscapeString(Name)}\":{snbt}";
            }

            return snbt;
        }

        private string EscapeString(string s)
        {
            return s.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "\\r").Replace("\t", "\\t");
        }

        private string FormatTag(NbtTag tag)
        {
            switch (tag.Type)
            {
                case TagType.Byte:
                    return ((ByteTag)tag).Value + "b";
                case TagType.Short:
                    return ((ShortTag)tag).Value + "s";
                case TagType.Int:
                    return ((IntTag)tag).Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
                case TagType.Long:
                    return ((LongTag)tag).Value + "L";
                case TagType.Float:
                    return ((FloatTag)tag).Value.ToString(System.Globalization.CultureInfo.InvariantCulture) + "f";
                case TagType.Double:
                    return ((DoubleTag)tag).Value.ToString(System.Globalization.CultureInfo.InvariantCulture) + "d";
                case TagType.String:
                    return "\"" + EscapeString(((StringTag)tag).Value) + "\"";
                case TagType.ByteArray:
                    var bArr = ((ByteArrayTag)tag).Value;
                    return "[B;" + string.Join(",", bArr.Select(b => b + "b")) + "]";
                case TagType.IntArray:
                    var iArr = ((IntArrayTag)tag).Value;
                    return "[I;" + string.Join(",", iArr.Select(i => i.ToString(System.Globalization.CultureInfo.InvariantCulture))) + "]";
                case TagType.LongArray:
                    var lArr = ((LongArrayTag)tag).Value;
                    return "[L;" + string.Join(",", lArr.Select(l => l + "L")) + "]";
                case TagType.List:
                    var list = (ListTag)tag;
                    var elems = list.Value?.Select(t => FormatTag(t)) ?? Enumerable.Empty<string>();
                    return "[" + string.Join(",", elems) + "]";
                case TagType.Compound:
                    var comp = (CompoundTag)tag;
                    var parts = comp.Value?.Select(t =>
                    {
                        string key = t.Name != null ? ("\"" + EscapeString(t.Name) + "\"") : "\"\"";
                        return key + ":" + FormatTag(t);
                    }) ?? Enumerable.Empty<string>();
                    return "{" + string.Join(",", parts) + "}";
                case TagType.End:
                default:
                    return "";
            }
        }
    }
}
