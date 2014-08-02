using System;

using Seven;
using Seven.Mathematics;
using Seven.Structures;

using System.Diagnostics;

using System.Linq.Expressions;
using Seven.Mathematics.Symbolics;
using Seven.Mathematics.Symbolics.Tools;

namespace Testing
{
  class Program
  {
    static void Main(string[] args)
    {
      int test = 10;

      Console.WriteLine("Welcome To SevenFramework!!!!");
      Console.WriteLine();
      Console.WriteLine("You are runnning the Data-Structures tutorial. Its purpose");
      Console.WriteLine("is to show you examples of you to use the structures provided");
      Console.WriteLine("in the SevenFramework.");
      Console.WriteLine();
      Console.WriteLine("Data Structures=======================================");
      Console.WriteLine();
      Console.WriteLine("  Storing " + test + " items in each structure (except link)");
      Console.WriteLine();

      #region Link

      Console.WriteLine("  Testing Link--------------------------------");
      Console.WriteLine("   Size: 6");
      Link link = new Link<int, int, int, int, int, int>(0, 1, 2, 3, 4, 5);
      Console.Write("    Delegate: ");
      link.Foreach((dynamic current) => { Console.Write(current); });
      Console.WriteLine();
      Console.Write("    IEnumerator: ");
      foreach (object value in link)
        Console.Write(value);
      Console.WriteLine();
      Console.WriteLine();

      #endregion

      #region Array

      Console.WriteLine("  Testing Array_Array<int>-------------------");
      Array<int> array = new Array_Array<int>(test);
      for (int i = 0; i < test; i++)
        array[i] = i;
      Console.Write("    Delegate: ");
      array.Foreach((int current) => { Console.Write(current); });
      Console.WriteLine();
      Console.Write("    IEnumerator: ");
      foreach (int current in array)
        Console.Write(current);
      Console.WriteLine();
      Console.WriteLine();

      #endregion

      #region List

      Console.WriteLine("  Testing List_Array<int>--------------------");
      List<int> list_array = new List_Array<int>(test);
      for (int i = 0; i < test; i++)
        list_array.Add(i);
      Console.Write("    Delegate: ");
      list_array.Foreach((int current) => { Console.Write(current); });
      Console.WriteLine();
      Console.Write("    IEnumerator: ");
      foreach (int current in list_array)
        Console.Write(current);
      Console.WriteLine();
      Console.WriteLine();

      Console.WriteLine("  Testing List_Linked<int>-------------------");
      List<int> list_linked = new List_Linked<int>();
      for (int i = 0; i < test; i++)
        list_linked.Add(i);
      Console.Write("    Delegate: ");
      list_linked.Foreach((int current) => { Console.Write(current); });
      Console.WriteLine();
      Console.Write("    IEnumerator: ");
      foreach (int current in list_linked)
        Console.Write(current);
      Console.WriteLine();
      Console.WriteLine();

      #endregion

      #region Stack

      Console.WriteLine("  Testing Stack_Linked<int>------------------");
      Stack<int> stack_linked = new Stack_Linked<int>();
      for (int i = 0; i < test; i++)
        stack_linked.Push(i);
      Console.Write("    Delegate: ");
      stack_linked.Foreach((int current) => { Console.Write(current); });
      Console.WriteLine();
      Console.Write("    IEnumerator: ");
      foreach (int current in stack_linked)
        Console.Write(current);
      Console.WriteLine();
      Console.WriteLine();

      #endregion

      #region Queue

      Console.WriteLine("  Testing Queue_Linked<int>------------------");
      Queue<int> queue_linked = new Queue_Linked<int>();
      for (int i = 0; i < test; i++)
        queue_linked.Enqueue(i);
      Console.Write("    Delegate: ");
      queue_linked.Foreach((int current) => { Console.Write(current); });
      Console.WriteLine();
      Console.Write("    IEnumerator: ");
      foreach (int current in queue_linked)
        Console.Write(current);
      Console.WriteLine();
      Console.WriteLine();

      #endregion

      #region Heap

      Console.WriteLine("  Testing Heap_Array<int>--------------------");
      Heap<int> heap_array = new Heap_Array<int>(Logic.Compare);
      for (int i = 0; i < test; i++)
        heap_array.Enqueue(i);
      Console.Write("    Delegate: ");
      heap_array.Foreach((int current) => { Console.Write(current); });
      Console.WriteLine();
      Console.Write("    IEnumerator: ");
      foreach (int current in heap_array)
        Console.Write(current);
      Console.WriteLine();
      Console.WriteLine();

      #endregion

      #region AVL Tree

      Console.WriteLine("  Testing AvlTree_Linked<int>----------------");
      AvlTree<int> avlTree_linked = new AvlTree_Linked<int>(Logic.Compare);
      for (int i = 0; i < test; i++)
        avlTree_linked.Add(i);
      Console.Write("    Delegate: ");
      avlTree_linked.Foreach((int current) => { Console.Write(current); });
      Console.WriteLine();
      Console.Write("    IEnumerator: ");
      foreach (int current in avlTree_linked)
        Console.Write(current);
      Console.WriteLine();
      Console.WriteLine();

      #endregion

      #region Red-Black Tree

      Console.WriteLine("  Testing RedBlack_Linked<int>---------------");
      RedBlackTree<int> redBlackTree_linked = new RedBlackTree_Linked<int>(Logic.Compare);
      for (int i = 0; i < test; i++)
        redBlackTree_linked.Add(i);
      Console.Write("    Delegate: ");
      redBlackTree_linked.Foreach((int current) => { Console.Write(current); });
      Console.WriteLine();
      Console.Write("    IEnumerator: ");
      foreach (int current in redBlackTree_linked)
        Console.Write(current);
      Console.WriteLine();
      Console.WriteLine();

      #endregion

      #region Map

      Console.WriteLine("  Testing HashTable_Linked<int, int>---------");
      Map<int, int> hashTable_linked = new Map_Linked<int, int>(
        (int left, int right) => { return left == right; },
        (int integer) => { return integer; });
      for (int i = 0; i < test; i++)
        hashTable_linked.Add(i, i);
      Console.Write("    Look Ups: ");
      for (int i = 0; i < test; i++)
        Console.Write(hashTable_linked[i]);
      Console.WriteLine();
      Console.Write("    Delegate: ");
      hashTable_linked.Foreach((int current) => { Console.Write(current); });
      Console.WriteLine();
      Console.Write("    IEnumerator: ");
      foreach (int current in hashTable_linked)
        Console.Write(current);
      Console.WriteLine();
      Console.WriteLine();

      #endregion

      #region Quad-Tree

      Console.WriteLine("  Testing Quadtree_Linked<int, double>-------");
      Quadtree<int> quadtree_linked = new Quadtree_Linked<int, double>(
        -test - 1, -test - 1, // minimum dimensions of the quadtree
        test + 1, test + 1, // maximum dimensions of the quadtree
        test + 1, // load factor
        (int i, out double x, out double y) => { x = i; y = i; },
        Logic.Compare,
        (double left, double right) => { return (left + right) * 0.5d; });
      for (int i = 0; i < test; i++)
        quadtree_linked.Add(i);
      Console.Write("    Delegate: ");
      quadtree_linked.Foreach((int current) => { Console.Write(current); });
      Console.WriteLine();
      Console.Write("    IEnumerator: ");
      foreach (int current in quadtree_linked)
        Console.Write(current);
      Console.WriteLine();
      Console.WriteLine();

      #endregion

      #region Oct-Tree

      Console.WriteLine("  Testing Octree_Linked<int, double>---------");
      Octree<int> octree_linked = new Octree_Linked<int, double>(
        -test - 1, -test - 1, -test - 1, // minimum dimensions of the octree
        test + 1, test + 1, test + 1, // maximum dimensions of the octree
        test + 1, // load factor
        (int i, out double x, out double y, out double z) => { x = i; y = i; z = i; },
        Logic.Compare,
        (double left, double right) => { return (left + right) * 0.5d; });
      for (int i = 0; i < test; i++)
        octree_linked.Add(i);
      Console.Write("    Delegate: ");
      octree_linked.Foreach((int current) => { Console.Write(current); });
      Console.WriteLine();
      Console.Write("    IEnumerator: ");
      foreach (int current in octree_linked)
        Console.Write(current);
      Console.WriteLine();
      Console.WriteLine();

      #endregion

      #region Omni-Tree

      // The octree has a minor bug. I'm already working on it.
      Console.WriteLine("  Testing Omnitree_Linked<int, double>-------");
      Omnitree<int, double> omnitree_linked = new Omnitree_Linked<int, double>(
        new double[] { -test - 1, -test - 1, -test - 1 }, // minimum dimensions of the omnitree
        new double[] { test + 1, test + 1, test + 1 }, // maximum dimensions of the omnitree
        (int i, out double[] location) => { location = new double[] { i, i, i }; },
        Logic.Compare, // comparison function
        (double left, double right) => { return (left + right) * 0.5d; }); // average function
      for (int i = 0; i < test; i++)
        omnitree_linked.Add(i);
      Console.Write("    Delegate: ");
      omnitree_linked.Foreach((int current) => { Console.Write(current); });
      Console.WriteLine();
      Console.Write("    IEnumerator: ");
      foreach (int current in omnitree_linked)
        Console.Write(current);
      Console.WriteLine();
      Console.WriteLine();
      
			Console.WriteLine("  Testing Omnitree_Array<int, double>---------------");
			Omnitree<int, double> omnitree_array = new Omnitree_Array<int, double>(
				new double[] { -test - 1, -test - 1, -test - 1 }, // minimum dimensions of the omnitree
				new double[] { test + 1, test + 1, test + 1 }, // maximum dimensions of the omnitree
				(int i, out double[] location) => { location = new double[] { i, i, i }; },
        Logic.Compare, // comparison function
				(double left, double right) => { return (left + right) * 0.5d; }); // average function
			Console.WriteLine("      Origin: [" + omnitree_array.Origin[0] + ", " + omnitree_array.Origin[1] + ", " + omnitree_array.Origin[2] + "]");
			Console.WriteLine("      Minimum: [" + omnitree_array.Min[0] + ", " + omnitree_array.Min[1] + ", " + omnitree_array.Min[2] + "]");
			Console.WriteLine("      Maximum: [" + omnitree_array.Max[0] + ", " + omnitree_array.Max[1] + ", " + omnitree_array.Max[2] + "]");
			Console.WriteLine("      Dimensions: " + omnitree_array.Dimensions);
			Console.WriteLine("      Count: " + omnitree_array.Count);
			Console.Write("    Adding 0-" + test + ": ");
			for (int i = 0; i < test; i++)
				omnitree_array.Add(i);
			omnitree_array.Foreach((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.WriteLine("      Count: " + omnitree_array.Count);
			Console.Write("    Foreach (delegate) [ALL]: ");
			omnitree_array.Foreach((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.Write("    Foreach (delegate) [" + (test / 2) + "-" + test + "]: ");
			omnitree_array.Foreach((int current) => { Console.Write(current); },
				new double[] { test / 2, test / 2, test / 2 },
				new double[] { test, test, test });
			Console.WriteLine();
			Console.Write("    Remove 0-" + test / 3 + ": ");
			omnitree_array.Remove(
				new double[] { 0, 0, 0 },
				new double[] { test / 3, test / 3, test / 3 });
			omnitree_array.Foreach((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.WriteLine("      Count: " + omnitree_array.Count);
			Console.Write("    Clear: ");
			omnitree_array.Clear();
			omnitree_array.Foreach((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.WriteLine("      Count: " + omnitree_array.Count);
			Console.WriteLine();

			#endregion

      Console.WriteLine();
      Console.WriteLine("============================================");
      Console.WriteLine(" Testing Complete...");
      Console.ReadLine();
    }
  }
}