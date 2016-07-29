using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public sealed class BinaryTree<TItem> 
    {
        private readonly IComparer<TItem> _comparer;
        private Node<TItem> _root;
        public BinaryTree() : this(Comparer<TItem>.Default)
        {
            
        }

        public BinaryTree(IComparer<TItem> comparer)
        {
            if (ReferenceEquals(comparer, null))
            {
                throw new ArgumentNullException($"{nameof(comparer)} is null");
            }
            _comparer = comparer;

        }

        public BinaryTree(IEnumerable<TItem> collection) : this(Comparer<TItem>.Default)
        {
            if (ReferenceEquals(collection, null))
            {
                throw new ArgumentNullException($"{nameof(collection)} is null");
            }

            CreateTree(collection);
        }

        public BinaryTree(IEnumerable<TItem> collection, IComparer<TItem> comparer) : this(comparer)
        {
            if (ReferenceEquals(collection, null))
            {
                throw new ArgumentNullException($"{nameof(collection)} is null");
            }

            CreateTree(collection);
        }

        /// <summary>
        /// Method create tree-collection
        /// </summary>
        private void CreateTree(IEnumerable<TItem> collection)
        {
            foreach (var item in collection)
            {
                if (ReferenceEquals(_root, null))
                {
                    _root = new Node<TItem>(item);
                    continue;
                }
                AddNode(ref _root, item);
            }
        }

        /// <summary>
        /// Add leaves to tree
        /// </summary>
        /// <param name="leaves">The leaves</param>
        public void AddLeaves(params TItem[] leaves)
        {
            if (ReferenceEquals(leaves, null))
                throw new ArgumentNullException();

            foreach (var item in leaves)
            {
                AddNode(ref _root, item);
            }
        }

        /// <summary>
        /// Add node to tree
        /// </summary>
        /// <param name="node">Adding node</param>
        /// <param name="item">The value of the node that will contain</param>
        private void AddNode(ref Node<TItem> node, TItem item)
        {
            if (ReferenceEquals(node, null))
            {
                node = new Node<TItem>(item);
            }

            else if (_comparer.Compare(item, node.Value) == 1)
            {

                AddNode(ref node.Right, item);
            }
            else if (_comparer.Compare(item, node.Value) == -1)
            {

                AddNode(ref node.Left, item);
            }
        }

        /// <summary>
        /// Traversing the tree in inorder
        /// </summary>
        /// <returns>An enumerable that can be used to iterate through the collection.</returns>
        public IEnumerable<TItem> Inorder()
        {
            return Inorder(_root);
        }

        private IEnumerable<TItem> Inorder(Node<TItem> node)
        {
            if (node == null)
                yield break;

            foreach (var item in Inorder(node.Left))
                yield return item;

            yield return node.Value;

            foreach (var item in Inorder(node.Right))
                yield return item;

        }

        /// <summary>
        /// Traversing the tree in preorder
        /// </summary>
        /// <returns>An enumerable that can be used to iterate through the collection.</returns>
        public IEnumerable<TItem> Preorder()
        {
            return Preorder(_root);
        }
        private IEnumerable<TItem> Preorder(Node<TItem> node)
        {
            if (node == null)
                yield break;

            yield return node.Value;

            foreach (var e in Preorder(node.Left))
                yield return e;

            foreach (var e in Preorder(node.Right))
                yield return e;
        }

        /// <summary>
        /// The method clear a tree.
        /// </summary>
        public void ClearTree()
        {
            _root = null;
        }

        /// <summary>
        /// Traversing the tree in preorder
        /// </summary>
        /// <returns>An enumerable that can be used to iterate through the collection.</returns>
        private IEnumerable<TItem> Postorder(Node<TItem> node)
        {
            if (node == null)
                yield break;

            foreach (var e in Postorder(node.Left))
                yield return e;

            foreach (var e in Postorder(node.Right))
                yield return e;

            yield return node.Value;
        }

        public IEnumerable<TItem> Postoredr()
        {
            return Postorder(_root);
        }

        /// <summary>
        /// Enumerotor of the collection
        /// </summary>
        /// <returns>An enumerator of the collection</returns>
        public IEnumerator<TItem> GetEnumerator()
        {
            return Preorder(_root).GetEnumerator();
        }
        /// <summary>
        /// This class description the collection
        /// </summary>
        /// <typeparam name="TItem">The type of objects</typeparam>
        public class Node<TItem>
        {
            public Node(TItem value)
            {
                Value = value;
            }

            public readonly TItem Value;
            public Node<TItem> Left;
            public Node<TItem> Right;

        }

    }
}
