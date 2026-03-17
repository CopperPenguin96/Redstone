using Redstone.Nbt.Tags;

namespace Redstone.Core.Types
{
    public class SlotData
    {
        public VarInt Count { get; set; }

        public OptValue<VarInt> ItemID { get; set; }

        private List<Component> Components = new();

        public List<VarInt> ToRemove = new();

        public Component this[Identifier ident]
        {
            get
            {
                foreach (Component comp in Components)
                {
                    if (comp.Identifier == ident)
                        return comp;
                }

                return null!;
            }
        }

        public static readonly Dictionary<Identifier, Delegate> ComponentFunctions = new()
        {
            { "custom_data", new Func<CompoundTag, Component>(CustomData) }
        };

        private bool ContainsComp(Identifier ident)
        {
            foreach (Component comp in Components)
            {
                if (comp.Identifier == ident)
                    return true;
            }

            return false;
        }

        public void RemoveComp(Identifier ident)
        {
            for (int i = 0; i < Components.Count; i++)
            {
                Component comp = Components[i];
                if (comp.Identifier == ident)
                    Components.RemoveAt(i);

            }
        }

        public void AddData(Identifier ident, params object?[] args)
        {
            Delegate func = ComponentFunctions[ident];
            Component comp = (Component)func.DynamicInvoke(args)!;
            Components.Add(comp);
        }

        public static Dictionary<VarInt, Identifier> CompDefinitions = new()
        {
            { 0, "custom_data" },
            { 1, "max_stack_size" },
            { 2, "max_damage" },
            { 3, "damage" },
            { 4, "unbreakable" },
            { 5, "custom_name" },
            { 6, "item_name" },
            { 7, "item_model" },
            { 8, "lore" },
            { 9, "rarity" },
            { 10, "enchantments" },
            { 11, "can_place_on" },
            { 12, "can_break" },
            { 13, "attribute_modifiers" },
            { 14, "custom_model_data" },
            { 15, "tooltip_display" },
            { 16, "repair_cost" },
            { 17, "creative_slot_lock" },
            { 18, "enchantment_glint_override" },
            { 19, "intangible_projectile" },
            { 20, "food" },
            { 21, "consumable" },
            { 22, "use_remainder" },
            { 23, "use_cooldown" },
            { 24, "damage_resistant" },
            { 25, "tool" },
            { 26, "weapon" },
            { 27, "enchantable" },
            { 28, "equippable" },
            { 29, "repairable" },
            { 30, "glider" },
            { 31, "tooltip_style" },
            { 32, "death_projection" },
            { 33, "block_attacks" },
            { 34, "stored_enchantments" },
            { 35, "dyed_color" },
            { 36, "map_color" },
            { 37, "map_id" },
            { 38, "map_decorations" },
            { 39, "map_post_processing" },
            { 40, "charged_projectiles" },
            { 41, "bundle_contents" },
            { 42, "potion_contents" },
            { 43, "potion_duration_scale" },
            { 44, "suspicious_stew_effects" },
            { 45, "writable_book_content" },
            { 46, "written_book_content" },
            { 47, "trim" },
            { 48, "debug_stick_state" },
            { 49, "entity_data" },
            { 50, "bucket_entity_data" },
            { 51, "block_entity_data" },
            { 52, "instrument" },
            { 53, "provides_trim_material" },
            { 54, "ominous_bottle_amplifier" },
            { 55, "jukebox_playable" },
            { 56, "provides_banner_patterns" },
            { 57, "recipes" },
            { 58, "lodestone_tracker" },
            { 59, "firework_explosion" },
            { 60, "fireworks" },
            { 61, "profile" },
            { 62, "note_block_sound" },
            { 63, "banner_patterns" },
            { 64, "base_color" },
            { 65, "pot_decorations" },
            { 66, "container" },
            { 67, "block_state" }, // teehee
            { 68, "bees" },
            { 69, "lock" },
            { 70, "container_loot" },
            { 71, "break_sound" },
            { 72, "villager/variant" },
            { 73, "wolf/variant" },
            { 74, "wolf/sound_varaint" },
            { 75, "wolf_collar" },
            { 76, "fox/variant" },
            { 77, "salmon/size" },
            { 78, "parrot/variant" },
            { 79, "tropical_fish/pattern" },
            { 80, "tropical_fish/base_color" },
            { 81, "tropical_fish/pattern_color" },
            { 82, "mooshroom/variant" },
            { 83, "rabbit/variant" },
            { 84, "pig/variant" },
            { 85, "cow_variant" },
            { 86, "chicken/variant" },
            { 87, "frog/variant" },
            { 88, "horse/variant" },
            { 89, "painting/variant" },
            { 90, "llama/variant" },
            { 91, "axolotl/variant" },
            { 92, "cat/variant" },
            { 93, "cat/collar" },
            { 94, "sheep/color" },
            { 95, "shulker/color" }
        };

        public VarInt GetTypeInt(Identifier ident)
        {
            foreach (VarInt key in CompDefinitions.Keys)
            {
                Identifier id = CompDefinitions[key];
                if (id == ident)
                {
                    return key;
                }
            }

            throw new RedstoneException("Key not found", Severity.Warning);
        }

        #region Components

        public static Component CustomData(CompoundTag compound)
        {
            return new Component(0)
            {
                Data = [compound]
            };
        }

        public static Component MaxStackSize(VarInt maxStackSize)
        {
            if (maxStackSize < 1 || maxStackSize > 99)
                RedstoneException.Throw(new IndexOutOfRangeException(), Severity.Warning);

            return new Component(1)
            {
                Data = [maxStackSize]
            };
        }

        public static Component MaxDamage(VarInt maxDamage)
        {
            return new Component(2)
            {
                Data = [maxDamage]
            };
        }

        public static Component Damage(VarInt damage)
        {
            return new Component(3)
            { 
                Data = [damage] 
            };
        }

        public static Component Unbreakable()
        {
            return new Component(4);
        }


        #endregion
    }

}
