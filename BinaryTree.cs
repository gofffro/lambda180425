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
  }
}