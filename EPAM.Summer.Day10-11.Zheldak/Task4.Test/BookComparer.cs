using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Book;

namespace Task4.Test
{
    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book lhs, Book rhs)
        {
            if (ReferenceEquals(rhs, null))
                return -1;
            if (ReferenceEquals(lhs, null))
                return 1;
            if (ReferenceEquals(lhs, rhs))
                return 0;
            if (lhs.Pages < rhs.Pages)
                return -1;
            if (lhs.Pages > rhs.Pages)
                return 1;
            return 0;
        }
    }
}
