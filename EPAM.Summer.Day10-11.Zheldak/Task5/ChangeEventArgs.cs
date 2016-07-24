using System;

namespace Task5
{
    /// <summary>
    /// A class contains the event information
    /// </summary>
    public class ChangeEventeArgs<T> : EventArgs
    {
        public int I { get; set; }
        public int J { get; set; }
        public T OldElem { get; set; }

        public ChangeEventeArgs(int indexI, int indexJ, T oldElem)
        {
            I = indexI;
            J = indexJ;
            OldElem = oldElem;
        }
    }
}