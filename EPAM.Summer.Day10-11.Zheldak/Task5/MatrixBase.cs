using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    /// The base abstract class for Square, Diagonal and Simmetric matrixes.
    /// </summary>
    /// <typeparam name="T">Type of object</typeparam>
    public abstract class BaseMatrix<T>
    {
        public event EventHandler<ChangeEventeArgs<T>> Changes = delegate { };

        /// <summary>
        /// The method that handles the event.
        /// </summary>
        /// <param name="sender">The object wich invoke the event.</param>
        /// <param name="eventArg">The object wich contains informations of event.</param>
        protected virtual void OnChange(object sender, ChangeEventeArgs<T> eventArg)
        {
            var change = Changes;
            if (change != null)
                change(sender, eventArg);
        }

        /// <summary>
        /// The index of the element to get or set
        /// </summary>
        /// <param name="i">index of row</param>
        /// <param name="j">index of column</param>
        /// <returns>Value an element of array wich have index[<param name="i"/>,<param name="j"/>] </returns>
        public abstract T this[int i, int j] { get; set; }

        /// <summary>
        /// Get size of array
        /// </summary>
        public abstract int Size { get; }


        protected bool IsIndex(int i)
        {
            return i >= 0 && i <= Size;
        }

        /// <summary>
        ///  Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object</returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    result.Append(this[i, j] + " ");
                result.Append("\n");
            }
            return result.ToString();
        }

        /// <summary>
        /// Get value from matrix.
        /// </summary>
        protected abstract T GetValue(int i, int j);

        /// <summary>
        /// Set value to the matrix.
        /// </summary>
        protected abstract void SetValue(int i, int j, T value);

        

    }
}
