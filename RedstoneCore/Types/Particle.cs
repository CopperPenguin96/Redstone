using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Redstone.Core.Types
{
    public struct Particle(VarInt id)
    {
        public VarInt ID { get; private set; } = id;

        public readonly Identifier Name => Registry.Particles[ID];

        public const string BLOCK_STATE = "block_state";
        public const string POWER = "power";

        private readonly Dictionary<string, object> _data = [];

        public object this[string key]
        {
            get => _data[key];
            set => _data[key] = value;
        }

        public static Particle Create(VarInt vi, Dictionary<string, object> data)
        {
            var particle = new Particle(vi);
            foreach (var kvp in data)
            {
                particle[kvp.Key] = kvp.Value;
            }
            return particle;
        }

        public static Particle Create(VarInt vi)
        {
            return new(vi);
        }

        public static Particle Create(Identifier ident)
        {
            for (int x = 0; x < Registry.Particles.Count; x++)
            {
                if (Registry.Particles[x] == ident)
                {
                    return new Particle(x);
                }
            }

            throw new RedstoneException("Particle identifier not found: " + ident);
        }

        public static Particle CreateBlock(VarInt state)
        {
            Particle p = new Particle(1);
            p[BLOCK_STATE] = state;
            return p;
        }

        public static Particle CreateBlockMarker(VarInt state)
        {
            Particle p = new Particle(2);
            p[BLOCK_STATE] = state;
            return p;
        }

        public static Particle CreateDragonBreath(float power)
        {
            Particle p = new(8);
            p[POWER] = power;
            return p;
        }

    }
}
