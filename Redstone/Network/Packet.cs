namespace Redstone.Network
{
    public enum Packet
    {
        #region Handshaking

        Handshaking = 0x00,
        LegacyPing = 0xFE,

        #endregion

        #region Status

        Response = 0x00,
        Pong = 0x01,
        Request = 0x00,
        Ping = 0x01,

        #endregion

        #region Login

        DisconnectLogin = 0x00,
        EncryptionRequest = 0x01,
        LoginSuccess = 0x02,
        SetCompression = 0x03,
        LoginPluginRequest = 0x04,
        LoginStart = 0x00,
        EncryptionResponse = 0x01,
        LoginPluginResponse = 0x02,

        #endregion

        #region Play - Clientbound

        SpawnEntity = 0x00,
        SpawnExperienceOrb = 0x01,
        SpawnLivingEntity = 0x02,
        SpawnPainting = 0x03,
        SpawnPlayer = 0x04,
        SculkVibrationSignal = 0x05,
        EntityAnimationClientbound = 0x06,
        Statistics = 0x07,
        AcknowledgePlayerDigging = 0x08,
        BlockBreakAnimation = 0x09,
        BlockEntityData = 0x0A,
        BlockAction = 0x0B,
        BlockChange = 0x0C,
        BossBar = 0x0D,
        ServerDifficulty = 0x0E,
        ChatMessageClientbound = 0x0F,
        ClearTitles = 0x10,
        TabComplete = 0x11,
        DeclareCommands = 0x12,
        CloseWindowClientbound = 0x13,
        WindowItems = 0x14,
        WindowProperty = 0x15,
        SetSlot = 0x16,
        SetCooldown = 0x17,
        PluginMessageClientbound = 0x18,
        NameSoundEffect = 0x19,
        DisconnectPlay = 0x1A,
        EntityStatus = 0x1B,
        Explosion = 0x1C,
        UnloadChunk = 0x1D,
        ChangeGameState = 0x1E,
        OpenHorseWindow = 0x1F,
        InitializeWorldBorder = 0x20,
        KeepAliveClientbound = 0x21,
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
        VehicleMoveClientBound = 0x2C,
        OpenBook = 0x2D,
        OpenWindow = 0x2E,
        OpenSignEditor = 0x2F,
        PingPlay = 0x30,
        CraftRecipeResponse = 0x31,
        PlayerAbilitiesClientbound = 0x32,
        EndCombatEvent = 0x33,
        EnterCobatEvent = 0x34,
        DeathCombatEvent = 0x35,
        PlayerInfo = 0x36,
        FacePlayer = 0x37,
        PlayerPosAndLook = 0x38,
        UnlockRecipes = 0x39,
        DestroyEntities = 0x3A,
        RemoveEntityEffect = 0x3B,
        ResourcePackSend = 0x3C,
        Respawn = 0x3D,
        EntityHeadLook = 0x3E,
        MultiBlockChange = 0x3F,
        SelectAdvancementTab = 0x40,
        ActionBar = 0x41,
        WorldBorderCenter = 0x42,
        WorldBorderLerpSize = 0x43,
        WorldBorderSize = 0x44,
        WorldBorderWarningDelay = 0x45,
        WorldBorderWarningReach = 0x46,
        Camera = 0x47,
        HeldItemChangeClientbound = 0x48,
        UpdateViewPos = 0x49,
        UpdateViewDistance = 0x4A,
        SpawnPos = 0x4B,
        DisplayScoreboard = 0x4C,
        EntityMetadata = 0x4D,
        AttachEntity = 0x4E,
        EntityVelocity = 0x4F,
        EntityEquipment = 0x50,
        SetExperience = 0x51,
        UpdateHealth = 0x52,
        ScoreboardObjective = 0x53,
        SetPassengers = 0x54,
        Teams = 0x55,
        UpdateScore = 0x56,
        SetTitleSubTitle = 0x57,
        TimeUpdate = 0x58,
        SetTitleText = 0x59,
        SetTitleTeams = 0x5A,
        EntitySoundEffect = 0x5B,
        SoundEffect = 0x5C,
        StopSound = 0x5D,
        PlayerListHeaderAndFooter = 0x5E,
        NBTQueryResponse = 0x5F,
        CollectItem = 0x60,
        EntityTeleport = 0x61,
        Advancements = 0x62,
        EntityProperties = 0x63,
        EntityEffect = 0x64,
        DeclareRecipes = 0x65,
        Tags = 0x66,

        #endregion

        #region Play - Serverbound

        TeleportConfirm = 0x00,
        QueryBlockNBT = 0x01,
        SetDifficulty = 0x02,
        ChatMessageServerbound = 0x03,
        ClientStatus = 0x04,
        ClientSettings = 0x05,
        TabCompleteServerbound = 0x06,
        ClickWindowButton = 0x07,
        ClickWindow = 0x08,
        CloseWindowServerbound = 0x09,
        PluginMessageServerbound = 0x0A,
        EditBook = 0x0B,
        QueryEntityNBT = 0x0C,
        InteractEntity = 0x0D,
        GenerateStructure = 0x0E,
        KeepAliveServerbound = 0x0F,
        LookDifficulty = 0x10,
        PlayerPos = 0x11,
        PlayerPosAndRotationServerbound = 0x12,
        PlayerRotation = 0x13,
        PlayerMovement = 0x14,
        VehicleMoveServerbound = 0x15,
        SteerBoat = 0x16,
        PickItem = 0x17,
        CraftRecipeRequest = 0x18,
        PlayerAbilitiesServerbound = 0x19,
        PlayerDigging = 0x1A,
        EntityAction = 0x1B,
        SteerVehicle = 0x1C,
        PongPlay = 0x1D,
        SetRecipeBookState = 0x1E,
        SetDisplayedRecipe = 0x1F,
        NameItem = 0x20,
        ResourcePackStatus = 0x21,
        AdvancementTab = 0x22,
        SelectTrade = 0x23,
        SetBeaconEffect = 0x24,
        HeldItemChangeServerbound = 0x25,
        UpdateCommandBlock = 0x26,
        UpdateCommandBlockMinecart = 0x27,
        CreateInventoryAction = 0x28,
        UpdateJigsawBlock = 0x29,
        UpdateStructureBlock = 0x2A,
        UpdateSign = 0x2B,
        AnimationServerbound = 0x2C,
        Spectate = 0x2D,
        PlayerBlockPlacement = 0x2E,
        UseItem = 0x2F

        #endregion
    }

    internal interface IReceivingPacket
    {
        Packet Packet { get; }

        string Name { get; }

        void Receive(ref MinecraftClient client, GameStream stream);
    }

    internal interface ISendingPacket
    {
        Packet Packet { get; }

        string Name { get; }

        void Send(ref MinecraftClient client, GameStream stream);
    }
}