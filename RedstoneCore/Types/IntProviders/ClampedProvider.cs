using Redstone.Nbt.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace Redstone.Core.Types.IntProviders
{
    public class ClampedProvider : IntProvider
    {
        public override string Type => "clamped";

        public int MinInclusive { get; set; }

        public int MaxInclusive { get; set; }

        public IntProvider Source { get; set; }

        public ClampedProvider() { }

        public ClampedProvider(int minInclusive, int maxInclusive, IntProvider source)
        {
            MinInclusive = minInclusive;
            MaxInclusive = maxInclusive;
            Source = source;
        }

        public override CompoundTag Nbt
        {
            get
            {
                return new CompoundTag()
                {
                    {  "type", Type },
                    {  "min_inclusive", MinInclusive },
                    {  "max_inclusive", MaxInclusive },
                    {  "source", Source.Nbt }
                };
            }
        }

        public override void FromJson(string json)
        {
            JsonObject jObj = JsonNode.Parse(json)!.AsObject();
            if (!jObj.ContainsKey("type")) throw new RedstoneException(new FormatException("JSON must contain a 'type' field."));
            if (!jObj.ContainsKey("min_inclusive")) throw new RedstoneException(new FormatException("JSON must contain a 'min_inclusive' field."));
            if (!jObj.ContainsKey("max_inclusive")) throw new RedstoneException(new FormatException("JSON must contain a 'max_inclusive' field."));
            if (!jObj.ContainsKey("source")) throw new RedstoneException(new FormatException("JSON must contain a 'source' field."));

            string type = jObj["type"]!.GetValue<string>();
            if (type != Type) throw new RedstoneException(new FormatException($"Invalid type: expected '{Type}', got '{type}'"));

            int minInclusive = jObj["min_inclusive"]!.GetValue<int>();
            int maxInclusive = jObj["max_inclusive"]!.GetValue<int>();

            JsonObject source = jObj["source"]!.AsObject();
            
            switch (source["type"]!.GetValue<string>())
            {
                case "constant":
                    var cp = new ConstantProvider();
                    cp.FromJson(source.ToJsonString());
                    Source = cp;
                    break;
                case "uniform":
                    var up = new UniformProvider();
                    up.FromJson(source.ToJsonString());
                    Source = up;
                    break;
                case "biased_to_bottom":
                    var btb = new BiasedToBottomProvider();
                    btb.FromJson(source.ToJsonString());
                    Source = btb;
                    break;
                case "clamped":
                    var cp2 = new ClampedProvider();
                    cp2.FromJson(source.ToJsonString());
                    Source = cp2;
                    break;
                case "clamped_normal":
                    var cn = new ClampedNormalProvider();
                    cn.FromJson(source.ToJsonString());
                    Source = cn;
                    break;
                case "weighted_list":
                    var wl = new WeightedListProvider();
                    wl.FromJson(source.ToJsonString());
                    Source = wl;
                    break;
            }

            MinInclusive = minInclusive;
            MaxInclusive = maxInclusive;
        }

        public override JsonNode ToJson()
        {
            JsonObject obj = new()
            {
                { "type", Type },
                { "min_inclusive", MinInclusive },
                { "max_inclusive", MaxInclusive },
                { "source", Source.ToJson().AsObject() }
            };
            return obj;
        }

        public override void Parse(NbtTag tag)
        {
            if (tag is not CompoundTag cTag) throw new RedstoneException(new FormatException("NBT tag must be a CompoundTag."));
            if (!cTag.Contains("type")) throw new RedstoneException(new FormatException("NBT tag must contain a 'type' field."));
            if (!cTag.Contains("min_inclusive")) throw new RedstoneException(new FormatException("NBT tag must contain a 'min_inclusive' field."));
            if (!cTag.Contains("max_inclusive")) throw new RedstoneException(new FormatException("NBT tag must contain a 'max_inclusive' field."));
            if (!cTag.Contains("source")) throw new RedstoneException(new FormatException("NBT tag must contain a 'source' field."));

            string type = cTag["type"]!.ValueAsString;
            if (type != Type) throw new RedstoneException(new FormatException($"Invalid type: expected '{Type}', got '{type}'"));

            List<NbtTag> source = cTag["source"]!.ValueAsList;
            CompoundTag compoundTag = new CompoundTag("source", source);
            switch (compoundTag["type"]!.ValueAsString)
            {
                case "constant":
                    var cp = new ConstantProvider();
                    cp.Parse(compoundTag);
                    Source = cp;
                    break;
                case "uniform":
                    var up = new UniformProvider();
                    up.Parse(compoundTag);
                    Source = up;
                    break;
                case "biased_to_bottom":
                    var btb = new BiasedToBottomProvider();
                    btb.Parse(compoundTag);
                    Source = btb;
                    break;
                case "clamped":
                    var cp2 = new ClampedProvider();
                    cp2.Parse(compoundTag);
                    Source = cp2;
                    break;
                case "clamped_normal":
                    var cn = new ClampedNormalProvider();
                    cn.Parse(compoundTag);
                    Source = cn;
                    break;
                case "weighted_list":
                    var wl = new WeightedListProvider();
                    wl.Parse(compoundTag);
                    Source = wl;
                    break;
            }


            int minInclusive = cTag["min_inclusive"]!.ValueAsInt;
            int maxInclusive = cTag["max_inclusive"]!.ValueAsInt;

            MinInclusive = minInclusive;
            MaxInclusive = maxInclusive;
        }
    }
}
