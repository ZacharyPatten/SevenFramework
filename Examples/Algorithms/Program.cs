using Seven;
using Seven.Structures;
using Seven.Mathematics;
using Seven.Algorithms.GraphSearch;
using System;
using Seven.Algorithms;

namespace Algorithms
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome To SevenFramework! :)");
			Console.WriteLine();
			Console.WriteLine("You are runnning the Algorithms tutorial.");
			Console.WriteLine("======================================================");
			Console.WriteLine();

			#region Sorting

			Console.WriteLine("Sorting Algorithms----------------------");
			Console.WriteLine();
			int[] dataSet = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			Console.Write("Data Set:");
			Console.Write(dataSet[0]);
			for (int i = 1; i < dataSet.Length; i++)
				Console.Write(", " + dataSet[i]);
			Console.WriteLine();

			// Delegates
			Get<int> get = (int index) => { return dataSet[index]; };
			Assign<int> assign = (int index, int value) => { dataSet[index] = value; };
			
			// Shuffling (Randomizing)
			Sort<int>.Shuffle(get, assign, 0, dataSet.Length);
			Console.Write("Shuffle (Randomizing): ");
			Console.Write(dataSet[0]);
			for (int i = 1; i < dataSet.Length; i++)
				Console.Write(", " + dataSet[i]);
			Console.WriteLine();
			
			// Bubble
			Sort<int>.Bubble(Compute<int>.Compare, get, assign, 0, dataSet.Length);
			Console.Write("Bubble: ");
			Console.Write(dataSet[0]);
			for (int i = 1; i < dataSet.Length; i++)
				Console.Write(", " + dataSet[i]);
			Console.WriteLine();

			Sort<int>.Shuffle(get, assign, 0, dataSet.Length);

			// Selection
			Sort<int>.Selection(Compute<int>.Compare, get, assign, 0, dataSet.Length);
			Console.Write("Selection: ");
			Console.Write(dataSet[0]);
			for (int i = 1; i < dataSet.Length; i++)
				Console.Write(", " + dataSet[i]);
			Console.WriteLine();

			Sort<int>.Shuffle(get, assign, 0, dataSet.Length);

			// Insertion
			Sort<int>.Insertion(Compute<int>.Compare, get, assign, 0, dataSet.Length);
			Console.Write("Insertion: ");
			Console.Write(dataSet[0]);
			for (int i = 1; i < dataSet.Length; i++)
				Console.Write(", " + dataSet[i]);
			Console.WriteLine();

			Sort<int>.Shuffle(get, assign, 0, dataSet.Length);

			// Quick
			Sort<int>.Quick(Compute<int>.Compare, get, assign, 0, dataSet.Length);
			Console.Write("Quick: ");
			Console.Write(dataSet[0]);
			for (int i = 1; i < dataSet.Length; i++)
				Console.Write(", " + dataSet[i]);
			Console.WriteLine();

			Sort<int>.Shuffle(get, assign, 0, dataSet.Length);

			// Merge
			Sort<int>.Merge(Compute<int>.Compare, get, assign, 0, dataSet.Length);
			Console.Write("Merge: ");
			Console.Write(dataSet[0]);
			for (int i = 1; i < dataSet.Length; i++)
				Console.Write(", " + dataSet[i]);
			Console.WriteLine();

			Sort<int>.Shuffle(get, assign, 0, dataSet.Length);

			// Heap
			Sort<int>.Heap(Compute<int>.Compare, get, assign, 0, dataSet.Length);
			Console.Write("Heap: ");
			Console.Write(dataSet[0]);
			for (int i = 1; i < dataSet.Length; i++)
				Console.Write(", " + dataSet[i]);
			Console.WriteLine();

			Sort<int>.Shuffle(get, assign, 0, dataSet.Length);

			// OddEven
			Sort<int>.OddEven(Compute<int>.Compare, get, assign, 0, dataSet.Length);
			Console.Write("OddEven: ");
			Console.Write(dataSet[0]);
			for (int i = 1; i < dataSet.Length; i++)
				Console.Write(", " + dataSet[i]);
			Console.WriteLine();

			//Sort<int>.Shuffle(get, set, 0, dataSet.Length);

			//// Slow
			//Sort<int>.Slow(Logic.compare, get, set, 0, dataSet.Length);
			//Console.Write("Slow: ");
			//Console.Write(dataSet[0]);
			//for (int i = 1; i < dataSet.Length; i++)
			//	Console.Write(", " + dataSet[i]);
			//Console.WriteLine();

			Sort<int>.Shuffle(get, assign, 0, dataSet.Length);

			// Bogo
			//Sort<int>.Bogo(Logic.compare, get, set, 0, dataSet.Length);
			Console.Write("Bogo: Enable (uncomment) in Source Code");
			//Console.Write(dataSet[0]);
			//for (int i = 1; i < dataSet.Length; i++)
			//	Console.Write(", " + dataSet[i]);
			//Console.WriteLine();

			Console.WriteLine();
			Console.WriteLine();

			#endregion

			#region Graph Search

			Console.WriteLine("Graph Searching----------------------");
			Console.WriteLine();

			// make a graph
			Graph<int> graph = new Graph_SetOmnitree<int>(
				Compute<int>.Compare, 
				Hash.Default, 
				0, 3, 
				(int l, int r) => { return (l + r) / 2; });

			// add nodes
			graph.Add(0);
			graph.Add(1);
			graph.Add(2);
			graph.Add(3);

			// add edges
			graph.Add(0, 1);
			graph.Add(0, 2);
			graph.Add(1, 3);
			graph.Add(2, 3);

			//// represent a graph
			//// Note: can be any type  (doesn't have to be int?[,])
			//int?[,] adjacencyMatrix = 
			//{
			//	{ null, 1, 2, null },
			//	{ null, null, null, 5 },
			//	{ null, null, null, 1 },
			//	{ null, null, null, null }
			//};

			// make a delegate for finding neighbor nodes
			Action<int, Step<int>> neighbors =
				(int current, Step<int> step_function) =>
				{
					//for (int i = 0; i < 4; i++)
					//	if (adjacencyMatrix[current, i] != null)
					//		step(i);
					graph.Neighbors(current, step_function);
				};

			// make a delegate for computing heuristics
			Func<int, int> heuristic =
				(int node) =>
					{
						switch (node)
						{
							case 0:
								return 3;
							case 1:
								return 6;
							case 2:
								return 1;
							case 3:
								return 0;
							default:
								throw new NotImplementedException();
						}
					};

			// make a delegate for computing costs
			Func<int, int, int> cost =
				(int from, int to) =>
					{
						if (from == 0 && to == 1)
							return 1;
						if (from == 0 && to == 2)
							return 2;
						if (from == 1 && to == 3)
							return 5;
						if (from == 2 && to == 3)
							return 1;
						throw new Exception("invalid path cost computation");
					};

			// make a delegate for determining if the goal is reached
			Func<int, bool> goal =
				(int node) =>
					{
						if (node == 3)
							return true;
						else
							return false;
					};

			// run A* the algorithm
			Stepper<int> aStar_path = AStar<int, int>.Run(
				0,
				new AStar<int, int>.Neighbors(neighbors),
				new AStar<int, int>.Heuristic(heuristic),
				new AStar<int, int>.Cost(cost),
				new AStar<int, int>.Goal(goal));

			// run the Greedy algorithm
			Stepper<int> greedy_path = Greedy<int, int>.Run(
				0,
				new Greedy<int, int>.Neighbors(neighbors),
				new Greedy<int, int>.Heuristic(heuristic),
				new Greedy<int, int>.Goal(goal));

			Console.Write("A* Path: ");
			if (aStar_path != null)
				aStar_path((int i) => { System.Console.Write(i + " "); });
			else
				Console.Write("none");

			Console.WriteLine();

			Console.Write("Greedy Path: ");
			if (greedy_path != null)
				greedy_path((int i) => { System.Console.Write(i + " "); });
			else
				Console.Write("none");
			Console.WriteLine();

			#endregion

			Console.WriteLine();
			Console.WriteLine("============================================");
			Console.WriteLine("Example Complete...");
			Console.ReadLine();
		}
	}
}
