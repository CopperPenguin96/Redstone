using Redstone.Core.Types;
using Redstone.Nbt;
using Redstone.Nbt.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Core.World
{
    public class EnvironmentAttribute(Identifier id) : NbtTagProvider
    {
        public Identifier ID { get; private set; } = id;

        public override NbtTag Nbt { get; }

        public static EnvironmentAttribute Create(Identifier id, NbtTag nbt)
        {
            return new EnvironmentAttribute(id)
            {
                //Nbt = nbt
            };
        }

        public static EnvironmentAttribute CreateAmbientSounds(int blockSearchExtent, int offset, SoundEvent primarySound, int tickDelay, int tickChance)
        {
            return new EnvironmentAttribute("");
        }

        public override void Parse(NbtTag tag)
        {
            throw new NotImplementedException();
        }
    }

    public enum EnvAttributeModifier
    {
        None,
        Override,
        BooleanAnd,
        BooleanNand,
        BooleanOr,
        BooleanNor,
        BooleanXor,
        BooleanXnor,
        FloatSimple,
        FloatAlphaBlend,
        RGBComponentWiseColorBlend,
        RGBAlphaBlend,
        RGBBlendToGray
    }
}
