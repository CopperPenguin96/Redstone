using Redstone.Nbt.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace Redstone.Core.Types.IntProviders
{
    public class WeightedListProvider : IntProvider
    {
        public override string Type => "weighted_list";

        public int MinInclusive { get; set; }

        public int MaxInclusive { get; set; }

        public List<WeightedEntry> Entries { get; set; }

        public WeightedListProvider() { }

        public WeightedListProvider(int minInclusive, int maxInclusive, List<WeightedEntry> entries)
        {
            MinInclusive = minInclusive;
            MaxInclusive = maxInclusive;
            Entries = entries;
        }

        public override CompoundTag Nbt
        {
            get
            {
                CompoundTag tag = new()
                {
                    {  "type", Type },
                    {  "min_inclusive", MinInclusive },
                    {  "max_inclusive", MaxInclusive }
                };

                ListTag distriList = new ListTag("distribution", TagType.Compound);
                foreach (var entry in Entries)
                {
                    CompoundTag di = new()
                    {
                        { "weight", entry.Weight },
                        { "entry", entry.Entry.Nbt }
                    };
                    distriList.Add(di);
                }

                tag.Add(distriList);

                return tag;
            }
            
        }

        public override void FromJson(string json)
        {
            JsonObject jObj = JsonNode.Parse(json)!.AsObject();
            if (!jObj.ContainsKey("type")) throw new RedstoneException(new FormatException("JSON must contain a 'type' field."));
            if (!jObj.ContainsKey("min_inclusive")) throw new RedstoneException(new FormatException("JSON must contain a 'min_inclusive' field."));
            if (!jObj.ContainsKey("max_inclusive")) throw new RedstoneException(new FormatException("JSON must contain a 'max_inclusive' field."));
            if (!jObj.ContainsKey("distribution")) throw new RedstoneException(new FormatException("JSON must contain a 'distribution' field."));

            string type = jObj["type"]!.GetValue<string>();
            if (type != Type) throw new RedstoneException(new FormatException($"Invalid type: expected '{Type}', got '{type}'"));

            int minInclusive = jObj["min_inclusive"]!.GetValue<int>();
            int maxInclusive = jObj["max_inclusive"]!.GetValue<int>();

            JsonArray distriArray = jObj["distribution"]!.AsArray();
            List<WeightedEntry> entries = new();

            foreach (var item in distriArray)
            {
                JsonObject entryObj = item!.AsObject();
                if (!entryObj.ContainsKey("weight")) throw new RedstoneException(new FormatException("Each distribution entry must contain a 'weight' field."));
                if (!entryObj.ContainsKey("entry")) throw new RedstoneException(new FormatException("Each distribution entry must contain an 'entry' field."));

                int weight = entryObj["weight"]!.GetValue<int>();
                JsonObject data = entryObj["data"]!.AsObject();
                IntProvider dataObject;
                switch (data["type"]!.GetValue<string>())
                {
                    case "constant":
                        var cp = new ConstantProvider();
                        cp.FromJson(data.ToJsonString());
                        dataObject = cp;
                        break;
                    case "uniform":
                        var up = new UniformProvider();
                        up.FromJson(data.ToJsonString());
                        dataObject = up;
                        break;
                    case "biased_to_bottom":
                        var btb = new BiasedToBottomProvider();
                        btb.FromJson(data.ToJsonString());
                        dataObject = btb;
                        break;
                    case "clamped":
                        var cp2 = new ClampedProvider();
                        cp2.FromJson(data.ToJsonString());
                        dataObject = cp2;
                        break;
                    case "clamped_normal":
                        var cn = new ClampedNormalProvider();
                        cn.FromJson(data.ToJsonString());
                        dataObject = cn;
                        break;
                    case "weighted_list":
                        var wl = new WeightedListProvider();
                        wl.FromJson(data.ToJsonString());
                        dataObject = wl;
                        break;
                    default:
                        throw new RedstoneException("Unknown IntProvider type: " + data["type"]!.GetValue<string>());
                }

                WeightedEntry entry = new(weight, dataObject);
                entries.Add(entry);
            }

            MinInclusive = minInclusive;
            MaxInclusive = maxInclusive;
            Entries = entries;
        }

        public override JsonNode ToJson()
        {
            JsonObject obj = new()
            {
                { "type", Type },
                { "min_inclusive", MinInclusive },
                { "max_inclusive", MaxInclusive }
            };

            JsonArray distriArray = new("distribution");

            foreach (var entry in Entries)
            {
                JsonObject entryObj = new()
                {
                    { "weight", entry.Weight },
                    { "data", entry.Entry.ToJson() }
                };
                distriArray.Add(entryObj);
            }
            obj["distribution"] = distriArray;
            return obj;
        }

        public override void Parse(NbtTag tag)
        {
            if (tag is not CompoundTag cTag) throw new RedstoneException(new FormatException("NBT tag must be a CompoundTag."));
            if (!cTag.Contains("type")) throw new RedstoneException(new FormatException("NBT CompoundTag must contain a 'type' field."));
            if (!cTag.Contains("min_inclusive")) throw new RedstoneException(new FormatException("NBT CompoundTag must contain a 'min_inclusive' field."));
            if (!cTag.Contains("max_inclusive")) throw new RedstoneException(new FormatException("NBT CompoundTag must contain a 'max_inclusive' field."));
            if (!cTag.Contains("distribution")) throw new RedstoneException(new FormatException("NBT CompoundTag must contain a 'distribution' field."));

            string type = cTag["type"]!.ValueAsString;
            if (type != Type) throw new RedstoneException(new FormatException($"Invalid type: expected '{Type}', got '{type}'"));

            int minInclusive = cTag["min_inclusive"]!.ValueAsInt;
            int maxInclusive = cTag["max_inclusive"]!.ValueAsInt;
            List<NbtTag> distriList = cTag["distribution"]!.ValueAsList;

            List<WeightedEntry> entries = new();

            foreach (var item in distriList)
            {
                if (item is not CompoundTag entryTag) throw new RedstoneException(new FormatException("Each distribution entry must be a CompoundTag."));
                if (!entryTag.Contains("weight")) throw new RedstoneException(new FormatException("Each distribution entry must contain a 'weight' field."));
                if (!entryTag.Contains("entry")) throw new RedstoneException(new FormatException("Each distribution entry must contain an 'entry' field."));
                int weight = entryTag["weight"]!.ValueAsInt;
                CompoundTag data = new(null!, entryTag["entry"]!.ValueAsList);
                IntProvider dataObject;
                switch (data["type"]!.ValueAsString)
                {
                    case "constant":
                        var cp = new ConstantProvider();
                        cp.Parse(data);
                        dataObject = cp;
                        break;
                    case "uniform":
                        var up = new UniformProvider();
                        up.Parse(data);
                        dataObject = up;
                        break;
                    case "biased_to_bottom":
                        var btb = new BiasedToBottomProvider();
                        btb.Parse(data);
                        dataObject = btb;
                        break;
                    case "clamped":
                        var cp2 = new ClampedProvider();
                        cp2.Parse(data);
                        dataObject = cp2;
                        break;
                    case "clamped_normal":
                        var cn = new ClampedNormalProvider();
                        cn.Parse(data);
                        dataObject = cn;
                        break;
                    case "weighted_list":
                        var wl = new WeightedListProvider();
                        wl.Parse(data);
                        dataObject = wl;
                        break;
                    default:
                        throw new RedstoneException("Unknown IntProvider type: " + data["type"]!.ValueAsString);
                }
                WeightedEntry entry = new(weight, dataObject);
                entries.Add(entry);
            }

            MinInclusive = minInclusive;
            MaxInclusive = maxInclusive;
            Entries = entries;
        }
    }

    public class WeightedEntry
    {
        public int Weight { get; set; }

        public IntProvider Entry { get; set; }

        public WeightedEntry() { }

        public WeightedEntry(int weight, IntProvider entry)
        {
            Weight = weight;
            Entry = entry;
        }
    }
}
