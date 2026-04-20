using Redstone.Nbt.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace Redstone.Core.Types.IntProviders
{
    public class ClampedNormalProvider : IntProvider
    {
        public override string Type => "clamped_normal";

        public int MinInclusive { get; set; }

        public int MaxInclusive { get; set; }

        public float Mean { get; set; }

        public float Deviation { get; set; }

        public ClampedNormalProvider() { }

        public ClampedNormalProvider(int minInclusive, int maxInclusive, float mean, float deviation)
        {
            MinInclusive = minInclusive;
            MaxInclusive = maxInclusive;
            Mean = mean;
            Deviation = deviation;
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
                    {  "mean", Mean },
                    {  "deviation", Deviation }
                };
            }
        }

        public override void FromJson(string json)
        {
            JsonObject jObj = JsonNode.Parse(json)!.AsObject();
            if (!jObj.ContainsKey("type")) throw new RedstoneException(new FormatException("JSON must contain a 'type' field."));
            if (!jObj.ContainsKey("min_inclusive")) throw new RedstoneException(new FormatException("JSON must contain a 'min_inclusive' field."));
            if (!jObj.ContainsKey("max_inclusive")) throw new RedstoneException(new FormatException("JSON must contain a 'max_inclusive' field."));
            if (!jObj.ContainsKey("mean")) throw new RedstoneException(new FormatException("JSON must contain a 'mean' field."));
            if (!jObj.ContainsKey("deviation")) throw new RedstoneException(new FormatException("JSON must contain a 'deviation' field."));

            string type = jObj["type"]!.GetValue<string>();
            if (type != Type) throw new RedstoneException(new FormatException($"Invalid type: expected '{Type}', got '{type}'"));

            int minInclusive = jObj["min_inclusive"]!.GetValue<int>();
            int maxInclusive = jObj["max_inclusive"]!.GetValue<int>();
            float mean = jObj["mean"]!.GetValue<float>();
            float deviation = jObj["deviation"]!.GetValue<float>();

            MinInclusive = minInclusive;
            MaxInclusive = maxInclusive;
            Mean = mean;
            Deviation = deviation;
        }

        public override JsonNode ToJson()
        {
            JsonObject obj = new()
            {
                { "type", Type },
                { "min_inclusive", MinInclusive },
                { "max_inclusive", MaxInclusive },
                { "mean", Mean },
                { "deviation", Deviation }
            };
            return obj;
        }

        public override void Parse(NbtTag tag)
        {
            if (tag is not CompoundTag cTag) throw new RedstoneException(new FormatException("NBT tag must be a CompoundTag."));
            if (!cTag.Contains("type")) throw new RedstoneException(new FormatException("NBT CompoundTag must contain a 'type' field."));
            if (!cTag.Contains("min_inclusive")) throw new RedstoneException(new FormatException("NBT CompoundTag must contain a 'min_inclusive' field."));
            if (!cTag.Contains("max_inclusive")) throw new RedstoneException(new FormatException("NBT CompoundTag must contain a 'max_inclusive' field."));
            if (!cTag.Contains("mean")) throw new RedstoneException(new FormatException("NBT CompoundTag must contain a 'mean' field."));
            if (!cTag.Contains("deviation")) throw new RedstoneException(new FormatException("NBT CompoundTag must contain a 'deviation' field."));

            string type = cTag["type"]!.ValueAsString;
            if (type != Type) throw new RedstoneException(new FormatException($"Invalid type: expected '{Type}', got '{type}'"));

            int minInclusive = cTag["min_inclusive"]!.ValueAsInt;
            int maxInclusive = cTag["max_inclusive"]!.ValueAsInt;
            float mean = cTag["mean"]!.ValueAsFloat;
            float deviation = cTag["deviation"]!.ValueAsFloat;

            MinInclusive = minInclusive;
            MaxInclusive = maxInclusive;
            Mean = mean;
            Deviation = deviation;
        }
    }
}
