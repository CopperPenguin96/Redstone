using Tomlyn.Model;

namespace Redstone.Core.Configuration.Sections
{
    internal class AdvancedConfig : ConfigSection
    {
        public AdvancedConfig() : base("advanced")
        {
            AddKey(BroadcastConsoleToOps);
            AddKey(EntityBroadcastRange);
            AddKey(FunctionPermissionLevel);
            AddKey(MaxChainedNeighborUpdates);
            AddKey(MaxTickTime);
            AddKey(PauseWhenEmptySeconds);
            AddKey(RateLimit);
            AddKey(SimDistance);
            AddKey(NativeTransport);
        }

        public readonly ConfigKey<bool> BroadcastConsoleToOps = new(_broadcastconsoleopsname, true);

        public readonly ConfigUShort EntityBroadcastRange = new(_entbroadname, 100)
        {
            MinValue = 10,
            MaxValue = 1000
        };

        public readonly ConfigByte FunctionPermissionLevel = new(_funcpermname, 2)
        {
            MinValue = 1,
            MaxValue = 4
        };

        public readonly ConfigInt MaxChainedNeighborUpdates = new(_maxchainname, 1000000);

        public readonly ConfigLong MaxTickTime = new(_maxtickname, 60000)
        {
            MinValue = -1,
            MaxValue = long.MaxValue
        };
        
        public readonly ConfigUInt PauseWhenEmptySeconds = new(_pausesecsname, 60)
        {
            MaxValue = int.MaxValue
        };

        public readonly ConfigUInt RateLimit = new(_ratelimname, 0);

        public readonly ConfigByte SimDistance = new(_simdisname, 10)
        {
            MinValue = 3,
            MaxValue = 32
        };

        public readonly ConfigKey<bool> NativeTransport = new(_usenavname, true);

        public override TomlTable TomlTable()
        {
            TomlTable table = new TomlTable
            {
                [_broadcastconsoleopsname] = BroadcastConsoleToOps.Value,
                [_entbroadname] = EntityBroadcastRange.Value,
                [_funcpermname] = FunctionPermissionLevel.Value,
                [_maxchainname] = MaxChainedNeighborUpdates.Value,
                [_maxtickname] = MaxTickTime.Value,
                [_pausesecsname] = PauseWhenEmptySeconds.Value,
                [_ratelimname] = RateLimit.Value,
                [_simdisname] = SimDistance.Value,
                [_usenavname] = NativeTransport.Value,
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
                    case _broadcastconsoleopsname:
                        BroadcastConsoleToOps.Value = (bool)table[_broadcastconsoleopsname];
                        break;
                    case _entbroadname:
                        EntityBroadcastRange.Value = (ushort)(long)table[_entbroadname];
                        break;
                    case _funcpermname:
                        FunctionPermissionLevel.Value = (byte)(long)table[_funcpermname];
                        break;
                    case _maxchainname:
                        MaxChainedNeighborUpdates.Value = (int)(long)table[_maxchainname];
                        break;
                    case _maxtickname:
                        MaxTickTime.Value = (long)table[_maxtickname];
                        break;
                    case _pausesecsname:
                        PauseWhenEmptySeconds.Value = (uint)(long)table[_pausesecsname];
                        break;
                    case _ratelimname:
                        RateLimit.Value = (uint)(long)table[_ratelimname];
                        break;
                    case _simdisname:
                        SimDistance.Value = (byte)(long)table[_simdisname];
                        break;
                    case _usenavname:
                        NativeTransport.Value = (bool)table[_usenavname];
                        break;
                    default:
                        UnrecognizedKeyWarning(key);
                        Unrecognized.Add(new ConfigKey<object>(key, table[key]));
                        break;
                }
            }
        }

        private const string _broadcastconsoleopsname = "broadcast-console-to-ops";
        private const string _entbroadname = "entity-broadcast-range-percentage";
        private const string _funcpermname = "function-permission-level";
        private const string _maxchainname = "max-chained-neighbor-updates";
        private const string _maxtickname = "max-tick-time";
        private const string _pausesecsname = "pause-when-empty-seconds";
        private const string _ratelimname = "rate-limit";
        private const string _simdisname = "simulation-distance";
        private const string _usenavname = "use-native-transport";
    }
}