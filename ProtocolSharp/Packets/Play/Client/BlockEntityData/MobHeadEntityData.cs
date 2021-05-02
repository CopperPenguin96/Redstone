using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
using System.Text;
using fNbt;
using Newtonsoft.Json.Serialization;
using ProtocolSharp.Network;
using ProtocolSharp.Utils;
using ProtocolSharp.Worlds.Blocks;
using JsonObject = Redstone.JsonObject;

namespace ProtocolSharp.Packets.Play.Client.BlockEntityData
{
	public class MobHeadEntityData : BlockEntityData
    {
        public int[] OwnerID => (int[]) ParentBlock[OwnerIDName];

        public string Name => (string) ParentBlock[NameName];

        public bool IsPublic => (bool) ParentBlock[PublicName];

        public string Url => (string) ParentBlock[UrlName];

        public MobHeadEntityData(Block parent) : base(parent)
        {
            
        }

        private string GetJson(ref MinecraftClient client)
        {
            JsonObject jObj = new JsonObject();
            jObj.Add("isPublic", true);
            jObj.Add("profileId", BitConverter.ToString(Encoding.Default.GetBytes(client.UniqueID)));
            jObj.Add("profileName", client.Username);
            // todo add capes?
            JsonObject textures = new JsonObject();
            JsonObject skin = new JsonObject();
            skin.Add("url", "https://crafatar.com/skins/" + client.UniqueID);
            textures.Add("SKIN", skin);
            jObj.Add("textures", textures);
            return jObj.ToString().Base64Encode();
        }

        public new void send(ref MinecraftClient client, GameStream stream)
        {
            NbtCompound nbt = new NbtCompound(
                new NbtTag[]
                {
                    new NbtCompound(SkullOwnerName, new List<NbtTag>
                    {
                        new NbtIntArray(OwnerIDName, OwnerID),
                        new NbtString(NameName, Name),
                        new NbtCompound(PropertiesName, new List<NbtTag>
                        {
                            new NbtList(TexturesName, new List<NbtTag>
                            {
                                new NbtCompound(new List<NbtTag> // An ind. texture
                                {
                                    new NbtString("Value", GetJson(ref client))
                                })
                            })
                        })
                    })
                });


            base.Send(ref client, stream,
                (int) BlockEntityDataAction.SetSkinMobHeadRotation,
                nbt);
        }

        #region constants

        public const string SkullOwnerName = "SkullOwner";
        public const string OwnerIDName = "Id";
        public const string NameName = "Name";
        public const string PropertiesName = "Properties";
        public const string TexturesName = "textures";
        public const string ValueName = "Value";
        public const string PublicName = "isPublic";
        public const string CapeName = "CAPE";
        public const string UrlName = "url";
        public const string SkinName = "SKIN";
        public const string TimeStampName = "timestamp";

        #endregion
    }
}