using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public abstract class ManrixBase<T>
    {
        protected T[,] _array;
        protected event EventHandler<ChangeEventeArgs<T>> Changes = delegate { };

        protected virtual void OnChange(object sender, ChangeEventeArgs<T> eventArg)
        {
            var change = Changes;
            if (change != null)
                change(sender, eventArg);
        }

        public abstract T this[int i, int j] { get; set; }

        public abstract int Size { get; }

        protected bool IsIndex(int i)
        {
            return i >= 0 && i <= Size;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    result.Append(this[i, j] + " ");
                result.Append("/n");
            }
            return result.ToString();
        }
    }
}
