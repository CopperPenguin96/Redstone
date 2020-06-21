﻿namespace Redstone.Network.Packets
{
	public enum Packet: byte
	{
		// Handshake/Status Packets
		Handshake = 0x00,
		LegacyPing = 0xFE,
		Response = 0x00,
		Pong = 0x01,
		Request = 0x00,
		Ping = 0x01,

		// Login Packets
		LoginDisconnect = 0x00,
		EncryptionRequest = 0x01,
		LoginSuccess = 0x02,
		SetCompression = 0x03,
		LoginPluginRequest = 0x04,
		LoginStart = 0x00,
		EncryptionResponse = 0x01,
		LoginPluginResponse = 0x02,

		// Play Packets
		SpawnEntity = 0x00,
		SpawnExperienceOrb = 0x01,
		SpawnWeatherEntity = 0x02,
		SpawnLivingEntity = 0x03,
		SpawnPainting = 0x04,
		SpawnPlayer = 0x05,
		EntityAnimation = 0x06,
		Statistics = 0x07,
		AcknowledgePlayerDigging = 0x08,
		BlockBreakAnimation = 0x09,
		BlockEntityData = 0x0A,
		BlockAction = 0x0B,
		BlockChange = 0x0C,
		BossBar = 0x0D,
		ServerDifficulty = 0x0E,
		ChatMessage = 0x0F,
		MultiBlockChange = 0x10,
		TabComplete = 0x11,
		DeclareCommands = 0x12,
		WindowConfirmation = 0x13,
		CloseWindow = 0x14,
		WindowItems = 0x15,
		WindowProperty = 0x16,
		SetSlot = 0x17,
		SetCooldown = 0x18,
		PluginMessage = 0x19,
		NamedSoundEffect = 0x1A,
		PlayDisconnect = 0x1B,
		EntityStatus = 0x1C,
		Explosion = 0x1D,
		UnloadChunk = 0x1E,
		ChangeGameState = 0x1F,
		OpenHorseWindow = 0x20,
		KeepAlive = 0x21,
		ChunkData = 0x22,
		Effect = 0x23,
		Particle = 0x24,
		UpdateLight = 0x25,
		JoinGame = 0x26,
		MapData = 0x27,
		TradeList = 0x28,
		EntityPosition = 0x29,
		EntityPositionAndRotation = 0x2A,
		EntityRotation = 0x2B,
		EntityMovement = 0x2C,
		VehicleMove = 0x2D,
		OpenBook = 0x2E,
		OpenWindow = 0x2F,
		OpenSignEditor = 0x30,
		CraftRecipeResponse = 0x31,
		PlayerAbilities = 0x32,
		CombatEvent = 0x33,
		PlayerInfo = 0x34,
		FacePlayer = 0x35,
		PlayerPositionAndLook = 0x36,
		UnlockRecipes = 0x37,
		DestroyEntities = 0x38,
		RemoveEntityEffect = 0x39,
		ResourcePackSend = 0x3A,
		Respawn = 0x3B,
		EntityHeadLook = 0x3C,
		SelectAdvancementTab = 0x3D,
		WorldBorder = 0x3E,
		Camera = 0x3F,
		HeldItemChange = 0x40,
		UpdateViewPosition = 0x41,
		UpdateViewDistance = 0x42,
		DisplayScoreboard = 0x43,
		EntityMetadata = 0x44,
		AttachEntity = 0x45,
		EntityVelocity = 0x46,
		EntityEquipment = 0x47,
		SetExperience = 0x48,
		UpdateHealth = 0x49,
		ScoreboardObjective = 0x4A,
		SetPassengers = 0x4B,
		Teams = 0x4C,
		UpdateScore = 0x4D,
		SpawnPosition = 0x4E,
		TimeUpdate = 0x4F,
		Title = 0x50,
		EntitySoundEffect = 0x51,
		SoundEffect = 0x52,
		StopSound = 0x53,
		PlayerListHeaderAndFooter = 0x54,
		NBTQueryResponse = 0x55,
		CollectItem = 0x56,
		EntityTeleport = 0x57,
		Advancements = 0x58,
		EntityProperties = 0x59,
		EntityEffect = 0x5A,
		DeclareRecipes = 0x5B,
		Tags = 0x5C,
		TeleportConfirm = 0x00,
		QueryBlockNBT = 0x01,
		SetDifficulty = 0x02,
		ChatMessageServer = 0x03,
		ClientStatus = 0x04,
		ClientSettings = 0x05,
		TabCompleteServer = 0x06,
		WindowConfirmationServer = 0x07,
		ClickWindowButton = 0x08,
		ClickWindow = 0x09,
		CloseWindowServer = 0x0A,
		PluginMessageServer = 0x0B,
		EditBook = 0x0C,
		EntityNBTRequest = 0x0D,
		InteractEntity = 0x0E,
		KeepAliveServer = 0x0F,
		LookDifficulty = 0x10,
		PlayerPosition = 0x11,
		PlayerPositionAndRotation = 0x12,
		PlayerRotation = 0x13,
		PlayerMovement = 0x14,
		VehicleMovement = 0x15,
		SteerBoat = 0x16,
		PickItem = 0x17,
		CraftRecipeRequest = 0x18,
		PlayerAbilitiesServer = 0x19,
		PlayerDigging = 0x1A,
		EntityAction = 0x1B,
		SteerVehicle = 0x1C,
		RecipeBookData = 0x1D,
		NameItem = 0x1E,
		ResourcePackStatus = 0x1F,
		AdvancementTab = 0x20,
		SelectTrade = 0x21,
		SetBeaconEffect = 0x22,
		HeldItemChangeServer = 0x23,
		UpdateCommandBlock = 0x24,
		UpdateCommandBlockMinecart = 0x25,
		CreativeInventoryAction = 0x26,
		UpdateJigsawBlock = 0x27,
		UpdateStructureBlock = 0x28,
		UpdateSign = 0x29,
		Animation = 0x2A,
		Spectate = 0x2B,
		PlayerBlockPlacement = 0x2C,
		UseItem = 0x2D
	}
}
