using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Types
{
    public class PosFloat : Position
    {
        // In case values were set before being cast to this object
        // Uses those values if not yet set

        private bool _xSet = false;
        private float _x;

        public new float X
        {
            get => _xSet ? _x : base.X;
            set
            {
                _x = value;
                _xSet = true;
            }
        }

        private bool _ySet = false;
        private float _y;

        public new float Y
        {
            get => _ySet ? _y : base.Y;
            set
            {
                _y = value;
                _ySet = true;
            }
        }

        private bool _zSet = false;
        private float _z;

        public new float Z
        {
            get => _zSet ? _z : base.Z;
            set
            {
                _z = value;
                _zSet = true;
            }
        }


        public PosFloat(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public PosFloat(int x, int y, int z)
            : base(x, y, z)
        {

        }
    }
}
