using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Network;
using ProtocolSharp.Types;
using ProtocolSharp.Worlds.Blocks;

namespace ProtocolSharp.Packets.Play.Client
{
    /// <summary>
    /// This packet is used for a number of actions and animations performed by
    /// blocks, usually non-persistent.
    /// </summary>
    public class BlockAction : ISendingPacket
    {
        public Packet Packet => Packet.BlockAction;

        public string Name => "Block Action";
        public void Send(ref MinecraftClient client, GameStream stream)
        {
            throw new NotImplementedException();
        }

        public void Send(ref MinecraftClient client, GameStream stream,
            Position location, byte actionId, byte actionParam, VarInt type)
        {
            if (location == null) throw new ArgumentNullException(nameof(location));
            if (type == null) throw new ArgumentNullException(nameof(type));

            Protocol.Send(ref client, stream, Packet, location, actionId, actionParam, type);
        }

        public void SendNoteBlockAction(ref MinecraftClient client, GameStream stream,
            Position location)
        {
            Send(ref client, stream, location,
                0, 0, BlockRegistry.NoteBlock.NumericID);
        }

        public void SendExtendPiston(ref MinecraftClient client, GameStream stream,
            Position location, bool isSticky, Direction direction)
        {
            if (direction == null) throw new ArgumentNullException(nameof(direction));
            Block kindOfPiston = isSticky ? BlockRegistry.StickyPiston : BlockRegistry.Piston;
            Send(ref client, stream, location,
                0, (byte) direction.Value.Value, kindOfPiston.NumericID);
        }

        public void SendRetractPiston(ref MinecraftClient client, GameStream stream,
            Position location, bool isSticky, Direction direction)
        {
            if (direction == null) throw new ArgumentNullException(nameof(direction));
            Block kindOfPiston = isSticky ? BlockRegistry.StickyPiston : BlockRegistry.Piston;
            Send(ref client, stream, location,
                1, (byte)direction.Value.Value, kindOfPiston.NumericID);
        }

        public void SendUpdateChest(ref MinecraftClient client, GameStream stream,
            Position location, Chest chest)
        {
            if (chest == null) throw new ArgumentNullException(nameof(chest));

            Send(ref client, stream, location,
                1, (byte) chest.LookingAt.Count, chest.NumericID);
        }

        public void SendUpdateEnderChest(ref MinecraftClient client, GameStream stream,
            Position location, EnderChest chest)
        {
            if (chest == null) throw new ArgumentNullException(nameof(chest));

            Send(ref client, stream, location,
                1, (byte) chest.LookingAt.Count, chest.NumericID);
        }

        public void SendRecalcBeaconBeam(ref MinecraftClient client, GameStream stream,
            Position loc)
        {
            Send(ref client, stream, loc, 1, 0, BlockRegistry.Beacon.NumericID);
        }

        public void SendResetSpawnerDelay(ref MinecraftClient client, GameStream stream,
            Position loc)
        {
            Send(ref client, stream, loc, 1, 0, BlockRegistry.Spawner.NumericID);
        }

        public void SendEntityPassEndGateway(ref MinecraftClient client, GameStream stream,
            Position loc)
        {
            Send(ref client, stream, loc, 1, 0, BlockRegistry.EndGateway.NumericID);
        }

        public void SendUpdateShulkerBox(ref MinecraftClient client, GameStream stream,
            Position loc, ShulkerBox box)
        {
            Send(ref client, stream, loc, 1, (byte) box.LookingAt.Count, box.NumericID);
        }

        public void SendRingBell(ref MinecraftClient client, GameStream stream,
            Position loc, Direction direction)
        {
            Send(ref client, stream, loc, 1, (byte) direction.Value.Value, BlockRegistry.Bell.NumericID);
        }
    }
}
