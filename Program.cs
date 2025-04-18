namespace lambda180425
{
  class Program
  {
    static void Main(string[] args)
    {
      var tree = new BinaryTree<int>((x, y) => x.CompareTo(y));

      tree.Insert(50);
      tree.Insert(30);
      tree.Insert(70);
      tree.Insert(20);
      tree.Insert(40);
      tree.Insert(60);
      tree.Insert(80);

      Console.WriteLine("Прямой обход (foreach):");
      foreach (var item in tree)
      {
        Console.Write(item + " ");
      }

      Console.WriteLine("\n\nПрямой итератор:");
      var forward = tree.GetForwardIterator();
      while (forward.Next())
      {
        Console.Write(forward.Current + " ");
      }

      Console.WriteLine("\n\nОбратный итератор:");
      var reverse = tree.GetReverseIterator();
      while (reverse.Previous())
      {
        Console.Write(reverse.Current + " ");
      }

      Console.WriteLine("\n\nЦентральный обход (лямбда):");
      var central = tree.GetCentralTraversalIterator()();
      foreach (var item in central)
      {
        Console.Write(item + " ");
      }
    }
  }

  public static class BinaryTreeExtensions
  {
    public static void Insert<T>(this BinaryTree<T> tree, T data) where T : IComparable<T>
    {
      tree.Insert(data, (a, b) => a.CompareTo(b));
    }
  }
}

