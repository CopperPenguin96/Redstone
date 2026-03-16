using Tomlyn.Model;

namespace Redstone.Core.Configuration.Sections
{
    internal class PlayerConfig : ConfigSection
    {
        public PlayerConfig() : base("player")
        {
            AddKey(HideOnlinePlayers);
            AddKey(OnlineMode);
            AddKey(OpPermLevel);
            AddKey(IdleTimeout);
        }

        public readonly ConfigKey<bool> HideOnlinePlayers = new(_hideonlname, false);

        public readonly ConfigKey<bool> OnlineMode = new(_onlmodename, true);

        public readonly ConfigByte OpPermLevel = new(_oppermname, 4)
        {
            MaxValue = 4
        };

        public readonly ConfigUInt IdleTimeout = new(_plidlename, 0);

        public override TomlTable TomlTable()
        {
            TomlTable table = new TomlTable
            {
                [_hideonlname] = HideOnlinePlayers.Value,
                [_onlmodename] = OnlineMode.Value,
                [_oppermname] = OpPermLevel.Value,
                [_plidlename] = IdleTimeout.Value
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
                    case _hideonlname:
                        HideOnlinePlayers.Value = (bool)table[_hideonlname];
                        break;
                    case _onlmodename:
                        OnlineMode.Value = (bool)table[_onlmodename];
                        break;
                    case _oppermname:
                        OpPermLevel.Value = (byte)(long)table[_oppermname];
                        break;
                    case _plidlename:
                        IdleTimeout.Value = (uint)(long)table[_plidlename];
                        break;
                    default:
                        UnrecognizedKeyWarning(key);
                        Unrecognized.Add(new ConfigKey<object>(key, table[key]));
                        break;
                }
            }
        }

        private const string _hideonlname = "hide-online-players";
        private const string _onlmodename = "online-mode";
        private const string _oppermname = "op-permission-level";
        private const string _plidlename = "player-idle-timeout";
    }
}
