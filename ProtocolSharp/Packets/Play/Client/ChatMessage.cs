using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Network;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Packets.Play.Client
{
    /// <summary>
    /// Clientbound variation of this packet.
    /// Processes chat messages to be sent to the client
    /// </summary>
    public class ChatMessage : ISendingPacket
    {
        public Packet Packet => Packet.ChatMessage;

        public string Name => "Chat Message (Clientbound)";

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            throw new NotImplementedException();
        }

        public void Send(ref MinecraftClient client, GameStream stream,
            Chat.ChatMessage message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            string msg = message.ToString();
            if (msg.ToBytes().Length > 262144) throw new ArgumentOutOfRangeException("message is too long");

            Protocol.Send(ref client, stream, Packet,
                msg, (byte) message.Position, message.SenderID);
        }
    }
}
