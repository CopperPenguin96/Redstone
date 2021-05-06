using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolSharp.Chat;
using ProtocolSharp.Network;
using ProtocolSharp.Types;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Packets.Play.Client
{
    public class BossBar : ISendingPacket
    {
        public string UniqueID { get; set; }

        public Packet Packet => Packet.BossBar;

        public string Name => "Boss Bar";

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a boss bar with the specified details.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        /// <param name="title">The title that goes with the boss bar.</param>
        /// <param name="health">From 0 to 1.</param>
        /// <param name="color">The Boss Bar color</param>
        /// <param name="div">The divisions are "notches" of the boss bar.</param>
        /// <param name="flags"></param>
        public void SendAdd(ref MinecraftClient client, GameStream stream,
            Chat.ChatMessage title, float health, BossBarColor color, BossBarDivision div,
            params BossBarFlags[] flags)
        {
            if (title == null) throw new ArgumentNullException(nameof(title));
            if (health < 0 || health > 1) throw new ArgumentOutOfRangeException(nameof(health));
            if (flags == null) throw new ArgumentNullException(nameof(flags));

            byte flagsX = 0;

            if (flags.Contains(BossBarFlags.DarkenSky)) 
                FlagsHelper.Set(ref flagsX, (byte) BossBarFlags.DarkenSky);
            if (flags.Contains(BossBarFlags.DragonBar))
                FlagsHelper.Set(ref flagsX, (byte) BossBarFlags.DragonBar);
            if (flags.Contains(BossBarFlags.CreateFog))
                FlagsHelper.Set(ref flagsX, (byte) BossBarFlags.CreateFog);

            Protocol.Send(ref client, stream, Packet,
                UniqueID, (VarInt) (int) BossBarAction.Add,
                title.ToString(), health, (VarInt) (int) color,
                (VarInt) (int) div, flagsX);
        }

        /// <summary>
        /// Removes the boss bar
        /// </summary>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        public void SendRemove(ref MinecraftClient client, GameStream stream)
        {
            Protocol.Send(ref client, stream, Packet, UniqueID, (VarInt) (int) BossBarAction.Remove);
        }

        /// <summary>
        /// Updates the health of the boss bar
        /// </summary>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        /// <param name="health">From 0 to 1</param>
        public void SendUpdateHealth(ref MinecraftClient client, GameStream stream, float health)
        {
            if (health < 0 || health > 1) throw new ArgumentOutOfRangeException(nameof(health));

            Protocol.Send(ref client, stream, Packet,
                UniqueID, (VarInt) (int) BossBarAction.UpdateHealth, health);
        }

        /// <summary>
        /// Updates the title
        /// </summary>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        /// <param name="title"></param>
        public void SendUpdateTitle(ref MinecraftClient client, GameStream stream, Chat.ChatMessage title)
        {
            if (title == null) throw new ArgumentNullException(nameof(title));

            Protocol.Send(ref client, stream, Packet, 
                UniqueID, (VarInt) (int) BossBarAction.UpdateTitle, title.ToString());
        }

        /// <summary>
        /// Updates the color and notches
        /// </summary>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        /// <param name="color"></param>
        /// <param name="divs"></param>
        public void SendUpdateStyle(ref MinecraftClient client, GameStream stream,
            BossBarColor color, BossBarDivision divs)
        {
            Protocol.Send(ref client, stream, Packet,
                UniqueID, (VarInt) (int) BossBarAction.UpdateStyle,
                (VarInt) (int) color,
                (VarInt) (int) divs);
        }

        /// <summary>
        /// Updates the flags
        /// </summary>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        /// <param name="flags"></param>
        public void SendUpdateFlags(ref MinecraftClient client, GameStream stream,
           params BossBarFlags[] flags)
        {
            if (flags == null) throw new ArgumentNullException(nameof(flags));

            byte flagsX = 0;

            if (flags.Contains(BossBarFlags.DarkenSky))
                FlagsHelper.Set(ref flagsX, (byte)BossBarFlags.DarkenSky);
            if (flags.Contains(BossBarFlags.DragonBar))
                FlagsHelper.Set(ref flagsX, (byte)BossBarFlags.DragonBar);
            if (flags.Contains(BossBarFlags.CreateFog))
                FlagsHelper.Set(ref flagsX, (byte)BossBarFlags.CreateFog);

            Protocol.Send(ref client, stream, Packet,
                UniqueID, (VarInt) (int) BossBarAction.UpdateFlags);
        }
    }

    /// <summary>
    /// The different actions utilized by the boss bar packet
    /// </summary>
    public enum BossBarAction
    {
        Add = 0,
        Remove = 1,
        UpdateHealth = 2,
        UpdateTitle = 3,
        UpdateStyle = 4,
        UpdateFlags = 5
    }

    /// <summary>
    /// The colors that a boss bar can be
    /// </summary>
    public enum BossBarColor
    {
        Pink = 0,
        Blue = 1,
        Red = 2,
        Green = 3,
        Yellow = 4,
        Purple = 5,
        White = 6
    }

    /// <summary>
    /// How many notches (dividers) can be in a boss bar
    /// </summary>
    public enum BossBarDivision
    {
        None = 0,
        Six = 1,
        Ten = 2,
        Twelve = 3,
        Twenty = 4
    }

    public enum BossBarFlags : byte
    {
        DarkenSky = 0x1,

        /// <summary>
        /// When set, plays end music
        /// </summary>
        DragonBar = 0x2,

        CreateFog = 0x04
    }
}
