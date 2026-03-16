using Tomlyn.Model;

namespace Redstone.Core.Configuration.Sections
{
    internal class NetworkConfig : ConfigSection
    {
        // todo - impl server management protocol later on maybe redstone 1.2 or 1.3?

        public NetworkConfig() : base("network")
        {
            AddKey(AcceptTransfers);
            AddKey(EnableStatus);
            AddKey(EnableRcon);
            AddKey(RconPort);
            AddKey(RconPassword);
            AddKey(BroadcastRconToOps);
            AddKey(NetworkCompressionThreshold);
            AddKey(EnableQuery);
            AddKey(QueryPort);
        }

        public readonly ConfigKey<bool> AcceptTransfers = new(_transname, false);

        public readonly ConfigKey<bool> EnableStatus = new(_statusname, true);

        // Rcon
        public readonly ConfigKey<bool> EnableRcon = new(_rconname, false);

        public readonly ConfigUShort RconPort = new(_rconportname, 25575)
        {
            MinValue = 1
        };

        public readonly ConfigString RconPassword = new(_rpassname, string.Empty);

        public readonly ConfigKey<bool> BroadcastRconToOps = new(_rbroadname, true);

        public readonly ConfigInt NetworkCompressionThreshold = new(_netcompname, 256)
        {
            MinValue = -1,
            MaxValue = 1500
        };

        // Query
        public readonly ConfigKey<bool> EnableQuery = new(_queryname, false);

        public readonly ConfigUShort QueryPort = new(_queryportname, 25565)
        {
            MinValue = 1
        };

        public override TomlTable TomlTable()
        {
            TomlTable table = new TomlTable
            {
                [_transname] = AcceptTransfers.Value,
                [_statusname] = EnableStatus.Value,
                [_rconname] = EnableRcon.Value,
                [_rconportname] = RconPort.Value,
                [_rpassname] = RconPassword.Value,
                [_rbroadname] = BroadcastRconToOps.Value,
                [_netcompname] = NetworkCompressionThreshold.Value,
                [_queryname] = EnableQuery.Value,
                [_queryportname] = QueryPort.Value
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
                    case _transname:
                        AcceptTransfers.Value = (bool)table[_transname];
                        break;
                    case _statusname:
                        EnableStatus.Value = (bool)table[_statusname];
                        break;
                    case _rconname:
                        EnableRcon.Value = (bool)table[_rconname];
                        break;
                    case _rconportname:
                        RconPort.Value = (ushort)(long)table[_rconportname];
                        break;
                    case _rpassname:
                        RconPassword.Value = (string)table[_rpassname];
                        break;
                    case _rbroadname:
                        BroadcastRconToOps.Value = (bool)table[_rbroadname];
                        break;
                    case _netcompname:
                        NetworkCompressionThreshold.Value = (int)(long)table[_netcompname];
                        break;
                    case _queryname:
                        EnableQuery.Value = (bool)table[_queryname];
                        break;
                    case _queryportname:
                        QueryPort.Value = (ushort)(long)table[_queryportname];
                        break;
                    default:
                        UnrecognizedKeyWarning(key);
                        Unrecognized.Add(new ConfigKey<object>(key, table[key]));
                        break;
                }
            }
        }

        private const string _transname = "accepts-transfers";
        private const string _statusname = "enable-status";
        private const string _rconname = "enable-rcon";
        private const string _rconportname = "rcon.port";
        private const string _rpassname = "rcon.password";
        private const string _rbroadname = "broadcast-rcon-to-ops";
        private const string _netcompname = "network-compression-threshold";
        private const string _queryname = "enable-query";
        private const string _queryportname = "query.port";
    }
}
