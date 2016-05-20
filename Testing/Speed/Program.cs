using Seven;
using Seven.Mathematics;
using Seven.Structures;
using Seven.Algorithms;
using Seven.Diagnostics;

using System;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

namespace Speed
{
	public class IntegerClass
	{
		public int _int;

		public IntegerClass(int integer)
		{
			this._int = integer;
		}

		public static bool operator <(IntegerClass a, IntegerClass b)
		{
			return a._int < b._int;
		}

		public static bool operator >(IntegerClass a, IntegerClass b)
		{
			return a._int > b._int;
		}

		public static bool operator ==(IntegerClass a, IntegerClass b)
		{
			if (object.ReferenceEquals(a, null))
				if (object.ReferenceEquals(b, null))
					return true;
				else
					return false;
			if (object.ReferenceEquals(b, null))
				return false;
			return a._int == b._int;
		}

		public static bool operator !=(IntegerClass a, IntegerClass b)
		{
			if (object.ReferenceEquals(a, null))
				if (object.ReferenceEquals(b, null))
					return false;
				else
					return true;
			if (object.ReferenceEquals(b, null))
				return true;
			return a._int != b._int;
		}

		public override bool Equals(object obj)
		{
			if (obj is IntegerClass)
				return this == (obj as IntegerClass);
			return base.Equals(obj);
		}

		public static implicit operator IntegerClass(int integer)
		{
			return new IntegerClass(integer);
		}

		public override int GetHashCode()
		{
			return this._int % 10;
			//return base.GetHashCode();
		}
	}

	class Program
	{

		//internal static int GetPrime(int min) {
		//				Debug.Assert(min >= 0, "min less than zero; handle overflow checking before calling HashHelpers"); 
 
		//				for (int i = 0; i < primes.Length; i++) { 
		//						int prime = primes[i]; 
		//						if (prime >= min) {
		//								return prime; 
		//						}
		//				}
 
		//				// Outside of our predefined table. Compute the hard way. 
		//				for (int i = (min | 1); i < Int32.MaxValue; i += 2) {
		//						if (IsPrime(i)) { 
		//								return i; 
		//						}
		//				} 
		//				return min;
		//		}
 
		//		internal static int GetMinPrime() { 
		//				return primes[0];
		//		} 
		//} 

		static void Main(string[] args)
		{
			//Console.WriteLine("This example is mainly for speed testing during development.");
			//Console.WriteLine("See the other examples provided for clearer usage examples.");
			//Console.WriteLine();

			//IntegerClass[] array = new IntegerClass[] { 0, 1, 2, null, 3, null, 4 };
			//array.

			//string random = RandomString(int.MaxValue / 50);
			//string temp1;
			//string temp2;

			//Console.WriteLine("Reverse1:      " + Seven.Diagnostics.Performance.Time(() => { temp1 = Reverse1(random); }));
			//Console.WriteLine("Reverse2:      " + Seven.Diagnostics.Performance.Time(() => { temp2 = Reverse2(random); }));

			Console.WriteLine(new int[0]);

			Console.WriteLine(@"1
2
3".PadLinesLeft("        ", 2, 4));


			#region Set Tests
			//{
			//	int iterations = int.MaxValue / 1000;

			//	HashSet<int> validation = new HashSet<int>();
			//	//for (int i = 0; i < interations; i++)
			//	//	validation.Add(i);

			//	{
			//		HashSet<int> set0 = new HashSet<int>();
			//		SetHashList<int> set1 = new SetHashList<int>();
			//		SetHashArray<int> set2 = new SetHashArray<int>();

			//		for (int i = 0; i < iterations; i++) set0.Add(i);
			//		for (int i = 0; i < iterations; i++) set1.Add(i);
			//		for (int i = 0; i < iterations; i++) set2.Add(i);
			//		for (int i = 0; i < iterations; i++)
			//			validation.Add(i);
			//		foreach (int i in set0) { validation.Remove(i); }
			//		for (int i = 0; i < iterations; i++)
			//			validation.Add(i);
			//		set1.Stepper((int i) => { validation.Remove(i); });
			//		for (int i = 0; i < iterations; i++)
			//			validation.Add(i);
			//		set2.Stepper((int i) => { validation.Remove(i); });
			//		for (int i = 0; i < iterations; i++) set0.Contains(i);
			//		for (int i = 0; i < iterations; i++) set1.Contains(i);
			//		for (int i = 0; i < iterations; i++) set2.Contains(i);
			//		for (int i = 0; i < iterations; i++) set0.Remove(i);
			//		for (int i = 0; i < iterations; i++) set1.Remove(i);
			//		for (int i = 0; i < iterations; i++) set2.Remove(i);

			//		Console.WriteLine("Adding HashSet:               " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) set0.Add(i); }));
			//		Console.WriteLine("Adding Set_HashLinkedList:    " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) set1.Add(i); }));
			//		Console.WriteLine("Adding SetHash:               " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) set2.Add(i); }));

			//		for (int i = 0; i < iterations; i++)
			//			validation.Add(i);
			//		foreach (int i in set0) { validation.Remove(i); }
			//		Console.WriteLine("Validate HashSet:             " + (validation.Count == 0));

			//		for (int i = 0; i < iterations; i++)
			//			validation.Add(i);
			//		set1.Stepper((int i) => { validation.Remove(i); });
			//		Console.WriteLine("Validate Set_HashLinkedList:  " + (validation.Count == 0));

			//		for (int i = 0; i < iterations; i++)
			//			validation.Add(i);
			//		set2.Stepper((int i) => { validation.Remove(i); });
			//		Console.WriteLine("Validate SetHas:              " + (validation.Count == 0));

			//		Console.WriteLine("Size HashSet:                 " + (typeof(HashSet<int>).GetField("m_buckets", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(set0) as int[]).Length);
			//		Console.WriteLine("Size Set_HashLinkedList:      " + set1.TableSize);
			//		Console.WriteLine("Size SetHash:                 " + set2.TableSize);

			//		Console.WriteLine("Constains HashSet:            " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) set0.Contains(i); }));
			//		Console.WriteLine("Constains Set_HashLinkedList: " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) set1.Contains(i); }));
			//		Console.WriteLine("Constains SetHash:            " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) set2.Contains(i); }));

			//		//Console.WriteLine("Removed HashSet:              " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) set0.Remove(i); }));
			//		//Console.WriteLine("Removed Set_HashLinkedList:   " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) set1.Remove(i); }));
			//		//Console.WriteLine("Remove SetHash:               " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) set2.Remove(i); }));

			//		Console.WriteLine("Removed HashSet:              " + Seven.Diagnostics.Performance.Time(() => { for (int i = iterations - 1; i >= 0; i--) set0.Remove(i); }));
			//		Console.WriteLine("Removed Set_HashLinkedList:   " + Seven.Diagnostics.Performance.Time(() => { for (int i = iterations - 1; i >= 0; i--) set1.Remove(i); }));
			//		Console.WriteLine("Remove SetHash:               " + Seven.Diagnostics.Performance.Time(() => { for (int i = iterations - 1; i >= 0; i--) set2.Remove(i); }));

			//		Console.WriteLine("Size HashSet:                 " + (typeof(HashSet<int>).GetField("m_buckets", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(set0) as int[]).Length);
			//		Console.WriteLine("Size Set_HashLinkedList:      " + set1.TableSize);
			//		Console.WriteLine("Size SetHash:                 " + set2.TableSize);
			//	}

			//	Console.WriteLine();
			//}
			#endregion

			#region Map/Dictionary
			//{
			//	int iterations = int.MaxValue / 10000;

			//	HashSet<int> validation = new HashSet<int>();
			//	//for (int i = 0; i < interations; i++)
			//	//	validation.Add(i);

			//	{
			//		Dictionary<int, int> map0 = new Dictionary<int, int>();
			//		//MapSetHashList<int, int> map1 = new MapSetHashList<int, int>();
			//		MapHashLinked<int, int> map2 = new MapHashLinked<int, int>();
			//		MapHashArray<int, int> map3 = new MapHashArray<int, int>();


			//		Console.WriteLine("Adding 0:    " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) map0.Add(i, i); }));
			//		//Console.WriteLine("Adding 1:    " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) map1.Add(i, i); }));
			//		Console.WriteLine("Adding 2:    " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) map2.Add(i, i); }));
			//		Console.WriteLine("Adding 3:    " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) map3.Add(i, i); }));

			//		for (int i = 0; i < iterations; i++)
			//			validation.Add(i);
			//		foreach (KeyValuePair<int, int> i in map0) { validation.Remove(i.Key); }
			//		Console.WriteLine("Validate 0:  " + (validation.Count == 0));

			//		//for (int i = 0; i < iterations; i++)
			//		//	validation.Add(i);
			//		////foreach (int i in map1) { validation.Remove(i); }
			//		//map1.Stepper((int i) => { validation.Remove(i); });
			//		//Console.WriteLine("Validate 1:  " + (validation.Count == 0));

			//		for (int i = 0; i < iterations; i++)
			//			validation.Add(i);
			//		//foreach (int i in map1) { validation.Remove(i); }
			//		map2.Stepper((int i) => { validation.Remove(i); });
			//		Console.WriteLine("Validate 2:  " + (validation.Count == 0));

			//		for (int i = 0; i < iterations; i++)
			//			validation.Add(i);
			//		//foreach (int i in map1) { validation.Remove(i); }
			//		map3.Stepper((int i) => { validation.Remove(i); });
			//		Console.WriteLine("Validate 3:  " + (validation.Count == 0));

			//		int temp;
			//		Console.WriteLine("Get 0:       " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) temp = map0[i]; }));
			//		//Console.WriteLine("Get 1:       " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) temp = map1[i]; }));
			//		Console.WriteLine("Get 2:       " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) temp = map2[i]; }));
			//		Console.WriteLine("Get 3:       " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) temp = map3[i]; }));

			//		Console.WriteLine("Removed 0:   " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) map0.Remove(i); }));
			//		//Console.WriteLine("Removed 1:   " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) map1.Remove(i); }));
			//		Console.WriteLine("Removed 2:   " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) map2.Remove(i); }));
			//		Console.WriteLine("Removed 3:   " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) map3.Remove(i); }));
			//	}
			//}
			#endregion

			#region Vector Test

			//Console.WriteLine();
			//Console.WriteLine("Vector Testing-------------------------------------");

			//Random random = new Random();
			//const int vector_size = 4;
			//const int vector_iterations = int.MaxValue / 100;

			//Vector<double> vector_a = new Vector<double>(vector_size);
			//Vector<double> vector_b = new Vector<double>(vector_size);
			//Vector<double> vector_c;

			//for (int i = 0; i < vector_size; i++)
			//{
			//	vector_a[i] = random.Next();
			//	vector_b[i] = random.Next();
			//}

			//Console.WriteLine("Compile 1: " + Seven.Diagnostics.Performance.Time(() => { vector_c = Vector<double>.Vector_Add(vector_a, vector_b); }));
			//Console.WriteLine("Compile 2: " + Seven.Diagnostics.Performance.Time(() => { vector_c = Vector<double>.Vector_Add2(vector_a, vector_b); }));
			//Console.WriteLine("Compile 3: " + Seven.Diagnostics.Performance.Time(() => { vector_c = Vector<double>.Vector_Add3(vector_a, vector_b); }));
			//Console.WriteLine("Compile 4: " + Seven.Diagnostics.Performance.Time(() => { vector_c = Vector<double>.Vector_Add4(vector_a, vector_b); }));

			//Console.WriteLine("Test 1:    " + Seven.Diagnostics.Performance.Time(() => {
			//	for (int i = 0; i < vector_iterations; i++)
			//		vector_c = Vector<double>.Vector_Add(vector_a, vector_b);
			//}));

			//Console.WriteLine("Test 2:    " + Seven.Diagnostics.Performance.Time(() =>
			//{
			//	for (int i = 0; i < vector_iterations; i++)
			//		vector_c = Vector<double>.Vector_Add2(vector_a, vector_b);
			//}));

			//Console.WriteLine("Test 3:    " + Seven.Diagnostics.Performance.Time(() =>
			//{
			//	for (int i = 0; i < vector_iterations; i++)
			//		vector_c = Vector<double>.Vector_Add3(vector_a, vector_b);
			//}));

			//Console.WriteLine("Test 4:    " + Seven.Diagnostics.Performance.Time(() =>
			//{
			//	for (int i = 0; i < vector_iterations; i++)
			//		vector_c = Vector<double>.Vector_Add4(vector_a, vector_b);
			//}));

			#endregion

			#region Sorting Speed
			//{
			//	int size = int.MaxValue / 1000000;
			//	int[] dataSet = new int[size];
			//	for (int i = 0; i < size; i++)
			//		dataSet[i] = i;

			//	Console.WriteLine("Sorting Algorithms----------------------");
			//	Console.WriteLine();

			//	//Sort<int>.Shuffle(dataSet);
			//	//Console.Write("Bubble:      " + Seven.Diagnostics.Performance.Time(() => { Sort<int>.Bubble(dataSet); }));
			//	Sort<int>.Shuffle(dataSet);
			//	Console.WriteLine("Selection:   " + Seven.Diagnostics.Performance.Time(() => { Sort<int>.Selection(dataSet); }));
			//	Sort<int>.Shuffle(dataSet);
			//	Console.WriteLine("Insertion:   " + Seven.Diagnostics.Performance.Time(() => { Sort<int>.Insertion(dataSet); }));
			//	Sort<int>.Shuffle(dataSet);
			//	Console.WriteLine("Quick:       " + Seven.Diagnostics.Performance.Time(() => { Sort<int>.Quick(dataSet); }));
			//	Sort<int>.Shuffle(dataSet);
			//	Console.WriteLine("Merge:       " + Seven.Diagnostics.Performance.Time(() => { Sort<int>.Merge(dataSet); }));
			//	Sort<int>.Shuffle(dataSet);
			//	Console.WriteLine("Heap:        " + Seven.Diagnostics.Performance.Time(() => { Sort<int>.Heap(dataSet); }));
			//	Sort<int>.Shuffle(dataSet);
			//	Console.WriteLine("OddEven:     " + Seven.Diagnostics.Performance.Time(() => { Sort<int>.OddEven(dataSet); }));

			//	Sort<int>.Shuffle(dataSet);
			//	Console.WriteLine("IEnumerable: " + Seven.Diagnostics.Performance.Time(() => { dataSet.OrderBy(item => item); }));
			//	Sort<int>.Shuffle(dataSet);
			//	Console.WriteLine("Array.Sort:  " + Seven.Diagnostics.Performance.Time(() => { Array.Sort(dataSet); }));
			//}
			#endregion

			//Random random = new Random();
			//const int matrix_rows = 4;
			//const int matrix_columns = 4;
			//const int matrix_iterations = int.MaxValue / 100;

			//{

			//	Seven.Mathematics.Matrix<double> matrix_a = new Seven.Mathematics.Matrix<double>(matrix_rows, matrix_columns);
			//	Seven.Mathematics.Matrix<double> matrix_b = new Seven.Mathematics.Matrix<double>(matrix_rows, matrix_columns);
			//	Seven.Mathematics.Matrix<double> matrix_c;

			//	matrix_c = matrix_a + matrix_b;
			//	matrix_c = matrix_b + matrix_a;
			//	//matrix_a = matrix_b + matrix_c;
			//	//matrix_a = matrix_c + matrix_b;

			//	for (int i = 0; i < matrix_rows; i++)
			//		for (int j = 0; j < matrix_columns; j++)
			//		{
			//			matrix_a[i, j] = random.Next();
			//			matrix_b[i, j] = random.Next();
			//		}

			//	Console.WriteLine("Test 1:    " + Seven.Diagnostics.Performance.Time(() =>
			//	{
			//		for (int i = 0; i < matrix_iterations; i++)
			//			matrix_c = matrix_a + matrix_b;
			//	}));

			//matrix_c = Matrix<double>.Matrix_Negate2(matrix_a);
			//Console.WriteLine("Test 2:    " + Seven.Diagnostics.Performance.Time(() =>
			//{
			//	for (int i = 0; i < matrix_iterations; i++)
			//		matrix_c = Matrix<double>.Matrix_Negate2(matrix_a);
			//}));

			//Console.WriteLine("Test 2:    " + Seven.Diagnostics.Performance.Time(() =>
			//{
			//	for (int i = 0; i < matrix_iterations; i++)
			//		Matrix<double>.Matrix_IsSymetric2(matrix_a);
			//}));

			//Console.WriteLine("Compile 1: " + Seven.Diagnostics.Performance.Time(() => { matrix_c = matrix_a + matrix_b; }));

			//Console.WriteLine("Test 1:    " + Seven.Diagnostics.Performance.Time(() =>
			//{
			//	for (int i = 0; i < matrix_iterations; i++)
			//		matrix_c = matrix_a + matrix_b;
			//}));

			//}

			Console.WriteLine();
			Console.WriteLine("Done...");
			Console.ReadLine();
		}
	}
}
