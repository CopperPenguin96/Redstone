using System;
using System.Collections.Generic;
using System.Text;
using fNbt;
using ProtocolSharp.Entities.Entities;
using ProtocolSharp.Network;
using ProtocolSharp.Types;
using ProtocolSharp.Worlds.Blocks;

namespace ProtocolSharp.Packets.Play.Client.BlockEntityData
{
    public class BeehiveEntityData : BlockEntityData
    {
        public HiveBee[] Bees => (HiveBee[]) ParentBlock[BeesName];

        public Position FlowerPos => (Position) ParentBlock[FlowerName];

        public BeehiveEntityData(Block parent) : base(parent)
        {
        }

        public new void Send(ref MinecraftClient client, GameStream stream)
        {
            NbtList list = new NbtList(BeesName);
            foreach (HiveBee bee in Bees)
            {
                list.Add(new NbtCompound
                {
                    new NbtCompound(DataName, bee.Nbt),
                    new NbtInt(MinOccTicksName, bee.MinOccupationTicks),
                    new NbtInt(TicksName, bee.TicksInHive)
                });
            }

            NbtCompound nbt = new NbtCompound(
                new NbtTag[]
                {
                    list,
                    new NbtCompound(FlowerName)
                    {
                        new NbtInt("X", FlowerPos.X),
                        new NbtInt("Y", FlowerPos.Y),
                        new NbtInt("Z", FlowerPos.Z)
                    }
                }
            );

            base.Send(ref client, stream, (int) BlockEntityDataAction.BeehiveInfo, nbt);
        }

        #region constants

        public const string BeesName = "Bees";
        public const string DataName = "EntityData";
        public const string MinOccTicksName = "MinOccupationTicks";
        public const string TicksName = "TicksInHive";
        public const string FlowerName = "FlowerPos";

        #endregion
    }

    public class HiveBee : Bee
    {
        public int MinOccupationTicks { get; set; }

        public int TicksInHive { get; set; }
    }
}
