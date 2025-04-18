namespace lambda180425
{
  public class BinaryTree<T> : IEnumerable<T>
  {
    private Node<T> _root;
    private readonly Func<T, T, int> _comparer;

    internal class Node<T>
    {
      public T Data { get; set; }
      public Node<T> Left { get; set; }
      public Node<T> Right { get; set; }
      public Node<T> Parent { get; set; }

      public Node(T data, Node<T> parent)
      {
        Data = data;
        Parent = parent;
      }
    }

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
    public IEnumerator<T> GetEnumerator() => new InOrderEnumerator(_root);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class InOrderEnumerator : IEnumerator<T>
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
    public ForwardIterator GetForwardIterator() => new ForwardIterator(_root);
    public ReverseIterator GetReverseIterator() => new ReverseIterator(_root);

    public class ForwardIterator
    {
      private Node<T> _current;

      internal ForwardIterator(Node<T> root) => _current = FindLeftmost(root);
      public T Current => _current.Data;

      public bool Next()
      {
        if (_current == null)
        {
          return false;
        }

        if (_current.Right != null)
        {
          _current = FindLeftmost(_current.Right);
          return true;
        }

        while (_current.Parent != null && _current == _current.Parent.Right)
        {
          _current = _current.Parent;
        }

        _current = _current.Parent;

        if (_current != null)
        {
          return true;
        }
        else
        {
          return false;
        }
      }

      private static Node<T> FindLeftmost(Node<T> node)
      {
        while (node != null && node.Left != null)
        {
          node = node.Left;
        }
        return node;
      }

      public static ForwardIterator operator ++(ForwardIterator iterator)
      {
        iterator.Next();
        return iterator;
      }
    }
    public class ReverseIterator
    {
      private Node<T> _current;

      internal ReverseIterator(Node<T> root) => _current = FindRightmost(root);
      public T Current => _current.Data;

      public bool Previous()
      {
        if (_current == null)
        {
          return false;
        }

        if (_current.Left != null)
        {
          _current = FindRightmost(_current.Left);
          return true;
        }

        while (_current.Parent != null && _current == _current.Parent.Left)
        {
          _current = _current.Parent;
        }

        _current = _current.Parent;

        if (_current != null)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }
   }
  }