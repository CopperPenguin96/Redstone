// ReSharper disable UnusedMember.Global
namespace Redstone.Network.Packets
{
	/// <summary>
	/// Enum detailing all the packets entailed by the protocol.
	/// Updated for 1.17.1 (756)
	/// </summary>
	public enum Packet : byte
	{
		#region Handshake Packets

		/// <summary>
		/// Handshake Packet - Bound to Server
		/// </summary>
		Handshake = 0x00,

		/// <summary>
		/// Handshake Packet - Bound to Server
		/// </summary>
		LegacyPing = 0xFE,

		#endregion

		#region Status Packets

		/// <summary>
		/// Status Packet - Bound to Client
		/// </summary>
		Response = 0x00,

		/// <summary>
		/// Status Packet - Bound to Client
		/// </summary>
		Pong = 0x01,

		/// <summary>
		/// Status Packet - Bound to Server
		/// </summary>
		Request = 0x00,

		/// <summary>
		/// Status Packet - Bound to Server
		/// </summary>
		Ping = 0x01,

		#endregion

		#region Login Packets

		/// <summary>
		/// Login Packet - Bound to Client
		/// </summary>
		LoginDisconnect = 0x00,

		/// <summary>
		/// Login Packet - Bound to Client
		/// </summary>
		EncryptionRequest = 0x01,

		/// <summary>
		/// Login Packet - Bound to Client
		/// </summary>
		LoginSuccess = 0x02,

		/// <summary>
		/// Login Packet - Bound to Client
		/// </summary>
		SetCompression = 0x03,

		/// <summary>
		/// Login Packet - Bound to Client
		/// </summary>
		LoginPluginRequest = 0x04,

		/// <summary>
		/// Login Packet - Bound to Server
		/// </summary>
		LoginStart = 0x00,

		/// <summary>
		/// Login Packet - Bound to Server
		/// </summary>
		EncryptionResponse = 0x01,

		/// <summary>
		/// Login Packet - Bound To Server
		/// </summary>
		LoginPluginResponse = 0x02,

		#endregion

		#region Play Packets - Clientbound

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		SpawnEntity = 0x00,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		SpawnExperienceOrb = 0x01,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		SpawnLivingEntity = 0x02,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		SpawnPainting = 0x03,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		SpawnPlayer = 0x04,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		SculkVibrationSignal = 0x05,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		EntityAnimation = 0x06,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		Statistics = 0x07,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		AcknowledgePlayerDigging = 0x08,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		BlockBreakAnimation = 0x09,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		BlockEntityData = 0x0A,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		BlockAction = 0x0B,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		BlockChange = 0x0C,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		BossBar = 0x0D,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		ServerDifficulty = 0x0E,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		ChatMessage = 0x0F,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		ClearTitles = 0x10,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		TabComplete = 0x11,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		DeclareCommands = 0x12,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		CloseWindow = 0x13,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		WindowItems = 0x14,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		WindowProperty = 0x15,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		SetSlot = 0x16,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		SetCooldown = 0x17,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		PluginMessage = 0x18,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		NamedSoundEffect = 0x19,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		PlayDisconnect = 0x1A,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		EntityStatus = 0x1B,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		Explosion = 0x1C,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		UnloadChunk = 0x1D,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		ChangeGameState = 0x1E,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		OpenHorseWindow = 0x1F,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		InitializeWorldBorder = 0x20,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		KeepAlive = 0x21,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		ChunkData = 0x22,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		Effect = 0x23,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		Particle = 0x24,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		UpdateLight = 0x25,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		JoinGame = 0x26,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		MapData = 0x27,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		TradeList = 0x28,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		EntityPosition = 0x29,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		EntityPositionAndRotation = 0x2A,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		EntityRotation = 0x2B,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		VehicleMove = 0x2C,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		OpenBook = 0x2D,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		OpenWindow = 0x2E,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		OpenSignEditor = 0x2F,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		PlayPing = 0x30,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		CraftRecipeResponse = 0x31,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		PlayerAbilities = 0x32,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		EndCombatEvent = 0x33,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		BeginCombatEvent = 0x34,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		DeathCombatEvent = 0x35,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		PlayerInfo = 0x36,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		FacePlayer = 0x37,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		PlayerPositionAndLook = 0x38,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		UnlockRecipes = 0x39,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		DestroyEntities = 0x3A,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		RemoveEntityEffect = 0x3B,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		ResourcePackSend = 0x3C,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		Respawn = 0x3D,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		EntityHeadLook = 0x3E,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		MultilockChange = 0x3F,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		SelectAdvancementTab = 0x40,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		ActionBar = 0x41,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		WorldBorderCenter = 0x42,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		WorldBorderLerpSize = 0x43,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		WorldBorderSize = 0x44,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		WorldBorderWarningDelay = 0x45,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		WorldBorderWarningReach = 0x46,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		Camera = 0x47,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		HeldItemChange = 0x48,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		UpdateViewPosition = 0x49,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		UpdateViewDistance = 0x4A,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		SpawnPosition = 0x4B,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		DisplayScoreboard = 0x4C,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		EntityMetadata = 0x4D,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		AttachEntity = 0x4E,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		EntityVelocity = 0x4F,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		EntityEquipment = 0x50,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		SetExperience = 0x51,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		UpdateHealth = 0x52,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		ScoreboardObjective = 0x53,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		SetPassengers = 0x54,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		Teams = 0x55,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		UpdateScore = 0x56,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		SetTitleSubTitle = 0x57,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		TimeUpdate = 0x58,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		SetTitleText = 0x59,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		SetTitleNames = 0x5A,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		EntitySoundEffect = 0x5B,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		SoundEffect = 0x5C,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		StopSound = 0x5D,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		PlayerListHeaderAndFooter = 0x5E,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		NBTQueryResponse = 0x5F,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		CollectItem = 0x60,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		EntityTeleport = 0x61,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		Advancements = 0x62,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		EntityProperties = 0x63,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		EntityEffect = 0x64,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		DeclareRecipes = 0x65,

		/// <summary>
		/// Play Packet - Bound to Client
		/// </summary>
		Tags = 0x66,

		#endregion

		#region Play Packet - Serverbound
		
		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		TeleportConfirm = 0x00,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		QueryBlockNBT = 0x01,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		SetDifficulty = 0x02,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		ChatMessageServer = 0x03,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		ClientStatus = 0x04,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		ClientSettings = 0x05,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		TabCompleteServer = 0x06,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		ClickWindowButton = 0x07,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		ClickWindow = 0x08,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		CloseWindowServer = 0x09,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		PluginMessageServer = 0x0A,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		EditBook = 0x0B,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		EntityNBTRequest = 0x0C,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		InteractEntity = 0x0D,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		GenerateStructure = 0x0E,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		KeepAliveServer = 0x0F,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		LookDifficulty = 0x10,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		PlayerPosition = 0x11,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		PlayerPositionAndRotation = 0x12,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		PlayerRotation = 0x13,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		PlayerMovement = 0x14,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		VehicleMovement = 0x15,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		SteerBoat = 0x16,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		PickItem = 0x17,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		CraftRecipeRequest = 0x18,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		PlayerAbilitiesServer = 0x19,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		PlayerDigging = 0x1A,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		EntityAction = 0x1B,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		SteerVehicle = 0x1C,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		PlayPong = 0x1D,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		SetRecipeBookState = 0x1E,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		SetDisplayedRecipe = 0x1F,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		NameItem = 0x20,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		ResourcePackStatus = 0x21,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		AdvancementTab = 0x22,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		SelectTrade = 0x23,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		SetBeaconEffect = 0x24,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		HeldItemChangeServer = 0x25,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		UpdateCommandBlock = 0x26,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		UpdateCommandBlockMinecart = 0x27,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		CreativeInventoryAction = 0x28,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		UpdateJigsawBlock = 0x29,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		UpdateStructureBlock = 0x2A,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		UpdateSign = 0x2B,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		Animation = 0x2C,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		Spectate = 0x2D,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		PlayerBlockPlacement = 0x2E,

		/// <summary>
		/// Play Packet - Bound to Server
		/// </summary>
		UseItem = 0x2F

		#endregion
	}
}
