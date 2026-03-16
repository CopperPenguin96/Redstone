using Redstone.Core.Types;
using Tomlyn.Model;

namespace Redstone.Core.Configuration.Sections
{
    internal class GeneralConfig : ConfigSection
    {
        public GeneralConfig() : base("general")
        {
            AddKey(ServerName);
            AddKey(IpAddress);
            AddKey(Port);
            AddKey(ForceGameMode);
            AddKey(GameMode);
            AddKey(Hardcore);
            AddKey(MaxPlayers);
            AddKey(Motd);
        }

        public readonly ConfigString ServerName = new(_servername, "[Redstone] Default")
        {
            MaxLength = 128,
            MinLength = 1
        };

        public readonly ConfigString IpAddress = new(_ipname, "0.0.0.0")
        {
            MaxLength = 253,
            MinLength = 1
        };

        public readonly ConfigUShort Port = new(_portname, 25565)
        {
            MinValue = 1
        };

        public readonly ConfigKey<bool> ForceGameMode = new(_forcename, false);

        public readonly ConfigKey<GameMode> GameMode = new(_modename, Core.Types.GameMode.Survival);

        public readonly ConfigKey<bool> Hardcore = new(_hardname, false);

        public readonly ConfigUInt MaxPlayers = new(_maxname, 20)
        {
            MaxValue = int.MaxValue
        };

        public readonly ConfigString Motd = new(_motdname, "A Redstone Minecraft Server")
        {
            MinLength = 1,
            MaxLength = 59
        };

        public override TomlTable TomlTable()
        {
            TomlTable table = new TomlTable
            {
                [_servername] = ServerName.Value,
                [_ipname] = IpAddress.Value,
                [_portname] = Port.Value,
                [_forcename] = ForceGameMode.Value,
                [_modename] = GameMode.Value.ToString(),
                [_hardname] = Hardcore.Value,
                [_maxname] = MaxPlayers.Value,
                [_motdname] = Motd.Value
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
                    case _servername:
                        ServerName.Value = (string)table[_servername];
                        break;
                    case _ipname:
                        IpAddress.Value = (string)table[_ipname]; 
                        break;
                    case _portname:
                        Port.Value = (ushort)(long)table[_portname];
                        break;
                    case _forcename:
                        ForceGameMode.Value = (bool)table[_forcename];
                        break;
                    case _modename:
                        GameMode.Value = Core.Types.GameMode.Parse((string)table[_modename]);
                        break;
                    case _hardname:
                        Hardcore.Value = (bool)table[_hardname];
                        break;
                    case _maxname:
                        MaxPlayers.Value = (uint)(long)table[_maxname];
                        break;
                    case _motdname:
                        Motd.Value = (string)table[_motdname];
                        break;
                    default:
                        UnrecognizedKeyWarning(key);
                        Unrecognized.Add(new ConfigKey<object>(key, table[key]));
                        break;
                }
            }
        }

        private const string _servername = "server-name";
        private const string _ipname = "server-ip";
        private const string _portname = "server-port";
        private const string _forcename = "force-gamemode";
        private const string _modename = "gamemode";
        private const string _hardname = "hardcore";
        private const string _maxname = "max-players";
        private const string _motdname = "motd";
    }
}
