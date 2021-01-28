namespace ProtocolSharp.Packets.Play.Client.BlockEntityData
{
	public enum BlockEntityDataAction : byte
	{
		/// <summary>
		/// Set data of a mob spawner (everything except for Spawn Potentials: current
		/// delay, min/max delay, mob to be spawned, spawn count, spawn range, etc.)
		/// </summary>
		SetMobSpawnerData = 1,

		/// <summary>
		/// Set command block text (command and last execution status)
		/// </summary>
		SetCommandBlockText = 2,

		/// <summary>
		/// Set the level, primary, and secondary powers of a beacon
		/// </summary>
		SetBeaconPowers = 3,

		/// <summary>
		/// Set rotation and skin of mob head
		/// </summary>
		SetSkinMobHeadRotation = 4,

		/// <summary>
		/// Declare a conduit
		/// </summary>
		DeclareConduit = 5,

		/// <summary>
		/// Set base color and patterns on a banner
		/// </summary>
		SetBaseColorPatternBanner = 6,

		/// <summary>
		/// Set the data for a structure tile entity
		/// </summary>
		SetDataStructureTileEntity = 7,

		/// <summary>
		/// Set the destination for an end gateway
		/// </summary>
		SetEndGatewayDestination = 8,

		/// <summary>
		/// Set the text on a sign
		/// </summary>
		SetSignText = 9,

		/// <summary>
		/// Unused
		/// </summary>
		Unsed = 10,

		/// <summary>
		/// Declare a bed
		/// </summary>
		DeclareBed = 11,

		/// <summary>
		/// Set data of a jigsaw block
		/// </summary>
		SetDataJigsaw = 12,

		/// <summary>
		/// Set items in a campfire
		/// </summary>
		SetItemsCampfire = 13,

		/// <summary>
		/// Beehive information
		/// </summary>
		BeehiveInfo = 14
	}
}