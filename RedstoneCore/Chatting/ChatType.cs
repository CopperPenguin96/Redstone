using Redstone.Core.Registries;
using Redstone.Core.Types;
using Redstone.Core.Utils;
using Redstone.Core.World;
using Redstone.Nbt;
using Redstone.Nbt.Tags;
using System.Text.Json.Nodes;

namespace Redstone.Core.Chatting
{
    public class ChatType : NbtTagProvider, IJsonProvider
    {
        public string TranslationKey { get; private set; }

        public ChatParam[] Params { get; private set; }

        public string NarrationTranslationKey { get; private set; }

        public ChatParam[] NarrationParams { get; private set; }

        public ChatType(string translationkey, ChatParam[] @params, string narrationTranslationKey, ChatParam[] narrationParams)
        {
            RedstoneException.ThrowIfNull(translationkey);
            RedstoneException.ThrowIfNull(@params);
            RedstoneException.ThrowIfNull(narrationTranslationKey);
            RedstoneException.ThrowIfNull(narrationParams);

            TranslationKey = translationkey;
            Params = @params;
            NarrationTranslationKey = narrationTranslationKey;
            NarrationParams = narrationParams;
        }

        public ChatType(string json)
        {
            RedstoneException.ThrowIfNull(json);
            FromJson(json);
        }

        public ChatType(NbtTag tag)
        {
            RedstoneException.ThrowIfNull(tag);
            Parse(tag);
        }

        public ChatType(JsonObject json)
        {
            RedstoneException.ThrowIfNull(json);
            FromJson(json.ToJsonString());
        }

        public override CompoundTag Nbt
        {
            get
            {
                CompoundTag tag = new();

                CompoundTag chatTag = new();
                chatTag.Add("translation_key", TranslationKey);
                ListTag paramsTag = new("parameters", TagType.String);

                foreach (ChatParam param in Params)
                {
                    paramsTag.Add(new StringTag(param.ToString().ToLower()));
                }

                chatTag.Add(paramsTag);
                tag.Add("chat", chatTag);

                CompoundTag narrationTag = new();
                narrationTag.Add("translation_key", NarrationTranslationKey);
                ListTag narrationParamsTag = new("parameters", TagType.String);
                foreach (ChatParam param in NarrationParams)
                {
                    narrationParamsTag.Add(new StringTag(param.ToString().ToLower()));
                }
                narrationTag.Add(narrationParamsTag);
                tag.Add("narration", narrationTag);
                return tag;
            }
        }

        public override void Parse(NbtTag tag)
        {
            RedstoneException.ThrowIfNull(tag);
            if (tag is not CompoundTag)
            {
                RedstoneException.Throw("Expected a CompoundTag for Chat Type.");
            }

            CompoundTag compound = (CompoundTag)tag;

            if (!compound.Contains("chat", out NbtTag chatTag) || chatTag is not CompoundTag)
            {
                RedstoneException.Throw("Missing or invalid 'chat' tag in Chat Type.");
            }

            if (!compound.Contains("narration", out NbtTag narrationTag) || narrationTag is not CompoundTag || chatTag is not CompoundTag)
            {
                RedstoneException.Throw("Missing or invalid 'narration' tag in Chat Type.");
            }

            CompoundTag chatCompound = (CompoundTag)chatTag;

            if (!chatCompound.Contains("translation_key", out NbtTag translationKeyTag) || translationKeyTag.ValueAsString == null)
            {
                RedstoneException.Throw("Missing or invalid 'translation_key' in 'chat' tag of Chat Type.");
            }

            if (!chatCompound.Contains("parameters", out NbtTag paramsTag) || paramsTag.Type != TagType.List || paramsTag.ValueAsList == null)
            {
                RedstoneException.Throw("Missing or invalid 'parameters' in 'chat' tag of Chat Type.");
            }

            TranslationKey = translationKeyTag.ValueAsString!;
            List<ChatParam> paramsList = new();
            foreach (NbtTag paramTag in paramsTag.ValueAsList!)
            {
                if (paramTag.ValueAsString == null || !Enum.TryParse(paramTag.ValueAsString, true, out ChatParam param))
                {
                    RedstoneException.Throw("Invalid parameter in 'parameters' of 'chat' tag in Chat Type.");
                }

                switch (paramTag.Value)
                {
                    case "sender":
                        paramsList.Add(ChatParam.Sender);
                        break;
                    case "target":
                        paramsList.Add(ChatParam.Target);
                        break;
                    case "content":
                        paramsList.Add(ChatParam.Content);
                        break;
                    default:
                        RedstoneException.Throw($"Unknown parameter '{paramTag.ValueAsString}' in 'parameters' of 'chat' tag in Chat Type.");
                        break;
                }
            }

            CompoundTag narrationCompound = (CompoundTag)narrationTag;

            if (!narrationCompound.Contains("translation_key", out NbtTag narrationTranslationKeyTag) || narrationTranslationKeyTag.ValueAsString == null)
            {
                RedstoneException.Throw("Missing or invalid 'translation_key' in 'narration' tag of Chat Type.");
            }

            if (!narrationCompound.Contains("parameters", out NbtTag narrationParamsTag) || narrationParamsTag.Type != TagType.List || narrationParamsTag.ValueAsList == null)
            {
                RedstoneException.Throw("Missing or invalid 'parameters' in 'narration' tag of Chat Type.");
            }

            NarrationTranslationKey = narrationTranslationKeyTag.ValueAsString!;

            List<ChatParam> narrationParamsList = new();

            foreach (NbtTag paramTag in narrationParamsTag.ValueAsList!)
            {
                if (paramTag.ValueAsString == null || !Enum.TryParse(paramTag.ValueAsString, true, out ChatParam param))
                {
                    RedstoneException.Throw("Invalid parameter in 'parameters' of 'narration' tag in Chat Type.");
                }
                switch (paramTag.Value)
                {
                    case "sender":
                        narrationParamsList.Add(ChatParam.Sender);
                        break;
                    case "target":
                        narrationParamsList.Add(ChatParam.Target);
                        break;
                    case "content":
                        narrationParamsList.Add(ChatParam.Content);
                        break;
                    default:
                        RedstoneException.Throw($"Unknown parameter '{paramTag.ValueAsString}' in 'parameters' of 'narration' tag in Chat Type.");
                        break;
                }
            }
        }

        public void FromJson(string json)
        {
            JsonObject obj = JsonNode.Parse(json)?.AsObject() ?? throw new RedstoneException("Invalid JSON for Chat Type.");

            if (!obj.ContainsKey("chat") || obj["chat"] is not JsonObject chatObj)
            {
                throw new RedstoneException("Missing 'chat' object in JSON for Chat Type in.");
            }

            if (!chatObj.ContainsKey("translation_key") || chatObj["translation_key"]?.GetValue<string>() == null)
            {
                throw new RedstoneException("Missing 'translation_key' in 'chat' object of JSON for Chat Type.");
            }

            if (!chatObj.ContainsKey("parameters") || chatObj["parameters"] is not JsonArray chatParamsArray)
            {
                throw new RedstoneException("Missing 'parameters' array in 'chat' object of JSON for Chat Type.");
            }

            TranslationKey = chatObj["translation_key"]!.GetValue<string>()!;
            Params = [.. chatParamsArray.Select(param =>
            {
                if (param!.GetValue<string>() == null || !Enum.TryParse(param.GetValue<string>(), true, out ChatParam chatParam))
                {
                    throw new RedstoneException("Invalid parameter in 'parameters' array of 'chat' object in JSON for Chat Type.");
                }
                return chatParam;
            })];

            if (!obj.ContainsKey("narration") || obj["narration"] is not JsonObject narrationObj)
            {
                throw new RedstoneException("Missing 'narration' object in JSON for Chat Type.");
            }

            if (!narrationObj.ContainsKey("translation_key") || narrationObj["translation_key"]?.GetValue<string>() == null)
            {
                throw new RedstoneException("Missing 'translation_key' in 'narration' object of JSON for Chat Type.");
            }

            if (!narrationObj.ContainsKey("parameters") || narrationObj["parameters"] is not JsonArray narrationParamsArray)
            {
                throw new RedstoneException("Missing 'parameters' array in 'narration' object of JSON for Chat Type.");
            }

            NarrationTranslationKey = narrationObj["translation_key"]!.GetValue<string>()!;
            NarrationParams = [.. narrationParamsArray.Select(param =>
            {
                if (param!.GetValue<string>() == null || !Enum.TryParse(param.GetValue<string>(), true, out ChatParam narrationParam))
                {
                    throw new RedstoneException("Invalid parameter in 'parameters' array of 'narration' object in JSON for Chat Type.");
                }
                return narrationParam;
            })];
        }

        public JsonNode ToJson()
        {
            JsonArray chatParams = new JsonArray();
            JsonArray narrationParams = new JsonArray();

            foreach (ChatParam param in Params)
            {
                chatParams.Add(param.ToString().ToLower());
            }

            foreach (ChatParam param in NarrationParams)
            {
                narrationParams.Add(param.ToString().ToLower());
            }

            return new JsonObject()
            {
                { "chat", new JsonObject()
                    {
                        { "translation_key", TranslationKey },
                        { "parameters", chatParams }
                    }
                 },
                { "narration", new JsonObject()
                    {
                        { "translation_key", NarrationTranslationKey },
                        { "parameters", narrationParams }
                    }
                }
            };
        }

        public static Dictionary<Identifier, object> Keys
        {
            get
            {
                JsonObject items = JsonNode.Parse(File.ReadAllText(RegistryManager.RegistryLocations["chat_type"]))!.AsObject();
                Dictionary<Identifier, object> keys = new Dictionary<Identifier, object>();
                foreach (var item in items)
                {
                    keys.Add(item.Key, new ChatType(item.Value!.AsObject()));
                }

                return keys;
            }
        }
    }

    public enum ChatParam
    {
        Sender,
        Target,
        Content
    }
}
