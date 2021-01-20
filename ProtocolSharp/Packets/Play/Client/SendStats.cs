using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Network;
using ProtocolSharp.Packets.Exceptions;
using ProtocolSharp.Types;

namespace ProtocolSharp.Packets.Play.Client
{
	/// <summary>
	/// Sent as a response to Client Status 0x04. Will only send the changed
	/// values if previously requested.
	/// NOTE: wiki.vg/Protocol lists this as "statistics"
	/// </summary>
	public class SendStats : ISendingPacket
	{
		public Packet Packet => Packet.Statistics;

		public string Name => "Statistics";

		public void Send(ref MinecraftClient client, GameStream stream)
		{
			throw new InvalidPacketUseException("Invalid Packet Use: Use overload with Statistics type");
		}

		public void Send(ref MinecraftClient client, GameStream stream, params Statistics[] stats)
		{
			if (stats.Length == 0) Send(ref client, stream);
			else
			{
				VarInt count = stats.Length;

				List<object> allItems = new List<object> {count};

				foreach (Statistics sts in stats)
				{
					allItems.Add(sts.Category.ID);
					allItems.Add(sts.Category.CustomID);
					allItems.Add(sts.Value);
				}

				Protocol.Send(ref client, stream, Packet, allItems);
			}
		}
	}

	public class Statistics
	{
		public StatsCategory Category { get; set; }

		public VarInt Value { get; set; }
	}

	public class StatsCategory
	{
		public VarInt ID { get; }
		public VarInt CustomID { get; }
		public string Name { get; }
		public StatsRegistry Registry { get; }

		internal StatsCategory(VarInt id, string name, StatsRegistry reg, VarInt custom = null)
		{
			ID = id ?? throw new ArgumentNullException(nameof(id));
			Name = "minecraft." + name;
			Registry = reg;

			if (custom == null || (custom == null && ID != 8))
			{
				CustomID = ID;
			}
			else
			{
				CustomID = custom;
			}
		}

		public static readonly StatsCategory Mined = new StatsCategory(0, "mined", StatsRegistry.Blocks);
		public static readonly StatsCategory Crafted = new StatsCategory(1, "crafted", StatsRegistry.Items);
		public static readonly StatsCategory Used = new StatsCategory(2, "used", StatsRegistry.Items);
		public static readonly StatsCategory Broken = new StatsCategory(3, "broken", StatsRegistry.Items);
		public static readonly StatsCategory PickedUp = new StatsCategory(4, "picked_up", StatsRegistry.Items);
		public static readonly StatsCategory Dropped = new StatsCategory(5, "dropped", StatsRegistry.Items);
		public static readonly StatsCategory Killed = new StatsCategory(6, "killed", StatsRegistry.Entities);
		public static readonly StatsCategory KilledBy = new StatsCategory(7, "killed_by", StatsRegistry.Entities);

		#region Custom Categories

		public static readonly StatsCategory LeaveGame = new StatsCategory(8, "leave_game", StatsRegistry.Custom, 0);
		public static readonly StatsCategory PlayOneMinute = new StatsCategory(8, "play_one_minute", StatsRegistry.Custom, 1);
		public static readonly StatsCategory TimeSinceDeath = new StatsCategory(8, "time_since_death", StatsRegistry.Custom, 2);
		public static readonly StatsCategory SneakTime = new StatsCategory(8, "sneak_time", StatsRegistry.Custom, 3);
		public static readonly StatsCategory WalkOneCm = new StatsCategory(8, "walk_one_cm", StatsRegistry.Custom, 4);
		public static readonly StatsCategory CrouchOneCm = new StatsCategory(8, "courch_one_cm", StatsRegistry.Custom, 5);
		public static readonly StatsCategory SprintOneCm = new StatsCategory(8, "sprint_one_cm", StatsRegistry.Custom, 6);
		public static readonly StatsCategory SwimOneCm = new StatsCategory(8, "swim_one_cm", StatsRegistry.Custom, 7);
		public static readonly StatsCategory FallOneCm = new StatsCategory(8, "fall_one_cm", StatsRegistry.Custom, 8);
		public static readonly StatsCategory ClimbOneCm = new StatsCategory(8, "climb_one_cm", StatsRegistry.Custom, 9);
		public static readonly StatsCategory FlyOneCm = new StatsCategory(8, "fly_one_cm", StatsRegistry.Custom, 10);
		public static readonly StatsCategory DiveOnCm = new StatsCategory(8, "dive_one_cm", StatsRegistry.Custom, 11);
		public static readonly StatsCategory MinecartOneCm = new StatsCategory(8, "minecart_one_cm", StatsRegistry.Custom, 12);
		public static readonly StatsCategory BoatOneCm = new StatsCategory(8, "boat_one_cm", StatsRegistry.Custom, 13);
		public static readonly StatsCategory PigOneCm = new StatsCategory(8, "pig_one_cm", StatsRegistry.Custom, 14);
		public static readonly StatsCategory HorseOneCm = new StatsCategory(8, "horse_one_cm", StatsRegistry.Custom, 15);
		public static readonly StatsCategory AviateOneCm = new StatsCategory(8, "aviate_one_cm", StatsRegistry.Custom, 16);
		public static readonly StatsCategory Jump = new StatsCategory(8, "jump", StatsRegistry.Custom, 17);
		public static readonly StatsCategory Drop = new StatsCategory(8, "drop", StatsRegistry.Custom, 18);
		public static readonly StatsCategory DamageDealt = new StatsCategory(8, "damage_dealt", StatsRegistry.Custom, 19);
		public static readonly StatsCategory DamageTaken = new StatsCategory(8, "damage_taken", StatsRegistry.Custom, 20);
		public static readonly StatsCategory Deaths = new StatsCategory(8, "deaths", StatsRegistry.Custom, 21);
		public static readonly StatsCategory MobKills = new StatsCategory(8, "mob_kills", StatsRegistry.Custom, 22);
		public static readonly StatsCategory AnimalsBred = new StatsCategory(8, "animals_bred", StatsRegistry.Custom, 23);
		public static readonly StatsCategory PlayerKills = new StatsCategory(8, "player_kills", StatsRegistry.Custom, 24);
		public static readonly StatsCategory FishCaught = new StatsCategory(8, "fish_caught", StatsRegistry.Custom, 25);
		public static readonly StatsCategory TalkedToVillager = new StatsCategory(8, "talked_to_villager", StatsRegistry.Custom, 26);
		public static readonly StatsCategory TradedWithVillager = new StatsCategory(8, "traded_with_villager", StatsRegistry.Custom, 27);
		public static readonly StatsCategory EatCakeSlice = new StatsCategory(8, "eat_cake_slice", StatsRegistry.Custom, 28); // I don't like that Minecraft is watching me engage in my fat making practices
		public static readonly StatsCategory FillCauldron = new StatsCategory(8, "fill_cauldron", StatsRegistry.Custom, 29);
		public static readonly StatsCategory UseCauldron = new StatsCategory(8, "use_cauldron", StatsRegistry.Custom, 30);
		public static readonly StatsCategory CleanArmor = new StatsCategory(8, "clean_armor", StatsRegistry.Custom, 31);
		public static readonly StatsCategory CleanBanner = new StatsCategory(8, "clean_banner", StatsRegistry.Custom, 32);
		public static readonly StatsCategory InteractWithBrewingStand = new StatsCategory(8, "interact_with_brewingstand", StatsRegistry.Custom, 33);
		public static readonly StatsCategory InteractWithBeacon = new StatsCategory(8, "interact_with_beacon", StatsRegistry.Custom, 34);
		public static readonly StatsCategory InspectDropper = new StatsCategory(8, "inspect_dropper", StatsRegistry.Custom, 35);
		public static readonly StatsCategory InspectHopper = new StatsCategory(8, "inspect_hopper", StatsRegistry.Custom, 36);
		public static readonly StatsCategory InspectDispenser = new StatsCategory(8, "inspect_dispenser", StatsRegistry.Custom, 37);
		public static readonly StatsCategory PlayNoteblock = new StatsCategory(8, "play_noteblock", StatsRegistry.Custom, 38);
		public static readonly StatsCategory TuneNoteblock = new StatsCategory(8, "tune_noteblock", StatsRegistry.Custom, 39);
		public static readonly StatsCategory PotFlower = new StatsCategory(8, "pot_flower", StatsRegistry.Custom, 40);
		public static readonly StatsCategory TriggerTrappedChest = new StatsCategory(8, "trigger_trapped_chest", StatsRegistry.Custom, 41);
		public static readonly StatsCategory OpenEnderchest = new StatsCategory(8, "open_enderchest", StatsRegistry.Custom, 42);
		public static readonly StatsCategory EnchantItem = new StatsCategory(8, "enchant_item", StatsRegistry.Custom, 43);
		public static readonly StatsCategory PlayRecord = new StatsCategory(8, "play_record", StatsRegistry.Custom, 44);
		public static readonly StatsCategory InteractWithFurnace = new StatsCategory(8, "interact_with_furnace", StatsRegistry.Custom, 45);
		public static readonly StatsCategory InteractWithCraftingTable = new StatsCategory(8, "interact_with_crafting_table", StatsRegistry.Custom, 46);
		public static readonly StatsCategory OpenChest = new StatsCategory(8, "open_chest", StatsRegistry.Custom, 47);
		public static readonly StatsCategory SleepInBed = new StatsCategory(8, "sleep_in_bed", StatsRegistry.Custom, 48);
		public static readonly StatsCategory OpenShulkerBox = new StatsCategory(8, "open_shulker_box", StatsRegistry.Custom, 49);

		#endregion
	}

	public enum StatsRegistry
	{
		Blocks,
		Items,
		Entities,
		Custom
	}
}
