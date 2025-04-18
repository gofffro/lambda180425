using System;
using System.Collections;
using System.Collections.Generic;

namespace lambda180425
{
  public class InOrderEnumerator<T> : IEnumerator<T>
  {
    private Node<T> _current;
    private readonly Node<T> _root;
    private readonly Stack<Node<T>> _stack;

    public InOrderEnumerator(Node<T> root)
    {
      _root = root;
      _stack = new Stack<Node<T>>();
      InitializeStack(root);
    }

    private void InitializeStack(Node<T> node)
    {
      while (node != null)
      {
        _stack.Push(node);
        node = node.Left;
      }
    }

    public T Current => _current.Data;
    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
      if (_stack.Count == 0)
      {
        return false;
      }

      _current = _stack.Pop();
      var node = _current.Right;
      while (node != null)
      {
        _stack.Push(node);
        node = node.Left;
      }
      return true;
    }

    public void Reset()
    {
      _stack.Clear();
      InitializeStack(_root);
      _current = null;
    }

    public void Dispose() { }
  }
}