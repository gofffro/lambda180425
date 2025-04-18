namespace lambda180425
{
  public class ReverseIterator<T>
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

      return _current != null;
    }

    private static Node<T> FindRightmost(Node<T> node)
    {
      while (node != null && node.Right != null)
      {
        node = node.Right;
      }
      return node;
    }

    public static ReverseIterator<T> operator --(ReverseIterator<T> iterator)
    {
      iterator.Previous();
      return iterator;
    }
  }
}