using System.Net;
using Newtonsoft.Json;
using Redstone.Configuration;
using Redstone.Players;
using Redstone.Utils;

namespace Redstone.Network.Packets.Login
{
    internal class LoginStart : IReceivingPacket
    {
        public Packet Packet => Packet.LoginStart;
        public string Name => "Login Start";

        public void Receive(ref MinecraftClient client, GameStream stream)
        {
            string username = stream.ReadString();
            string idRequest = new WebClient().DownloadString(PlayerDatabase.uuidRetrieval + username).Trim();
            UniqueIdRequest request = JsonConvert.DeserializeObject<UniqueIdRequest>(idRequest);

            for (int x = 0; x < PlayerDatabase.Players.Count; x++)
            {
                Player player = PlayerDatabase.Players[x];
                if (player.UniqueId == request.UniqueId)
                {
                    player.Username = username; // Make sure username is updated
                    PlayerDatabase.Players.RemoveAt(x);
                    PlayerDatabase.Players.Add(player);
                    PlayerDatabase.Save();
                }
            }

            Logger.Log($"{username} is trying to connect. ({request.UniqueId})");

            if (!Config.EnableEncryption)
            {
                new LoginSuccess(false).Send(ref client, stream);
            }
            else
            {
                new EncryptionRequest().Send(ref client, stream);
            }
        }
    }

    internal class UniqueIdRequest
    {
        [JsonProperty("name")]
        internal string Username { get; set; }

        [JsonProperty("id")]
        internal string UniqueId { get; set; }
    }
}
