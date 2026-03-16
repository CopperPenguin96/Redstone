using Redstone.Core.Logging;
using Tomlyn.Model;

namespace Redstone.Core.Configuration.Sections
{
    public abstract class ConfigSection(string name)
    {
        public string Name { get; private set; } = name;

        public byte Index { get; internal set; }

        public readonly List<IConfigKey> Keys = [];

        public readonly List<IConfigKey> Unrecognized = [];

        public void AddKey<T>(ConfigKey<T> key)
        {
            Keys.Add(key);
        }

        public IConfigKey GetKey(string key)
        {
            foreach (var kv in Keys)
            {
                if (kv.Key.Equals(key)) return kv;
            }

            return null!;
        }

        protected void UnrecognizedKeyWarning(string key)
        {
            Logger.LogWarning($"Unrecognized config key found in {Name}: {key}. Will be kept but may not have any effect.");
        }

        public abstract TomlTable TomlTable();

        public abstract void Load(TomlTable table);
    }
}
