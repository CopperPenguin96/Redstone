using Redstone.Core.Utils;
using Redstone.Nbt;
using Redstone.Nbt.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace Redstone.Core.Types.IntProviders
{

    public abstract class IntProvider : NbtTagProvider, IJsonProvider
    {
        public abstract string Type { get; }

        public override abstract CompoundTag Nbt { get; }

        public abstract void FromJson(string json);

        public abstract JsonNode ToJson();

        public abstract override void Parse(NbtTag tag);

        protected static string ReadProviderType(JsonObject json)
        {
            if (!json.ContainsKey("type")) throw new RedstoneException(new FormatException("JSON must contain a 'type' field."));
            return json["type"]!.GetValue<string>();
        }

        protected static string ReadProviderType(CompoundTag tag)
        {
            if (!tag.Contains("type")) throw new RedstoneException(new FormatException("NBT tag must contain a 'type' field."));
            return tag["type"]!.ValueAsString;
        }
    }
}
