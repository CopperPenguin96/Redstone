using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using SmartNbt.Tags;

namespace Redstone.Worlds
{
    public class DragonFight
    {
        public bool DragonKilled { get; set; } = false;

        public bool NeedsStateScanning { get; set; } = false;

        public bool PreviouslyKilled { get; set; } = false;

        private List<int>? _gateways = null;

        public NbtList Gateways
        {
            get
            {
                List<int> gates = _gateways ??= GenerateGateways();
                NbtList ret = new("Gateways");

                foreach (int i in gates)
                {
                    ret.Add(new NbtInt(i));
                }

                return ret;
            }
            set
            {
                _gateways.Clear();
                foreach (NbtInt i in value)
                {
                    _gateways.Add(i.Value);
                }
            }
        }

        private List<int> GenerateGateways()
        {
            List<int> selected = new();

            while (selected.Count < 20)
            {
                Random rnd = new(new Random().Next());
                int next = rnd.Next(0, 19);
                if (selected.Contains(next)) continue;

                selected.Add(next);
            }

            return selected;
        }
    }
}
