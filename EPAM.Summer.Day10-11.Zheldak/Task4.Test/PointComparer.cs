using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Test;

namespace Task4.Test
{
    class PointComparer : IComparer<CustomPoint>, IComparer
    {
        public int Compare(object first, object second)
        {
            first = first as CustomPoint;
            if (first == null)
            {
                return 1;
            }
            second = second as CustomPoint;
            if (second == null)
            {
                return -1;
            }

            return Compare((CustomPoint)first, (CustomPoint)second);
        }

        public int Compare(CustomPoint first, CustomPoint second)
        {
            if (ReferenceEquals(first, null))
                return 1;
            if (ReferenceEquals(second, null))
                return -1;
            if (Distance(first) < Distance(second))
                return -1;
            if (Distance(first) > Distance(second))
                return 1;
            return 0;
        }

        private double Distance(CustomPoint first)
        {
            return Math.Pow(first.X * first.X + first.Y * first.Y, 0.5);
        }
    }
}
