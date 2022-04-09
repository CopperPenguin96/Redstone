namespace Redstone.Network.Packets.Play.Clientbound
{
    internal class SkulkVibrationSignal : ISendingPacket
    {
        public Packet Packet => Packet.SculkVibrationSignal;
        public string Name => "Sculk Vibration Signal";
        
        public void Send(ref MinecraftClient client, GameStream stream)
        {
            // todo?
        }
    }
}
