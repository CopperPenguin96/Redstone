using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Types
{
    public class PosDouble : Position
    {
        // In case values were set before being cast to this object
        // Uses those values if not yet set

        private bool _xSet = false;
        private double _x;

        public new double X
        {
            get => _xSet ? _x : base.X;
            set
            {
                _x = value;
                _xSet = true;
            }
        }

        private bool _ySet = false;
        private double _y;

        public new double Y
        {
            get => _ySet ? _y : base.Y;
            set
            {
                _y = value;
                _ySet = true;
            }
        }

        private bool _zSet = false;
        private double _z;

        public new double Z
        {
            get => _zSet ? _z : base.Z;
            set
            {
                _z = value;
                _zSet = true;
            }
        }

        
        public PosDouble(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public PosDouble(int x, int y, int z)
            : base(x, y, z)
        {

        }
    }
}
