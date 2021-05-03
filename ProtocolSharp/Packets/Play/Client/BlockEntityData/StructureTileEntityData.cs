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
    public class StructureTileEntityData : BlockEntityData
    {
        public string Author => (string) ParentBlock[AuthorName];

        public bool IgnoreEntities => (bool) ParentBlock[IgnoreEntitiesName];

        public float Integrity => (float) ParentBlock[IntegrityName];

        public string Metadata => (string) ParentBlock[MetadataName];

        public StructureMirror Mirror => (StructureMirror) ParentBlock[MirrorName];

        public StructureMode Mode => (StructureMode) ParentBlock[ModeName];

        public string StructureName => (string) ParentBlock[NameName];

        public int PosX => (int) ParentBlock[XPosName];

        public int PosY => (int) ParentBlock[YPosName];

        public int PosZ => (int) ParentBlock[ZPosName];

        public bool Powered => (bool) ParentBlock[PoweredName];

        public StructureRotation Rotation => (StructureRotation) ParentBlock[RotationName];

        public long Seed => (long) ParentBlock[SeedName];

        public bool ShowBoundingBox => (bool) ParentBlock[ShowBoundingName];

        public int SizeX => (int) ParentBlock[XSizeName];

        public int SizeY => (int) ParentBlock[YSizeName];

        public int SizeZ => (int) ParentBlock[ZSizeName];

        public StructureTileEntityData(Block parent) : base(parent)
        {
        }

        public new void Send(ref MinecraftClient client, GameStream stream)
        {
            string rotation = "";
            switch (Rotation)
            {
                case StructureRotation.None:
                    rotation = "NONE";
                    break;
                case StructureRotation.Clockwise90:
                    rotation = "CLOCKWISE_90";
                    break;
                case StructureRotation.Clockwise180:
                    rotation = "CLOCKWISE_180";
                    break;
                case StructureRotation.Counterclockwise90:
                    rotation = "CLOCKWISE_90";
                    break;
                default:
                    throw new ArgumentException(nameof(Rotation));
            }

            string mode = "";
            switch (Mode)
            {
                case StructureMode.Save:
                    mode = "SAVE";
                    break;
                case StructureMode.Load:
                    mode = "LOAD";
                    break;
                case StructureMode.Corner:
                    mode = "CORNER";
                    break;
                case StructureMode.Data:
                    mode = "DATA";
                    break;
                default:
                    throw new ArgumentException(nameof(Mode));
            }

            string mirror = "";
            switch (Mirror)
            {
                case StructureMirror.None:
                    mirror = "None";
                    break;
                case StructureMirror.LeftRight:
                    mirror = "LEFT_RIGHT";
                    break;
                case StructureMirror.FrontBack:
                    mirror = "FRONT_BACK";
                    break;
                default:
                    throw new ArgumentException(nameof(Mirror));
            }

            NbtCompound nbt = new NbtCompound(
                new NbtTag[]
                {
                    new NbtString(AuthorName, Author),
                    new NbtByte(IgnoreEntitiesName, IgnoreEntities.ToByte()),
                    new NbtFloat(IntegrityName, Integrity),
                    new NbtString(MetadataName, Metadata),
                    new NbtString(MirrorName, mirror),
                    new NbtString(ModeName, mode),
                    new NbtString(NameName, Name),
                    new NbtInt(XPosName, PosX),
                    new NbtInt(YPosName, PosY),
                    new NbtInt(ZPosName, PosZ),
                    new NbtByte(PoweredName, Powered.ToByte()),
                    new NbtString(RotationName, rotation),
                    new NbtLong(SeedName, Seed),
                    new NbtByte(ShowBoundingName, ShowBoundingBox.ToByte()),
                    new NbtInt(XSizeName, SizeX),
                    new NbtInt(YSizeName, SizeY),
                    new NbtInt(ZSizeName, SizeZ)
                });
            base.Send(ref client, stream, (int) BlockEntityDataAction.SetDataStructureTileEntity, nbt);
        }

        #region constants

        public const string AuthorName = "author";
        public const string IgnoreEntitiesName = "ignoreEntities";
        public const string IntegrityName = "integrity";
        public const string MetadataName = "metadata";
        public const string MirrorName = "mirror";
        public const string ModeName = "mode";
        public const string NameName = "name";
        public const string XPosName = "posX";
        public const string YPosName = "posY";
        public const string ZPosName = "posZ";
        public const string PoweredName = "powered";
        public const string RotationName = "rotation";
        public const string SeedName = "seed";
        public const string ShowBoundingName = "showboundingbox";
        public const string XSizeName = "sizeX";
        public const string YSizeName = "sizeY";
        public const string ZSizeName = "sizeZ";

        #endregion
    }

    public enum StructureRotation
    {
        None, Clockwise90, Clockwise180, Counterclockwise90
    }

    public enum StructureMode
    {
        Save, Load, Corner, Data
    }

    public enum StructureMirror
    {
        None, LeftRight, FrontBack
    }
}
