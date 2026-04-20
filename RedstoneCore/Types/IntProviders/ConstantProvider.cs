using Redstone.Nbt.Tags;
using System.Text.Json.Nodes;

namespace Redstone.Core.Types.IntProviders
{
    public class ConstantProvider : IntProvider
    {
        public override string Type => "constant";

        public int Value { get; set; }

        public ConstantProvider() { }

        public ConstantProvider(int value)
        {
            Value = value;
        }

        public override CompoundTag Nbt
        {
            get
            {
                return new CompoundTag()
                {
                    {  "type", Type },
                    {  "value", Value }
                };
            }
        }

        public override void FromJson(string json)
        {
            JsonObject jObj = JsonNode.Parse(json)!.AsObject();
            if (!jObj.ContainsKey("type")) throw new RedstoneException(new FormatException("JSON must contain a 'type' field."));
            if (!jObj.ContainsKey("value")) throw new RedstoneException(new FormatException("JSON must contain a 'value' field."));

            string type = jObj["type"]!.GetValue<string>();
            if (type != Type) throw new RedstoneException(new FormatException($"Invalid type: expected '{Type}', got '{type}'"));

            int value = jObj["value"]!.GetValue<int>();

            
            Value = value;
        }

        public override JsonNode ToJson()
        {
            JsonObject obj = new()
            {
                { "type", Type },
                { "value", Value }
            };
            return obj;
        }

        public override void Parse(NbtTag tag)
        {
            if (tag is not CompoundTag cTag) throw new RedstoneException(new FormatException("NBT tag must be a CompoundTag."));
            if (!cTag.Contains("type")) throw new RedstoneException(new FormatException("NBT tag must contain a 'type' field."));
            if (!cTag.Contains("value")) throw new RedstoneException(new FormatException("NBT tag must contain a 'value' field."));

            string type = cTag["type"]!.ValueAsString;
            if (type != Type) throw new RedstoneException(new FormatException($"Invalid type: expected '{Type}', got '{type}'"));

            int value = cTag["value"]!.ValueAsInt;

            
            Value = value;
        }
    }
}
