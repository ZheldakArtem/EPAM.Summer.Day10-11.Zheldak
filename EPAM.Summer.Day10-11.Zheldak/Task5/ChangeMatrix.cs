using System;

namespace Task5
{
    public class ChangeEventeArgs<T> : EventArgs
    {
        private int _i;
        private int _j;
        private T _oldElem;

        public ChangeEventeArgs(int indexI, int indexJ, T oldElem)
        {
            _i = indexI;
            _j = indexJ;
            _oldElem = oldElem;
        }
    }
}