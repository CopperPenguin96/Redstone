using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Players;
using Redstone.Types;
using Redstone.Utils;
using SmartNbt;
using SmartNbt.Tags;

namespace Redstone.Worlds
{
    public class World
    {
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
        public int DataVersion { get; set; }

        /// <summary>
        /// The time of day.
        /// </summary>
        public long TimeOfDay { get; set; }

        public void SetDayTime(DayTime daytime) => TimeOfDay = (long) daytime;
        
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
        


        public bool IsHardcore { get; set; }

        public bool GenerateStructures { get; set; }

        public bool IsRaining { get; set; }

        public bool Thundering { get; set; }

        public GameMode GameMode { get; set; }

        public int GeneratorVersion { get; set; }

        public int RainTime { get; set; }

        public Position Spawn { get; set; }

        public int ThunderTime { get; set; }

        public int Version { get; set; }

        public long LastPlayed { get; set; }

        public long RandomSeed { get; set; }

        public long SizeOnDisk { get; set; }

        public long Time { get; set; }

        public string GeneratorName { get; set; }

        public string LevelName { get; set; }

        public Block GetAtPosition(Position pos)
        {
            if (pos == null) throw new ArgumentNullException(nameof(pos));

            return null!;
        }

        public void Save()
        {
            NbtCompound levelDat = new();
            // Create level.dat
            NbtCompound levelData = new("Data")
            {
                new NbtByte("allowCommands", AllowCommands.ToByte()),
                new NbtByte("hardcore", IsHardcore.ToByte()),
                new NbtByte("MapFeatures", GenerateStructures.ToByte()),
                new NbtByte("raining", IsRaining.ToByte()),
                new NbtByte("thundering", Thundering.ToByte()),
                new NbtInt("GameType", (int) GameMode),
                new NbtInt("generatorVersion", GeneratorVersion),
                new NbtInt("rainTime", RainTime),
                new NbtInt("SpawnX", Spawn.X),
                new NbtInt("SpawnY", Spawn.Y),
                new NbtInt("SpawnZ", Spawn.Z),
                new NbtInt("thunderTime", ThunderTime),
                new NbtInt("version", Version),
                new NbtLong("lastPlayed", LastPlayed),
                new NbtLong("RandomSeed", RandomSeed),
                new NbtLong("SizeOnDisk", SizeOnDisk),
                new NbtLong("Time", Time),
                new NbtString("generatorName", GeneratorName),
                new NbtString("LevelName", LevelName)
            };
            levelDat.Add(levelData);

            var writer = File.Create("level.dat");
            NbtWriter levelDatWriter = new(writer, "Data", false);
            levelDatWriter.WriteTag(levelDat);
            levelDatWriter.BaseStream.Flush();
            levelDatWriter.BaseStream.Close();

            // Create [uuid].dat files
            foreach (string uuid in PlayerIds)
            {
                Player player = Player.FindById(uuid)!;
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
                    new NbtInt("Dimension", (int) player.Dimension),
                    new NbtInt("foodLevel", player.FoodLevel),
                    new NbtInt("foodTickTimer", player.FoodTickTimer),
                    new NbtInt("playerGameType", (int) player.GameMode),
                    new NbtInt("XpLevel", player.ExperienceLevel),
                    new NbtInt("XpTotal", player.ExperienceTotal),
                    new NbtFloat("XpP", player.XpP),
                    new NbtCompound("Inventory")
                    {

                    }
                };
            }
        }
    }
}
