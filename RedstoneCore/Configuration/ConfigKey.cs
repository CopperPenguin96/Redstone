namespace Redstone.Core.Configuration
{
    public class ConfigKey<T> : IConfigKey
    {
        protected readonly Dictionary<string, object> Properties = [];

        public string Key { get; set; }

        public T Value { get; set; }

        public T DefaultValue
        {
            get
            {
                if (ContainsProperty("default"))
                {
                    return (T)Properties["default"];
                }
                else
                {
                    throw new Exception("Default value not set.");
                }
            }
            protected set
            {
                Properties["default"] = value!;
            }
        }

        public void SetDefault()
        {
            if (Properties.TryGetValue("default", out object? value))
            {
                Value = (T)value;
            }
        }

        protected bool ContainsProperty(string name)
        {
            return Properties.ContainsKey(name);
        }

        public ConfigKey(string key, T defaultValue)
        {
            Key = key;
            DefaultValue = defaultValue;
            Value = defaultValue;
        }

        public object ValueAsObject() => Value!;

        public string ValueAsString() => Value?.ToString() ?? string.Empty;

        public int ValueAsInt() => Convert.ToInt32(Value);

        public bool ValueAsBool() => Convert.ToBoolean(Value);

        public long ValueAsLong() => Convert.ToInt64(Value);

        public ushort ValueAsUShort() => Convert.ToUInt16(Value);

        public byte ValueAsByte() => Convert.ToByte(Value);

        public uint ValueAsUInt() => Convert.ToUInt32(Value);
    }

    public class ConfigString(string key, string defaultValue) : ConfigKey<string>(key, defaultValue)
    {
        public uint MinLength
        {
            get
            {
                if (ContainsProperty("min")) return (uint)Properties["min"];
                else return uint.MinValue;
            }
            set
            {
                Properties["min"] = value;
            }
        }

        public uint MaxLength
        {
            get
            {
                if (ContainsProperty("max")) return (uint)Properties["max"];
                else return uint.MaxValue;
            }
            set
            {
                Properties["max"] = value;
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }

    }

    public class ConfigInt(string key, int defaultValue) : ConfigKey<int>(key, defaultValue)
    {
        public int MinValue
        {
            get
            {
                if (ContainsProperty("min")) return (int)Properties["min"];
                else return int.MinValue;
            }
            set
            {
                Properties["min"] = value;
            }
        }

        public int MaxValue
        {
            get
            {
                if (ContainsProperty("max")) return (int)Properties["max"];
                else return int.MaxValue;
            }
            set
            {
                Properties["max"] = value;
            }
        }
    }

    public class ConfigLong(string key, long defaultValue) : ConfigKey<long>(key, defaultValue)
    {
        public long MinValue
        {
            get
            {
                if (ContainsProperty("min")) return (long)Properties["min"];
                else return long.MinValue;
            }
            set
            {
                Properties["min"] = value;
            }
        }

        public long MaxValue
        {
            get
            {
                if (ContainsProperty("max")) return (long)Properties["max"];
                else return long.MaxValue;
            }
            set
            {
                Properties["max"] = value;
            }
        }
    }

    public class ConfigUShort(string key, ushort defaultValue) : ConfigKey<ushort>(key, defaultValue)
    {
        public ushort MinValue
        {
            get
            {
                if (ContainsProperty("min")) return (ushort)Properties["min"];
                else return ushort.MinValue;
            }
            set
            {
                Properties["min"] = value;
            }
        }

        public ushort MaxValue
        {
            get
            {
                if (ContainsProperty("max")) return (ushort)Properties["max"];
                else return ushort.MaxValue;
            }
            set
            {
                Properties["max"] = value;
            }
        }
    }

    public class ConfigByte(string key, byte defaultValue) : ConfigKey<byte>(key, defaultValue)
    {
        public byte MinValue
        {
            get
            {
                if (ContainsProperty("min")) return (byte)Properties["min"];
                else return byte.MinValue;
            }
            set
            {
                Properties["min"] = value;
            }
        }

        public byte MaxValue
        {
            get
            {
                if (ContainsProperty("max")) return (byte)Properties["max"];
                else return byte.MaxValue;
            }
            set
            {
                Properties["max"] = value;
            }
        }
    }

    public class ConfigUInt(string key, uint defaultValue) : ConfigKey<uint>(key, defaultValue)
    {
        public uint MinValue
        {
            get
            {
                if (ContainsProperty("min")) return (uint)Properties["min"];
                else return uint.MinValue;
            }
            set
            {
                Properties["min"] = value;
            }
        }

        public uint MaxValue
        {
            get
            {
                if (ContainsProperty("max")) return (uint)Properties["max"];
                else return uint.MaxValue;
            }
            set
            {
                Properties["max"] = value;
            }
        }
    }
}
