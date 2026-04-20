using Redstone.Core.Registries;
using Redstone.Core.Types;
using Redstone.Core.Utils;
using Redstone.Nbt;
using Redstone.Nbt.Tags;
using System.Text.Json.Nodes;

namespace Redstone.Core.World
{
    public class BannerPattern : NbtTagProvider, IJsonProvider
    {
        public Identifier AssetID { get; private set; }

        public string TranslationKey { get; private set; }

        public BannerPattern(Identifier assetID, string translationKey)
        {
            RedstoneException.ThrowIfNull(assetID);
            RedstoneException.ThrowIfNull(translationKey);

            AssetID = assetID;
            TranslationKey = translationKey;
        }

        public BannerPattern(string json)
        {
            RedstoneException.ThrowIfNull(json);
            FromJson(json);
        }

        public BannerPattern(NbtTag tag)
        {
            RedstoneException.ThrowIfNull(tag);
            Parse(tag);
        }

        public BannerPattern(JsonObject json)
        {
            RedstoneException.ThrowIfNull(json);
            FromJson(json.ToJsonString());
        }

        public override CompoundTag Nbt
        {
            get
            {
                return new CompoundTag
                {
                    { "asset_id", AssetID.ToString() },
                    { "translation_key", TranslationKey }
                };
            }
        }

        public static Dictionary<Identifier, object> Keys
        {
            get
            {
                JsonObject items = JsonNode.Parse(File.ReadAllText(RegistryManager.RegistryLocations["banner_pattern"]))!.AsObject();
                Dictionary<Identifier, object> keys = new Dictionary<Identifier, object>();
                foreach (var item in items)
                {
                    keys.Add(item.Key, new BannerPattern(item.Value!.AsObject()));
                }

                return keys;
            }
        }

        public override void Parse(NbtTag tag)
        {
            RedstoneException.ThrowIfNull(tag);
            if (tag is not CompoundTag)
            {
                RedstoneException.Throw("Expected a CompoundTag for BannerPattern.");
            }
            
            CompoundTag compound = (CompoundTag)tag;

            if (!compound.Contains("asset_id", out NbtTag assetIdTag) || assetIdTag.ValueAsString == null)
            {
                RedstoneException.Throw("Missing or invalid 'asset_id' in BannerPattern.");
            }

            if (!compound.Contains("translation_key", out NbtTag translationKeyTag) || translationKeyTag.ValueAsString == null)
            {
                RedstoneException.Throw("Missing or invalid 'translation_key' in BannerPattern.");
            }

            AssetID = assetIdTag.ValueAsString!;
            TranslationKey = translationKeyTag.ValueAsString!;
        }

        public void FromJson(string json)
        {
            JsonObject obj = JsonNode.Parse(json)?.AsObject() ?? throw new RedstoneException("Invalid JSON for Banner Pattern.");
            if (!obj.TryGetPropertyValue("asset_id", out JsonNode? assetIdNode) || assetIdNode == null || assetIdNode.GetValue<string>() == null)
            {
                RedstoneException.Throw("Missing or invalid 'asset_id' in Banner Pattern JSON.");
            }

            if (!obj.TryGetPropertyValue("translation_key", out JsonNode? translationKeyNode) || translationKeyNode == null || translationKeyNode.GetValue<string>() == null)
            {
                RedstoneException.Throw("Missing or invalid 'translation_key' in Banner Pattern JSON.");
            }

            AssetID = assetIdNode.GetValue<string>()!;
            TranslationKey = translationKeyNode!.GetValue<string>()!;
        }

        public JsonNode ToJson()
        {
            return new JsonObject()
            {
                { "asset_id", AssetID.ToString()  },
                { "translation_key", TranslationKey  }
            };
        }


    }
}
