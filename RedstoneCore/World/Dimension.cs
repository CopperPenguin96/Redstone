using Redstone.Core.Registries;
using Redstone.Core.Types;
using Redstone.Core.Types.IntProviders;
using Redstone.Core.Utils;
using Redstone.Nbt;
using Redstone.Nbt.Tags;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;

namespace Redstone.Core.World
{
    /// <summary>
    /// Represents a Minecraft dimension identifier with enum-like semantics.
    /// Uses <see cref="Identifier"/> as the backing value.
    /// </summary>
    public class Dimension : NbtTagProvider, IJsonProvider
    {
        public Identifier Name { get; private set; }

        public float AmbientLight { get; set; } = 0.0f;

        public bool BedWorks { get; set; } = true;

        public double CoordinateScale { get; set; } = 1.0;

        public Identifier Effects { get; set; } = "minecraft:overworld";

        public bool HasCeiling { get; set; } = false;

        public bool HasRaids { get; set; } = true;

        public bool HasSkylight { get; set; } = true;

        public int Height { get; set; } = 384;

        public Identifier Infiniburn { get; set; } = "minecraft:infiniburn_overworld";

        public int LogicalHeight { get; set; } = 384;

        public int MinY { get; set; } = -64;

        public int MonsterSpawnBlockLightLimit { get; set; } = 0;

        public IntProvider MonsterSpawnLightLevel { get; set; } = new UniformProvider()
        {
            MaxInclusive = 7,
            MinInclusive = 0
        };

        public bool IsNatural { get; set; } = true;

        public bool IsPigligSafe { get; set; } = false;

        public bool RespawnAnchorWorks { get; set; } = false;

        public bool IsUltraWarm { get; set; } = false;

        public Dimension(Identifier name)
        {
            Name = name;
        }

        public override NbtTag Nbt
        {
            get
            {
                return new CompoundTag(Name.ToString())
                {
                    { "ambient_light", AmbientLight },
                    { "bed_works", BedWorks },
                    { "coordinate_scale", CoordinateScale },
                    { "effects", Effects.ToString() },
                    { "has_ceiling", HasCeiling },
                    { "has_raids", HasRaids },
                    { "has_skylight", HasSkylight },
                    { "height", Height },
                    { "infiniburn", Infiniburn.ToString() },
                    { "logical_height", LogicalHeight },
                    { "min_y", MinY },
                    { "monster_spawn_block_light_limit", MonsterSpawnBlockLightLimit },
                    { "monster_spawn_light_level", MonsterSpawnLightLevel.Nbt },
                    { "natural", IsNatural },
                    { "piglin_safe", IsPigligSafe },
                    { "respawn_anchor_works", RespawnAnchorWorks },
                    { "ultrawarm", IsUltraWarm }
                };
            }
        }

        public override void Parse(NbtTag tag)
        {
            if (!(tag is CompoundTag compoundTag))
                throw new ArgumentException("Expected a CompoundTag to parse Dimension from.");

            if (!compoundTag.Contains("name", out NbtTag nameTag) || nameTag.Type != TagType.String)
                throw new ArgumentException("Dimension tag must contain a 'name' string.");

            Name = nameTag.ValueAsString;
            AmbientLight = compoundTag.Contains("ambient_light", out NbtTag ambientLight) && ambientLight.Type == TagType.Float
                ? compoundTag["ambient_light"].ValueAsFloat
                : 0.0f;
            BedWorks = compoundTag.Contains("bed_works", out NbtTag bedWorks) && bedWorks.Type == TagType.Boolean;
            CoordinateScale = compoundTag.Contains("coordinate_scale", out NbtTag coordinateScale) && coordinateScale.Type == TagType.Double
                ? compoundTag["coordinate_scale"].ValueAsDouble
                : 1.0;
            Effects = compoundTag.Contains("effects", out NbtTag effects) && effects.Type == TagType.String
                ? effects.ValueAsString
                : "minecraft:overworld";
            HasCeiling = compoundTag.Contains("has_ceiling", out NbtTag hasCeiling) && hasCeiling.Type == TagType.Boolean;
            HasRaids = compoundTag.Contains("has_raids", out NbtTag hasRaids) && hasRaids.Type == TagType.Boolean;
            HasSkylight = compoundTag.Contains("has_skylight", out NbtTag hasSkylight) && hasSkylight.Type == TagType.Boolean;
            Height = compoundTag.Contains("height", out NbtTag height) && height.Type == TagType.Int
                ? height.ValueAsInt
                : 384;
            Infiniburn = compoundTag.Contains("infiniburn", out NbtTag infiniburn) && infiniburn.Type == TagType.String
                ? infiniburn.ValueAsString
                : "minecraft:infiniburn_overworld";
            LogicalHeight = compoundTag.Contains("logical_height", out NbtTag logicalHeight) && logicalHeight.Type == TagType.Int
                ? logicalHeight.ValueAsInt
                : 0;
            MinY = compoundTag.Contains("min_y", out NbtTag minY) && minY.Type == TagType.Int
                ? minY.ValueAsInt
                : -64;
            MonsterSpawnBlockLightLimit = compoundTag.Contains("monster_spawn_block_light_limit", out NbtTag monsterSpawnBlockLightLimit) && monsterSpawnBlockLightLimit.Type == TagType.Int
                ? monsterSpawnBlockLightLimit.ValueAsInt
                : 0;

            if (!compoundTag.Contains("monster_spawn_light_level", out NbtTag monsterSpawnLightLevel) || monsterSpawnLightLevel.Type != TagType.Compound)
            {
                MonsterSpawnLightLevel = new UniformProvider()
                {
                    MaxInclusive = 7,
                    MinInclusive = 0
                };
            }
            else
            {
                MonsterSpawnLightLevel = new UniformProvider();
                MonsterSpawnLightLevel.Parse(monsterSpawnLightLevel);
            }

            IsNatural = compoundTag.Contains("natural", out NbtTag isNatural) && isNatural.Type == TagType.Boolean
                ? isNatural.ValueAsBool
                : true;
            IsPigligSafe = compoundTag.Contains("piglin_safe", out NbtTag isPiglinSafe) && isPiglinSafe.Type == TagType.Boolean;
            RespawnAnchorWorks = compoundTag.Contains("respawn_anchor_works", out NbtTag respawnAnchorWorks) && respawnAnchorWorks.Type == TagType.Boolean;
            IsUltraWarm = compoundTag.Contains("ultra_warm", out NbtTag isUltraWarm) && isUltraWarm.Type == TagType.Boolean;
        }

        public JsonNode ToJson()
        {
            JsonObject obj = new JsonObject()
            {
                ["ambient_light"] = AmbientLight,
                ["bed_works"] = BedWorks,
                ["coordinate_scale"] = CoordinateScale,
                ["effects"] = Effects.ToString(),
                ["has_ceiling"] = HasCeiling,
                ["has_raids"] = HasRaids,
                ["has_skylight"] = HasSkylight,
                ["height"] = Height,
                ["infiniburn"] = Infiniburn.ToString(),
                ["logical_height"] = LogicalHeight,
                ["min_y"] = MinY,
                ["monster_spawn_block_light_limit"] = MonsterSpawnBlockLightLimit,
                ["monster_spawn_light_level"] = MonsterSpawnLightLevel.ToJson(),
                ["natural"] = IsNatural,
                ["piglin_safe"] = IsPigligSafe,
                ["respawn_anchor_works"] = RespawnAnchorWorks,
                ["ultra_warm"] = IsUltraWarm
            };
            return obj;
        }

        public void FromJson(string json)
        {
            JsonObject obj = JsonNode.Parse(json)!.AsObject();
            AmbientLight = obj.ContainsKey("ambient_light") ? obj["ambient_light"]!.GetValue<float>() : 0.0f;
            BedWorks = obj.ContainsKey("bed_works") ? obj["bed_works"]!.GetValue<bool>() : true;
            CoordinateScale = obj.ContainsKey("coordinate_scale") ? obj["coordinate_scale"]!.GetValue<double>() : 1.0;
            Effects = obj.ContainsKey("effects") ? new Identifier(obj["effects"]!.GetValue<string>()) : "minecraft:overworld";
            HasCeiling = obj.ContainsKey("has_ceiling") ? obj["has_ceiling"]!.GetValue<bool>() : false;
            HasRaids = obj.ContainsKey("has_raids") ? obj["has_raids"]!.GetValue<bool>() : true;
            HasSkylight = obj.ContainsKey("has_skylight") ? obj["has_skylight"]!.GetValue<bool>() : true;
            Height = obj.ContainsKey("height") ? obj["height"]!.GetValue<int>() : 384;
            Infiniburn = obj.ContainsKey("infiniburn") ? new Identifier(obj["infiniburn"]!.GetValue<string>()) : "minecraft:infiniburn_overworld";
            LogicalHeight = obj.ContainsKey("logical_height") ? obj["logical_height"]!.GetValue<int>() : 384;
            MinY = obj.ContainsKey("min_y") ? obj["min_y"]!.GetValue<int>() : -64;
            MonsterSpawnBlockLightLimit = obj.ContainsKey("monster_spawn_block_light_limit") ? obj["monster_spawn_block_light_limit"]!.GetValue<int>() : 0;

            if (!obj.ContainsKey("monster_spawn_light_level") || obj["monster_spawn_light_level"]!.GetValueKind() != JsonValueKind.Object)
            {
                MonsterSpawnLightLevel = new UniformProvider()
                {
                    MaxInclusive = 7,
                    MinInclusive = 0
                };
            }
            else
            {
                MonsterSpawnLightLevel = new UniformProvider();
                MonsterSpawnLightLevel.FromJson(obj["monster_spawn_light_level"]!.ToJsonString());
            }

            IsNatural = obj.ContainsKey("natural") ? obj["natural"]!.GetValue<bool>() : true;
            IsPigligSafe = obj.ContainsKey("piglin_safe") ? obj["piglin_safe"]!.GetValue<bool>() : false;
            RespawnAnchorWorks = obj.ContainsKey("respawn_anchor_works") ? obj["respawn_anchor_works"]!.GetValue<bool>() : false;
            IsUltraWarm = obj.ContainsKey("ultrawarm") ? obj["ultrawarm"]!.GetValue<bool>() : false;
        }

        public static Dictionary<Identifier, object> Keys
        {
            get
            {
                JsonObject items = JsonNode.Parse(File.ReadAllText(RegistryManager.RegistryLocations["dimension_type"]))!.AsObject();
                Dictionary<Identifier, object> keys = new Dictionary<Identifier, object>();
                foreach (var kvp in items)
                {
                    keys.Add(new Identifier(kvp.Key), new Dimension(kvp.Key));
                }
                return keys;
            }
        }
    }

    public enum CardinalLight
    {
        Default,
        Nether
    }

    public enum Skybox
    {
        None,
        Overworld,
        End
    }

    public enum TimeMarker
    {
        WakeUpFromSleep,
        RollVilalgeSiege
    }
}
