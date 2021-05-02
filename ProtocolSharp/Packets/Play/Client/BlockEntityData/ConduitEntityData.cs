using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using fNbt;
using ProtocolSharp.Network;

namespace ProtocolSharp.Packets.Play.Client.BlockEntityData
{
    public class ConduitEntityData : BlockEntityData
    { // int[] target the uuid of the hostile mob the conduit is currently
        // attacking, stored as 4 ints. May not be present

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
    }
}
