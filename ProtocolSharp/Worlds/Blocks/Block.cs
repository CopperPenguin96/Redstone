using System;
using System.Collections.Generic;
using System.Linq;
using ProtocolSharp.Packets.Play.Client.BlockEntityData;
using ProtocolSharp.Types;

namespace ProtocolSharp.Worlds.Blocks
{
	public class Block
	{
		public Identifier Id { get; set; }

		public VarInt State { get; set; }

		/// <summary>
		/// Certain blocks have different things happen, protocol uses this packet here
		/// </summary>
		public BlockEntityData EntityDataPacket { get; set; }

		public List<BlockData> Data { get; set; }

		public byte DestroyStage { get; set; }

		public bool IsCustom { get; }

		private string _name;

		public string Name
		{
			get => IsCustom ? _name : FindVanillaBlock(Id.Name).Name;
			set => _name = value;
		}

		private Identifier _legacy;

		public Identifier LegacyId
		{
			get => IsCustom ? _legacy : FindVanillaBlock(Id.Name).LegacyId;
			set => _legacy = value;
		}

		private int _type;

		public int Type
		{
			get => IsCustom ? _type : FindVanillaBlock(Id.Name).Type;
			set => _type = value;
		}

		private int _meta;

		public int Meta
		{
			get => IsCustom ? _type : FindVanillaBlock(Id.Name).Meta;
			set => _meta = value;
		}


		/// <summary>
		/// Use only for defining custom blocks. Should NOT be used to define vanilla blocks
		/// </summary>
		/// <param name="name">The name of the block</param>
		/// <param name="id">The identifier that id's the block. {namespace}.{id}</param>
		/// <param name="type">block ID</param>
		/// <param name="meta">meta value of the block</param>
		public Block(string name, Identifier id, int type, int meta)
		{
			Name = name ?? throw new ArgumentNullException(nameof(name));
			Id = id ?? throw new ArgumentNullException(nameof(id));
			Type = type;
			Meta = meta;
			IsCustom = true;
		}

		/// <summary>
		/// Used to load a vanilla blocks.
		/// </summary>
		/// <param name="id">The name part of an Identifier from Minecraft's name space minecraft:{id}</param>
		public Block(string id)
		{
			if (id == null) throw new ArgumentNullException(nameof(id));
			Id = new Identifier("minecraft", id);
			IsCustom = false;
		}

		public static Block FindVanillaBlock(string id)
		{
			if (id == null) throw new ArgumentNullException(nameof(id));

			foreach (var b in BlockRegistry.Blocks.Where(b => b.Id.Name == id))
			{
				return b;
			}

			throw new ArgumentException("Block does not exist in vanilla.");
		}

		#region Block Definitions

		public static Block Air = new Block("air");
		public static Block Stone = new Block("stone");
		public static Block Granite = new Block("granite");
		public static Block PolishedGranite = new Block("polished_granite");
		public static Block Diorite = new Block("diorite");
		public static Block PolishedDiorite = new Block("polished_diorite");
		public static Block Andesite = new Block("andesite");
		public static Block PolishedAndesite = new Block("polished_andesite");
		public static Block GrassBlock = new Block("grass_block");
		public static Block Dirt = new Block("dirt");
		public static Block CoarseDirt = new Block("coarse_dirt");
		public static Block Podzol = new Block("podzol,");
		public static Block Cobblestone = new Block("cobblestone");
		public static Block OakWoodPlank = new Block("oak_planks");
		public static Block SpruceWoodPlank = new Block("spruce_planks");
		public static Block BirchWoodPlank = new Block("birch_planks");
		public static Block JungleWoodPlank = new Block("jungle_planks");
		public static Block AcaciaWoodPlank = new Block("acacia_planks");
		public static Block DarkOakWoodPlank = new Block("dark_oak_planks");
		public static Block OakSapling = new Block("oak_sapling");
		public static Block SpruceSapling = new Block("spruce_sapling");
		public static Block BirchSapling = new Block("birch_sapling");
		public static Block JungleSapling = new Block("jungle_sapling");
		public static Block AcaciaSapling = new Block("acacia_sapling");
		public static Block DarkOakSapling = new Block("dark_oak_sapling");
		public static Block Bedrock = new Block("bedrock");
		public static Block FlowingWater = new Block("flowing_water");
		public static Block StillWater = new Block("water");
		public static Block FlowingLava = new Block("flowing_lava");
		public static Block StillLava = new Block("lava");
		public static Block Sand = new Block("sand");
		public static Block RedSand = new Block("red_sand");
		public static Block Gravel = new Block("gravel");
		public static Block GoldOre = new Block("gold_ore");
		public static Block IronOre = new Block("iron_ore");
		public static Block CoalOre = new Block("coal_ore");
		public static Block OakWood = new Block("oak_log");
		public static Block SpruceWood = new Block("spruce_log");
		public static Block BirchWood = new Block("birch_log");
		public static Block JungleWood = new Block("jungle_log");
		public static Block OakLeaves = new Block("oak_leaves");
		public static Block SpruceLeaves = new Block("spruce_leaves");
		public static Block BirchLeaves = new Block("birch_leaves");
		public static Block JungleLeaves = new Block("jungle_leaves");
		public static Block Sponge = new Block("sponge");
		public static Block WetSponge = new Block("wet_sponge");
		public static Block Glass = new Block("glass");
		public static Block LapisLazuliOre = new Block("lapis_ore");
		public static Block LapisLazuliBlock = new Block("lapis_block");
		public static Block Dispenser = new Block("dispenser");
		public static Block Sandstone = new Block("sandstone");
		public static Block ChiseledSandstone = new Block("chiseled_sandstone");
		public static Block SmoothSandstone = new Block("cut_sandstone");
		public static Block NoteBlock = new Block("note_block");
		public static Block Bed = new Block("bed");
		public static Block PoweredRail = new Block("powered_rail");
		public static Block DetectorRail = new Block("detector_rail");
		public static Block StickyPiston = new Block("sticky_piston");
		public static Block Cobweb = new Block("web");
		public static Block DeadShrub = new Block("tallgrass");
		public static Block Grass = new Block("tallgrass");
		public static Block Fern = new Block("fern");
		public static Block DeadBush = new Block("dead_bush");
		public static Block Piston = new Block("piston");
		public static Block PistonHead = new Block("piston_head");
		public static Block WhiteWool = new Block("white_wool");
		public static Block OrangeWool = new Block("orange_wool");
		public static Block MagentaWool = new Block("magenta_wool");
		public static Block LightBlueWool = new Block("light_blue_wool");
		public static Block YellowWool = new Block("yellow_wool");
		public static Block LimeWool = new Block("lime_wool");
		public static Block PinkWool = new Block("pink_wool");
		public static Block GrayWool = new Block("gray_wool");
		public static Block LightGrayWool = new Block("light_gray_wool");
		public static Block CyanWool = new Block("cyan_wool");
		public static Block PurpleWool = new Block("purple_wool");
		public static Block BlueWool = new Block("blue_wool");
		public static Block BrownWool = new Block("brown_wool");
		public static Block GreenWool = new Block("green_wool");
		public static Block RedWool = new Block("red_wool");
		public static Block BlackWool = new Block("black_wool");
		public static Block Dandelion = new Block("dandelion");
		public static Block Poppy = new Block("poppy");
		public static Block BlueOrchid = new Block("blue_orchid");
		public static Block Allium = new Block("allium");
		public static Block AzureBluet = new Block("azure_bluet");
		public static Block RedTulip = new Block("red_tulip");
		public static Block OrangeTulip = new Block("orange_tulip");
		public static Block WhiteTulip = new Block("white_tulip");
		public static Block PinkTulip = new Block("pink_tulip");
		public static Block OxeyeDaisy = new Block("oxeye_daisy");
		public static Block BrownMushroom = new Block("brown_mushroom");
		public static Block RedMushroom = new Block("red_mushroom");
		public static Block GoldBlock = new Block("gold_block");
		public static Block IronBlock = new Block("iron_block");
		public static Block DoubleStoneSlab = new Block("double_stone_slab");
		public static Block DoubleSandstoneSlab = new Block("double_stone_slab");
		public static Block DoubleWoodenSlab = new Block("double_stone_slab");
		public static Block DoubleCobblestoneSlab = new Block("double_stone_slab");
		public static Block DoubleBrickSlab = new Block("double_stone_slab");
		public static Block DoubleStoneBrickSlab = new Block("double_stone_slab");
		public static Block DoubleNetherBrickSlab = new Block("double_stone_slab");
		public static Block DoubleQuartzSlab = new Block("smooth_quartz");
		public static Block StoneSlab = new Block("stone_slab");
		public static Block SandstoneSlab = new Block("sandstone_slab");
		public static Block WoodenSlab = new Block("stone_slab");
		public static Block CobblestoneSlab = new Block("cobblestone_slab");
		public static Block BrickSlab = new Block("brick_slab");
		public static Block StoneBrickSlab = new Block("stone_brick_slab");
		public static Block NetherBrickSlab = new Block("nether_brick_slab");
		public static Block QuartzSlab = new Block("quartz_slab");
		public static Block Bricks = new Block("bricks");
		public static Block Tnt = new Block("tnt");
		public static Block Bookshelf = new Block("bookshelf");
		public static Block MossStone = new Block("mossy_cobblestone");
		public static Block Obsidian = new Block("obsidian");
		public static Block Torch = new Block("torch");
		public static Block Fire = new Block("fire");


		public static Block MonsterSpawner = new Block("spawner")
		{

		};

		public static Block OakWoodStairs = new Block("oak_stairs");
		public static Block Chest = new Block("chest");
		public static Block RedstoneWire = new Block("redstone_wire");
		public static Block DiamondOre = new Block("diamond_ore");
		public static Block DiamondBlock = new Block("diamond_block");
		public static Block CraftingTable = new Block("crafting_table");
		public static Block WheatCrops = new Block("wheat");
		public static Block Farmland = new Block("farmland");
		public static Block Furnace = new Block("furnace");
		public static Block BurningFurnace = new Block("lit_furnace");
		public static Block StandingSignBlock = new Block("standing_sign");
		public static Block OakDoorBlock = new Block("wooden_door");
		public static Block Ladder = new Block("ladder");
		public static Block Rail = new Block("rail");
		public static Block CobblestoneStairs = new Block("cobblestone_stairs");
		public static Block WallMountedSignBlock = new Block("wall_sign");
		public static Block Lever = new Block("lever");
		public static Block StonePressurePlate = new Block("stone_pressure_plate");
		public static Block IronDoorBlock = new Block("iron_door");
		public static Block WoodenPressurePlate = new Block("oak_pressure_plate");
		public static Block RedstoneOre = new Block("redstone_ore");
		public static Block GlowingRedstoneOre = new Block("lit_redstone_ore");
		public static Block RedstoneTorchOff = new Block("unlit_redstone_torch");
		public static Block RedstoneTorchOn = new Block("redstone_torch");
		public static Block StoneButton = new Block("stone_button");
		public static Block Snow = new Block("snow");
		public static Block Ice = new Block("ice");
		public static Block SnowBlock = new Block("snow_block");
		public static Block Cactus = new Block("cactus");
		public static Block Clay = new Block("clay");
		public static Block SugarCanes = new Block("reeds");
		public static Block Jukebox = new Block("jukebox");
		public static Block OakFence = new Block("oak_fence");
		public static Block Pumpkin = new Block("pumpkin");
		public static Block Netherrack = new Block("netherrack");
		public static Block SoulSand = new Block("soul_sand");
		public static Block Glowstone = new Block("glowstone");
		public static Block NetherPortal = new Block("nether_portal");
		public static Block JackoLantern = new Block("jack_o_lantern");
		public static Block CakeBlock = new Block("cake");
		public static Block RedstoneRepeaterBlockOff = new Block("unpowered_repeater");
		public static Block RedstoneRepeaterBlockOn = new Block("powered_repeater");
		public static Block WhiteStainedGlass = new Block("white_stained_glass");
		public static Block OrangeStainedGlass = new Block("orange_stained_glass");
		public static Block MagentaStainedGlass = new Block("magenta_stained_glass");
		public static Block LightBlueStainedGlass = new Block("light_blue_stained_glass");
		public static Block YellowStainedGlass = new Block("yellow_stained_glass");
		public static Block LimeStainedGlass = new Block("lime_stained_glass");
		public static Block PinkStainedGlass = new Block("pink_stained_glass");
		public static Block GrayStainedGlass = new Block("gray_stained_glass");
		public static Block LightGrayStainedGlass = new Block("light_gray_stained_glass");
		public static Block CyanStainedGlass = new Block("cyan_stained_glass");
		public static Block PurpleStainedGlass = new Block("purple_stained_glass");
		public static Block BlueStainedGlass = new Block("blue_stained_glass");
		public static Block BrownStainedGlass = new Block("brown_stained_glass");
		public static Block GreenStainedGlass = new Block("green_stained_glass");
		public static Block RedStainedGlass = new Block("red_stained_glass");
		public static Block BlackStainedGlass = new Block("black_stained_glass");
		public static Block WoodenTrapdoor = new Block("oak_trapdoor");
		public static Block StoneMonsterEgg = new Block("infested_stone");
		public static Block CobblestoneMonsterEgg = new Block("infested_cobblestone");
		public static Block StoneBrickMonsterEgg = new Block("infested_stone_bricks");
		public static Block MossyStoneBrickMonsterEgg = new Block("infested_mossy_stone_bricks");
		public static Block CrackedStoneBrickMonsterEgg = new Block("infested_cracked_stone_bricks");
		public static Block ChiseledStoneBrickMonsterEgg = new Block("infested_chiseled_stone_bricks");
		public static Block StoneBricks = new Block("stone_bricks");
		public static Block MossyStoneBricks = new Block("mossy_stone_bricks");
		public static Block CrackedStoneBricks = new Block("cracked_stone_bricks");
		public static Block ChiseledStoneBricks = new Block("chiseled_stone_bricks");
		public static Block BrownMushroomBlock = new Block("brown_mushroom_block");
		public static Block RedMushroomBlock = new Block("red_mushroom_block");
		public static Block IronBars = new Block("iron_bars");
		public static Block GlassPane = new Block("glass_pane");
		public static Block MelonBlock = new Block("melon");
		public static Block PumpkinStem = new Block("pumpkin_stem");
		public static Block MelonStem = new Block("melon_stem");
		public static Block Vines = new Block("vine");
		public static Block OakFenceGate = new Block("oak_fence_gate");
		public static Block BrickStairs = new Block("brick_stairs");
		public static Block StoneBrickStairs = new Block("stone_brick_stairs");
		public static Block Mycelium = new Block("mycelium");
		public static Block LilyPad = new Block("lily_pad");
		public static Block NetherBrick = new Block("nether_bricks");
		public static Block NetherBrickFence = new Block("nether_brick_fence");
		public static Block NetherBrickStairs = new Block("nether_brick_stairs");
		public static Block NetherWart = new Block("nether_wart");
		public static Block EnchantmentTable = new Block("enchanting_table");
		public static Block BrewingStand = new Block("brewing_stand");
		public static Block Cauldron = new Block("cauldron");
		public static Block EndPortal = new Block("end_portal");
		public static Block EndPortalFrame = new Block("end_portal_frame");
		public static Block EndStone = new Block("end_stone");
		public static Block DragonEgg = new Block("dragon_egg");
		public static Block RedstoneLampInactive = new Block("redstone_lamp");
		public static Block RedstoneLampActive = new Block("lit_redstone_lamp");
		public static Block DoubleOakWoodSlab = new Block("double_wooden_slab");
		public static Block DoubleSpruceWoodSlab = new Block("double_wooden_slab");
		public static Block DoubleBirchWoodSlab = new Block("double_wooden_slab");
		public static Block DoubleJungleWoodSlab = new Block("double_wooden_slab");
		public static Block DoubleAcaciaWoodSlab = new Block("double_wooden_slab");
		public static Block DoubleDarkOakWoodSlab = new Block("double_wooden_slab");
		public static Block OakWoodSlab = new Block("oak_slab");
		public static Block SpruceWoodSlab = new Block("spruce_slab");
		public static Block BirchWoodSlab = new Block("birch_slab");
		public static Block JungleWoodSlab = new Block("jungle_slab");
		public static Block AcaciaWoodSlab = new Block("acacia_slab");
		public static Block DarkOakWoodSlab = new Block("dark_oak_slab");
		public static Block Cocoa = new Block("cocoa");
		public static Block SandstoneStairs = new Block("sandstone_stairs");
		public static Block EmeraldOre = new Block("emerald_ore");
		public static Block EnderChest = new Block("ender_chest");
		public static Block TripwireHook = new Block("tripwire_hook");
		public static Block Tripwire = new Block("tripwire");
		public static Block EmeraldBlock = new Block("emerald_block");
		public static Block SpruceWoodStairs = new Block("spruce_stairs");
		public static Block BirchWoodStairs = new Block("birch_stairs");
		public static Block JungleWoodStairs = new Block("jungle_stairs");

		public static Block CommandBlock = new Block("command_block")
		{
			Data = new List<BlockData>
			{
				new BlockData("CustomName", ""),
				new BlockData("Command", ""),
				new BlockData("SuccessCount", 0),
				new BlockData("LastOutput", ""),
				new BlockData("TrackOutput", false),
				new BlockData("powered", false),
				new BlockData("auto", false),
				new BlockData("conditionMet", false),
				new BlockData("UpdateLastExecution", false),
				new BlockData("LastExecution", 0)
			}
		};

		public static Block Beacon = new Block("beacon")
		{
			Data = new List<BlockData>
			{
				new BlockData("Lock", ""),
				new BlockData("Levels", 0),
				new BlockData("Primary", 0),
				new BlockData("Secondary", 0)
			}
		};

		public static Block CobblestoneWall = new Block("cobblestone_wall");
		public static Block MossyCobblestoneWall = new Block("mossy_cobblestone_wall");
		public static Block FlowerPot = new Block("flower_pot");
		public static Block Carrots = new Block("carrots");
		public static Block Potatoes = new Block("potatoes");
		public static Block WoodenButton = new Block("oak_button");
		public static Block MobHead = new Block("skull");
		public static Block Anvil = new Block("anvil");
		public static Block TrappedChest = new Block("trapped_chest");
		public static Block WeightedPressurePlateLight = new Block("light_weighted_pressure_plate");
		public static Block WeightedPressurePlateHeavy = new Block("heavy_weighted_pressure_plate");
		public static Block RedstoneComparatorInactive = new Block("unpowered_comparator");
		public static Block RedstoneComparatorActive = new Block("powered_comparator");
		public static Block DaylightSensor = new Block("daylight_detector");
		public static Block RedstoneBlock = new Block("redstone_block");
		public static Block NetherQuartzOre = new Block("nether_quartz_ore");
		public static Block Hopper = new Block("hopper");
		public static Block QuartzBlock = new Block("quartz_block");
		public static Block ChiseledQuartzBlock = new Block("chiseled_quartz_block");
		public static Block PillarQuartzBlock = new Block("quartz_pillar");
		public static Block QuartzStairs = new Block("quartz_stairs");
		public static Block ActivatorRail = new Block("activator_rail");
		public static Block Dropper = new Block("dropper");
		public static Block WhiteHardenedClay = new Block("white_terracotta");
		public static Block OrangeHardenedClay = new Block("orange_terracotta");
		public static Block MagentaHardenedClay = new Block("magenta_terracotta");
		public static Block LightBlueHardenedClay = new Block("light_blue_terracotta");
		public static Block YellowHardenedClay = new Block("yellow_terracotta");
		public static Block LimeHardenedClay = new Block("lime_terracotta");
		public static Block PinkHardenedClay = new Block("pink_terracotta");
		public static Block GrayHardenedClay = new Block("gray_terracotta");
		public static Block LightGrayHardenedClay = new Block("light_gray_terracotta");
		public static Block CyanHardenedClay = new Block("cyan_terracotta");
		public static Block PurpleHardenedClay = new Block("purple_terracotta");
		public static Block BlueHardenedClay = new Block("blue_terracotta");
		public static Block BrownHardenedClay = new Block("brown_terracotta");
		public static Block GreenHardenedClay = new Block("green_terracotta");
		public static Block RedHardenedClay = new Block("red_terracotta");
		public static Block BlackHardenedClay = new Block("black_terracotta");
		public static Block WhiteStainedGlassPane = new Block("white_stained_glass_pane");
		public static Block OrangeStainedGlassPane = new Block("orange_stained_glass_pane");
		public static Block MagentaStainedGlassPane = new Block("magenta_stained_glass_pane");
		public static Block LightBlueStainedGlassPane = new Block("light_blue_stained_glass_pane");
		public static Block YellowStainedGlassPane = new Block("yellow_stained_glass_pane");
		public static Block LimeStainedGlassPane = new Block("lime_stained_glass_pane");
		public static Block PinkStainedGlassPane = new Block("pink_stained_glass_pane");
		public static Block GrayStainedGlassPane = new Block("gray_stained_glass_pane");
		public static Block LightGrayStainedGlassPane = new Block("light_gray_glass_pane");
		public static Block CyanStainedGlassPane = new Block("cyan_stained_glass_pane");
		public static Block PurpleStainedGlassPane = new Block("purple_stained_glass_pane");
		public static Block BlueStainedGlassPane = new Block("blue_stained_glass_pane");
		public static Block BrownStainedGlassPane = new Block("brown_stained_glass_pane");
		public static Block GreenStainedGlassPane = new Block("green_stained_glass_pane");
		public static Block RedStainedGlassPane = new Block("red_stained_glass_pane");
		public static Block BlackStainedGlassPane = new Block("black_stained_glass_pane");
		public static Block AcaciaLeaves = new Block("acacia_leaves");
		public static Block DarkOakLeaves = new Block("dark_oak_leaves");
		public static Block AcaciaWood = new Block("acacia_log");
		public static Block DarkOakWood = new Block("dark_oak_log");
		public static Block AcaciaWoodStairs = new Block("acacia_stairs");
		public static Block DarkOakWoodStairs = new Block("dark_oak_stairs");
		public static Block SlimeBlock = new Block("slime_block");
		public static Block Barrier = new Block("barrier");
		public static Block IronTrapdoor = new Block("iron_trapdoor");
		public static Block Prismarine = new Block("prismarine");
		public static Block PrismarineBricks = new Block("prismarine_bricks");
		public static Block DarkPrismarine = new Block("dark_prismarine");
		public static Block SeaLantern = new Block("sea_lantern");
		public static Block HayBale = new Block("hay_block");
		public static Block WhiteCarpet = new Block("white_carpet");
		public static Block OrangeCarpet = new Block("orange_carpet");
		public static Block MagentaCarpet = new Block("magenta_carpet");
		public static Block LightBlueCarpet = new Block("light_blue_carpet");
		public static Block YellowCarpet = new Block("yellow_carpet");
		public static Block LimeCarpet = new Block("lime_carpet");
		public static Block PinkCarpet = new Block("pink_carpet");
		public static Block GrayCarpet = new Block("gray_carpet");
		public static Block LightGrayCarpet = new Block("light_gray_carpet");
		public static Block CyanCarpet = new Block("cyan_carpet");
		public static Block PurpleCarpet = new Block("purple_carpet");
		public static Block BlueCarpet = new Block("blue_carpet");
		public static Block BrownCarpet = new Block("brown_carpet");
		public static Block GreenCarpet = new Block("green_carpet");
		public static Block RedCarpet = new Block("red_carpet");
		public static Block BlackCarpet = new Block("black_carpet");
		public static Block HardenedClay = new Block("terracotta");
		public static Block BlockofCoal = new Block("coal_block");
		public static Block PackedIce = new Block("packed_ice");
		public static Block Sunflower = new Block("sunflower");
		public static Block Lilac = new Block("lilac");
		public static Block DoubleTallgrass = new Block("tall_grass");
		public static Block LargeFern = new Block("large_fern");
		public static Block RoseBush = new Block("rose_bush");
		public static Block Peony = new Block("peony");
		public static Block FreeStandingBanner = new Block("standing_banner");
		public static Block WallMountedBanner = new Block("wall_banner");
		public static Block InvertedDaylightSensor = new Block("daylight_detector_inverted");
		public static Block RedSandstone = new Block("red_sandstone");
		public static Block ChiseledRedSandstone = new Block("chiseled_red_sandstone");
		public static Block SmoothRedSandstone = new Block("cut_red_sandstone");
		public static Block RedSandstoneStairs = new Block("red_sandstone_stairs");
		public static Block DoubleRedSandstoneSlab = new Block("double_stone_slab2");
		public static Block RedSandstoneSlab = new Block("red_sandstone_slab");
		public static Block SpruceFenceGate = new Block("spruce_fence_gate");
		public static Block BirchFenceGate = new Block("birch_fence_gate");
		public static Block JungleFenceGate = new Block("jungle_fence_gate");
		public static Block DarkOakFenceGate = new Block("dark_oak_fence_gate");
		public static Block AcaciaFenceGate = new Block("acacia_fence_gate");
		public static Block SpruceFence = new Block("spruce_fence");
		public static Block BirchFence = new Block("birch_fence");
		public static Block JungleFence = new Block("jungle_fence");
		public static Block DarkOakFence = new Block("dark_oak_fence");
		public static Block AcaciaFence = new Block("acacia_fence");
		public static Block SpruceDoorBlock = new Block("spruce_door");
		public static Block BirchDoorBlock = new Block("birch_door");
		public static Block JungleDoorBlock = new Block("jungle_door");
		public static Block AcaciaDoorBlock = new Block("acacia_door");
		public static Block DarkOakDoorBlock = new Block("dark_oak_door");
		public static Block EndRod = new Block("end_rod");
		public static Block ChorusPlant = new Block("chorus_plant");
		public static Block ChorusFlower = new Block("chorus_flower");
		public static Block PurpurBlock = new Block("purpur_block");
		public static Block PurpurPillar = new Block("purpur_pillar");
		public static Block PurpurStairs = new Block("purpur_stairs");
		public static Block PurpurDoubleSlab = new Block("purpur_double_slab");
		public static Block PurpurSlab = new Block("purpur_slab");
		public static Block EndStoneBricks = new Block("end_stone_bricks");
		public static Block BeetrootBlock = new Block("beetroots");
		public static Block GrassPath = new Block("grass_path");
		public static Block EndGateway = new Block("end_gateway");
		public static Block RepeatingCommandBlock = new Block("repeating_command_block");
		public static Block ChainCommandBlock = new Block("chain_command_block");
		public static Block FrostedIce = new Block("frosted_ice");
		public static Block MagmaBlock = new Block("magma_block");
		public static Block NetherWartBlock = new Block("nether_wart_block");
		public static Block RedNetherBrick = new Block("red_nether_bricks");
		public static Block BoneBlock = new Block("bone_block");
		public static Block StructureVoid = new Block("structure_void");
		public static Block Observer = new Block("observer");
		public static Block WhiteShulkerBox = new Block("white_shulker_box");
		public static Block OrangeShulkerBox = new Block("orange_shulker_box");
		public static Block MagentaShulkerBox = new Block("magenta_shulker_box");
		public static Block LightBlueShulkerBox = new Block("light_blue_shulker_box");
		public static Block YellowShulkerBox = new Block("yellow_shulker_box");
		public static Block LimeShulkerBox = new Block("lime_shulker_box");
		public static Block PinkShulkerBox = new Block("pink_shulker_box");
		public static Block GrayShulkerBox = new Block("gray_shulker_box");
		public static Block LightGrayShulkerBox = new Block("silver_shulker_box");
		public static Block CyanShulkerBox = new Block("cyan_shulker_box");
		public static Block PurpleShulkerBox = new Block("purple_shulker_box");
		public static Block BlueShulkerBox = new Block("blue_shulker_box");
		public static Block BrownShulkerBox = new Block("brown_shulker_box");
		public static Block GreenShulkerBox = new Block("green_shulker_box");
		public static Block RedShulkerBox = new Block("red_shulker_box");
		public static Block BlackShulkerBox = new Block("black_shulker_box");
		public static Block WhiteGlazedTerracotta = new Block("white_glazed_terracotta");
		public static Block OrangeGlazedTerracotta = new Block("orange_glazed_terracotta");
		public static Block MagentaGlazedTerracotta = new Block("magenta_glazed_terracotta");
		public static Block LightBlueGlazedTerracotta = new Block("light_blue_glazed_terracotta");
		public static Block YellowGlazedTerracotta = new Block("yellow_glazed_terracotta");
		public static Block LimeGlazedTerracotta = new Block("lime_glazed_terracotta");
		public static Block PinkGlazedTerracotta = new Block("pink_glazed_terracotta");
		public static Block GrayGlazedTerracotta = new Block("gray_glazed_terracotta");
		public static Block LightGrayGlazedTerracotta = new Block("light_gray_glazed_terracotta");
		public static Block CyanGlazedTerracotta = new Block("cyan_glazed_terracotta");
		public static Block PurpleGlazedTerracotta = new Block("purple_glazed_terracotta");
		public static Block BlueGlazedTerracotta = new Block("blue_glazed_terracotta");
		public static Block BrownGlazedTerracotta = new Block("brown_glazed_terracotta");
		public static Block GreenGlazedTerracotta = new Block("green_glazed_terracotta");
		public static Block RedGlazedTerracotta = new Block("red_glazed_terracotta");
		public static Block BlackGlazedTerracotta = new Block("black_glazed_terracotta");
		public static Block WhiteConcrete = new Block("white_concrete");
		public static Block OrangeConcrete = new Block("orange_concrete");
		public static Block MagentaConcrete = new Block("magenta_concrete");
		public static Block LightBlueConcrete = new Block("light_blue_concrete");
		public static Block YellowConcrete = new Block("yellow_concrete");
		public static Block LimeConcrete = new Block("lime_concrete");
		public static Block PinkConcrete = new Block("pink_concrete");
		public static Block GrayConcrete = new Block("gray_concrete");
		public static Block LightGrayConcrete = new Block("light_gray_concrete");
		public static Block CyanConcrete = new Block("cyan_concrete");
		public static Block PurpleConcrete = new Block("purple_concrete");
		public static Block BlueConcrete = new Block("blue_concrete");
		public static Block BrownConcrete = new Block("brown_concrete");
		public static Block GreenConcrete = new Block("green_concrete");
		public static Block RedConcrete = new Block("red_concrete");
		public static Block BlackConcrete = new Block("black_concrete");
		public static Block WhiteConcretePowder = new Block("white_concrete_powder");
		public static Block OrangeConcretePowder = new Block("orange_concrete_powder");
		public static Block MagentaConcretePowder = new Block("magenta_concrete_powder");
		public static Block LightBlueConcretePowder = new Block("light_blue_concrete_powder");
		public static Block YellowConcretePowder = new Block("yellow_concrete_powder");
		public static Block LimeConcretePowder = new Block("lime_concrete_powder");
		public static Block PinkConcretePowder = new Block("pink_concrete_powder");
		public static Block GrayConcretePowder = new Block("gray_concrete_powder");
		public static Block LightGrayConcretePowder = new Block("light_gray_concrete_powder");
		public static Block CyanConcretePowder = new Block("cyan_concrete_powder");
		public static Block PurpleConcretePowder = new Block("purple_concrete_powder");
		public static Block BlueConcretePowder = new Block("blue_concrete_powder");
		public static Block BrownConcretePowder = new Block("brown_concrete_powder");
		public static Block GreenConcretePowder = new Block("green_concrete_powder");
		public static Block RedConcretePowder = new Block("red_concrete_powder");
		public static Block BlackConcretePowder = new Block("black_concrete_powder");
		public static Block StructureBlock = new Block("structure_block");
		public static Block IronShovel = new Block("iron_shovel");
		public static Block IronPickaxe = new Block("iron_pickaxe");
		public static Block IronAxe = new Block("iron_axe");
		public static Block FlintandSteel = new Block("flint_and_steel");
		public static Block Apple = new Block("apple");
		public static Block Bow = new Block("bow");
		public static Block Arrow = new Block("arrow");
		public static Block Coal = new Block("coal");
		public static Block Charcoal = new Block("coal");
		public static Block Diamond = new Block("diamond");
		public static Block IronIngot = new Block("iron_ingot");
		public static Block GoldIngot = new Block("gold_ingot");
		public static Block IronSword = new Block("iron_sword");
		public static Block WoodenSword = new Block("wooden_sword");
		public static Block WoodenShovel = new Block("wooden_shovel");
		public static Block WoodenPickaxe = new Block("wooden_pickaxe");
		public static Block WoodenAxe = new Block("wooden_axe");
		public static Block StoneSword = new Block("stone_sword");
		public static Block StoneShovel = new Block("stone_shovel");
		public static Block StonePickaxe = new Block("stone_pickaxe");
		public static Block StoneAxe = new Block("stone_axe");
		public static Block DiamondSword = new Block("diamond_sword");
		public static Block DiamondShovel = new Block("diamond_shovel");
		public static Block DiamondPickaxe = new Block("diamond_pickaxe");
		public static Block DiamondAxe = new Block("diamond_axe");
		public static Block Stick = new Block("stick");
		public static Block Bowl = new Block("bowl");
		public static Block MushroomStew = new Block("mushroom_stew");
		public static Block GoldenSword = new Block("golden_sword");
		public static Block GoldenShovel = new Block("golden_shovel");
		public static Block GoldenPickaxe = new Block("golden_pickaxe");
		public static Block GoldenAxe = new Block("golden_axe");
		public static Block String = new Block("string");
		public static Block Feather = new Block("feather");
		public static Block Gunpowder = new Block("gunpowder");
		public static Block WoodenHoe = new Block("wooden_hoe");
		public static Block StoneHoe = new Block("stone_hoe");
		public static Block IronHoe = new Block("iron_hoe");
		public static Block DiamondHoe = new Block("diamond_hoe");
		public static Block GoldenHoe = new Block("golden_hoe");
		public static Block WheatSeeds = new Block("wheat_seeds");
		public static Block Wheat = new Block("wheat");
		public static Block Bread = new Block("bread");
		public static Block LeatherHelmet = new Block("leather_helmet");
		public static Block LeatherTunic = new Block("leather_chestplate");
		public static Block LeatherPants = new Block("leather_leggings");
		public static Block LeatherBoots = new Block("leather_boots");
		public static Block ChainmailHelmet = new Block("chainmail_helmet");
		public static Block ChainmailChestplate = new Block("chainmail_chestplate");
		public static Block ChainmailLeggings = new Block("chainmail_leggings");
		public static Block ChainmailBoots = new Block("chainmail_boots");
		public static Block IronHelmet = new Block("iron_helmet");
		public static Block IronChestplate = new Block("iron_chestplate");
		public static Block IronLeggings = new Block("iron_leggings");
		public static Block IronBoots = new Block("iron_boots");
		public static Block DiamondHelmet = new Block("diamond_helmet");
		public static Block DiamondChestplate = new Block("diamond_chestplate");
		public static Block DiamondLeggings = new Block("diamond_leggings");
		public static Block DiamondBoots = new Block("diamond_boots");
		public static Block GoldenHelmet = new Block("golden_helmet");
		public static Block GoldenChestplate = new Block("golden_chestplate");
		public static Block GoldenLeggings = new Block("golden_leggings");
		public static Block GoldenBoots = new Block("golden_boots");
		public static Block Flint = new Block("flint");
		public static Block RawPorkchop = new Block("porkchop");
		public static Block CookedPorkchop = new Block("cooked_porkchop");
		public static Block Painting = new Block("painting");
		public static Block GoldenApple = new Block("golden_apple");
		public static Block EnchantedGoldenApple = new Block("enchanted_golden_apple");
		public static Block Sign = new Block("sign");
		public static Block OakDoor = new Block("oak_door");
		public static Block Bucket = new Block("bucket");
		public static Block WaterBucket = new Block("water_bucket");
		public static Block LavaBucket = new Block("lava_bucket");
		public static Block Minecart = new Block("minecart");
		public static Block Saddle = new Block("saddle");
		public static Block IronDoor = new Block("iron_door");
		public static Block Redstone = new Block("redstone");
		public static Block Snowball = new Block("snowball");
		public static Block OakBoat = new Block("oak_boat");
		public static Block Leather = new Block("leather");
		public static Block MilkBucket = new Block("milk_bucket");
		public static Block Brick = new Block("brick");
		public static Block ClayBall = new Block("clay_ball");
		public static Block SugarCane = new Block("sugar_cane");
		public static Block Paper = new Block("paper");
		public static Block Book = new Block("book");
		public static Block Slimeball = new Block("slime_ball");
		public static Block MinecartwithChest = new Block("chest_minecart");
		public static Block MinecartwithFurnace = new Block("furnace_minecart");
		public static Block Egg = new Block("egg");
		public static Block Compass = new Block("compass");
		public static Block FishingRod = new Block("fishing_rod");
		public static Block Clock = new Block("clock");
		public static Block GlowstoneDust = new Block("glowstone_dust");
		public static Block RawFish = new Block("cod");
		public static Block RawSalmon = new Block("salmon");
		public static Block Clownfish = new Block("tropical_fish");
		public static Block Pufferfish = new Block("pufferfish");
		public static Block CookedFish = new Block("cooked_cod");
		public static Block CookedSalmon = new Block("cooked_salmon");
		public static Block InkSack = new Block("ink_sac");
		public static Block RoseRed = new Block("rose_red");
		public static Block CactusGreen = new Block("cactus_green");
		public static Block CocoBeans = new Block("cocoa_beans");
		public static Block LapisLazuli = new Block("lapis_lazuli");
		public static Block PurpleDye = new Block("purple_dye");
		public static Block CyanDye = new Block("cyan_dye");
		public static Block LightGrayDye = new Block("light_gray_dye");
		public static Block GrayDye = new Block("gray_dye");
		public static Block PinkDye = new Block("pink_dye");
		public static Block LimeDye = new Block("lime_dye");
		public static Block DandelionYellow = new Block("dandelion_yellow");
		public static Block LightBlueDye = new Block("light_blue_dye");
		public static Block MagentaDye = new Block("magenta_dye");
		public static Block OrangeDye = new Block("orange_dye");
		public static Block BoneMeal = new Block("bone_meal");
		public static Block Bone = new Block("bone");
		public static Block Sugar = new Block("sugar");
		public static Block Cake = new Block("cake");
		public static Block WhiteBed = new Block("white_bed");
		public static Block RedstoneRepeater = new Block("repeater");
		public static Block Cookie = new Block("cookie");
		public static Block Map = new Block("filled_map");
		public static Block Shears = new Block("shears");
		public static Block Melon = new Block("melon_slice");
		public static Block PumpkinSeeds = new Block("pumpkin_seeds");
		public static Block MelonSeeds = new Block("melon_seeds");
		public static Block RawBeef = new Block("beef");
		public static Block Steak = new Block("cooked_beef");
		public static Block RawChicken = new Block("chicken");
		public static Block CookedChicken = new Block("cooked_chicken");
		public static Block RottenFlesh = new Block("rotten_flesh");
		public static Block EnderPearl = new Block("ender_pearl");
		public static Block BlazeRod = new Block("blaze_rod");
		public static Block GhastTear = new Block("ghast_tear");
		public static Block GoldNugget = new Block("gold_nugget");
		public static Block Potion = new Block("potion");
		public static Block GlassBottle = new Block("glass_bottle");
		public static Block SpiderEye = new Block("spider_eye");
		public static Block FermentedSpiderEye = new Block("fermented_spider_eye");
		public static Block BlazePowder = new Block("blaze_powder");
		public static Block MagmaCream = new Block("magma_cream");
		public static Block EyeofEnder = new Block("ender_eye");
		public static Block GlisteringMelon = new Block("glistering_melon_slice");
		public static Block SpawnElderGuardian = new Block("elder_guardian_spawn_egg");
		public static Block SpawnWitherSkeleton = new Block("wither_skeleton_spawn_egg");
		public static Block SpawnStray = new Block("stray_spawn_egg");
		public static Block SpawnHusk = new Block("husk_spawn_egg");
		public static Block SpawnZombieVillager = new Block("zombie_villager_spawn_egg");
		public static Block SpawnSkeletonHorse = new Block("skeleton_horse_spawn_egg");
		public static Block SpawnZombieHorse = new Block("zombie_horse_spawn_egg");
		public static Block SpawnDonkey = new Block("donkey_spawn_egg");
		public static Block SpawnMule = new Block("mule_spawn_egg");
		public static Block SpawnEvoker = new Block("evoker_spawn_egg");
		public static Block SpawnVex = new Block("vex_spawn_egg");
		public static Block SpawnVindicator = new Block("vindicator_spawn_egg");
		public static Block SpawnCreeper = new Block("creeper_spawn_egg");
		public static Block SpawnSkeleton = new Block("skeleton_spawn_egg");
		public static Block SpawnSpider = new Block("spider_spawn_egg");
		public static Block SpawnZombie = new Block("zombie_spawn_egg");
		public static Block SpawnSlime = new Block("slime_spawn_egg");
		public static Block SpawnGhast = new Block("ghast_spawn_egg");
		public static Block SpawnZombiePigman = new Block("zombie_pigman_spawn_egg");
		public static Block SpawnEnderman = new Block("enderman_spawn_egg");
		public static Block SpawnCaveSpider = new Block("cave_spider_spawn_egg");
		public static Block SpawnSilverfish = new Block("spawn_egg");
		public static Block SpawnBlaze = new Block("blaze_spawn_egg");
		public static Block SpawnMagmaCube = new Block("magma_cube_spawn_egg");
		public static Block SpawnBat = new Block("bat_spawn_egg");
		public static Block SpawnWitch = new Block("witch_spawn_egg");
		public static Block SpawnEndermite = new Block("endermite_spawn_egg");
		public static Block SpawnGuardian = new Block("guardian_spawn_egg");
		public static Block SpawnShulker = new Block("shulker_spawn_egg");
		public static Block SpawnPig = new Block("pig_spawn_egg");
		public static Block SpawnSheep = new Block("sheep_spawn_egg");
		public static Block SpawnCow = new Block("cow_spawn_egg");
		public static Block SpawnChicken = new Block("chicken_spawn_egg");
		public static Block SpawnSquid = new Block("squid_spawn_egg");
		public static Block SpawnWolf = new Block("wolf_spawn_egg");
		public static Block SpawnMooshroom = new Block("mooshroom_spawn_egg");
		public static Block SpawnOcelot = new Block("ocelot_spawn_egg");
		public static Block SpawnHorse = new Block("horse_spawn_egg");
		public static Block SpawnRabbit = new Block("rabbit_spawn_egg");
		public static Block SpawnPolarBear = new Block("polar_bear_spawn_egg");
		public static Block SpawnLlama = new Block("llama_spawn_egg");
		public static Block SpawnParrot = new Block("spawn_egg");
		public static Block SpawnVillager = new Block("villager_spawn_egg");
		public static Block BottleEnchanting = new Block("experience_bottle");
public static Block FireCharge = new Block("fire_charge");
		public static Block BookandQuill = new Block("writable_book");
		public static Block WrittenBook = new Block("written_book");
		public static Block Emerald = new Block("emerald");
		public static Block ItemFrame = new Block("item_frame");
		public static Block Carrot = new Block("carrot");
		public static Block Potato = new Block("potato");
		public static Block BakedPotato = new Block("baked_potato");
		public static Block PoisonousPotato = new Block("poisonous_potato");
		public static Block EmptyMap = new Block("map");
		public static Block GoldenCarrot = new Block("golden_carrot");
		public static Block MobHeadSkeleton = new Block("skeleton_skull");
		public static Block MobHeadWitherSkeleton = new Block("wither_skeleton_skull");
		public static Block MobHeadZombie = new Block("zombie_head");
		public static Block MobHeadHuman = new Block("player_head");
		public static Block MobHeadCreeper = new Block("creeper_head");
		public static Block MobHeadDragon = new Block("dragon_head");
		public static Block CarrotonaStick = new Block("carrot_on_a_stick");
		public static Block NetherStar = new Block("nether_star");
		public static Block PumpkinPie = new Block("pumpkin_pie");
		public static Block FireworkRocket = new Block("firework_rocket");
		public static Block FireworkStar = new Block("firework_star");
		public static Block EnchantedBook = new Block("enchanted_book");
		public static Block NetherQuartz = new Block("quartz");
		public static Block MinecartwithTnt = new Block("tnt_minecart");
		public static Block MinecartwithHopper = new Block("hopper_minecart");
		public static Block PrismarineShard = new Block("prismarine_shard");
		public static Block PrismarineCrystals = new Block("prismarine_crystals");
		public static Block RawRabbit = new Block("rabbit");
		public static Block CookedRabbit = new Block("cooked_rabbit");
		public static Block RabbitStew = new Block("rabbit_stew");
		public static Block RabbitsFoot = new Block("rabbit_foot");
		public static Block RabbitHide = new Block("rabbit_hide");
		public static Block ArmorStand = new Block("armor_stand");
		public static Block IronHorseArmor = new Block("iron_horse_armor");
		public static Block GoldenHorseArmor = new Block("golden_horse_armor");
		public static Block DiamondHorseArmor = new Block("diamond_horse_armor");
		public static Block Lead = new Block("lead");
		public static Block NameTag = new Block("name_tag");
		public static Block MinecartwithCommandBlock = new Block("command_block_minecart");
		public static Block RawMutton = new Block("mutton");
		public static Block CookedMutton = new Block("cooked_mutton");
		public static Block Banner = new Block("black_banner");
		public static Block EndCrystal = new Block("end_crystal");
		public static Block SpruceDoor = new Block("spruce_door");
		public static Block BirchDoor = new Block("birch_door");
		public static Block JungleDoor = new Block("jungle_door");
		public static Block AcaciaDoor = new Block("acacia_door");
		public static Block DarkOakDoor = new Block("dark_oak_door");
		public static Block ChorusFruit = new Block("chorus_fruit");
		public static Block PoppedChorusFruit = new Block("popped_chorus_fruit");
		public static Block Beetroot = new Block("beetroot");
		public static Block BeetrootSeeds = new Block("beetroot_seeds");
		public static Block BeetrootSoup = new Block("beetroot_soup");
		public static Block DragonsBreath = new Block("dragon_breath");
public static Block SplashPotion = new Block("splash_potion");
		public static Block SpectralArrow = new Block("spectral_arrow");
		public static Block TippedArrow = new Block("tipped_arrow");
		public static Block LingeringPotion = new Block("lingering_potion");
		public static Block Shield = new Block("shield");
		public static Block Elytra = new Block("elytra");
		public static Block SpruceBoat = new Block("spruce_boat");
		public static Block BirchBoat = new Block("birch_boat");
		public static Block JungleBoat = new Block("jungle_boat");
		public static Block AcaciaBoat = new Block("acacia_boat");
		public static Block DarkOakBoat = new Block("dark_oak_boat");
		public static Block TotemofUndying = new Block("totem_of_undying");
		public static Block ShulkerShell = new Block("shulker_shell");
		public static Block IronNugget = new Block("iron_nugget");
		public static Block KnowledgeBook = new Block("knowledge_book");
		public static Block Disc13 = new Block("music_disc_13");
		public static Block CatDisc = new Block("music_disc_cat");
		public static Block BlocksDisc = new Block("music_disc_blocks");
		public static Block ChirpDisc = new Block("music_disc_chirp");
		public static Block FarDisc = new Block("music_disc_far");
		public static Block MallDisc = new Block("music_disc_mall");
		public static Block MellohiDisc = new Block("music_disc_mellohi");
		public static Block StalDisc = new Block("music_disc_stal");
		public static Block StradDisc = new Block("music_disc_strad");
		public static Block WardDisc = new Block("music_disc_ward");
		public static Block Disc11 = new Block("music_disc_11");
		public static Block WaitDisc = new Block("music_disc_wait");
		public static Block SmoothStone = new Block("smooth_stone");
		public static Block ChippedAnvil = new Block("chipped_anvil");
		public static Block DamagedAnvil = new Block("damaged_anvil");
		public static Block OrangeBed = new Block("orange_bed");
		public static Block MagentaBed = new Block("magenta_bed");
		public static Block LightBlueBed = new Block("light_blue_bed");
		public static Block YellowBed = new Block("yellow_bed");
		public static Block LimeBed = new Block("lime_bed");
		public static Block PinkBed = new Block("pink_bed");
		public static Block GrayBed = new Block("gray_bed");
		public static Block LightGrayBed = new Block("light_gray_bed");
		public static Block CyanBed = new Block("cyan_bed");
		public static Block PurpleBed = new Block("purple_bed");
		public static Block BlueBed = new Block("blue_bed");
		public static Block BrownBed = new Block("brown_bed");
		public static Block GreenBed = new Block("green_bed");
		public static Block RedBed = new Block("red_bed");
		public static Block BlackBed = new Block("black_bed");
		public static Block WhiteBanner = new Block("white_banner");
		public static Block OrangeBanner = new Block("orange_banner");
		public static Block MagnetaBanner = new Block("magneta_banner");
		public static Block LightBlueBanner = new Block("light_blue_banner");
		public static Block YellowBanner = new Block("yellow_banner");
		public static Block LimeBanner = new Block("lime_banner");
		public static Block PinkBanner = new Block("pink_banner");
		public static Block GrayBanner = new Block("gray_banner");
		public static Block LightGrayBanner = new Block("light_gray_banner");
		public static Block CyanBanner = new Block("cyan_banner");
		public static Block PurpleBanner = new Block("purple_banner");
		public static Block BlueBanner = new Block("blue_banner");
		public static Block BrownBanner = new Block("brown_banner");
		public static Block GreenBanner = new Block("green_banner");
		public static Block RedBanner = new Block("red_banner");


		#endregion
	}
}
