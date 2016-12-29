using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Offy.Core
{
    public class Extent
    {
        private double xmin;
        private double ymin;
        private double xmax;
        private double ymax;

        public Extent(double _xmin, double _ymin, double _xmax, double _ymax)
        {
            xmin = _xmin;
            ymin = _ymin;
            xmax = _xmax;
            ymax = _ymax;
        }

        public Extent Clone()
        {
            return new Extent(xmin, ymin, xmax, ymax);
        }

        public bool Compare(Extent extent)
        {
            if (xmin != extent.xmin) return false;
            if (ymin != extent.ymin) return false;
            if (xmax != extent.xmax) return false;
            if (ymax != extent.ymax) return false;

            return true;
        }

        public string getString()
        {
            System.Globalization.CultureInfo usC = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            return xmin.ToString(usC) + "," + ymin.ToString(usC) + "," + xmax.ToString(usC) + "," + ymax.ToString(usC);
        }

        public double Xmin
        {             
            get
            {
                return xmin;
            }

            set
            {
                xmin = value;
            }
        }

        public double Ymin
        {
            get
            {
                return ymin;
            }

            set
            {
                ymin = value;
            }
        }

        public double Xmax
        {
            get
            {
                return xmax;
            }

            set
            {
                xmax = value;
            }
        }

        public double Ymax
        {
            get
            {
                return ymax;
            }

            set
            {
                ymax = value;
            }
        }
    }
}
