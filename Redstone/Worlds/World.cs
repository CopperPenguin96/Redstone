using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;
using Redstone.Types.Exceptions;
using Redstone.Utils;
using SmartNbt;
using SmartNbt.Tags;

namespace Redstone.Worlds
{
    public class World
    {
        public Level Level { get; set; }

        public World(string name = "DefaultRedstoneWorld")
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            Level = new Level
            {
                Name = name
            };
        }

        public static World Load(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            string dir = WorldManager.Dir + "name" + "/";
            if (!Directory.Exists(dir))
            {
                throw new WorldNotFoundException(name, true);
            }

            string fileDat = dir + "level.dat";
            string oldDat = dir + "level.dat_old";
            NbtFile file = null!;
            if (!File.Exists(fileDat) && File.Exists(oldDat))
            {
                Logger.LogWarning("World Manager: Level not found for " + name + ". Using backup.");
                file = new NbtFile(oldDat);
            }
            else if (File.Exists(fileDat))
            {
                file = new NbtFile(fileDat);
            }
            else
            {
                throw new InvalidWorldException(name, true);
            }

            if (file == null) throw new InvalidWorldException(nameof(file));

            NbtCompound rootTag = file.RootTag;
            if (rootTag.Name != "Data") throw new InvalidWorldException("World " + name + " has an invalid Root Tag");

            World world = new()
            {
                Level = new Level()
            };

            foreach (NbtTag tag in rootTag.Tags)
            {
                // Todo custom boss events, data packs
                switch (tag.Name)
                {
                    case "DragonFight":
                        DragonFight fight = new();
                        NbtCompound dragonTag = (NbtCompound) tag;

                        foreach (NbtTag dTags in dragonTag)
                        {
                            switch (dTags.Name)
                            {
                                case "Gateways":
                                    fight.Gateways = (NbtList) dTags;
                                    break;
                                case "DragonKilled":
                                    fight.DragonKilled =
                                        ((NbtByte) dTags).Value != 0;
                                    break;
                                case "NeedsStateScanning":
                                    fight.NeedsStateScanning =
                                        ((NbtByte)dTags).Value != 0;
                                    break;
                                case "PreviouslyKilled":
                                    fight.PreviouslyKilled =
                                        ((NbtByte)dTags).Value != 0;
                                    break;
                            }
                        }

                        world.Level.DragonFight = fight;
                        break;
                    case "GameRules":
                        NbtCompound rules = (NbtCompound) tag;

                        world.Level.GameRules = new();
                        foreach (NbtString rule in rules.Tags)
                        {
                            world.Level.GameRules.Add(
                                new GameRule(rule.Name!, rule.Value)
                                );
                        }
                        break;
                    case "WorldGenSettings": // 0.o
                        NbtCompound genSettings = (NbtCompound) tag;

                        foreach (NbtTag genTags in genSettings.Tags)
                        {
                            switch (genTags.Name)
                            {
                                case "bonus_chest":
                                    world.Level.BonusChest =
                                        ((NbtByte) genTags).Value != 0;
                                    break;
                                case "generate_features":
                                    world.Level.GenerateStructures =
                                        ((NbtByte) genTags).Value != 0;
                                    break;
                                case "seed":
                                    world.Level.Seed =
                                        ((NbtLong) genTags).Value;
                                    break;
                                case "minecraft:overworld": // only used to get large biomes
                                    NbtCompound n = (NbtCompound) genTags;
                                    foreach (NbtTag t in n.Tags)
                                    {
                                        if (t.Name != "generator") continue;
                                        NbtCompound tz = (NbtCompound) t;
                                        foreach (NbtTag tf in tz.Tags)
                                        {
                                            if (tf.Name != "biome_source") continue;
                                            NbtCompound tl = (NbtCompound) tf;
                                            foreach (NbtTag tg in tl.Tags)
                                            {
                                                if (tg.Name == "large_biomes")
                                                {
                                                    world.Level.Overworld.LargeBiomes =
                                                        ((NbtByte) tg).Value != 0;
                                                }
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    case "ScheduledEvents":
                        break; // todo
                    case "ServerBrands":
                        break; // todo
                    case "allowCommands":
                        world.Level.AllowCommands =
                            ((NbtByte) tag).Value != 0;
                        break;
                    case "BorderCenterX":
                        world.Level.BorderCenter.X =
                            ((NbtDouble) tag).Value;
                        break;
                    case "BorderCenterZ":
                        world.Level.BorderCenter.Z =
                            ((NbtDouble) tag).Value;
                        break;
                    case "BorderDamagePerBlock":
                        world.Level.BorderDamagePerBlock =
                            ((NbtDouble) tag).Value;
                        break;
                    case "BorderSafeZone":
                        world.Level.BorderSafeZone =
                            ((NbtDouble) tag).Value;
                        break;
                    case "BorderSize":
                        world.Level.BorderSize =
                            ((NbtDouble) tag).Value;
                        break;
                    case "BorderSizeLerpTarget":
                        world.Level.BorderSizeLerpTarget =
                            ((NbtDouble) tag).Value;
                        break;
                    case "BorderSizeLerpTime":
                        world.Level.BorderSizeLerpTime =
                            TimeSpan.FromTicks(((NbtLong) tag).Value);
                        break;
                    case "BorderWarningBlocks":
                        world.Level.BorderWarningBlocks =
                            ((NbtDouble) tag).Value;
                        break;
                    case "BorderWarningTime":
                        world.Level.BorderWarningTime =
                            ((NbtDouble) tag).Value;
                        break;
                    case "clearWeatherTime":
                        world.Level.ClearWeatherTime =
                            ((NbtInt) tag).Value;
                        break;
                    case "DayTime":
                        world.Level.DayTime =
                            TimeSpan.FromTicks(((NbtLong) tag).Value);
                        break;
                    case "Difficulty":
                        world.Level.Difficulty =
                            (Difficulty) ((NbtByte) tag).Value;
                        break;
                    case "DifficultyLocked":
                        world.Level.DifficultyLocked =
                            ((NbtByte) tag).Value != 0;
                        break;
                    case "GameType":
                        world.Level.GameMode =
                            (GameMode) ((NbtInt) tag).Value;
                        break;
                    case "hardcore":
                        world.Level.IsHardcore =
                            ((NbtByte) tag).Value != 0;
                        break;
                    case "initialized":
                        world.Level.Initialized =
                            ((NbtByte)tag).Value != 0;
                        break;
                    case "LastPlayed":
                        world.Level.LastPlayed =
                            new DateTime(((NbtLong) tag).Value);
                        break;
                    case "LevelName":
                        world.Level.Name =
                            ((NbtString) tag).Value;
                        break;
                    case "raining":
                        world.Level.IsRaining =
                            ((NbtByte)tag).Value != 0;
                        break;
                    case "rainTime":
                        world.Level.RainTime =
                            ((NbtInt) tag).Value;
                        break;
                    case "SpawnAngle":
                        world.Level.SpawnAngle =
                            ((NbtFloat) tag).Value;
                        break;
                    case "SpawnX":
                        world.Level.Spawn.X =
                            ((NbtInt) tag).Value;
                        break;
                    case "SpawnY":
                        world.Level.Spawn.Y =
                            ((NbtInt) tag).Value;
                        break;
                    case "SpawnZ":
                        world.Level.Spawn.Z =
                            ((NbtInt) tag).Value;
                        break;
                    case "thundering":
                        world.Level.IsThundering =
                            ((NbtByte) tag).Value != 0;
                        break;
                    case "Time":
                        world.Level.Time =
                            TimeSpan.FromTicks(((NbtLong) tag).Value);
                        break;
                    case "thunderTime":
                        world.Level.ThunderTime =
                            TimeSpan.FromTicks(((NbtInt) tag).Value);
                        break;
                    case "WanderingTraderSpawnChance":
                        world.Level.WanderingTraderSpawnChance =
                            ((NbtInt) tag).Value;
                        break;
                    case "WanderingTraderSpawnDelay":
                        world.Level.WanderingTraderSpawnDelay =
                            ((NbtInt) tag).Value;
                        break;
                    case "WasModded":
                        world.Level.WasModded =
                            ((NbtByte)tag).Value != 0;
                        break;
                }
            }

            return world;
        }

        public static bool TryLoad(string name, out World world, out Exception ex)
        {
            try
            {
                world = Load(name);
                ex = null!;
                return true;
            }
            catch (Exception e)
            {
                world = null!;
                ex = e;
                return false;
            }
        }
        public void Save()
        {
            string saveDir = WorldManager.Dir + Level.Name + "/";

            // Save level.dat & make level.dat_old
            string levelDat = saveDir + "level.dat";
            string oldDat = saveDir + "level.dat_old";

            if (File.Exists(levelDat))
            {
                if (File.Exists(oldDat)) File.Delete(oldDat);
                File.Copy(levelDat, oldDat);
            }

            NbtFile levelDatFile = new(Level.Nbt);
            levelDatFile.SaveToFile(levelDat, NbtCompression.None);
        }

        public bool TrySave(out Exception ex)
        {
            try
            {
                Save();
                ex = null!;
                return true;
            }
            catch (Exception e)
            {
                ex = e;
                return false;
            }
        }
    }
}
