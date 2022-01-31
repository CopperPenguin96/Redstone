using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Network.Packets;
using Redstone.Network.Packets.Login;
using Redstone.Network.Packets.Status;
using Redstone.Types;
using SmartNbt;

namespace Redstone.Network
{
    public class Protocol
    {
        protected internal static RSACryptoServiceProvider CryptoProvider { get; set; }

        public static List<MinecraftClient> ConnectedClients = new();

        protected internal static RSAParameters Key { get; set; }

        public static bool AuthRequired { get; private set; }
        
        public static string ServerID;

        public static void Init(bool requireAuth, string serverId)
        {
            if (requireAuth)
            {
                CryptoProvider = new RSACryptoServiceProvider(1024);
                Key = CryptoProvider.ExportParameters(true);
                AuthRequired = true;
            }

            ServerID = serverId;
        }

        public static void LoginDisconnect(MinecraftClient client, GameStream stream, string reason)
        {
            new LoginDisconnect(reason).Send(ref client, stream);
            client.Client.Close();
        }

        public static void Receive(ref MinecraftClient client, GameStream stream)
        {
            VarInt id = stream.ReadVarInt();
            switch (client.State)
            {
                case ConnectionState.Handshake:
                    if (id == (byte) Packet.Handshaking) new Handshake().Receive(ref client, stream);
                    break;
                case ConnectionState.Status:
                    if (id == (byte) Packet.Ping) new Ping().Receive(ref client, stream);
                    if (id == (byte) Packet.Request) new Request().Receive(ref client, stream);
                    break;
                case ConnectionState.Login:
                    if (id == (byte) Packet.LoginStart) new LoginStart().Receive(ref client, stream);
                    if (id == (byte) Packet.EncryptionResponse) new EncryptionResponse().Receive(ref client, stream);
                    break;
                case ConnectionState.Play:
                    break;
            }
        }

        public static void Send(ref MinecraftClient client, GameStream stream,
            Packet packet, params object[] contents)
        {
            Send(ref client, stream, packet, contents.ToList());
        }

        public static void Send(ref MinecraftClient client, GameStream stream,
            Packet packet, object content)
        {
            Send(ref client, stream, packet, new List<object> { content });
        }

        public static void Send(ref MinecraftClient client, GameStream stream,
            Packet packet, List<object> content)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (content == null) throw new ArgumentNullException(nameof(content));

            VarInt id = (byte)packet;

            // Gets combined length of id + data
            VarInt length = 0;

            foreach (object o in content)
            {
                length += GetItemLength(o);
            }

            length += id.Length;

            // Write the length and id
            client.Stream.WriteVarInt(length);
            client.Stream.WriteVarInt(id);

            // Write the data
            foreach (object o in content)
            {
                client.Stream.Write(o);
            }

            // Flush it :3
            client.Stream.Flush();
        }

        private static VarInt GetItemLength(object o)
        {
            switch (o)
            {
                case bool _:
                case sbyte _:
                case byte _:
                    return 1;
                case short _:
                case ushort _:
                    return 2;
                case int _:
                case float _:
                    return 4;
                case long _:
                case double _:
                    return 8;
                case string str:
                    byte[] bts = Encoding.UTF8.GetBytes(str);
                    VarInt length = bts.Length;
                    return length + length.Length;
                case VarInt vI:
                    return vI.Length;
                case byte[] b:
                    return b.Length;
                case NbtFile file:
                    return file.BufferSize;
            }

            throw new Exception("Unknown data type");
        }
	}
}
