using Redstone.Core.World;
using Tomlyn.Model;

namespace Redstone.Core.Configuration.Sections
{
    internal class WorldConfig : ConfigSection
    {
        public WorldConfig() : base("world")
        {
            AddKey(GenerateStructures);
            AddKey(GeneratorSettings);
            AddKey(SpawnLevelName);
            AddKey(SpawnLevelSeed);
            AddKey(SpawnLevelType);
            AddKey(MaxWorldSize);
            AddKey(SpawnProtection);
            AddKey(ViewDistance);
        }

        public readonly ConfigKey<bool> GenerateStructures = new(_genstrname, true);

        public readonly ConfigKey<GeneratorSettings> GeneratorSettings = new(_gensetname, new GeneratorSettings());

        public readonly ConfigString SpawnLevelName = new(_levelname, "world")
        {
            MinLength = 1,
            MaxLength = 64
        };

        public readonly ConfigString SpawnLevelSeed = new(_seedname, string.Empty)
        {
            MinLength = 0,
            MaxLength = 128
        };

        public readonly ConfigKey<LevelType> SpawnLevelType = new(_typename, LevelType.Normal);

        public readonly ConfigInt MaxWorldSize = new(_maxname, 29999984)
        {
            MinValue = 1,
            MaxValue = 29999984
        };

        public readonly ConfigUInt SpawnProtection = new(_spawnname, 16);

        public readonly ConfigByte ViewDistance = new(_viewname, 10)
        {
            MinValue = 3,
            MaxValue = 32
        };

        public override TomlTable TomlTable()
        {
            TomlTable table = new TomlTable
            {
                [_genstrname] = GenerateStructures.Value,
                [_gensetname] = GeneratorSettings.Value.ToString(),
                [_levelname] = SpawnLevelName.Value,
                [_seedname] = SpawnLevelSeed.Value,
                [_typename] = LevelType.Normal.ToString(),
                [_maxname] = MaxWorldSize.Value,
                [_spawnname] = SpawnProtection.Value,
                [_viewname] = ViewDistance.Value
            };

            foreach (IConfigKey key in Unrecognized)
            {
                table.Add(key.Key, key.ValueAsObject());
            }

            return table;
        }

        public override void Load(TomlTable table)
        {
            foreach (string key in table.Keys)
            {
                switch (key)
                {
                    case _genstrname:
                        GenerateStructures.Value = (bool)table[_genstrname];
                        break;
                    case _gensetname:
                        GeneratorSettings.Value = World.GeneratorSettings.Parse((string)table[_gensetname]);
                        break;
                    case _levelname:
                        SpawnLevelName.Value = (string)table[_levelname];
                        break;
                    case _seedname:
                        SpawnLevelSeed.Value = (string)table[_seedname];
                        break;
                    case _typename:
                        SpawnLevelType.Value = LevelType.Parse((string)table[_typename]);
                        break;
                    case _maxname:
                        MaxWorldSize.Value = (int)(long)table[_maxname];
                        break;
                    case _spawnname:
                        SpawnProtection.Value = (uint)(long)table[_spawnname];
                        break;
                    case _viewname:
                        ViewDistance.Value = (byte)(long)table[_viewname];
                        break;
                    default:
                        UnrecognizedKeyWarning(key);
                        Unrecognized.Add(new ConfigKey<object>(key, table[key]));
                        break;
                }
            }
        }

        private const string _genstrname = "generate-structures";
        private const string _gensetname = "generator-settings";
        private const string _levelname = "level-name";
        private const string _seedname = "level-seed";
        private const string _typename = "level-type";
        private const string _maxname = "max-world-size";
        private const string _spawnname = "spawn-protection";
        private const string _viewname = "view-distance";
    }
}
