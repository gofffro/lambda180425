namespace lambda180425
{
  public class ForwardIterator<T>
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

      return _current != null;
    }

    private static Node<T> FindLeftmost(Node<T> node)
    {
      while (node != null && node.Left != null)
      {
        node = node.Left;
      }
      return node;
    }

    public static ForwardIterator<T> operator ++(ForwardIterator<T> iterator)
    {
      iterator.Next();
      return iterator;
    }
  }
}