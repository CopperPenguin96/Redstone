using Redstone.Core.Types;
using Redstone.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace Redstone.Core.World
{
    public struct Biome : IJsonProvider
    {
        // Attributes are represented as a dictionary keyed by the attribute identifier
        // The value is a typed BiomeAttribute which can represent booleans, strings or a BackgroundMusic entry
        public Dictionary<Identifier, BiomeAttribute> Attributes { get; private set; }

        public List<Identifier> Carvers { get; private set; }

        public double CreatureSpawnProbability { get; set; }

        public double Downfall { get; set; }

        public BiomeEffects Effects { get; set; }

        public List<List<Identifier>> Features { get; private set; }

        public bool HasPrecipitation { get; set; }

        // Spawn costs are keyed by mob identifier and contain typed spawn cost information
        public Dictionary<Identifier, SpawnCost> SpawnCosts { get; private set; }

        public BiomeSpawners Spawners { get; private set; }

        public double Temperature { get; set; }

        public Biome(string json)
        {
            Attributes = new Dictionary<Identifier, BiomeAttribute>();
            Carvers = new List<Identifier>();
            CreatureSpawnProbability = 0;
            Downfall = 0;
            Effects = new BiomeEffects();
            Features = new List<List<Identifier>>();
            HasPrecipitation = false;
            SpawnCosts = new Dictionary<Identifier, SpawnCost>();
            Spawners = new BiomeSpawners();
            Temperature = 0;

            FromJson(json);
        }

        public void FromJson(string json)
        {
            JsonObject root = JsonNode.Parse(json)!.AsObject();

            Attributes = new Dictionary<Identifier, BiomeAttribute>();
            if (root["attributes"] is JsonObject attrObj)
            {
                foreach (var kvp in attrObj)
                {
                    string key = kvp.Key;
                    JsonNode? val = kvp.Value;
                    Identifier id = new Identifier(key);

                    if (val is null)
                    {
                        continue;
                    }

                    if (val is JsonValue v)
                    {
                        if (v.TryGetValue<bool>(out var b))
                        {
                            Attributes[id] = new BiomeAttribute(b);
                            continue;
                        }

                        if (v.TryGetValue<string>(out var s))
                        {
                            Attributes[id] = new BiomeAttribute(s);
                            continue;
                        }
                    }

                    if (val is JsonObject complex)
                    {
                        // Example: minecraft:audio/background_music contains a `default` object
                        if (complex["default"] is JsonObject def && def["sound"] is not null)
                        {
                            var bg = new BackgroundMusic();
                            if (def["max_delay"] != null) bg.MaxDelay = def["max_delay"]!.GetValue<int>();
                            if (def["min_delay"] != null) bg.MinDelay = def["min_delay"]!.GetValue<int>();
                            if (def["sound"] != null) bg.Sound = new Identifier(def["sound"]!.GetValue<string>());

                            Attributes[id] = new BiomeAttribute(bg);
                            continue;
                        }

                        // Fallback: serialize the object to a string representation
                        Attributes[id] = new BiomeAttribute(complex.ToString());
                    }
                }
            }

            Carvers = new List<Identifier>();
            if (root["carvers"] is JsonArray carverArr)
            {
                foreach (var n in carverArr)
                {
                    if (n is JsonValue vv && vv.TryGetValue<string>(out var s))
                    {
                        Carvers.Add(new Identifier(s));
                    }
                }
            }

            CreatureSpawnProbability = root["creature_spawn_probability"] is not null ? root["creature_spawn_probability"]!.GetValue<double>() : 0;
            Downfall = root["downfall"] is not null ? root["downfall"]!.GetValue<double>() : 0;

            Effects = new BiomeEffects();
            if (root["effects"] is JsonObject eff)
            {
                if (eff["foliage_color"] != null) Effects.FoliageColor = eff["foliage_color"]!.GetValue<string>();
                if (eff["grass_color"] != null) Effects.GrassColor = eff["grass_color"]!.GetValue<string>();
                if (eff["water_color"] != null) Effects.WaterColor = eff["water_color"]!.GetValue<string>();
            }

            Features = new List<List<Identifier>>();
            if (root["features"] is JsonArray featuresArr)
            {
                foreach (var tier in featuresArr)
                {
                    var list = new List<Identifier>();
                    if (tier is JsonArray tierArr)
                    {
                        foreach (var item in tierArr)
                        {
                            if (item is JsonValue val && val.TryGetValue<string>(out var s)) list.Add(new Identifier(s));
                        }
                    }
                    Features.Add(list);
                }
            }

            HasPrecipitation = root["has_precipitation"] is not null && root["has_precipitation"]!.GetValue<bool>();

            SpawnCosts = new Dictionary<Identifier, SpawnCost>();
            if (root["spawn_costs"] is JsonObject sc)
            {
                foreach (var kvp in sc)
                {
                    var id = new Identifier(kvp.Key);
                    if (kvp.Value is JsonObject costObj)
                    {
                        var spawnCost = new SpawnCost();
                        if (costObj["energy_budget"] != null) spawnCost.EnergyBudget = costObj["energy_budget"]!.GetValue<double>();
                        if (costObj["charge"] != null) spawnCost.Charge = costObj["charge"]!.GetValue<double>();
                        SpawnCosts[id] = spawnCost;
                    }
                }
            }

            Spawners = new BiomeSpawners();
            if (root["spawners"] is JsonObject sp)
            {
                Spawners.FromJson(sp);
            }

            Temperature = root["temperature"] is not null ? root["temperature"]!.GetValue<double>() : 0;
        }

        public readonly string JsonString()
        {
            var root = new JsonObject();

            // Attributes
            var attrObj = new JsonObject();
            foreach (var kvp in Attributes)
            {
                var key = kvp.Key.ToString();
                var val = kvp.Value;
                if (val.IsBool && val.BoolValue is not null) attrObj[key] = val.BoolValue.Value;
                else if (val.IsString && val.StringValue is not null) attrObj[key] = val.StringValue;
                else if (val.IsBackgroundMusic && val.BackgroundMusicValue is not null)
                {
                    var b = new JsonObject();
                    var def = new JsonObject();
                    if (val.BackgroundMusicValue.MaxDelay is not null) def["max_delay"] = val.BackgroundMusicValue.MaxDelay.Value;
                    if (val.BackgroundMusicValue.MinDelay is not null) def["min_delay"] = val.BackgroundMusicValue.MinDelay.Value;
                    if (val.BackgroundMusicValue.Sound is not null) def["sound"] = val.BackgroundMusicValue.Sound.ToString();
                    b["default"] = def;
                    attrObj[key] = b;
                }
                else if (val.IsString && val.StringValue is not null)
                {
                    attrObj[key] = val.StringValue;
                }
            }
            root["attributes"] = attrObj;

            // Carvers
            var carversArr = new JsonArray();
            foreach (var c in Carvers) carversArr.Add(c.ToString());
            root["carvers"] = carversArr;

            root["creature_spawn_probability"] = CreatureSpawnProbability;
            root["downfall"] = Downfall;

            var eff = new JsonObject();
            if (Effects.FoliageColor is not null) eff["foliage_color"] = Effects.FoliageColor;
            if (Effects.GrassColor is not null) eff["grass_color"] = Effects.GrassColor;
            if (Effects.WaterColor is not null) eff["water_color"] = Effects.WaterColor;
            root["effects"] = eff;

            var feats = new JsonArray();
            foreach (var tier in Features)
            {
                var tierArr = new JsonArray();
                foreach (var id in tier) tierArr.Add(id.ToString());
                feats.Add(tierArr);
            }
            root["features"] = feats;

            root["has_precipitation"] = HasPrecipitation;

            var scObj = new JsonObject();
            foreach (var kvp in SpawnCosts)
            {
                var sObj = new JsonObject();
                if (kvp.Value.EnergyBudget is not null) sObj["energy_budget"] = kvp.Value.EnergyBudget.Value;
                if (kvp.Value.Charge is not null) sObj["charge"] = kvp.Value.Charge.Value;
                scObj[kvp.Key.ToString()] = sObj;
            }
            root["spawn_costs"] = scObj;

            root["spawners"] = Spawners.ToJson();

            root["temperature"] = Temperature;

            return root.ToString();
        }

        public readonly struct BiomeAttribute
        {
            public bool? BoolValue { get; }
            public string? StringValue { get; }
            public BackgroundMusic? BackgroundMusicValue { get; }

            public bool IsBool => BoolValue.HasValue;
            public bool IsString => StringValue is not null;
            public bool IsBackgroundMusic => BackgroundMusicValue != null;

            public BiomeAttribute(bool b)
            {
                BoolValue = b;
                StringValue = null;
                BackgroundMusicValue = null;
            }

            public BiomeAttribute(string s)
            {
                BoolValue = null;
                StringValue = s;
                BackgroundMusicValue = null;
            }

            public BiomeAttribute(BackgroundMusic bg)
            {
                BoolValue = null;
                StringValue = null;
                BackgroundMusicValue = bg;
            }
        }

        public class BackgroundMusic
        {
            public int? MaxDelay { get; set; }
            public int? MinDelay { get; set; }
            public Identifier? Sound { get; set; }
        }

        public class BiomeEffects
        {
            public string? FoliageColor { get; set; }
            public string? GrassColor { get; set; }
            public string? WaterColor { get; set; }
        }

        public struct SpawnCost
        {
            public double? EnergyBudget { get; set; }
            public double? Charge { get; set; }
        }

        public sealed class BiomeSpawners
        {
            public List<SpawnEntry> Ambient { get; } = new();
            public List<SpawnEntry> Axolotls { get; } = new();
            public List<SpawnEntry> Creature { get; } = new();
            public List<SpawnEntry> Misc { get; } = new();
            public List<SpawnEntry> Monster { get; } = new();
            public List<SpawnEntry> UndergroundWaterCreature { get; } = new();
            public List<SpawnEntry> WaterAmbient { get; } = new();
            public List<SpawnEntry> WaterCreature { get; } = new();

            internal void FromJson(JsonObject obj)
            {
                foreach (var kvp in obj)
                {
                    var list = GetListForKey(kvp.Key);
                    if (kvp.Value is JsonArray arr)
                    {
                        foreach (var item in arr)
                        {
                            if (item is JsonObject o)
                            {
                                var entry = new SpawnEntry();
                                if (o["type"] != null) entry.Type = new Identifier(o["type"]!.GetValue<string>());
                                if (o["maxCount"] != null) entry.MaxCount = o["maxCount"]!.GetValue<int>();
                                if (o["minCount"] != null) entry.MinCount = o["minCount"]!.GetValue<int>();
                                if (o["weight"] != null) entry.Weight = o["weight"]!.GetValue<int>();
                                list.Add(entry);
                            }
                        }
                    }
                }
            }

            internal JsonObject ToJson()
            {
                var obj = new JsonObject();
                void addList(string key, List<SpawnEntry> l)
                {
                    var arr = new JsonArray();
                    foreach (var e in l)
                    {
                        var o = new JsonObject
                        {
                            ["type"] = e.Type.ToString(),
                            ["maxCount"] = e.MaxCount,
                            ["minCount"] = e.MinCount,
                            ["weight"] = e.Weight
                        };
                        arr.Add(o);
                    }
                    obj[key] = arr;
                }

                addList("ambient", Ambient);
                addList("axolotls", Axolotls);
                addList("creature", Creature);
                addList("misc", Misc);
                addList("monster", Monster);
                addList("underground_water_creature", UndergroundWaterCreature);
                addList("water_ambient", WaterAmbient);
                addList("water_creature", WaterCreature);

                return obj;
            }

            private List<SpawnEntry> GetListForKey(string key)
            {
                return key switch
                {
                    "ambient" => Ambient,
                    "axolotls" => Axolotls,
                    "creature" => Creature,
                    "misc" => Misc,
                    "monster" => Monster,
                    "underground_water_creature" => UndergroundWaterCreature,
                    "water_ambient" => WaterAmbient,
                    "water_creature" => WaterCreature,
                    _ => new List<SpawnEntry>()
                };
            }
        }

        public struct SpawnEntry
        {
            public Identifier Type { get; set; }
            public int MaxCount { get; set; }
            public int MinCount { get; set; }
            public int Weight { get; set; }
        }
    }
}
