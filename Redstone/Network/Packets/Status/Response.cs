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

            string responseStr = "{" +
                                 "\"version\": {" +
                                 "\"name\": \"" + MinecraftVersion.Current + "\"," +
                                 "\"protocol\": " + MinecraftVersion.Current.Protocol + "}," +
                                 "\"players\": {" +
                                 "\"max\":" + PlayerList.MaxPlayers + "," +
                                 "\"online\":" + PlayerList.Online + "," +
                                 "\"sample\": [{\"name\": \"CopperPenguin96\", \"id\":\"be57c0e9-0832-48a7-9940-2baf96b32f92\"}]}," +
                                 "\"description\": " + Chat.Format(Config.MessageOfTheDay, null) + "," +
                                 "\"favicon\": \"data:image/png;base64," + image + "\" }";


            var writer = File.CreateText("new2.json");
            writer.WriteLine(responseStr);
            writer.Flush();
            writer.Close();
            Protocol.Send(ref client, stream, Packet,
                responseStr);
        }
    }
}