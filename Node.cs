namespace lambda180425
{
  public class Node<T>
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