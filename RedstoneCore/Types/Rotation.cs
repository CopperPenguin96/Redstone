using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Core.Types
{
    public struct Rotation(float x, float y, float z)
    {
        public float X { get; set; } = x;

        public float Y { get; set; } = y;

        public float Z { get; set; } = z;
    }
}
