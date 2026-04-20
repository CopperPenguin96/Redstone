using Redstone.Core.Registries;
using Redstone.Core.Types;
using Redstone.Core.Utils;
using Redstone.Core.World;
using Redstone.Nbt;
using Redstone.Nbt.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace Redstone.Core.Entities
{
    public class DamageType : NbtTagProvider, IJsonProvider
    {
        public string MessageId { get; private set; }

        public float Exhaustion { get; private set; }

        public DamageScaling Scaling { get; private set; }

        public OptValue<DamageEffect> Effects { get; set; } = new();

        public OptValue<DeathMessageType> DeathMessage { get; set; } = new();

        public DamageType(string messageId, float exhaustion, DamageScaling scaling, DamageEffect? effects = null, DeathMessageType? deathMessageType = null)
        {
            RedstoneException.ThrowIfNull(messageId);

            MessageId = messageId;
            Exhaustion = exhaustion;
            Scaling = scaling;
            Effects = effects != null ? new OptValue<DamageEffect>(effects.Value) : new OptValue<DamageEffect>();
            DeathMessage = deathMessageType != null ? new OptValue<DeathMessageType>(deathMessageType.Value) : new OptValue<DeathMessageType>();
        }

        public DamageType(string json)
        {
            RedstoneException.ThrowIfNull(json);
            FromJson(json);
        }

        public DamageType(JsonObject json)
        {
            RedstoneException.ThrowIfNull(json);
            FromJson(json.ToJsonString());
        }

        public DamageType(NbtTag tag)
        {
            RedstoneException.ThrowIfNull(tag);
            Parse(tag);
        }

        public override CompoundTag Nbt
        {
            get
            {
                CompoundTag tag = new();
                tag.Add("message_id", MessageId);
                tag.Add("exhaustion", Exhaustion);
                tag.Add("scaling", ScalingToString(Scaling));

                if (Effects != null && Effects.Enabled)
                {
                    tag.Add("effects", DamageEffectToString(Effects.Value));
                }

                if (DeathMessage != null && DeathMessage.Enabled)
                {
                    tag.Add("death_message_type", DeathMessageTypeToString(DeathMessage.Value));
                }

                return tag;
            }
        }

        public override void Parse(NbtTag tag)
        {
            RedstoneException.ThrowIfNull(tag);
            if (tag is not CompoundTag)
            {
                RedstoneException.Throw("Expected a CompoundTag for Damage Type.");
            }

            CompoundTag compound = (CompoundTag)tag;

            if (!compound.Contains("message_id", out NbtTag? messageTag) || messageTag.ValueAsString == null)
            {
                RedstoneException.Throw("Missing or invalid 'message_id' in Damage Type.");
            }

            if (!compound.Contains("exhaustion", out NbtTag? exhaustionTag))
            {
                RedstoneException.Throw("Missing 'exhaustion' in Damage Type.");
            }

            if (!compound.Contains("scaling", out NbtTag? scalingTag) || scalingTag.ValueAsString == null)
            {
                RedstoneException.Throw("Missing or invalid 'scaling' in Damage Type.");
            }

            MessageId = messageTag.ValueAsString!;
            Exhaustion = exhaustionTag.ValueAsFloat;
            Scaling = ParseScaling(scalingTag.ValueAsString!);

            if (compound.Contains("effects", out NbtTag? effectsTag) && effectsTag.ValueAsString != null)
            {
                Effects = new OptValue<DamageEffect>(ParseDamageEffect(effectsTag.ValueAsString!));
            }
            else
            {
                Effects = new OptValue<DamageEffect>();
            }

            if (compound.Contains("death_message_type", out NbtTag? dmtTag) && dmtTag.ValueAsString != null)
            {
                DeathMessage = new OptValue<DeathMessageType>(ParseDeathMessageType(dmtTag.ValueAsString!));
            }
            else
            {
                DeathMessage = new OptValue<DeathMessageType>();
            }
        }

        public void FromJson(string json)
        {
            JsonObject obj = JsonNode.Parse(json)?.AsObject() ?? throw new RedstoneException("Invalid JSON for Damage Type.");

            if (!obj.ContainsKey("message_id") || obj["message_id"]?.GetValue<string>() == null)
            {
                throw new RedstoneException("Missing 'message_id' in JSON for Damage Type.");
            }

            if (!obj.ContainsKey("exhaustion") || obj["exhaustion"]?.GetValue<float?>() == null)
            {
                throw new RedstoneException("Missing 'exhaustion' in JSON for Damage Type.");
            }

            if (!obj.ContainsKey("scaling") || obj["scaling"]?.GetValue<string>() == null)
            {
                throw new RedstoneException("Missing 'scaling' in JSON for Damage Type.");
            }

            MessageId = obj["message_id"]!.GetValue<string>()!;
            Exhaustion = obj["exhaustion"]!.GetValue<float>();
            Scaling = ParseScaling(obj["scaling"]!.GetValue<string>()!);

            if (obj.ContainsKey("effects") && obj["effects"]?.GetValue<string>() != null)
            {
                Effects = new OptValue<DamageEffect>(ParseDamageEffect(obj["effects"]!.GetValue<string>()!));
            }
            else
            {
                Effects = new OptValue<DamageEffect>();
            }

            if (obj.ContainsKey("death_message_type") && obj["death_message_type"]?.GetValue<string>() != null)
            {
                DeathMessage = new OptValue<DeathMessageType>(ParseDeathMessageType(obj["death_message_type"]!.GetValue<string>()!));
            }
            else
            {
                DeathMessage = new OptValue<DeathMessageType>();
            }
        }

        public JsonNode ToJson()
        {
            JsonObject outObj = new();
            outObj["message_id"] = MessageId;
            outObj["exhaustion"] = Exhaustion;
            outObj["scaling"] = ScalingToString(Scaling);

            if (Effects != null && Effects.Enabled) outObj["effects"] = DamageEffectToString(Effects.Value);
            if (DeathMessage != null && DeathMessage.Enabled) outObj["death_message_type"] = DeathMessageTypeToString(DeathMessage.Value);

            return outObj;
        }

        private static DamageScaling ParseScaling(string s)
        {
            return s switch
            {
                "never" => DamageScaling.Never,
                "always" => DamageScaling.Always,
                "when_caused_by_living_non_player" => DamageScaling.WhenCausedByLivingNonPlayer,
                _ => throw new RedstoneException($"Unknown scaling '{s}' in Damage Type.")
            };
        }

        private static string ScalingToString(DamageScaling s)
        {
            return s switch
            {
                DamageScaling.Never => "never",
                DamageScaling.Always => "always",
                DamageScaling.WhenCausedByLivingNonPlayer => "when_caused_by_living_non_player",
                _ => "when_caused_by_living_non_player"
            };
        }

        private static DamageEffect ParseDamageEffect(string s)
        {
            return s switch
            {
                "hurt" => DamageEffect.Hurt,
                "thorns" => DamageEffect.Thorns,
                "drowning" => DamageEffect.Drowning,
                "burning" => DamageEffect.Burning,
                "poking" => DamageEffect.Poking,
                "freezing" => DamageEffect.Freezing,
                _ => throw new RedstoneException($"Unknown effects '{s}' in Damage Type.")
            };
        }

        private static string DamageEffectToString(DamageEffect e)
        {
            return e switch
            {
                DamageEffect.Hurt => "hurt",
                DamageEffect.Thorns => "thorns",
                DamageEffect.Drowning => "drowning",
                DamageEffect.Burning => "burning",
                DamageEffect.Poking => "poking",
                DamageEffect.Freezing => "freezing",
                _ => "hurt"
            };
        }

        private static DeathMessageType ParseDeathMessageType(string s)
        {
            return s switch
            {
                "default" => DeathMessageType.Default,
                "fall_variants" => DeathMessageType.FallVariants,
                "intentional_game_design" => DeathMessageType.IntentionalGameDesign,
                _ => throw new RedstoneException($"Unknown death_message_type '{s}' in Damage Type.")
            };
        }

        private static string DeathMessageTypeToString(DeathMessageType d)
        {
            return d switch
            {
                DeathMessageType.Default => "default",
                DeathMessageType.FallVariants => "fall_variants",
                DeathMessageType.IntentionalGameDesign => "intentional_game_design",
                _ => "default"
            };
        }
        public static Dictionary<Identifier, object> Keys
        {
            get
            {
                JsonObject items = JsonNode.Parse(File.ReadAllText(RegistryManager.RegistryLocations["damage_type"]))!.AsObject();
                Dictionary<Identifier, object> keys = new Dictionary<Identifier, object>();
                foreach (var item in items)
                {
                    keys.Add(item.Key, new DamageType(item.Value!.AsObject()));
                }

                return keys;
            }
        }

    }

    public enum DamageScaling
    {
        Never,
        Always,
        WhenCausedByLivingNonPlayer
    }

    public enum DamageEffect
    {
        Hurt,
        Thorns,
        Drowning,
        Burning,
        Poking,
        Freezing
    }

    public enum DeathMessageType
    {
        Default,
        FallVariants,
        IntentionalGameDesign
    }
}
