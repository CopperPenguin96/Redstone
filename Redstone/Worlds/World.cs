using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using java.util;
using org.omg.CORBA;
using Redstone.Network;
using Redstone.Players;
using Redstone.Types;
using Redstone.Utils;
using Redstone.Worlds.Dimensions;
using SmartNbt;
using SmartNbt.Tags;
using Slot = Redstone.Types.Slot;

namespace Redstone.Worlds
{
    public class World
    {
        public const int Version = 19133;

        public const int VersionId = 2730;

        public readonly string VersionName = MinecraftVersion.Current.ToString();

        public const bool IsSnapshot = false;

        /// <summary>
        /// List of UUID's of players that have ever entered this world.
        /// </summary>
        public static List<string> PlayerIds = new();

        /// <summary>
        /// True if cheats are enabled.
        /// </summary>
        public bool AllowCommands { get; set; }

        /// <summary>
        /// Center of the world border on the X coordinate.
        /// Defaults to 0.
        /// </summary>
        public double BorderCenterX { get; set; }

        /// <summary>
        /// Center of the world border on the Z coordinate.
        /// Defaults to 0.
        /// </summary>
        public double BorderCenterZ { get; set; }

        /// <summary>
        /// Defaults to 0.2.
        /// </summary>
        public double BorderDamagePerBlock { get; set; } = 0.2;

        /// <summary>
        /// Width and length of the border of the border.
        /// Defaults to 60000000.
        /// </summary>
        public double BorderSize { get; set; } = 60000000;

        /// <summary>
        /// Defaults to 5.
        /// </summary>
        public double BorderSafeZone { get; set; } = 5;

        /// <summary>
        /// Defaults to 60000000.
        /// </summary>
        public double BorderSizeLerpTarget { get; set; } = 60000000;

        /// <summary>
        /// Defaults to 0.
        /// </summary>
        public long BorderSizeLerpTime { get; set; } = 0;

        /// <summary>
        /// Defaults to 5.
        /// </summary>
        public double BorderWarningBlocks { get; set; } = 5;

        /// <summary>
        /// Defaults to 15.
        /// </summary>
        public double BorderWarningTime { get; set; } = 15;

        /// <summary>
        /// The number of ticks until clear weather has ended.
        /// </summary>
        public int ClearWeatherTime { get; set; }

        /// <summary>
        /// A collection of bossbars
        /// </summary>
        public List<CustomBossEvent> CustomBossEvents { get; set; }

        /// <summary>
        /// An integer displayng the data version.
        /// </summary>
        public int DataVersion = 2730;

        /// <summary>
        /// The time of day.
        /// </summary>
        public long TimeOfDay { get; set; }

        public void SetDayTime(DayTime daytime) => TimeOfDay = (long)daytime;

        public void SetSunrise() => SetDayTime(DayTime.Sunrise);

        public void SetMidDay() => SetDayTime(DayTime.MidDay);

        public void SetSunset() => SetDayTime(DayTime.Sunset);

        public void SetMidnight() => SetDayTime(DayTime.Midnight);

        public void SetNextDay() => SetDayTime(DayTime.NextDay);

        public Difficulty Difficulty { get; set; }

        public bool DifficultyLocked { get; set; }

        public List<GameRule> Rules { get; set; }

        public bool BonusChest { get; set; }

        public long Seed { get; set; }

        public List<IDimension> Dimensions { get; set; }

        public bool IsHardcore { get; set; }

        public bool IsInitialized { get; set; }

        public bool GenerateStructures { get; set; }

        public bool IsRaining { get; set; }

        public bool Thundering { get; set; }

        public GameMode GameMode { get; set; }

        public int GeneratorVersion { get; set; }

        public int RainTime { get; set; }

        public Position Spawn { get; set; }

        public int ThunderTime { get; set; }

        public long LastPlayed { get; set; }

        public long RandomSeed { get; set; }

        public long SizeOnDisk { get; set; }

        public long Time { get; set; }
        
        public string LevelName { get; set; }

        public UUID WanderingTraderUuid { get; set; }

        public int WanderingTraderSpawnChance { get; set; }

        public int WanderingTraderSpawnDelay { get; set; }

        public bool WasModded { get; set; }

        public TheEnd TheEnd { get; set; }

        public bool IsLargeBiomes { get; set; }

        public Block GetAtPosition(Position pos)
        {
            if (pos == null) throw new ArgumentNullException(nameof(pos));

            return null!;
        }

        public void Save()
        {
            // Create level.dat
            NbtCompound levelData = new("Data")
            {
                new NbtByte("allowCommands", AllowCommands.ToByte()),
                new NbtDouble("BorderCenterX", BorderCenterX),
                new NbtDouble("BorderCenterZ", BorderCenterZ),
                new NbtDouble("BorderDamagePerBlock", BorderDamagePerBlock),
                new NbtDouble("BorderSize", BorderSize),
                new NbtDouble("BorderSafeZone", BorderSafeZone),
                new NbtDouble("BorderSizeLerpTarget", BorderSizeLerpTarget),
                new NbtLong("BorderSizeLerpTime", BorderSizeLerpTime),
                new NbtDouble("BorderWarningBlocks", BorderWarningBlocks),
                new NbtDouble("BorderWarningTime", BorderWarningTime),
                new NbtInt("clearWeatherTime", ClearWeatherTime),
                new NbtInt("DataVersion", DataVersion),
                new NbtLong("DayTime", TimeOfDay),
                new NbtByte("Difficulty", (byte)Difficulty),
                new NbtByte("DifficultyLocked", DifficultyLocked.ToByte()),
                new NbtInt("GameType", (int)GameMode),
                new NbtByte("hardcore", IsHardcore.ToByte()),
                new NbtByte("initialized", IsInitialized.ToByte()),
                new NbtLong("LastPlayed", LastPlayed),
                new NbtString("LevelName", LevelName),
                new NbtByte("MapFeatures", GenerateStructures.ToByte()),
                new NbtByte("raining", IsRaining.ToByte()),
                new NbtLong("RandomSeed", RandomSeed),
                new NbtInt("rainTime", RainTime),
                new NbtLong("SizeOnDisk", SizeOnDisk),
                new NbtInt("SpawnX", Spawn.X),
                new NbtInt("SpawnY", Spawn.Y),
                new NbtInt("SpawnZ", Spawn.Z),
                new NbtByte("thundering", Thundering.ToByte()),
                new NbtInt("thunderTime", ThunderTime),
                new NbtLong("Time", Time),
                new NbtInt("version", Version),
                new NbtCompound("Version")
                {
                    new NbtInt("Id", VersionId),
                    new NbtString("Name", VersionName),
                    new NbtString("Series", "main"),
                    new NbtByte("Snapshot", IsSnapshot.ToByte())
                },
                
                new NbtByte("WasModded", WasModded.ToByte())
            };

            bool ifWandSpawned = false;

            // Add wandering trader if he exists
            if (ifWandSpawned)
            {
                var f = new NbtIntArray("WanderingTraderId", WanderingTraderUuid.GetIntArray());
                var x = new NbtInt("WanderingTraderSpawnChance", WanderingTraderSpawnChance);
                var t = new NbtInt("WanderingTraderSpawnDelay", WanderingTraderSpawnDelay);
                levelData.Add(f);
                levelData.Add(x);
                levelData.Add(t);
            }
            
            // Add custom boss events to the NBT structure
            NbtCompound bossEvents = new("CustomBossEvents");
            foreach (CustomBossEvent cbe in CustomBossEvents)
            {
                NbtCompound id = new(cbe.Id.ToString());
                NbtList cbePlayers = new("Player");
                foreach (Player p in cbe.PlayersVisibleTo)
                {
                    cbePlayers.Add(new NbtIntArray(p.UniqueId.GetIntArray()));
                }

                id.Add(cbePlayers);
                id.Add(
                    new NbtString(
                        "Color",
                        MinecraftFormatting
                            .CodeToId(cbe.Color.Code.ToString())));
                id.Add(new NbtByte("CreateWorldFog", cbe.CreateWorldFog.ToByte()));
                id.Add(new NbtByte("DarkenScreen", cbe.DarkenScreen.ToByte()));
                id.Add(new NbtInt("Max", cbe.MaxHealth));
                id.Add(new NbtInt("Value", cbe.Value));
                id.Add(new NbtString("Name", cbe.Name));
                id.Add(new NbtString("Overlay", cbe.OverlayString));
                id.Add(new NbtByte("PlayBossMusic", cbe.PlayBossMusic.ToByte()));
                id.Add(new NbtByte("Visible", cbe.Visible.ToByte()));
                bossEvents.Add(id);
            }

            levelData.Add(bossEvents);

            // Add "datapacks" future feature?
            /*NbtCompound dataPacks = new("DataPacks")
            {
                new NbtList("Disabled"),
                new NbtList("Enabled") { new NbtString("vanilla") }
            };
            levelData.Add(dataPacks);*/

            // Add Dragon Fight info
            NbtCompound dragonFight = new("DragonFight")
            {
                new NbtCompound("ExitPortalLocation")
                {
                    new NbtByte("X", (byte) TheEnd.ExitPortalLocation.X),
                    new NbtByte("Y", (byte) TheEnd.ExitPortalLocation.Y),
                    new NbtByte("Z", (byte) TheEnd.ExitPortalLocation.Z)
                },
                new NbtByte("DragonKilled", TheEnd.DragonKilled.ToByte()),
                new NbtLong("DragonUUIDLeast", TheEnd.DragonUuid.getLeastSignificantBits()),
                new NbtLong("DragonUUIDMost", TheEnd.DragonUuid.getMostSignificantBits()),
                new NbtByte("PreviouslyKilled", TheEnd.PreviouslyKilled.ToByte())
            };
            levelData.Add(dragonFight);

            // Add Game Rules
            NbtCompound gameRules = new("GameRules");
            foreach (GameRule rule in Rules)
            {
                gameRules.Add(new NbtString(rule.Name, rule.Value.ToString()!));
            }

            levelData.Add(gameRules);

            // Add World Gen Settings
            NbtCompound worldGenSettings = new("WorldGenSettings")
            {
                new NbtByte("bonus_chest", BonusChest.ToByte()),
                new NbtLong("seed", Seed),
                new NbtByte("generate_features", GenerateStructures.ToByte())
            };
            NbtCompound dims = new("dimensions");
            foreach (var dim in Dimensions)
            {
                NbtCompound d = new(dim.Type.ToString())
                {
                    new NbtString("type", dim.Type.ToString())
                };
                NbtCompound g = new("generator")
                {
                    new NbtLong("seed", Seed),
                    new NbtString("settings", dim.Type.ToString().Replace("the_", "")),
                    new NbtString("type", "noise")
                };
                NbtCompound bSource = new("biome_source")
                {
                    new NbtByte("large_biomes", IsLargeBiomes.ToByte()),
                    new NbtLong("seed", Seed),
                    new NbtString("type", dim.BiomeSourceType)
                };
                g.Add(bSource);
                d.Add(g);
                dims.Add(d);
            }

            worldGenSettings.Add(dims);
            levelData.Add(worldGenSettings);
            NbtFile nbtFile = new(levelData);

            string dir = "Redstone/Worlds/";
            string full = dir + LevelName;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (!Directory.Exists(dir + LevelName))
            {
                Directory.CreateDirectory(full);
            }

            if (!Directory.Exists(full + "DIM-1"))
            {
                Directory.CreateDirectory(full + "DIM-1");
            }

            if (!Directory.Exists(full + "DIM-1/region/"))
            {
                Directory.CreateDirectory(full + "DIM-1/region");
            }

            if (!Directory.Exists(full + "DIM1"))
            {
                Directory.CreateDirectory(full + "DIM1/");
            }

            if (!Directory.Exists(full + "DIM1/region/"))
            {
                Directory.CreateDirectory(full + "DIM1/region/");
            }

            if (!Directory.Exists(full + "players/"))
            {
                Directory.CreateDirectory(full + "players/");
            }

            if (!Directory.Exists(full + "region/"))
            {
                Directory.CreateDirectory(full + "region/");
            }
            
            nbtFile.SaveToFile(full + "level.dat", NbtCompression.None); // Save level.dat

            // Save player files
            foreach (Player player in PlayerDatabase.Players)
            {
                // Don't save if player is not in the world currently
                if (player.World.LevelName != LevelName) continue;

                int dimension = -1;
                switch (player.Dimension.Type.ToString().ToLower())
                {
                    case "overworld":
                        dimension = 0;
                        break;
                    case "the_nether":
                        dimension = 1;
                        break;
                    case "the_end":
                        dimension = 2;
                        break;
                }
                NbtCompound cmp = new()
                {
                    new NbtByte("OnGround", player.OnGround.ToByte()),
                    new NbtByte("Sleeping", player.IsSleeping.ToByte()),
                    new NbtShort("Air", player.Air),
                    new NbtShort("AttackTime", player.AttackTime),
                    new NbtShort("DeathTime", player.DeathTime),
                    new NbtShort("Fire", player.Fire),
                    new NbtShort("Health", player.Health),
                    new NbtShort("HurtTime", player.HurtTime),
                    new NbtShort("SleepTimer", player.SleepTimer),
                    new NbtInt("Dimension", dimension),
                    new NbtInt("foodLevel", player.FoodLevel),
                    new NbtInt("foodTickTimer", player.FoodTickTimer),
                    new NbtInt("playerGameType", (int) player.GameMode),
                    new NbtInt("XpLevel", player.ExperienceLevel),
                    new NbtInt("XpTotal", player.ExperienceTotal),
                    new NbtFloat("XpP", player.XpP),
                    new NbtList("Motion")
                    {
                        new NbtDouble(player.Motion.X),
                        new NbtDouble(player.Motion.Y),
                        new NbtDouble(player.Motion.Z)
                    },
                    new NbtList("Pos")
                    {
                        new NbtDouble(player.Position.X),
                        new NbtDouble(player.Position.Y),
                        new NbtDouble(player.Position.Z)
                    },
                    new NbtList("Rotation")
                    {
                        new NbtFloat(player.Rotation.X),
                        new NbtFloat(player.Rotation.Y)
                    }
                };

                // Save inventory
                NbtList inv = new("Inventory");
                foreach (Slot sl in player.Inventory)
                {
                    if (!sl.Present) continue;
                    NbtCompound slot = new()
                    {
                        new NbtByte("Count", sl.ItemCount),
                        new NbtByte("Slot", sl.Spot),
                        new NbtString("id", sl.ItemCount.ToString())
                    };

                    if (sl.NBT != null) slot.Add(sl.NBT);
                    inv.Add(slot);
                }
                cmp.Add(inv);

                nbtFile.SaveToFile(full + "Players/" 
                                        + player.UniqueId.ToString() 
                                        + ".dat", NbtCompression.None); // Save players

            }
        }
    }
}
