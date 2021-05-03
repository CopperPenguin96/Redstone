using System;
using System.Collections.Generic;
using System.Text;
using fNbt;
using ProtocolSharp.Network;
using ProtocolSharp.Types;
using ProtocolSharp.Utils;
using ProtocolSharp.Worlds.Blocks;

namespace ProtocolSharp.Packets.Play.Client.BlockEntityData
{
    public class EndGatewayEntityData : BlockEntityData
    {
        public long Age => (long) ParentBlock[AgeName];

        public bool ExactTeleport => (bool) ParentBlock[ExactTeleportName];

        public Position ExitPortalLoc => (Position) ParentBlock["ExitPortalLoc"];

        public EndGatewayEntityData(Block parent) : base(parent)
        {
        }

        public new void Send(ref MinecraftClient client, GameStream stream)
        {
            NbtCompound nbt = new NbtCompound(
                new NbtTag[]
                {
                    new NbtLong(AgeName, Age),
                    new NbtByte(ExactTeleportName, ExactTeleport.ToByte()),
                    new NbtCompound(ExitName,
                        new []
                        {
                            new NbtInt(XName, ExitPortalLoc.X),
                            new NbtInt(YName, ExitPortalLoc.Y),
                            new NbtInt(ZName, ExitPortalLoc.Z)
                        })
                });

            base.Send(ref client, stream, (int) BlockEntityDataAction.SetEndGatewayDestination, nbt);
        }

        #region constants

        public const string AgeName = "Age";
        public const string ExactTeleportName = "ExactTeleportName";
        public const string ExitName = "ExitPortal";
        public const string XName = "X";
        public const string YName = "Y";
        public const string ZName = "Z";

        #endregion
    }
}
