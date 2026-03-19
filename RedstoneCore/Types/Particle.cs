using Redstone.Core.Registries;
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
        public const string COLOR = "color";
        public const string SCALE = "scale";    
        public const string FROM_COLOR = "from_color";
        public const string TO_COLOR = "to_color";
        public const string ROLL = "roll";
        public const string ITEM = "item";
        public const string POS_SOURCE = "pos_source";
        public const string BLOCK_POS = "block_pos";
        public const string ENTITY_ID = "entity_id";
        public const string ENTITY_EYE_HEIGHT = "entity_eye_height";
        public const string TICKS = "ticks";
        public const string POS_X = "x";
        public const string POS_Y = "y";
        public const string POS_Z = "z";
        public const string DURATION = "duration";
        public const string DELAY = "delay";

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

        public static Particle CreateDust(Color color, float scale)
        {
            Particle p = new(14);
            p[COLOR] = color.ToArgb();
            p[SCALE] = scale;
            return p;
        }

        public static Particle CreateDustColorTransition(Color from, Color to, float scale)
        {
            Particle p = new(15);
            p[FROM_COLOR] = from.ToArgb();
            p[TO_COLOR] = to.ToArgb();
            p[SCALE] = scale;
            return p;
        }

        public static Particle CreateEffect(Color color, float power)
        {
            Particle p = new(16);
            p[COLOR] = color.ToArgb();
            p[POWER] = power;
            return p;
        }

        public static Particle CreateEntityEffect(Color color)
        {
            Particle p = new(21);
            p[COLOR] = color.ToArgb();
            return p;
        }

        public static Particle CreateTintedLeaves(Color color)
        {
            Particle p = new(36);
            p[COLOR] = color.ToArgb();
            return p;
        }

        public static Particle CreateSkulkChange(float roll)
        {
            Particle p = new(38);
            p[ROLL] = roll;
            return p;
        }

        public static Particle CreateFlash(Color color)
        {
            Particle p = new(42);
            p[COLOR] = color.ToArgb();
            return p;
        }

        public static Particle CreateInstantEffect(Color color, float power)
        {
            Particle p = new(46);
            p[COLOR] = color.ToArgb();
            p[POWER] = power;
            return p;
        }

        public static Particle CreateItem(SlotData slot)
        {
            Particle p = new(47);
            p[ITEM] = slot;
            return p;
        }

        public static Particle CreateVibrationBlock(Position position, VarInt ticks)
        {
            Particle p = new(48);
            p[POS_SOURCE] = 0;
            p[BLOCK_POS] = position;
            p[TICKS] = ticks;
            return p;
        }

        public static Particle CreateVibrationEntity(VarInt eid, float entityeyeheight)
        {
            Particle p = new(48);
            p[POS_SOURCE] = 0;
            p[ENTITY_ID] = eid;
            p[ENTITY_EYE_HEIGHT] = entityeyeheight;
            p[TICKS] = TICKS;
            return p;
        }

        public static Particle CreateTrail(double targetX, double targetY, double targetZ, Color color, VarInt duration)
        {
            Particle p = new(49);
            p[POS_X] = targetX;
            p[POS_Y] = targetY;
            p[POS_Z] = targetZ;
            p[COLOR] = color.ToArgb();
            p[DURATION] = duration;
            return p;
        }

        public static Particle CreateShriek(VarInt delay)
        {
            Particle p = new(103);
            p[DELAY] = delay;
            return p;
        }

        public static Particle CreateDustPillar(VarInt blockState)
        {
            Particle p = new(109);
            p[BLOCK_STATE] = blockState;
            return p;
        }

        public static Particle CreateBlockCrumble(VarInt blockState)
        {
            Particle p = new(113);
            p[BLOCK_STATE] = blockState;
            return p;
        }
    }
}
