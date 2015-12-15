using System;

using Seven;
using Seven.Mathematics;
using Seven.Structures;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Testing
{
	class Program
	{
		static void Main(string[] args)
		{
			Random random = new Random();
			int test = 10;
			int temp;

			//using (FileStream serializeStream = new FileStream("Omnitree_Save.omnitree", FileMode.Create))
			//{
			//	//int[] serialized_array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			//	//BinaryFormatter formatter = new BinaryFormatter();
			//	//formatter.Serialize(serializeStream, serialized_array);
			//	//serializeStream.Flush();

			//	Omnitree_LinkedLinkedLists<int, double> serialized_omnitree = new Omnitree_LinkedLinkedLists<int, double>(
			//		new double[] { -test - 1, -test - 1, -test - 1 },
			//		new double[] { test + 1, test + 1, test + 1 },
			//		(int i) => { return Accessor.Get(new double[] { i, i, i }); },
			//		Logic.compare,
			//		Statistics.Mean);
			//	for (int i = 0; i < test; i++)
			//		serialized_omnitree.Add(i);
			//	BinaryFormatter formatter = new BinaryFormatter();
			//	formatter.Serialize(serializeStream, serialized_omnitree);
			//	serializeStream.Flush();
			//}

			//using (FileStream serializeStream = new FileStream("Omnitree_Save.omnitree", FileMode.Open))
			//{
			//	//int[] serialized_array;
			//	//BinaryFormatter formatter = new BinaryFormatter();
			//	//serialized_array = formatter.Deserialize(serializeStream) as int[];
			//	//foreach (int i in serialized_array)
			//	//	Console.WriteLine(i);

			//	Omnitree_LinkedLinkedLists<int, double> serialized_omnitree;
			//	BinaryFormatter formatter = new BinaryFormatter();
			//	serialized_omnitree = formatter.Deserialize(serializeStream) as Omnitree_LinkedLinkedLists<int, double>;
			//	serialized_omnitree.Stepper((int i) => { Console.WriteLine(i); });
			//}

			Console.WriteLine("Welcome To SevenFramework! :)");
			Console.WriteLine();
			Console.WriteLine("You are runnning the Data-Structures example.");
			Console.WriteLine("======================================================");
			Console.WriteLine();

			#region Link

			Console.WriteLine("	Testing Link-------------------------------");
			Console.WriteLine("	 Size: 6");
			Link link = new Link<int, int, int, int, int, int>(0, 1, 2, 3, 4, 5);
			Console.Write("		Delegate: ");
			link.Stepper((dynamic current) => { Console.Write(current); });
			Console.WriteLine();
			Console.Write("		IEnumerator: ");
			foreach (object value in link)
				Console.Write(value);
			Console.WriteLine();
			//Console.WriteLine("	Press Enter to continue...");
			//Console.ReadLine();
			Console.WriteLine();

			#endregion
			
			#region Array

			Console.WriteLine("	Testing Array_Array<int>-------------------");
			Array<int> array = new Array_Array<int>(test);
			for (int i = 0; i < test; i++)
				array[i] = i;
			Console.Write("		Delegate: ");
			array.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.Write("		IEnumerator: ");
			foreach (int current in array)
				Console.Write(current);
			Console.WriteLine();
			//Console.WriteLine("	Press Enter to continue...");
			//Console.ReadLine();
			Console.WriteLine();

			#endregion
			
			#region List

			Console.WriteLine("	Testing List_Array<int>--------------------");
			List<int> list_array = new List_Array<int>(test);
			for (int i = 0; i < test; i++)
				list_array.Add(i);
			Console.Write("		Delegate: ");
			list_array.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.Write("		IEnumerator: ");
			foreach (int current in list_array)
				Console.Write(current);
			Console.WriteLine();
			Console.WriteLine();

			Console.WriteLine("	Testing List_Linked<int>-------------------");
			List<int> list_linked = new List_Linked<int>();
			for (int i = 0; i < test; i++)
				list_linked.Add(i);
			Console.Write("		Delegate: ");
			list_linked.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.Write("		IEnumerator: ");
			foreach (int current in list_linked)
				Console.Write(current);
			Console.WriteLine();
			//Console.WriteLine("	Press Enter to continue...");
			//Console.ReadLine();
			Console.WriteLine();

			#endregion

			#region Stack

			Console.WriteLine("	Testing Stack_Linked<int>------------------");
			Stack<int> stack_linked = new Stack_Linked<int>();
			for (int i = 0; i < test; i++)
				stack_linked.Push(i);
			Console.Write("		Delegate: ");
			stack_linked.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.Write("		IEnumerator: ");
			foreach (int current in stack_linked)
				Console.Write(current);
			Console.WriteLine();
			//Console.WriteLine("	Press Enter to continue...");
			//Console.ReadLine();
			Console.WriteLine();

			#endregion

			#region Queue

			Console.WriteLine("	Testing Queue_Linked<int>------------------");
			Queue<int> queue_linked = new Queue_Linked<int>();
			for (int i = 0; i < test; i++)
				queue_linked.Enqueue(i);
			Console.Write("		Delegate: ");
			queue_linked.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.Write("		IEnumerator: ");
			foreach (int current in queue_linked)
				Console.Write(current);
			Console.WriteLine();
			//Console.WriteLine("	Press Enter to continue...");
			//Console.ReadLine();
			Console.WriteLine();

			#endregion

			#region Heap

			Console.WriteLine("	Testing Heap_Array<int>--------------------");
			Heap<int> heap_array = new Heap_Array<int>(Logic.compare);
			for (int i = 0; i < test; i++)
				heap_array.Enqueue(i);
			Console.Write("		Delegate: ");
			heap_array.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.Write("		IEnumerator: ");
			foreach (int current in heap_array)
				Console.Write(current);
			Console.WriteLine();
			//Console.WriteLine("\tPress Enter to continue...");
			//Console.ReadLine();
			Console.WriteLine();

			#endregion

			#region Tree

			Console.WriteLine("	Testing Tree_Map<int>----------------------");
			Tree<int> treeMap = new Tree_Map<int>(0, Logic.equate, Hash.Default);
			for (int i = 1; i < test; i++)
				treeMap.Add(i, i / (int)System.Math.Sqrt(test));
			Console.Write("		Children of 0 (root): ");
			treeMap.Children(0, (int i) => { Console.Write(i + " "); });
			Console.WriteLine();
			Console.Write("		Children of " + ((int)System.Math.Sqrt(test) - 1) + " (root): ");
			treeMap.Children(((int)System.Math.Sqrt(test) - 1), (int i) => { Console.Write(i + " "); });
			Console.WriteLine();
			Console.Write("		Delegate: ");
			treeMap.Stepper((int i) => { Console.Write(i + " "); });
			//Console.WriteLine();
			//Console.Write("		IEnumerator: ");
			//foreach (int current in treeMap)
			//	Console.Write(current);
			Console.WriteLine();
			//Console.WriteLine("\tPress Enter to continue...");
			//Console.ReadLine();
			Console.WriteLine();

			#endregion

			#region AVL Tree

			Console.WriteLine("	Testing AvlTree_Linked<int>----------------");
			// Construction
			AvlTree<int> avlTree_linked = new AvlTree_Linked<int>(Logic.compare);
			// Adding Items
			Console.Write("		Adding (0-" + test + ")...");
			for (int i = 0; i < test; i++)
				avlTree_linked.Add(i);
			Console.WriteLine();
			// Iteration
			Console.Write("		Iteration: ");
			avlTree_linked.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.Write("		IEnumerator: ");
			foreach (int current in avlTree_linked)
				Console.Write(current);
			// Removal
			int avl_tree_linked_removal = random.Next(0, test);
			avlTree_linked.Remove(avl_tree_linked_removal);
			Console.WriteLine();
			Console.Write("		Remove(" + avl_tree_linked_removal + "): ");
			avlTree_linked.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			// Look Up Items
			int avl_tree_linked_lookup = random.Next(0, test);
			while (avl_tree_linked_lookup == avl_tree_linked_removal)
				avl_tree_linked_lookup = random.Next(0, test);
			Console.WriteLine("		Look Up (" + avl_tree_linked_lookup + "): " + avlTree_linked.TryGet(avl_tree_linked_lookup, Logic.compare, out temp));
			Console.WriteLine("		Look Up (" + avl_tree_linked_removal + "): " + avlTree_linked.TryGet(avl_tree_linked_removal, Logic.compare, out temp));
			avlTree_linked.Get(avl_tree_linked_lookup, Logic.compare);
			// Current Min-Max Values
			Console.WriteLine("		Least: " + avlTree_linked.CurrentLeast + " Greatest: " + avlTree_linked.CurrentGreatest);
			//Console.WriteLine("	Press Enter to continue...");
			//Console.ReadLine();
			Console.WriteLine();

			#endregion

			#region Red-Black Tree

			Console.WriteLine("	Testing RedBlack_Linked<int>---------------");
			RedBlackTree<int> redBlackTree_linked = new RedBlackTree_Linked<int>(Logic.compare);
			for (int i = 0; i < test; i++)
				redBlackTree_linked.Add(i);
			Console.Write("		Delegate: ");
			redBlackTree_linked.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.Write("		IEnumerator: ");
			foreach (int current in redBlackTree_linked)
				Console.Write(current);
			Console.WriteLine();
			//Console.WriteLine("	Press Enter to continue...");
			//Console.ReadLine();
			Console.WriteLine();

			#endregion

			#region BTree

			//Console.WriteLine("	Testing BTree_LinkedArray<int>-------------");
			//BTree<int> btree_linked = new BTree_LinkedArray<int>(Logic.compare, 3);
			//for (int i = 0; i < test; i++)
			//	btree_linked.Add(i);
			//Console.Write("		Delegate: ");
			//btree_linked.Stepper((int current) => { Console.Write(current); });
			//Console.WriteLine();
			//Console.Write("		IEnumerator: ");
			//foreach (int current in btree_linked)
			//	Console.Write(current);
			//Console.WriteLine();
			//Console.WriteLine("	Press Enter to continue...");
			//Console.ReadLine();
			//Console.WriteLine();

			#endregion

			#region Map
			
			Console.WriteLine("	Testing Map_Linked<int, int>---------------");
			Map<int, int> hashTable_linked = new Map_Linked<int, int>(Logic<int>.equate, Hash.Default);
			for (int i = 0; i < test; i++)
				hashTable_linked.Add(i, i);
			Console.Write("		Look Ups: ");
			for (int i = 0; i < test; i++)
				Console.Write(hashTable_linked[i]);
			Console.WriteLine();
			Console.Write("		Delegate: ");
			hashTable_linked.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.Write("		IEnumerator: ");
			foreach (int current in hashTable_linked)
				Console.Write(current);
			Console.WriteLine();
			//Console.WriteLine("	Press Enter to continue...");
			//Console.ReadLine();
			Console.WriteLine();

			#endregion

			#region Quad-Tree
			
			Console.WriteLine("	Testing Quadtree_Array<int, double>--------");

			// Construction
			Quadtree<int, double> quadtree_array = new Quadtree_Array<int, double>(
				-test - 1, -test - 1, // minimum dimensions of the quadtree
				test + 1, test + 1, // maximum dimensions of the quadtree
				(int i, out double x, out double y) => { x = i; y = i; }, // 2D location function
				Logic.compare, // axis comparison function
				Statistics.Mean); // axis average function

			// Adding
			for (int i = 0; i < test; i++)
				quadtree_array.Add(i);

			// Proper Traversal
			Console.Write("		Delegate: ");
			quadtree_array.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();

			// Improper Traversal (AVOID "foreach" KEYWORD)
			Console.Write("		IEnumerator: ");
			foreach (int current in quadtree_array)
				Console.Write(current);
			Console.WriteLine();
			Console.WriteLine();

			Console.WriteLine("	Testing Quadtree_Linked<int, double>-------");

			// Construction
			Quadtree<int, double> quadtree_linked = new Quadtree_Linked<int, double>(
				-test - 1, -test - 1, // minimum dimensions of the quadtree
				test + 1, test + 1, // maximum dimensions of the quadtree
				(int i, out double x, out double y) => { x = i; y = i; }, // 2D location function
				Logic.compare, // axis comparison function
				(Quadtree.Average<double>)Statistics.Mean<double>); // axis average function

			// Adding
			for (int i = 0; i < test; i++)
				quadtree_linked.Add(i);

			// Proper Traversal
			Console.Write("		Delegate: ");
			quadtree_linked.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();

			// Improper Traversal (AVOID "foreach" KEYWORD)
			Console.Write("		IEnumerator: ");
			foreach (int current in quadtree_linked)
				Console.Write(current);
			Console.WriteLine();
			//Console.WriteLine("	Press Enter to continue...");
			//Console.ReadLine();
			Console.WriteLine();

			#endregion

			#region Oct-Tree
			
			Console.WriteLine("	Testing Octree_Linked<int, double>---------");

			// Construction
			Octree<int, double> octree_linked = new Octree_Linked<int, double>(
				-test - 1, -test - 1, -test - 1, // minimum dimensions of the octree
				test + 1, test + 1, test + 1, // maximum dimensions of the octree
				(int i, out double x, out double y, out double z) => { x = i; y = i; z = i; }, // 3D location function
				Logic.compare, // axis comparison function
				Statistics.Mean); // axis average function

			// Addition
			for (int i = 0; i < test; i++)
				octree_linked.Add(i);

			// Proper Traversal
			Console.Write("		Delegate: ");
			octree_linked.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();

			// Improper Traversal (AVOID "foreach" KEYWORD)
			Console.Write("		IEnumerator: ");
			foreach (int current in octree_linked)
				Console.Write(current);
			Console.WriteLine();
			//Console.WriteLine("	Press Enter to continue...");
			//Console.ReadLine();
			Console.WriteLine();

			#endregion

			#region Omnitree
			
			Console.WriteLine("	Testing Omnitree_Linked<int, double>-------");

			// Construction
			Omnitree<int, double> omnitree_linked = new Omnitree_LinkedLinkedLists<int, double>(
				new double[] { -test - 1, -test - 1, -test - 1 }, // minimum dimensions of the omnitree
				new double[] { test + 1, test + 1, test + 1 }, // maximum dimensions of the omnitree
				(int i) => { return Accessor.Get(new double[] { i, i, i }); }, // "N-D" location function
				Logic.compare, // axis comparison function
				Statistics.Mean); // axis average function
			Console.WriteLine("			Origin: [" + omnitree_linked.Origin(0) + ", " + omnitree_linked.Origin(1) + ", " + omnitree_linked.Origin(2) + "]");
			Console.WriteLine("			Minimum: [" + omnitree_linked.Min(0) + ", " + omnitree_linked.Min(1) + ", " + omnitree_linked.Min(2) + "]");
			Console.WriteLine("			Maximum: [" + omnitree_linked.Max(0) + ", " + omnitree_linked.Max(1) + ", " + omnitree_linked.Max(2) + "]");
			Console.WriteLine("			Dimensions: " + omnitree_linked.Dimensions);
			Console.WriteLine("			Count: " + omnitree_linked.Count);
			// Addition
			Console.Write("		Adding 0-" + test + ": ");
			for (int i = 0; i < test; i++)
				omnitree_linked.Add(i);
			omnitree_linked.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.WriteLine("			Count: " + omnitree_linked.Count);
			Console.Write("		Foreach [ALL]: ");
			omnitree_linked.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.Write("		Foreach [" + (test / 2) + "-" + test + "]: ");
			omnitree_linked.Stepper((int current) => { Console.Write(current); },
				new double[] { test / 2, test / 2, test / 2 },
				new double[] { test, test, test });
			Console.WriteLine();
			Console.Write("		Remove 0-" + test / 3 + ": ");
			omnitree_linked.Remove(
				new double[] { 0, 0, 0 },
				new double[] { test / 3, test / 3, test / 3 });
			omnitree_linked.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.WriteLine("			Count: " + omnitree_linked.Count);
			Console.Write("		Clear: ");
			omnitree_linked.Clear();
			omnitree_linked.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.WriteLine("			Count: " + omnitree_linked.Count);
			Console.WriteLine();
			//Console.WriteLine("	Press Enter to continue...");
			//Console.ReadLine();
			Console.WriteLine();
			
			Console.WriteLine("	Testing Omnitree_Array<int, double>--------");
			Omnitree<int, double> omnitree_array = new Omnitree_LinkedLinkedLists<int, double>(
				new double[] { -test - 1, -test - 1, -test - 1 }, // minimum dimensions of the omnitree
				new double[] { test + 1, test + 1, test + 1 }, // maximum dimensions of the omnitree
								(int i) => { return Accessor.Get(new double[] { i, i, i }); }, // "N-D" location function
								Logic.compare, // comparison function
								Statistics.Mean); // average function
			Console.WriteLine("			Origin: [" + omnitree_array.Origin(0) + ", " + omnitree_array.Origin(1) + ", " + omnitree_array.Origin(2) + "]");
			Console.WriteLine("			Minimum: [" + omnitree_array.Min(0) + ", " + omnitree_array.Min(1) + ", " + omnitree_array.Min(2) + "]");
			Console.WriteLine("			Maximum: [" + omnitree_array.Max(0) + ", " + omnitree_array.Max(1) + ", " + omnitree_array.Max(2) + "]");
			Console.WriteLine("			Dimensions: " + omnitree_array.Dimensions);
			Console.WriteLine("			Count: " + omnitree_array.Count);
			Console.Write("		Adding 0-" + test + ": ");
			for (int i = 0; i < test; i++)
				omnitree_array.Add(i);
			omnitree_array.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.WriteLine("			Count: " + omnitree_array.Count);
			Console.Write("		Foreach [ALL]: ");
						omnitree_array.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.Write("		Foreach [" + (test / 2) + "-" + test + "]: ");
						omnitree_array.Stepper((int current) => { Console.Write(current); },
				new double[] { test / 2, test / 2, test / 2 },
				new double[] { test, test, test });
			Console.WriteLine();
			Console.Write("		Remove 0-" + test / 3 + ": ");
			omnitree_array.Remove(
				new double[] { 0, 0, 0 },
				new double[] { test / 3, test / 3, test / 3 });
						omnitree_array.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.WriteLine("			Count: " + omnitree_array.Count);
			Console.Write("		Clear: ");
			omnitree_array.Clear();
						omnitree_array.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.WriteLine("			Count: " + omnitree_array.Count);
			Console.WriteLine();
			//Console.WriteLine("	Press Enter to continue...");
			//Console.ReadLine();
			Console.WriteLine();

			#endregion

			#region Graph

			Console.WriteLine("	Testing Graph_SetOmnitree<int>-------------");
			Graph<int> graph = new Graph_SetOmnitree<int>(Logic.equate, Logic.compare, Hash.Default, 0, test, Statistics.Mean);
			// add nodes
			for (int i = 0; i < test; i++)
				graph.Add(i);
			// add edges
			for (int i = 0; i < test - 1; i++)
				graph.Add(i, i + 1);
			Console.Write("		Delegate: ");
			graph.Stepper((int current) => { Console.Write(current); });
			Console.WriteLine();
			Console.Write("		IEnumerator: not yet implemented");
			//foreach (int current in graph)
			//		Console.Write(current);
			Console.WriteLine();
			Console.WriteLine("		Edges: ");
			//((Graph_SetQuadtree<int>)graph)._edges.Foreach((Graph_SetQuadtree<int>.Edge e) => { Console.WriteLine("		 " + e.Start + " " + e.End); });
			graph.Stepper(
					(int current) =>
					{
						Console.Write("		 " + current + ": ");
						graph.Neighbors(current,
						(int a) =>
						{
							Console.Write(a);
						});
						Console.WriteLine();
					});
			Console.WriteLine();

			#endregion

			Console.WriteLine();
			Console.WriteLine("============================================");
			Console.WriteLine("Examples Complete...");
			Console.ReadLine();
		}
	}
}