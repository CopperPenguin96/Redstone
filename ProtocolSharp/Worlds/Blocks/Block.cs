using System;
using System.Text.Json;
using Org.BouncyCastle.Math.EC.Rfc7748;
using ProtocolSharp.Types;

namespace ProtocolSharp.Worlds.Blocks
{
	public class Block
    {
        public Identifier ID { get; set; }

        public Block(Identifier id)
        {
            ID = id ?? throw new ArgumentNullException(nameof(id));
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
	}
}
