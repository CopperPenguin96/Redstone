using Redstone.Core.Registries;
using Redstone.Core.Types;
using Redstone.Core.Utils;
using Redstone.Nbt;
using Redstone.Nbt.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace Redstone.Core.World
{
    public class PaintingVariant : NbtTagProvider, IJsonProvider
    {
        public Identifier Asset { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public PaintingVariant(Identifier asset, int width, int height)
        {
            Asset = asset;
            Width = width;
            Height = height;
        }

        public override NbtTag Nbt
        {
            get
            {
                return new CompoundTag(Asset.ToString())
                {
                    { "asset_id", Asset.ToString() },
                    { "width", Width },
                    { "height", Height }
                };
            }
        }

        public void FromJson(string json)
        {
            JsonObject obj = JsonNode.Parse(json)?.AsObject() ?? throw new ArgumentException("Invalid JSON string provided.");

            if (!obj.TryGetPropertyValue("asset_id", out JsonNode? assetNode) || assetNode == null)
            {
                throw new ArgumentException("JSON must contain an 'asset_id' property.");
            }

            if (!obj.TryGetPropertyValue("width", out JsonNode? widthNode) || widthNode == null || !int.TryParse(widthNode.ToString(), out int width))
            {
                throw new ArgumentException("JSON must contain a valid 'width' property.");
            }

            if (!obj.TryGetPropertyValue("height", out JsonNode? heightNode) || heightNode == null || !int.TryParse(heightNode.ToString(), out int height))
            {
                throw new ArgumentException("JSON must contain a valid 'height' property.");
            }

            Asset = new Identifier(assetNode.ToString());
            Width = obj["width"]!.GetValue<int>();
            Height = obj["height"]!.GetValue<int>();
        }

        public override void Parse(NbtTag tag)
        {
            if (!(tag is CompoundTag compound))
            {
                throw new ArgumentException("Expected a CompoundTag for PaintingVariant.");
            }

            if (!compound.Contains("asset_id") || !compound.Contains("width") || !compound.Contains("height"))
            {
                throw new ArgumentException("CompoundTag must contain 'asset_id', 'width', and 'height' properties.");
            }

            Asset = new Identifier(compound["asset_id"]!.ValueAsString);
            Width = compound["width"]!.ValueAsInt;
            Height = compound["height"]!.ValueAsInt;
        }

        public JsonNode ToJson()
        {
            return new JsonObject
            {
                { "asset_id", Asset.ToString() },
                { "width", Width },
                { "height", Height }
            };
        }

        public static Dictionary<Identifier, object> Keys
        {
            get
            {
                Dictionary<Identifier, object> keys = new Dictionary<Identifier, object>();
                foreach (var entry in RegistryManager.Registries[new Identifier("painting_variant")].Entries)
                {
                    keys.Add(entry.Key, entry.Value);
                }
                return keys;
            }
        }
    }
}
