using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Redstone.Security;
using Redstone.Types;

namespace Redstone.Network.Packets
{
    internal class EncryptionResponse : IReceivingPacket
    {
        public Packet Packet => Packet.EncryptionResponse;
        public string Name => "Encryption Response";

        private const string SessionChecker = "https://sessionserver.mojang.com/session/minecraft/hasJoined?username={0}&serverId={1}";


        public void Receive(ref MinecraftClient client, GameStream stream)
        {
            VarInt secretLength = stream.ReadVarInt();
            byte[] sharedSecret = stream.ReadByteArray((int) secretLength.Value);
            VarInt tokenLength = stream.ReadVarInt();
            byte[] verifyToken = stream.ReadByteArray((int) tokenLength.Value);

            var decryptedToken = Protocol.CryptoProvider.Decrypt(verifyToken, false);
            for (int i = 0; i < decryptedToken.Length; i++)
            {
                if (decryptedToken[i] != client.VerifyToken[i])
                {
                    client.Disconnect("Unable to authenticate");
                    return;
                }
            }

            client.SharedToken = Protocol.CryptoProvider.Decrypt(sharedSecret, false);
            AsnKeyBuilder.AsnMessage encodedKey = AsnKeyBuilder.PublicKeyToX509(Protocol.Key);
            byte[] shaData = Encoding.UTF8.GetBytes(Protocol.ServerID)
                .Concat(client.SharedToken)
                .Concat(encodedKey.GetBytes()).ToArray();
            string hash = Cryptography.JavaHexDigest(shaData);

            WebClient webClient = new();
            StreamReader webReader = new(webClient.OpenRead(
                new Uri(string.Format(SessionChecker, client.Player.Username, hash))
            ));

            string response = webReader.ReadToEnd();
            webReader.Close();
            JToken json = JToken.Parse(response);
            if (string.IsNullOrEmpty(response))
            {
                client.Disconnect("Failed to verify username");
                return;
            }

            client.Stream = new(new AesStream(client.Stream.BaseStream, client.SharedToken));
            string uuid = json["id"].Value<string>();
            if (uuid != client.Player.UniqueId)
            {
                client.Disconnect("Failed to verify UniqueID");
                return;
            }

            client.EncryptionPassed = true;
            new LoginSuccess(true).Send(ref client, client.Stream);
        }
    }
}
