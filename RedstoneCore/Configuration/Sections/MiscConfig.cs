using Tomlyn.Model;

namespace Redstone.Core.Configuration.Sections
{
    internal class MiscConfig : ConfigSection
    {
        public MiscConfig() : base("misc")
        {
            AddKey(AllowFlight);
            AddKey(InitialDisabledPacks);
            AddKey(InitialEnabledPacks);
            AddKey(RequireResourcePack);
            AddKey(ResourcePackUrl);
            AddKey(ResourcePackId);
            AddKey(ResourcePackSha1);
            AddKey(ResourcePackPrompt);
        }

        public readonly ConfigKey<bool> AllowFlight = new(_flightname, false);

        public readonly ConfigKey<string[]> InitialDisabledPacks = new(_dispacksname, []);

        public readonly ConfigKey<string[]> InitialEnabledPacks = new(_enabpacksname, ["vanilla"]);

        public readonly ConfigKey<bool> RequireResourcePack = new(_reqresname, false);

        public readonly ConfigString ResourcePackUrl = new(_resname, string.Empty);

        public readonly ConfigString ResourcePackId = new(_packidname, string.Empty);

        public readonly ConfigString ResourcePackSha1 = new(_sha1name, string.Empty);

        public readonly ConfigString ResourcePackPrompt = new(_promptname, string.Empty)
        {
            MaxLength = 128
        };

        public override TomlTable TomlTable()
        {
            TomlTable table = new TomlTable
            {
                [_flightname] = AllowFlight.Value,
                [_dispacksname] = InitialDisabledPacks.Value,
                [_enabpacksname] = InitialEnabledPacks.Value,
                [_reqresname] = RequireResourcePack.Value,
                [_resname] = ResourcePackUrl.Value,
                [_packidname] = ResourcePackId.Value,
                [_sha1name] = ResourcePackSha1.Value,
                [_promptname] = ResourcePackPrompt.Value
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
                    case _flightname:
                        AllowFlight.Value = (bool)table[_flightname];
                        break;
                    case _dispacksname:
                        InitialDisabledPacks.Value = [.. (table[_dispacksname] as TomlArray)!.Select(x => x!.ToString())!];
                        break;
                    case _enabpacksname:
                        InitialEnabledPacks.Value = [.. (table[_enabpacksname] as TomlArray)!.Select(x => x!.ToString())!];
                        break;
                    case _reqresname:
                        RequireResourcePack.Value = (bool)table[_reqresname];
                        break;
                    case _resname:
                        ResourcePackUrl.Value = (string)table[_resname];
                        break;
                    case _packidname:
                        ResourcePackId.Value = (string)table[_packidname];
                        break;
                    case _sha1name:
                        ResourcePackSha1.Value = (string)table[_sha1name];
                        break;
                    case _promptname:
                        ResourcePackPrompt.Value = (string)table[_promptname];
                        break;
                    default:
                        UnrecognizedKeyWarning(key);
                        Unrecognized.Add(new ConfigKey<object>(key, table[key]));
                        break;
                }
            }
        }

        private const string _flightname = "allow-flight";
        private const string _dispacksname = "initial-disabled-packs";
        private const string _enabpacksname = "initial-enabled-packs";
        private const string _reqresname = "require-resource-pack";
        private const string _resname = "resource-pack";
        private const string _packidname = "resource-pack-id";
        private const string _sha1name = "resource-pack-sha1";
        private const string _promptname = "resource-pack-prompt";
    }
}
