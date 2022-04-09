using MinecraftTypes;
using SmartBlocks.Blocks;
using SmartNbt.Tags;

namespace Redstone.Network.Packets.Play.Clientbound
{
    internal class BlockEntityData : ISendingPacket
    {
        public Packet Packet => Packet.BlockEntityData;
        public string Name => "Block Entity Data";

        private Position _pos;
        private BlockEntityAction _action;
        private Block _block;
        private NbtCompound _nbt;

        public BlockEntityData(Position pos, BlockEntityAction action,
            Block? block
            )
        {
            _pos = pos;
            _action = action;
            _block = block;
        }


        public void Send(ref MinecraftClient client, GameStream stream)
        {
            if (!(_block == null || _nbt == null))
            {
                Protocol.Send(ref client, stream, Packet,
                    _nbt);
            }
        }
    }

    internal enum BlockEntityAction : byte
    {
        SetMobSpawnerData = 1,
        SetCommandBlockText = 2,
        SetBeaconPowers = 3,
        SetMobHeadRotation = 4,
        DecareConduit = 5,
        SetColorAndPatternBanner = 6,
        SetTileEntityStructure = 7,
        SetEndGatewayDestination = 8,
        SetSignText = 9,
        Unused = 10,
        DeclareBed = 11,
        SetJigsawData = 12,
        SetCampfireItems = 13,
        BeehiveInfo = 14
    }
}
