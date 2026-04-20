using Redstone.Nbt.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace Redstone.Core.Types.IntProviders
{
    public class UniformProvider : IntProvider
    {
        public override string Type => "uniform";

        public int MinInclusive { get; set; }

        public int MaxInclusive { get; set; }

        public UniformProvider() { }

        public UniformProvider(int minInclusive, int maxInclusive)
        {
            MinInclusive = minInclusive;
            MaxInclusive = maxInclusive;
        }

        public override CompoundTag Nbt
        {
            get
            {
                return new CompoundTag()
                {
                    {  "type", Type },
                    {  "min_inclusive", MinInclusive },
                    {  "max_inclusive", MaxInclusive }
                };
            }
        }

        public override void FromJson(string json)
        {
            JsonObject jObj = JsonNode.Parse(json)!.AsObject();
            if (!jObj.ContainsKey("type")) throw new RedstoneException(new FormatException("JSON must contain a 'type' field."));
            if (!jObj.ContainsKey("min_inclusive")) throw new RedstoneException(new FormatException("JSON must contain a 'min_inclusive' field."));
            if (!jObj.ContainsKey("max_inclusive")) throw new RedstoneException(new FormatException("JSON must contain a 'max_inclusive' field."));

            string type = jObj["type"]!.GetValue<string>();
            if (type != Type) throw new RedstoneException(new FormatException($"Invalid type: expected '{Type}', got '{type}'"));

            int minInclusive = jObj["min_inclusive"]!.GetValue<int>();
            int maxInclusive = jObj["max_inclusive"]!.GetValue<int>();

            MinInclusive = minInclusive;
            MaxInclusive = maxInclusive;
        }

        public override JsonNode ToJson()
        {
            JsonObject obj = new()
            {
                { "type", Type },
                { "min_inclusive", MinInclusive },
                { "max_inclusive", MaxInclusive }
            };
            return obj;
        }

        public override void Parse(NbtTag tag)
        {
            if (tag is not CompoundTag cTag) throw new RedstoneException(new FormatException("NBT tag must be a CompoundTag."));
            if (!cTag.Contains("type")) throw new RedstoneException(new FormatException("NBT CompoundTag must contain a 'type' field."));
            if (!cTag.Contains("min_inclusive")) throw new RedstoneException(new FormatException("NBT CompoundTag must contain a 'min_inclusive' field."));
            if (!cTag.Contains("max_inclusive")) throw new RedstoneException(new FormatException("NBT CompoundTag must contain a 'max_inclusive' field."));

            string type = cTag["type"]!.ValueAsString;
            if (type != Type) throw new RedstoneException(new FormatException($"Invalid type: expected '{Type}', got '{type}'"));

            int minInclusive = cTag["min_inclusive"]!.ValueAsInt;
            int maxInclusive = cTag["max_inclusive"]!.ValueAsInt;

            MinInclusive = minInclusive;
            MaxInclusive = maxInclusive;
        }
    }
}
