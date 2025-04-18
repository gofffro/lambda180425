using System;
using System.Collections;
using System.Collections.Generic;

namespace lambda180425
{
  public class BinaryTree<T> : IEnumerable<T>
  {
    private Node<T> _root;
    private readonly Func<T, T, int> _comparer;

    public BinaryTree(Func<T, T, int> comparer)
    {
      if (comparer == null)
      {
        throw new ArgumentNullException(nameof(comparer));
      }
      _comparer = comparer;
    }

    public void Insert(T data, Func<T, T, int> comparer)
    {
      if (_root == null)
      {
        _root = new Node<T>(data, null);
        return;
      }

      Node<T> current = _root;
      while (true)
      {
        int comparison = comparer(data, current.Data);
        if (comparison < 0)
        {
          if (current.Left == null)
          {
            current.Left = new Node<T>(data, current);
            break;
          }
          current = current.Left;
        }
        else
        {
          if (current.Right == null)
          {
            current.Right = new Node<T>(data, current);
            break;
          }
          current = current.Right;
        }
      }
    }

    public IEnumerator<T> GetEnumerator() => new InOrderEnumerator<T>(_root);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public ForwardIterator<T> GetForwardIterator() => new ForwardIterator<T>(_root);
    public ReverseIterator<T> GetReverseIterator() => new ReverseIterator<T>(_root);

    public Func<IEnumerable<T>> GetCentralTraversalIterator() => () =>
    {
      List<T> result = new List<T>();
      TraverseInOrder(_root, result);
      return result;
    };

    private void TraverseInOrder(Node<T> node, List<T> result)
    {
      if (node == null)
      {
        return;
      }
      TraverseInOrder(node.Left, result);
      result.Add(node.Data);
      TraverseInOrder(node.Right, result);
    }
  }
}