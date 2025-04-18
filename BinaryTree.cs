namespace lambda180425
{
  public class BinaryTree<T>
  {
    private readonly Func<T, T, int> _comparer;

    public BinaryTree(Func<T, T, int> comparer)
    {
      if (comparer == null)
      {
        throw new ArgumentNullException(nameof(comparer));
      }
      _comparer = comparer;
    }
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

    private Node<T> _root;

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
  }
}