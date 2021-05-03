using System;
using System.Collections.Generic;
using System.Text;
using fNbt;
using ProtocolSharp.Chat;
using ProtocolSharp.Network;
using ProtocolSharp.Worlds.Blocks;

namespace ProtocolSharp.Packets.Play.Client.BlockEntityData
{
    public class SignEntityData : BlockEntityData
    {
        public DyeColor Color => (DyeColor) ParentBlock[ColorName];

        public string Text1 => (string) ParentBlock[T1Name];

        public string Text2 => (string) ParentBlock[T2Name];

        public string Text3 => (string) ParentBlock[T3Name];

        public string Text4 => (string) ParentBlock[T4Name];


        public SignEntityData(Block parent) : base(parent)
        {
        }

        public new void Send(ref MinecraftClient client, GameStream stream)
        {
            NbtCompound nbt = new NbtCompound(
                new NbtTag[]
                {
                    new NbtString(ColorName, Color),
                    new NbtString(T1Name, Text1),
                    new NbtString(T2Name, Text2),
                    new NbtString(T3Name, Text3),
                    new NbtString(T4Name, Text4)
                }
            );

            base.Send(ref client, stream, (int) BlockEntityDataAction.SetSignText, nbt);
        }

        #region constants

        public const string ColorName = "Color";
        public const string T1Name = "Text1";
        public const string T2Name = "Text2";
        public const string T3Name = "Text3";
        public const string T4Name = "Text4";

        #endregion
    }
}
