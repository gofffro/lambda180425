using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambda180425
{
  public class BinaryTree<T>
  {
    private Node root;

    private class Node
    {
      public T Value { get; set; }
      public Node Left { get; set; }
      public Node Right { get; set; }
      public Node Parent { get; set; }
    }
  }
}
