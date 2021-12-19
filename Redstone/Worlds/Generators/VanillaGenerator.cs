using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medallion;
using Redstone.Worlds.Dimensions;
using SmartNbt.Tags;

namespace Redstone.Worlds.Generators
{
    public class VanillaGenerator : Generator
    {
        private string _levelName;

        public override void Generate(string name, long seed = -1)
        {
            _levelName = name ?? throw new ArgumentNullException(nameof(name));
            if (seed == -1) seed = new Random().NextInt64();
            World world = new()
            {
                CustomBossEvents = new(),
                // todo if implement data packs add here
                Seed = seed,
                RandomSeed = seed,
                GenerateStructures = true,
                BonusChest = false,
                Dimensions = new()
                {
                    new VanillaDimension()
                    {
                        Seed = seed,
                        Type = "noise",
                        LargeBiomes = false
                    }
                },
                Rules = new() // Game rules
                {
                    new(GameRule.AnnounceAdvancements, true),
                    new(GameRule.CommandBlockOutput, true),
                    new(GameRule.DisableElytraMovementChest, false),
                    new(GameRule.DisableRaids, false),
                    new(GameRule.DoDaylightCycle, true),
                    new(GameRule.DoEntityDrops, true),
                    new(GameRule.DoFireTick, true),
                    new(GameRule.DoInsomnia, true),
                    new(GameRule.DoImmediateRespawn, false),
                    new(GameRule.DoLimitedCrafting, false),
                    new(GameRule.DoMobLoot, true),
                    new(GameRule.DoMobSpawning, true),
                    new(GameRule.DoPatrolSpawning, true),
                    new(GameRule.DoTileDrops, true),
                    new(GameRule.DoTraderSpawning, true),
                    new(GameRule.DoWeatherCycle, true),
                    new(GameRule.DrowningDamage, true),
                    new(GameRule.FallDamage, true),
                    new(GameRule.FireDamage, true),
                    new(GameRule.ForgiveDeadPlayers, true),
                    new(GameRule.FreezeDamage, true),
                    new(GameRule.KeepInventory, false),
                    new(GameRule.LogAdminCommands, true),
                    new(GameRule.MaxCommandChainLength, 65536),
                    new(GameRule.MaxEntityCramming, 24),
                    new(GameRule.MobGriefing, true),
                    new(GameRule.NaturalRegeneration, true),
                    new(GameRule.PlayersSleepingPercentage, 100),
                    new(GameRule.RandomTickSpeed, 3),
                    new(GameRule.ReducedDebugInfo, false),
                    new(GameRule.SendCommandFeedback, true),
                    new(GameRule.ShowDeathMessages, true),
                    new(GameRule.SpawnRadius, 10),
                    new(GameRule.UniversalAnger, false)
                },
                TheEnd =
                {
                    // Dragon fight
                    DragonKilled = true,
                    PreviouslyKilled = true,
                    Gateways = _gateways.Shuffled(new Random()).ToList()
                }
            };

            // Game rules

        }

        private int[] _gateways =
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19
        };
    }
}
