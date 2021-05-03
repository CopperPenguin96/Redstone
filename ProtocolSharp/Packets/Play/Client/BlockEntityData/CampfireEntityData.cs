using System;
using System.Collections.Generic;
using System.Text;
using fNbt;
using ProtocolSharp.Network;
using ProtocolSharp.Worlds.Blocks;

namespace ProtocolSharp.Packets.Play.Client.BlockEntityData
{
    public class CampfireEntityData : BlockEntityData
    {
        public int[] CookingTimes => (int[]) ParentBlock[TimesName];

        public int[] CookingTotalTimes => (int[]) ParentBlock[TotalTimesName];

        public CampfireSlot[] Slots => (CampfireSlot[]) ParentBlock[ItemsName];

        public CampfireEntityData(Block parent) : base(parent)
        {
        }

        public new void Send(ref MinecraftClient client, GameStream stream)
        {
            NbtList list = new NbtList(ItemsName);
            foreach (var s in Slots)
            {
                list.Add(new NbtByte(CountName, s.Count));
                list.Add(new NbtByte(SlotName, s.Slot));
                list.Add(new NbtString(IdName, s.Id));
                if (s.Tag != null) list.Add(s.Tag);
            }

            NbtCompound nbt = new NbtCompound(
                new NbtTag[]
                {
                    new NbtIntArray(TimesName, CookingTimes),
                    new NbtIntArray(TotalTimesName, CookingTotalTimes),
                    list
                }
            );

            base.Send(ref client, stream, 
                (int) BlockEntityDataAction.SetItemsCampfire, nbt);
        }

        #region constants

        public const string TimesName = "CookingTimes";
        public const string TotalTimesName = "CookingTotalTimes";
        public const string ItemsName = "Items";
        public const string CountName = "Count";
        public const string SlotName = "Slot";
        public const string IdName = "id";
        public const string TagName = "tag";

        #endregion
    }

    public sealed class CampfireSlot
    {
        public byte Count { get; set; }

        public byte Slot { get; set; }

        public string Id { get; set; }

        public NbtTag Tag { get; set; }
    }
}
