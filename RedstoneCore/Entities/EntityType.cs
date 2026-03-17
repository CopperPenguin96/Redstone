using Redstone.Core.Types;

namespace Redstone.Core.Entities
{
    public struct EntityType : IEquatable<EntityType>
    {
        public VarInt Type { get; }
        public float Width { get; set;  }
        public float Height { get; set; }
        public Identifier Id { get; }

        private EntityType(VarInt type, float width, float height, string ident)
        {
            Type = type;
            Width = width;
            Height = height;
            Id = new Identifier(ident);
        }

        #region Entity Type Definitions

        public static readonly EntityType AcaciaBoat = new (0, 1.375f, 0.5625f, "minecraft:acacia_boat");
        public static readonly EntityType AcaciaBoatWithChest = new (1, 1.375f, 0.5625f, "minecraft:acacia_chest_boat");
        public static readonly EntityType Allay = new(2, 0.35f, 0.6f, "minecraft:allay");
        public static readonly EntityType AreaEffectCloud = new(3, 2.0f, 0.5f, "minecraft:area_effect_cloud");
        public static readonly EntityType Armadillo = new(4, 0.7f, 0.65f, "minecraft:armadillo");
        public static readonly EntityType ArmorStand = new (5, 0.5f, 1.975f, "minecraft:armor_stand");
        public static readonly EntityType Arrow = new(6, 0.5f, 0.5f, "minecraft:arrow");
        public static readonly EntityType Axolotl = new(7, 0.75f, 0.42f, "minecraft:axolotl");
        public static readonly EntityType BambooRaftWithChest = new (8, 1.375f, 0.5625f, "minecraft:bamboo_chest_raft");
        public static readonly EntityType BambooRaft = new (9, 1.375f, 0.5625f, "minecraft:bamboo_raft");
        public static readonly EntityType Bat = new(10, 0.5f, 0.9f, "minecraft:bat");
        public static readonly EntityType Bee = new(11, 0.7f, 0.6f, "minecraft:bee");
        public static readonly EntityType BirchBoat = new (12, 1.375f, 0.5625f, "minecraft:birch_boat");
        public static readonly EntityType BirchBoatWithChest = new (13, 1.375f, 0.5625f, "minecraft:birch_chest_boat");
        public static readonly EntityType Blaze = new(14, 0.6f, 1.8f, "minecraft:blaze");
        public static readonly EntityType BlockDisplay = new (15, 0.0f, 0.0f, "minecraft:block_display");
        public static readonly EntityType Bogged = new(16, 0.6f, 1.99f, "minecraft:bogged");
        public static readonly EntityType Breeze = new(17, 0.6f, 1.77f, "minecraft:breeze");
        public static readonly EntityType BreezeWindCharge = new (18, 0.3125f, 0.3125f, "minecraft:breeze_wind_charge");
        public static readonly EntityType Camel = new(19, 1.7f, 2.375f, "minecraft:camel");
        public static readonly EntityType CamelHusk = new (20, 1.7f, 2.375f, "minecraft:camel_husk");
        public static readonly EntityType Cat = new(21, 0.6f, 0.7f, "minecraft:cat");
        public static readonly EntityType CaveSpider = new (22, 0.7f, 0.5f, "minecraft:cave_spider");
        public static readonly EntityType CherryBoat = new (23, 1.375f, 0.5625f, "minecraft:cherry_boat");
        public static readonly EntityType CherryBoatWithChest = new (24, 1.375f, 0.5625f, "minecraft:cherry_chest_boat");
        public static readonly EntityType MinecartWithChest = new(25, 0.98f, 0.7f, "minecraft:chest_minecart");
        public static readonly EntityType Chicken = new(26, 0.4f, 0.7f, "minecraft:chicken");
        public static readonly EntityType Cod = new(27, 0.5f, 0.3f, "minecraft:cod");
        public static readonly EntityType CopperGolem = new (28, 0.49f, 0.98f, "minecraft:copper_golem");
        public static readonly EntityType MinecartWithCommandBlock = new (29, 0.98f, 0.7f, "minecraft:command_block_minecart");
        public static readonly EntityType Cow = new(30, 0.9f, 1.4f, "minecraft:cow");
        public static readonly EntityType Creaking = new(31, 0.9f, 2.7f, "minecraft:creaking");
        public static readonly EntityType Creeper = new(32, 0.6f, 1.7f, "minecraft:creeper");
        public static readonly EntityType DarkOakBoat = new(33, 1.375f, 0.5625f, "minecraft:dark_oak_boat");
        public static readonly EntityType DarkOakBoatWithChest = new(34, 1.375f, 0.5625f, "minecraft:dark_oak_chest_boat");
        public static readonly EntityType Dolphin = new(35, 0.9f, 0.6f, "minecraft:dolphin");
        public static readonly EntityType Donkey = new(36, 1.3964844f, 1.5f, "minecraft:donkey");
        public static readonly EntityType DragonFireball = new (37, 1.0f, 1.0f, "minecraft:dragon_fireball");
        public static readonly EntityType Drowned = new(38, 0.6f, 1.95f, "minecraft:drowned");
        public static readonly EntityType ThrownEgg = new (39, 0.25f, 0.25f, "minecraft:egg");
        public static readonly EntityType ElderGuardian = new (40, 1.9975f, 1.9975f, "minecraft:elder_guardian");
        public static readonly EntityType Enderman = new(41, 0.6f, 2.9f, "minecraft:enderman");
        public static readonly EntityType Endermite = new(42, 0.4f, 0.3f, "minecraft:endermite");
        public static readonly EntityType EnderDragon = new (43, 16.0f, 8.0f, "minecraft:ender_dragon");
        public static readonly EntityType ThrownEnderPearl = new(44, 0.25f, 0.25f, "minecraft:ender_pearl");
        public static readonly EntityType EndCrystal = new (45, 2.0f, 2.0f, "minecraft:end_crystal");
        public static readonly EntityType Evoker = new(46, 0.6f, 1.95f, "minecraft:evoker");
        public static readonly EntityType EvokerFangs = new (47, 0.5f, 0.8f, "minecraft:evoker_fangs");
        public static readonly EntityType ThrownBottleOfEnchanting = new(48, 0.25f, 0.25f, "minecraft:experience_bottle");
        public static readonly EntityType ExperienceOrb = new (49, 0.5f, 0.5f, "minecraft:experience_orb");
        public static readonly EntityType EyeOfEnder = new(50, 0.25f, 0.25f, "minecraft:eye_of_ender");
        public static readonly EntityType FallingBlock = new (51, 0.98f, 0.98f, "minecraft:falling_block");
        public static readonly EntityType Fireball = new(52, 1.0f, 1.0f, "minecraft:fireball");
        public static readonly EntityType FireworkRocket = new (53, 0.25f, 0.25f, "minecraft:firework_rocket");
        public static readonly EntityType Fox = new(54, 0.6f, 0.7f, "minecraft:fox");
        public static readonly EntityType Frog = new(55, 0.5f, 0.5f, "minecraft:frog");
        public static readonly EntityType MinecartWithFurnace = new(56, 0.98f, 0.7f, "minecraft:furnace_minecart");
        public static readonly EntityType Ghast = new(57, 4.0f, 4.0f, "minecraft:ghast");
        public static readonly EntityType HappyGhast = new (58, 4.0f, 4.0f, "minecraft:happy_ghast");
        public static readonly EntityType Giant = new(59, 3.6f, 12.0f, "minecraft:giant");
        public static readonly EntityType GlowItemFrame = new(60, 0.75f, 0.75f, "minecraft:glow_item_frame");
        public static readonly EntityType GlowSquid = new (61, 0.8f, 0.8f, "minecraft:glow_squid");
        public static readonly EntityType Goat = new(62, 1.3f, 0.9f, "minecraft:goat");
        public static readonly EntityType Guardian = new(63, 0.85f, 0.85f, "minecraft:guardian");
        public static readonly EntityType Hoglin = new(64, 1.3964844f, 1.4f, "minecraft:hoglin");
        public static readonly EntityType MinecartWithHopper = new(65, 0.98f, 0.7f, "minecraft:hopper_minecart");
        public static readonly EntityType Horse = new(66, 1.3964844f, 1.6f, "minecraft:horse");
        public static readonly EntityType Husk = new(67, 0.6f, 1.95f, "minecraft:husk");
        public static readonly EntityType Illusioner = new(68, 0.6f, 1.95f, "minecraft:illusioner");
        public static readonly EntityType Interaction = new(69, 0.0f, 0.0f, "minecraft:interaction");
        public static readonly EntityType IronGolem = new (70, 1.4f, 2.7f, "minecraft:iron_golem");
        public static readonly EntityType Item = new(71, 0.25f, 0.25f, "minecraft:item");
        public static readonly EntityType ItemDisplay = new (72, 0.0f, 0.0f, "minecraft:item_display");
        public static readonly EntityType ItemFrame = new (73, 0.75f, 0.75f, "minecraft:item_frame");
        public static readonly EntityType JungleBoat = new (74, 1.375f, 0.5625f, "minecraft:jungle_boat");
        public static readonly EntityType JungleBoatWithChest = new (75, 1.375f, 0.5625f, "minecraft:jungle_chest_boat");
        public static readonly EntityType LeashKnot = new (76, 0.375f, 0.5f, "minecraft:leash_knot");
        public static readonly EntityType LightningBolt = new (77, 0.0f, 0.0f, "minecraft:lightning_bolt");
        public static readonly EntityType Llama = new(78, 0.9f, 1.87f, "minecraft:llama");
        public static readonly EntityType LlamaSpit = new (79, 0.25f, 0.25f, "minecraft:llama_spit");
        public static readonly EntityType MagmaCube = new (80, 0.5202f, 0.5202f, "minecraft:magma_cube");
        public static readonly EntityType MangroveBoat = new (81, 1.375f, 0.5625f, "minecraft:mangrove_boat");
        public static readonly EntityType MangroveBoatWithChest = new (82, 1.375f, 0.5625f, "minecraft:mangrove_chest_boat");
        public static readonly EntityType Mannequin = new(83, 0.6f, 1.8f, "minecraft:mannequin");
        public static readonly EntityType Marker = new(84, 0.0f, 0.0f, "minecraft:marker");
        public static readonly EntityType Minecart = new(85, 0.98f, 0.7f, "minecraft:minecart");
        public static readonly EntityType Mooshroom = new(86, 0.9f, 1.4f, "minecraft:mooshroom");
        public static readonly EntityType Mule = new(87, 1.3964844f, 1.6f, "minecraft:mule");
        public static readonly EntityType Nautilus = new(88, 0.875f, 0.95f, "minecraft:nautilus");
        public static readonly EntityType OakBoat = new (89, 1.375f, 0.5625f, "minecraft:oak_boat");
        public static readonly EntityType OakBoatWithChest = new (90, 1.375f, 0.5625f, "minecraft:oak_chest_boat");
        public static readonly EntityType Ocelot = new(91, 0.6f, 0.7f, "minecraft:ocelot");
        public static readonly EntityType OminousItemSpawner = new(92, 0.25f, 0.25f, "minecraft:ominous_item_spawner");
        public static readonly EntityType Painting = new(93, 0.5f, 0.5f, "minecraft:painting");
        public static readonly EntityType PaleOakBoat = new(94, 1.375f, 0.5625f, "minecraft:pale_oak_boat");
        public static readonly EntityType PaleOakBoatWithChest = new(95, 1.375f, 0.5625f, "minecraft:pale_oak_chest_boat");
        public static readonly EntityType Panda = new(96, 1.3f, 1.25f, "minecraft:panda");
        public static readonly EntityType Parched = new(97, 0.6f, 1.99f, "minecraft:parched");
        public static readonly EntityType Parrot = new(98, 0.5f, 0.9f, "minecraft:parrot");
        public static readonly EntityType Phantom = new(99, 0.9f, 0.5f, "minecraft:phantom");
        public static readonly EntityType Pig = new(100, 0.9f, 0.9f, "minecraft:pig");
        public static readonly EntityType Piglin = new(101, 0.6f, 1.95f, "minecraft:piglin");
        public static readonly EntityType PiglinBrute = new (102, 0.6f, 1.95f, "minecraft:piglin_brute");
        public static readonly EntityType Pillager = new(103, 0.6f, 1.95f, "minecraft:pillager");
        public static readonly EntityType PolarBear = new (104, 1.4f, 1.4f, "minecraft:polar_bear");
        public static readonly EntityType SplashPotion = new (105, 0.25f, 0.25f, "minecraft:splash_potion");
        public static readonly EntityType LingeringPotion = new (106, 0.25f, 0.25f, "minecraft:lingering_potion");
        public static readonly EntityType Pufferfish = new(107, 0.7f, 0.7f, "minecraft:pufferfish");
        public static readonly EntityType Rabbit = new(108, 0.4f, 0.5f, "minecraft:rabbit");
        public static readonly EntityType Ravager = new(109, 1.95f, 2.2f, "minecraft:ravager");
        public static readonly EntityType Salmon = new(110, 0.7f, 0.4f, "minecraft:salmon");
        public static readonly EntityType Sheep = new(111, 0.9f, 1.3f, "minecraft:sheep");
        public static readonly EntityType Shulker = new(112, 1.0f, 2.0f, "minecraft:shulker");
        public static readonly EntityType ShulkerBullet = new (113, 0.3125f, 0.3125f, "minecraft:shulker_bullet");
        public static readonly EntityType Silverfish = new(114, 0.4f, 0.3f, "minecraft:silverfish");
        public static readonly EntityType Skeleton = new(115, 0.6f, 1.99f, "minecraft:skeleton");
        public static readonly EntityType SkeletonHorse = new (116, 1.3964844f, 1.6f, "minecraft:skeleton_horse");
        public static readonly EntityType Slime = new(117, 0.5202f, 0.5202f, "minecraft:slime");
        public static readonly EntityType SmallFireball = new (118, 0.3125f, 0.3125f, "minecraft:small_fireball");
        public static readonly EntityType Sniffer = new(119, 1.9f, 1.75f, "minecraft:sniffer");
        public static readonly EntityType Snowball = new(120, 0.25f, 0.25f, "minecraft:snowball");
        public static readonly EntityType SnowGolem = new (121, 0.7f, 1.9f, "minecraft:snow_golem");
        public static readonly EntityType MinecartWithMonsterSpawner = new (122, 0.98f, 0.7f, "minecraft:spawner_minecart");
        public static readonly EntityType SpectralArrow = new (123, 0.5f, 0.5f, "minecraft:spectral_arrow");
        public static readonly EntityType Spider = new(124, 1.4f, 0.9f, "minecraft:spider");
        public static readonly EntityType SpruceBoat = new (125, 1.375f, 0.5625f, "minecraft:spruce_boat");
        public static readonly EntityType SpruceBoatWithChest = new (126, 1.375f, 0.5625f, "minecraft:spruce_chest_boat");
        public static readonly EntityType Squid = new(127, 0.8f, 0.8f, "minecraft:squid");
        public static readonly EntityType Stray = new(128, 0.6f, 1.99f, "minecraft:stray");
        public static readonly EntityType Strider = new(129, 0.9f, 1.7f, "minecraft:strider");
        public static readonly EntityType Tadpole = new(130, 0.4f, 0.3f, "minecraft:tadpole");
        public static readonly EntityType TextDisplay = new (131, 0.0f, 0.0f, "minecraft:text_display");
        public static readonly EntityType PrimedTNT = new (132, 0.98f, 0.98f, "minecraft:tnt");
        public static readonly EntityType MinecartWithTNT = new(133, 0.98f, 0.7f, "minecraft:tnt_minecart");
        public static readonly EntityType TraderLlama = new (134, 0.9f, 1.87f, "minecraft:trader_llama");
        public static readonly EntityType Trident = new(135, 0.5f, 0.5f, "minecraft:trident");
        public static readonly EntityType TropicalFish = new (136, 0.5f, 0.4f, "minecraft:tropical_fish");
        public static readonly EntityType Turtle = new(137, 1.2f, 0.4f, "minecraft:turtle");
        public static readonly EntityType Vex = new(138, 0.4f, 0.8f, "minecraft:vex");
        public static readonly EntityType Villager = new(139, 0.6f, 1.95f, "minecraft:villager");
        public static readonly EntityType Vindicator = new(140, 0.6f, 1.95f, "minecraft:vindicator");
        public static readonly EntityType WanderingTrader = new (141, 0.6f, 1.95f, "minecraft:wandering_trader");
        public static readonly EntityType Warden = new(142, 0.9f, 2.9f, "minecraft:warden");
        public static readonly EntityType WindCharge = new (143, 0.3125f, 0.3125f, "minecraft:wind_charge");
        public static readonly EntityType Witch = new(144, 0.6f, 1.95f, "minecraft:witch");
        public static readonly EntityType Wither = new(145, 0.9f, 3.5f, "minecraft:wither");
        public static readonly EntityType WitherSkeleton = new (146, 0.7f, 2.4f, "minecraft:wither_skeleton");
        public static readonly EntityType WitherSkull = new (147, 0.3125f, 0.3125f, "minecraft:wither_skull");
        public static readonly EntityType Wolf = new(148, 0.6f, 0.85f, "minecraft:wolf");
        public static readonly EntityType Zoglin = new(149, 1.3964844f, 1.4f, "minecraft:zoglin");
        public static readonly EntityType Zombie = new(150, 0.6f, 1.95f, "minecraft:zombie");
        public static readonly EntityType ZombieHorse = new (151, 1.3964844f, 1.6f, "minecraft:zombie_horse");
        public static readonly EntityType ZombieNautilus = new (152, 0.875f, 0.95f, "minecraft:zombie_nautilus");
        public static readonly EntityType ZombieVillager = new (153, 0.6f, 1.95f, "minecraft:zombie_villager");
        public static readonly EntityType ZombifiedPiglin = new (154, 0.6f, 1.95f, "minecraft:zombified_piglin");
        public static readonly EntityType Player = new(155, 0.6f, 1.8f, "minecraft:player");
        public static readonly EntityType FishingBobber = new (156, 0.25f, 0.25f, "minecraft:fishing_bobber");

        #endregion

        public bool Equals(EntityType other)
        {
            return Type == other.Type && Id.ToString() == other.Id.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is EntityType other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + Type.GetHashCode();
                hash = hash * 31 + Id.ToString().GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return $"{Id}:{Type.Value}";
        }
    }
}
