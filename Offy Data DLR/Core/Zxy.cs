using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Offy.Core.TileManager;

namespace Offy.Core
{
    public class Zxy
    {
        private int z;
        private int x;
        private int y;

        public Zxy(int _z, int _x, int _y)
        {
            z = _z;
            x = _x;
            y = _y;
        }

        public Zxy(int _z, PointT point)
        {
            z = _z;
            x = point.X;
            y = point.Y;
        }

        public Zxy Clone()
        {
            return new Zxy(z, x, y);
        }

        public bool Compare(Zxy zxy)
        {
            if (z != zxy.z) return false;
            if (x != zxy.x) return false;
            if (y != zxy.y) return false;

            return true;
        }

        public string getString()
        {
            System.Globalization.CultureInfo usC = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            return z.ToString(usC) + "," + x.ToString(usC) + "," + y.ToString(usC);
        }

        public int Z
        {
            get
            {
                return z;
            }

            set
            {
                z = value;
            }
        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
    }
}
