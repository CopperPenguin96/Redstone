namespace Redstone.Core.Types
{
    public sealed class KeybindDefinition
    {
        public static readonly KeybindDefinition Jump = new("key.jump");
        public static readonly KeybindDefinition Sneak = new("key.sneak");
        public static readonly KeybindDefinition Spring = new("key.sprint");
        public static readonly KeybindDefinition StrafeLeft = new("key.left");
        public static readonly KeybindDefinition StrafeRight = new("key.right");
        public static readonly KeybindDefinition WalkBackward = new("key.back");
        public static readonly KeybindDefinition WalkForward = new("key.forward");
        public static readonly KeybindDefinition Advancedments = new("key.advancements");
        public static readonly KeybindDefinition QuickActions = new("key.quickActions");
        public static readonly KeybindDefinition TakeScreenshot = new("key.screenshot");
        public static readonly KeybindDefinition ToggleCinematicCamera = new("key.smoothCamera");
        public static readonly KeybindDefinition ToggleFullscreen = new("key.fullscreen");
        public static readonly KeybindDefinition ToggleGUI = new("key.toggleGui");
        public static readonly KeybindDefinition TogglePerspective = new("key.togglePerspective");
        public static readonly KeybindDefinition ToggleSpectatorShaderEffects = new("key.toggleSpectatorShaderEffects");
        public static readonly KeybindDefinition ListPlayers = new("key.playerList");
        public static readonly KeybindDefinition OpenChat = new("key.chat");
        public static readonly KeybindDefinition OpenCommand = new("key.command");
        public static readonly KeybindDefinition SocialInteractionsScreen = new("key.socialInteractions");
        public static readonly KeybindDefinition AttackDestroy = new("key.attack");
        public static readonly KeybindDefinition PickBlock = new("key.pickItem");
        public static readonly KeybindDefinition UseItemPlaceBlock = new("key.use");
        public static readonly KeybindDefinition DropSelectedItem = new("key.drop");
        public static readonly KeybindDefinition[] HotbarSlot =
        [
            new("key.hotbar.1"), new("key.hotbar.2"), new("key.hotbar.3"), new("key.hotbar.4"), new("key.hotbar.5"),
            new("key.hotbar.6"), new("key.hotbar.7"), new("key.hotbar.8"), new("key.hotbar.9")
        ];
        public static readonly KeybindDefinition OpenCloseInventory = new("key.inventory");
        public static readonly KeybindDefinition SwapItemsInHands = new("key.swapOffhand");
        public static readonly KeybindDefinition LoadToolbarActivator = new("key.loadToolbarActivator");
        public static readonly KeybindDefinition SaveToolbarActivator = new("key.saveToolbarActivator");
        public static readonly KeybindDefinition HighlightPlayers = new("key.spectatorOutlines");
        public static readonly KeybindDefinition SelectOnHotbar = new("key.spectatorHotbar");
        public static readonly KeybindDefinition ToggleOverlay = new("key.debug.overlay");
        public static readonly KeybindDefinition DebugModifierKey = new("key.debug.modifier");
        public static readonly KeybindDefinition ClearChat = new("key.debug.clearChat");
        public static readonly KeybindDefinition CopyData = new("key.debug.copyRecreateCommand");
        public static readonly KeybindDefinition CopyLocation = new("key.debug.copyLocation");
        public static readonly KeybindDefinition CycleSpectator = new("key.debug.spectate");
        public static readonly KeybindDefinition DebugCrash = new("key.debug.crash");
        public static readonly KeybindDefinition DebugOptions = new("key.debug.debugOptions");
        public static readonly KeybindDefinition DumpDynamicTextures = new("key.debug.dumpDynamicTextures");
        public static readonly KeybindDefinition DumpVersionInfo = new("key.debug.dumpVersion");
        public static readonly KeybindDefinition GameModeSwitcher = new("key.debug.switchGameMode");
        public static readonly KeybindDefinition ReloadChunks = new("key.debug.reloadChunk");
        public static readonly KeybindDefinition ReloadResourcePacks = new("key.debug.reloadResourcePacks");
        public static readonly KeybindDefinition ShowAdvancedTooltips = new("key.debug.dumpVersion");
        public static readonly KeybindDefinition ShowChunkBoundaries = new("key.debug.showChunkBorders");
        public static readonly KeybindDefinition ShowHitboxes = new("key.debug.showHitboxes");
        public static readonly KeybindDefinition StartStopProfiling = new("key.debug.profiling");
        public static readonly KeybindDefinition ToggleLostFocusPause = new("key.debug.focusPause");
        public static readonly KeybindDefinition ProfilingChart = new("key.debug.profilingChart");
        public static readonly KeybindDefinition FPSCharts = new("key.debug.fpsCharts");
        public static readonly KeybindDefinition NetworkCHarts = new("key.debug.networkCharts");
        public string Value { get; }

        private KeybindDefinition(string value)
        {
            Value = value;
        }

        public override string ToString() => Value;

        public static bool operator ==(KeybindDefinition? a, KeybindDefinition? b) => ReferenceEquals(a, b);
        public static bool operator !=(KeybindDefinition? a, KeybindDefinition? b) => !ReferenceEquals(a, b);

        public override bool Equals(object? obj) => ReferenceEquals(this, obj);
        public override int GetHashCode() => Value.GetHashCode();

        public static KeybindDefinition Parse(string value) => value.ToLower() switch
        {
            "key.jump" => Jump,
            "key.sneak" => Sneak,
            "key.sprint" => Spring,
            "key.left" => StrafeLeft,
            "key.right" => StrafeRight,
            "key.back" => WalkBackward,
            "key.forward" => WalkForward,
            "key.advancements" => Advancedments,
            "key.quickActions" => QuickActions,
            "key.screenshot" => TakeScreenshot,
            "key.smoothCamera" => ToggleCinematicCamera,
            "key.fullscreen" => ToggleFullscreen,
            "key.toggleGui" => ToggleGUI,
            "key.togglePerspective" => TogglePerspective,
            "key.toggleSpectatorShaderEffects" => ToggleSpectatorShaderEffects,
            "key.playerList" => ListPlayers,
            "key.chat" => OpenChat,
            "key.command" => OpenCommand,
            "key.socialInteractions" => SocialInteractionsScreen,
            "key.attack" => AttackDestroy,
            "key.pickItem" => PickBlock,
            "key.use" => UseItemPlaceBlock,
            "key.drop" => DropSelectedItem,
            "key.hotbar.1" => HotbarSlot[0],
            "key.hotbar.2" => HotbarSlot[1],
            "key.hotbar.3" => HotbarSlot[2],
            "key.hotbar.4" => HotbarSlot[3],
            "key.hotbar.5" => HotbarSlot[4],
            "key.hotbar.6" => HotbarSlot[5],
            "key.hotbar.7" => HotbarSlot[6],
            "key.hotbar.8" => HotbarSlot[7],
            "key.hotbar.9" => HotbarSlot[8],
            "key.inventory" => OpenCloseInventory,
            "key.swapOffhand" => SwapItemsInHands,
            "key.loadToolbarActivator" => LoadToolbarActivator,
            "key.saveToolbarActivator" => SaveToolbarActivator,
            "key.spectatorOutlines" => HighlightPlayers,
            "key.spectatorHotbar" => SelectOnHotbar,
            "key.debug.overlay" => ToggleOverlay,
            "key.debug.modifier" => DebugModifierKey,
            "key.debug.clearChat" => ClearChat,
            "key.debug.copyRecreateCommand" => CopyData,
            "key.debug.copyLocation" => CopyLocation,
            "key.debug.spectate" => CycleSpectator,
            "key.debug.crash" => DebugCrash,
            "key.debug.debugOptions" => DebugOptions,
            "key.debug.dumpDynamicTextures" => DumpDynamicTextures,
            "key.debug.dumpVersion" => DumpVersionInfo,
            "key.debug.switchGameMode" => GameModeSwitcher,
            "key.debug.reloadChunk" => ReloadChunks,
            "key.debug.reloadResourcePacks" => ReloadResourcePacks,
            "key.debug.showChunkBorders" => ShowChunkBoundaries,
            "key.debug.showHitboxes" => ShowHitboxes,
            "key.debug.profiling" => StartStopProfiling,
            "key.debug.focusPause" => ToggleLostFocusPause,
            "key.debug.profilingChart" => ProfilingChart,
            "key.debug.fpsCharts" => FPSCharts,
            "key.debug.networkCharts" => NetworkCHarts,
            _ => throw new RedstoneException($"Unknown keybind: {value}")
        };
    }
}
