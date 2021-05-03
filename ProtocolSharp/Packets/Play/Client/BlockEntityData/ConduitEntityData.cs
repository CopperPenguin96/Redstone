using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using fNbt;
using ProtocolSharp.Network;
using ProtocolSharp.Worlds.Blocks;

namespace ProtocolSharp.Packets.Play.Client.BlockEntityData
{
    public class ConduitEntityData : BlockEntityData
    {
        public int[] Target => (int[]) ParentBlock["Target"];

        public new void Send(ref MinecraftClient client, GameStream stream)
        {
            NbtCompound nbt = new NbtCompound(
                new[]
                {
                    new NbtIntArray("Target", Target)
                }
            );

            base.Send(ref client, stream, (int) BlockEntityDataAction.DeclareConduit, nbt);
        }

        public ConduitEntityData(Block parent) : base(parent)
        {
        }
    }
}
