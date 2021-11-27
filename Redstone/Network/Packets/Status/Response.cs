using Redstone.ChatSystem;
using Redstone.Configuration;
using Redstone.Players;
using Redstone.Utils;

namespace Redstone.Network.Packets.Status
{
    internal class Response : ISendingPacket
    {
        public Packet Packet => Packet.Response;
        public string Name => "Response";

        public void Send(ref MinecraftClient client, GameStream stream)
        {
            byte[] array = File.ReadAllBytes(Config.IconFile);
            string image = Convert.ToBase64String(array);
            JsonObject response = new()
            {
                {
                    "version", new JsonObject
                    {
                        {"name", MinecraftVersion.Current.ToString()},
                        {"protocol", MinecraftVersion.Current.Protocol}
                    }
                },
                {
                    "players", new JsonObject
                    {
                        {"max", PlayerList.MaxPlayers},
                        {"online", PlayerList.Online},
                        {
                            "Sample", new JsonObject
                            {
                                {"name", "CopperPenguin96"},
                                {"id", "be57c0e9-0832-48a7-9940-2baf96b32f92"}
                            }
                        }
                    }
                },
                {
                    "description", Chat.Format(Config.MessageOfTheDay, null)
                },
                {
                    "favicon", "data:image/png;base64," + image
                }
            };

            Protocol.Send(ref client, stream, Packet, response.ToString());
        }
    }
}
