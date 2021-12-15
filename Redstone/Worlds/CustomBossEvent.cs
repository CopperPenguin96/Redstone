using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.ChatSystem;
using Redstone.Players;
using Redstone.Types;
using Redstone.Utils;

namespace Redstone.Worlds
{
    public class CustomBossEvent
    {
        public PlayerList PlayersVisibleTo { get; set; }

        public Identifier Id { get; set; }

        public MinecraftFormatting Color { get; set; }

        public bool CreateWorldFog { get; set; }

        public bool DarkenScreen { get; set; }

        public int MaxHealth { get; set; }

        public int Value { get; set; }

        private string _name;

        public string Name
        {
            get => _name;
            set => _name = Chat.Format(value, null);
        }

        public BossBarOverlay Overlay { get; set; }

        public string OverlayString
        {
            get
            {
                return Overlay switch
                {
                    BossBarOverlay.Progress => "progress",
                    BossBarOverlay.Notched6 => "notched_6",
                    BossBarOverlay.Notched10 => "notched_10",
                    BossBarOverlay.Notched12 => "notched_12",
                    BossBarOverlay.Notched20 => "notched_20",
                    _ => throw new InvalidOperationException()
                };
            }
        }

        public bool PlayBossMusic { get; set; }

        public bool Visible { get; set; }
    }

    public enum BossBarOverlay
    {
        Progress, Notched6, Notched10, Notched12, Notched20
    }
}
