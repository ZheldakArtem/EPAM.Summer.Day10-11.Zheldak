using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Test
{
    class StringComparer : IComparer<string>
    {
        public int Compare(string lhs, string rhs)
        {
            if (ReferenceEquals(rhs, null))
                return -1;
            if (ReferenceEquals(lhs, null))
                return 1;
            if (ReferenceEquals(lhs, rhs))
                return 0;

            if (lhs.Length < rhs.Length)
                return -1;
            return lhs.Length > rhs.Length ? 1 : 0;
        }
    }
}
