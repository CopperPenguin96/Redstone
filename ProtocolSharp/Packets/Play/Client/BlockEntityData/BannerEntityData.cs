using System;
using System.Collections.Generic;
using System.Text;
using fNbt;
using ProtocolSharp.Network;
using ProtocolSharp.Worlds.Blocks;

namespace ProtocolSharp.Packets.Play.Client.BlockEntityData
{
    public class BannerEntityData : BlockEntityData
    {
        /*
         * String CustomName - Name
         * Patterns (Comp) List of all patterns applied to the banner
         *      int Color Color of the selection
         *      Pattern string the banner pattern code the color applied to
         */

        public string CustomName => (string) ParentBlock[CustomNameName];

        public int[] Color => (int[]) ParentBlock[ColorName];

        public string[] Pattern => (string[]) ParentBlock[PatternName];

        public BannerEntityData(Block parent) : base(parent)
        {

        }

        public new void Send(ref MinecraftClient client, GameStream stream)
        {
            NbtCompound nbt = new NbtCompound();

            if (Pattern.Length != Color.Length) throw new ArgumentException("Index mismatch");

            NbtList list = new NbtList(PatternsName);
            for (int x = 0; x < Color.Length; x++)
            {
                int y = Color[x];
                string z = Pattern[x];
                list.Add(
                    new NbtCompound
                    {
                        new NbtInt(ColorName, y), new NbtString(PatternName, z)
                    });
            }

            nbt.Add(list);
            if (CustomName != null) nbt.Add(new NbtString("CustomName", CustomName));

            base.Send(ref client, stream,
                (int) BlockEntityDataAction.SetBaseColorPatternBanner, nbt);
        }

        #region constants

        public const string CustomNameName = "CustomName";
        public const string PatternsName = "Patterns";
        public const string ColorName = "Color";
        public const string PatternName = "Pattern";

        #endregion
    }
}
