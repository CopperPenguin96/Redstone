using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Org.BouncyCastle.Math.EC.Rfc7748;
using ProtocolSharp.Packets.Play.Client.BlockEntityData;
using ProtocolSharp.Types;

namespace ProtocolSharp.Worlds.Blocks
{
	public class Block
    {
        public Identifier ID { get; set; }

        private byte _dStage;
        public byte DestroyStage
        {
            get => _dStage;
            set
            {
                if (value > 9) throw new IndexOutOfRangeException();
                _dStage = value;
            }
        }

        public VarInt State { get; set; }

        /// <summary>
        /// Certain blocks have different things happen, protocol uses the
        /// packet here
        /// </summary>
        public BlockEntityData EntityDataPacket { get; set; }

        public int Hardness { get; set; }

        public List<BlockData> Data { get; set; }

        public object this[string name]
        {
            get
            {
                foreach (var data in Data.Where(data => string.Equals(data.Name, name, StringComparison.CurrentCultureIgnoreCase)))
                {
                    return data.Value;
                }

                throw new IndexOutOfRangeException(nameof(name));
            }
        }

        public readonly bool IsCustom = false;

        public Block(Identifier id)
        {
            ID = id ?? throw new ArgumentNullException(nameof(id));
        }

        public Block(string id) : this(new Identifier(id))
        {
        }

        protected Block()
        {
            throw new NotImplementedException();
        }

        public int NumericID => LocateBlock().GetProperty("id").GetInt32();

        public double BlastResistance => LocateBlock().GetProperty("explosion_resistance").GetDouble();


        private JsonElement LocateBlock()
        {
            JsonElement root = BlockRegistry.Doc.RootElement;
            for (int x = 0; x < root.GetArrayLength(); x++)
            {
                JsonElement blockEntry = root[x];
                if (ID.ToString() == blockEntry.EnumerateObject().Current.Name)
                {
                    return blockEntry;
                }
            }

            throw new Exception();
        }

        public static VarInt FindIDByIdentif(Identifier id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            JsonElement root = BlockRegistry.Doc.RootElement;
            for (int x = 0; x < root.GetArrayLength(); x++)
            {
                JsonElement blockEntry = root[x];
                JsonProperty blk = blockEntry.EnumerateObject().Current;
                if (id.ToString() == blk.Name)
                {
                    return blockEntry.GetProperty("id").GetInt32();
                }
            }

            throw new Exception($"Block does not exist. (ID: {id})");
        }
	}
}
