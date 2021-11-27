using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Types
{
    public class Rotation
    {
        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public Rotation(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
	}
}
