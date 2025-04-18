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
  }