using com.sun.xml.@internal.bind.v2.model.core;
using JetBrains.Annotations;
using Redstone.Types;

namespace Redstone.Worlds.Dimensions
{
    public interface IDimension
    {
        Identifier Type { get; set; }

        Identifier Id { get; }

        string BiomeSourceType { get; set; }
    }
}
