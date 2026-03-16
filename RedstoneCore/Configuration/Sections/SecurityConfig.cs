using Tomlyn.Model;

namespace Redstone.Core.Configuration.Sections
{
    internal class SecurityConfig : ConfigSection
    {
        public SecurityConfig() : base("security")
        {
            AddKey(EnforceSecureProfile);
            AddKey(EnforceWhitelist);
            AddKey(LogIps);
            AddKey(PreventProxy);
            AddKey(EnableWhitelist);
        }

        public readonly ConfigKey<bool> EnforceSecureProfile = new(_enfsecname, true);

        public readonly ConfigKey<bool> LogIps = new(_logipname, true);

        public readonly ConfigKey<bool> PreventProxy = new(_prevproxname, false);

        // Whitelist
        public readonly ConfigKey<bool> EnforceWhitelist = new(_enfwhitename, false);

        public readonly ConfigKey<bool> EnableWhitelist = new(_whitename, false);

        public override TomlTable TomlTable()
        {
            TomlTable table = new TomlTable
            {
                [_enfsecname] = EnforceSecureProfile.Value,
                [_logipname] = LogIps.Value,
                [_prevproxname] = PreventProxy.Value,
                [_enfwhitename] = EnforceWhitelist.Value,
                [_whitename] = EnableWhitelist.Value
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
                    case _enfsecname:
                        EnforceSecureProfile.Value = (bool)table[_enfsecname];
                        break;
                    case _logipname:
                        LogIps.Value = (bool)table[_logipname];
                        break;
                    case _prevproxname:
                        PreventProxy.Value = (bool)table[_prevproxname];
                        break;
                    case _enfwhitename:
                        EnforceWhitelist.Value = (bool)table[_enfwhitename];
                        break;
                    case _whitename:
                        EnableWhitelist.Value = (bool)table[_whitename];
                        break;
                    default:
                        UnrecognizedKeyWarning(key);
                        Unrecognized.Add(new ConfigKey<object>(key, table[key]));
                        break;
                }
            }
        }

        private const string _enfsecname = "enforce-secure-profile";
        private const string _logipname = "log-ips";
        private const string _prevproxname = "prevent-proxy-connections";
        private const string _enfwhitename = "enforce-whitelist";
        private const string _whitename = "white-list";
    }
}
