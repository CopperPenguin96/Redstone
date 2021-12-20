using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medallion;
using Redstone.Types;
using Redstone.Utils;
using Redstone.Worlds.Dimensions;
using SmartNbt.Tags;
using java.util;
using Random = System.Random;

namespace Redstone.Worlds.Generators
{
    public class VanillaGenerator : Generator
    {
        private string _levelName;

        public override World Generate(string name, long seed = -1)
        {
            _levelName = name ?? throw new ArgumentNullException(nameof(name));
            if (seed == -1) seed = new Random().NextInt64();
            var world = new World();
            world.CustomBossEvents = new(); // todo if implement data packs add here
            world.Seed = seed;
            world.RandomSeed = seed;
            world.GenerateStructures = true;
            world.BonusChest = false;
            world.Dimensions = new()
            {
                new VanillaDimension()
                {
                    Seed = seed,
                    Type = DimensionType.Overworld,
                    LargeBiomes = false
                }
            };
            world.AllowCommands = false;
            world.BorderCenterX = 0;
            world.BorderCenterZ = 0;
            world.BorderDamagePerBlock = 0.2;
            world.BorderSafeZone = 5;
            world.BorderSize = 59999968;
            world.BorderSizeLerpTarget = 59999968;
            world.BorderSizeLerpTime = 0;
            world.BorderWarningBlocks = 5;
            world.BorderWarningTime = 15;
            world.ClearWeatherTime = 0;
            world.TimeOfDay = 0;
            world.Difficulty = Difficulty.Normal;
            world.DifficultyLocked = false;
            world.GameMode = GameMode.Survival;
            world.IsHardcore = false;
            world.IsInitialized = true;
            world.LastPlayed = DateTime.Now.Ticks;
            world.LevelName = name;
            world.IsRaining = false;
            world.RainTime = 0;
            world.Spawn = new(0, 0, 0);
            world.Thundering = false;
            world.ThunderTime = 0;
            world.WanderingTraderSpawnChance = 25;
            world.WanderingTraderSpawnDelay = 24000;
            world.WasModded = false;
            world.Rules = new() // Game rules
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
            };
            // Setup the end.
            world.TheEnd = new();
            world.TheEnd.ExitPortalLocation = new Position(0, 0, 0);
            world.TheEnd.DragonKilled = true;
            world.TheEnd.PreviouslyKilled = true;
            world.TheEnd.Gateways = _gateways.Shuffled(new Random()).ToList();
            world.TheEnd.DragonUuid = new UUID(0, 0);
            return world;
        }

        private int[] _gateways =
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19
        };
    }
}
