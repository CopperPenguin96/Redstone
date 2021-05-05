using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolSharp.Types;

namespace ProtocolSharp.Worlds.Blocks
{
    public class Chest : Block
    {
        public Chest()
        {
            ID = new Identifier("chest");
        }

        public List<MinecraftClient> LookingAt = new List<MinecraftClient>();

        public void LookAtChest(MinecraftClient client)
        {
            bool already = false;
            foreach (var cl in LookingAt.Where(cl => client.UniqueID == cl.UniqueID))
            {
                already = true;
            }

            if (!already)
            {
                LookingAt.Add(client);
            }
        }

        public void StopLookingAt(MinecraftClient client)
        {
            for (int x = 0; x < LookingAt.Count; x++)
            {
                MinecraftClient cl = LookingAt[x];
                if (cl.UniqueID == client.UniqueID)
                {
                    LookingAt.RemoveAt(x);
                }
            }
        }
    }

    public class EnderChest : Chest
    {
        public EnderChest()
        {
            ID = new Identifier("ender_chest");
        }
    }

    public class ShulkerBox : Chest
    {
        public ShulkerBox()
        {
            ID = new Identifier("shulker_box");
        }
    }
}
