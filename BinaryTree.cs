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
  }
}