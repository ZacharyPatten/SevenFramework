using Seven;
using Seven.Mathematics;
using Seven.Structures;
using Seven.Algorithms;
using Seven.Diagnostics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Reflection;

namespace Speed
{
	#region IntegerClass

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

	#endregion

	#region TestObject
	public class TestObject
	{
		public int Id { get; set; }
		public double X { get; set; }
		public double Y { get; set; }
		public double Z { get; set; }

		public TestObject(int id, double x, double y, double z)
		{
			this.Id = id;
			this.X = x;
			this.Y = y;
			this.Z = z;
		}
	}
	#endregion

	class Program
	{
		static void Test()
		{
			Console.WriteLine();
		}

		static void Main(string[] args)
		{
			#region Delegate
			//Action test1 = () => { Console.WriteLine("test 1"); };
			//Action test2 = () => { Console.WriteLine("test 2"); };

			//Action action = test1;

			////foreach (byte b in test1.Method.GetMethodBody().GetILAsByteArray())
			////	Console.WriteLine(b);
			////
			////foreach (System.Reflection.FieldInfo field in typeof(Action).GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
			////	Console.WriteLine(field);

			//action();
			////Console.WriteLine(typeof(Action).GetField("_target", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).GetValue(action));

			//IntPtr methodPtr = (IntPtr)typeof(Action).GetField("_methodPtr", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).GetValue(test2);
			//IntPtr methodPtrAux = (IntPtr)typeof(Action).GetField("_methodPtrAux", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).GetValue(test2);
			//object target = typeof(Action).GetField("_target", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).GetValue(test2);
			//object methodBase = typeof(Action).GetField("_methodBase", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).GetValue(test2);

			////typeof(Action).GetField("_methodPtr", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(action, methodPtr);
			////typeof(Action).GetField("_methodPtrAux", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(action, methodPtrAux);
			////typeof(Action).GetField("_target", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(action, target);
			////typeof(Action).GetField("_methodBase", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(action, methodBase);

			//byte[] array = test1.Method.GetMethodBody().GetILAsByteArray();
			//System.Runtime.InteropServices.GCHandle pinnedArray = System.Runtime.InteropServices.GCHandle.Alloc(array, System.Runtime.InteropServices.GCHandleType.Pinned);
			//IntPtr pointer = pinnedArray.AddrOfPinnedObject();

			//typeof(Action).GetField("_methodPtrAux", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(action, pointer);

			//pinnedArray.Free();

			//action();
			////Console.WriteLine(typeof(Action).GetField("_target", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).GetValue(action));

			//System.Action<System.String, System.Int32, System.Double>
			//System.Action`3[System.String, System.Int32, System.Double]

			//int i = 0;
			//foreach (string s in "Action<int, double, decimal>".Split('<', '>'))
			//	Console.WriteLine(i++ + " "+ s);

			//Console.WriteLine(string.IsNullOrWhiteSpace("Action<int, double, decimal>".Split('<', '>')["Action<int, double, decimal>".Split('<', '>').Length - 1]));

			//Console.WriteLine(Type.GetType("System.Action`3[System.String, System.Int32, System.Double]"));
			//Console.WriteLine(Type.GetType("Action<int>"));
			//Console.WriteLine(typeof(Action<int>).Name);
			//Console.WriteLine(typeof(Action<float>).Name);
			//Console.WriteLine(typeof(Action<double>).Name);
			//Console.WriteLine(typeof(Action<decimal>).Name);
			//Console.WriteLine(typeof(System.Collections.Generic.List<int>).Name);
			//Console.WriteLine(typeof(System.Collections.Generic.List<float>).Name);
			//Console.WriteLine(typeof(System.Collections.Generic.List<double>).Name);
			//Console.WriteLine(typeof(System.Collections.Generic.List<decimal>).Name);

			//Console.WriteLine(Type.GetType("List'1"));

			//Action test2 = Test;
			
			//Console.WriteLine(typeof(Action).GetField("_methodPtr", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).GetValue(test2));
			//Console.WriteLine(typeof(Action).GetField("_methodPtrAux", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).GetValue(test2));
			//Console.WriteLine(typeof(Action).GetField("_target", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).GetValue(test2));
			//Console.WriteLine(typeof(Action).GetField("_methodBase", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).GetValue(test2));
			//Console.WriteLine(test2.Truncate().Target);
			//Console.WriteLine(test2.Truncate().Method.DeclaringType.Name);

			//Action d = (Action)Delegate.CreateDelegate(typeof(Action), test2.Method);

			//114
			//1
			//0
			//0
			//112
			//40
			//22
			//0
			//0
			//10
			//42
			//System.Object _target
			//System.Object _methodBase
			//IntPtr _methodPtr
			//IntPtr _methodPtrAux


			#endregion

			#region Random Generators

			//int iterationsperrandom = 3;
			//Action<Random> testrandom = (Random random) =>
			//	{
			//		for (int i = 0; i < iterationsperrandom; i++)
			//			Console.WriteLine(i + ": " + random.Next());
			//		Console.WriteLine();
			//	};
			//Arbitrary mcg_2pow59_13pow13 = Arbitrary.MultiplicativeCongruentGenerator_Modulus2power59_Multiplier13power13();
			//Console.WriteLine("mcg_2pow59_13pow13 randoms:");
			//testrandom(mcg_2pow59_13pow13);
			//Arbitrary mcg_2pow31m1_1132489760 = Arbitrary.MultiplicativeCongruentGenerator_Modulus2power31minus1_Multiplier1132489760();
			//Console.WriteLine("mcg_2pow31m1_1132489760 randoms:");
			//testrandom(mcg_2pow31m1_1132489760);
			//Arbitrary mersenneTwister = Arbitrary.MersenneTwister();
			//Console.WriteLine("mersenneTwister randoms:");
			//testrandom(mersenneTwister);
			//Arbitrary cmr32_c2_o3 = Arbitrary.CombinedMultipleRecursiveGenerator32bit_components2_order3();
			//Console.WriteLine("mersenneTwister randoms:");
			//testrandom(cmr32_c2_o3);
			//Arbitrary wh1982cmcg = Arbitrary.WichmannHills1982_CombinedMultiplicativeCongruentialGenerator();
			//Console.WriteLine("mersenneTwister randoms:");
			//testrandom(wh1982cmcg);
			//Arbitrary wh2006cmcg = Arbitrary.WichmannHills2006_CombinedMultiplicativeCongruentialGenerator();
			//Console.WriteLine("mersenneTwister randoms:");
			//testrandom(wh2006cmcg);
			//Arbitrary mwcxorsg = Arbitrary.MultiplyWithCarryXorshiftGenerator();
			//Console.WriteLine("mwcxorsg randoms:");
			//testrandom(mwcxorsg);

			#endregion

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

			//		Console.WriteLine("Adding HashSet:               " + Seven.Diagnostics.Performance.Time_DateTimNow(() => { for (int i = 0; i < iterations; i++) set0.Add(i); }));
			//		Console.WriteLine("Adding Set_HashLinkedList:    " + Seven.Diagnostics.Performance.Time_DateTimNow(() => { for (int i = 0; i < iterations; i++) set1.Add(i); }));
			//		Console.WriteLine("Adding SetHash:               " + Seven.Diagnostics.Performance.Time_DateTimNow(() => { for (int i = 0; i < iterations; i++) set2.Add(i); }));

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

			//		Console.WriteLine("Constains HashSet:            " + Seven.Diagnostics.Performance.Time_DateTimNow(() => { for (int i = 0; i < iterations; i++) set0.Contains(i); }));
			//		Console.WriteLine("Constains Set_HashLinkedList: " + Seven.Diagnostics.Performance.Time_DateTimNow(() => { for (int i = 0; i < iterations; i++) set1.Contains(i); }));
			//		Console.WriteLine("Constains SetHash:            " + Seven.Diagnostics.Performance.Time_DateTimNow(() => { for (int i = 0; i < iterations; i++) set2.Contains(i); }));

			//		//Console.WriteLine("Removed HashSet:              " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) set0.Remove(i); }));
			//		//Console.WriteLine("Removed Set_HashLinkedList:   " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) set1.Remove(i); }));
			//		//Console.WriteLine("Remove SetHash:               " + Seven.Diagnostics.Performance.Time(() => { for (int i = 0; i < iterations; i++) set2.Remove(i); }));

			//		Console.WriteLine("Removed HashSet:              " + Seven.Diagnostics.Performance.Time_DateTimNow(() => { for (int i = iterations - 1; i >= 0; i--) set0.Remove(i); }));
			//		Console.WriteLine("Removed Set_HashLinkedList:   " + Seven.Diagnostics.Performance.Time_DateTimNow(() => { for (int i = iterations - 1; i >= 0; i--) set1.Remove(i); }));
			//		Console.WriteLine("Remove SetHash:               " + Seven.Diagnostics.Performance.Time_DateTimNow(() => { for (int i = iterations - 1; i >= 0; i--) set2.Remove(i); }));

			//		Console.WriteLine("Size HashSet:                 " + (typeof(HashSet<int>).GetField("m_buckets", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(set0) as int[]).Length);
			//		Console.WriteLine("Size Set_HashLinkedList:      " + set1.TableSize);
			//		Console.WriteLine("Size SetHash:                 " + set2.TableSize);
			//	}
			//	Console.WriteLine();
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

			//		Console.WriteLine("Adding HashSet:               " + Seven.Diagnostics.Performance.Time_StopWatch(() => { for (int i = 0; i < iterations; i++) set0.Add(i); }));
			//		Console.WriteLine("Adding Set_HashLinkedList:    " + Seven.Diagnostics.Performance.Time_StopWatch(() => { for (int i = 0; i < iterations; i++) set1.Add(i); }));
			//		Console.WriteLine("Adding SetHash:               " + Seven.Diagnostics.Performance.Time_StopWatch(() => { for (int i = 0; i < iterations; i++) set2.Add(i); }));

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

			//		Console.WriteLine("Constains HashSet:            " + Seven.Diagnostics.Performance.Time_StopWatch(() => { for (int i = 0; i < iterations; i++) set0.Contains(i); }));
			//		Console.WriteLine("Constains Set_HashLinkedList: " + Seven.Diagnostics.Performance.Time_StopWatch(() => { for (int i = 0; i < iterations; i++) set1.Contains(i); }));
			//		Console.WriteLine("Constains SetHash:            " + Seven.Diagnostics.Performance.Time_StopWatch(() => { for (int i = 0; i < iterations; i++) set2.Contains(i); }));

			//		//Console.WriteLine("Removed HashSet:              " + Seven.Diagnostics.Performance.Time2(() => { for (int i = 0; i < iterations; i++) set0.Remove(i); }));
			//		//Console.WriteLine("Removed Set_HashLinkedList:   " + Seven.Diagnostics.Performance.Time2(() => { for (int i = 0; i < iterations; i++) set1.Remove(i); }));
			//		//Console.WriteLine("Remove SetHash:               " + Seven.Diagnostics.Performance.Time2(() => { for (int i = 0; i < iterations; i++) set2.Remove(i); }));

			//		Console.WriteLine("Removed HashSet:              " + Seven.Diagnostics.Performance.Time_StopWatch(() => { for (int i = iterations - 1; i >= 0; i--) set0.Remove(i); }));
			//		Console.WriteLine("Removed Set_HashLinkedList:   " + Seven.Diagnostics.Performance.Time_StopWatch(() => { for (int i = iterations - 1; i >= 0; i--) set1.Remove(i); }));
			//		Console.WriteLine("Remove SetHash:               " + Seven.Diagnostics.Performance.Time_StopWatch(() => { for (int i = iterations - 1; i >= 0; i--) set2.Remove(i); }));

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

			#region Matrix Test

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

			#endregion

			#region Omnitree

			Omnitree.Locate<TestObject, double> locate = (TestObject record) =>
			{
				return (int i) =>
				{
					switch (i)
					{
						case 0:
							return record.X;
						case 1:
							return record.Y;
						case 2:
							return record.Z;
						default:
							throw new System.Exception();
					}
				};
			};

			Compute<double>.Compare(0, 0);
			Omnitree<TestObject, double> omnitree = new OmnitreeLinked<TestObject, double>(
				3,
				Accessor.Get(new double[] { 0, 0, 0 }),
				Accessor.Get(new double[] { 1, 1, 1 }),
				locate,
				(double a, double b) => { return a == b; },
				Equate.Default,
				Compute<double>.Compare,
				(double a, double b) => { return (a + b) / 2; });

			System.Collections.Generic.List<TestObject> list = new System.Collections.Generic.List<TestObject>();

			System.Collections.Generic.LinkedList<TestObject> linkedlist = new System.Collections.Generic.LinkedList<TestObject>();

			Random random = new Random(7);
			int count = 10000;
			TestObject[] records = new TestObject[count];
			for (int i = 0; i < count; i++)
				records[i] = new TestObject(i, random.NextDouble(), random.NextDouble(), random.NextDouble());

			Console.WriteLine("Testing with " + count + " records...");
			Console.WriteLine();

			Console.WriteLine("Adding (Omnitree):          " + Seven.Diagnostics.Performance.Time_StopWatch(() =>
				{
					for (int i = 0; i < count; i++)
						omnitree.Add(records[i]);
				}));

			Console.WriteLine("Adding (List):              " + Seven.Diagnostics.Performance.Time_StopWatch(() =>
			{
				for (int i = 0; i < count; i++)
					list.Add(records[i]);
			}));

			Console.WriteLine("Adding (L-List):            " + Seven.Diagnostics.Performance.Time_StopWatch(() =>
			{
				for (int i = 0; i < count; i++)
					linkedlist.AddLast(records[i]);
			}));

			Console.WriteLine();

			Sort<TestObject>.Shuffle(random, Accessor.Get(records), Accessor.Assign(records), 0, records.Length);

			Console.WriteLine("Querying Single (Omnitree): " + Seven.Diagnostics.Performance.Time_StopWatch(() =>
				{
					bool query_test;
					for (int i = 0; i < count; i++)
					{
						query_test = false;
						omnitree[locate(records[i])]((TestObject record) => { query_test = true; });
						//omnitree[records[i].X, records[i].Y, records[i].Z]((TestObject record) => { query_test = true; });
						if (query_test == false)
							throw new System.Exception();
					}
				}));

			Console.WriteLine("Querying Single (List):     " + Seven.Diagnostics.Performance.Time_StopWatch(() =>
			{
				bool query_test = false;
				for (int i = 0; i < count; i++)
				{
					foreach (TestObject record in list)
					{
						if (record.X == records[i].X && record.Y == records[i].Y && record.Z == records[i].Z)
						{
							query_test = true;
							break;
						}
					}
					if (query_test == false)
						throw new System.Exception();
				}
			}));

			Console.WriteLine("Querying Single (L-List):   " + Seven.Diagnostics.Performance.Time_StopWatch(() =>
			{
				bool query_test = false;
				for (int i = 0; i < count; i++)
				{
					foreach (TestObject record in linkedlist)
					{
						if (record.X == records[i].X && record.Y == records[i].Y && record.Z == records[i].Z)
						{
							query_test = true;
							break;
						}
					}
					if (query_test == false)
						throw new System.Exception();
				}
			}));

			Console.WriteLine();

			int random_query_count = count / 100;
			double[][] random_mins = new double[random_query_count][];
			for (int i = 0; i < random_query_count; i++)
				random_mins[i] = new double[] { random.NextDouble(), random.NextDouble(), random.NextDouble(), };
			double[][] random_maxes = new double[random_query_count][];
			for (int i = 0; i < random_query_count; i++)
				random_maxes[i] = new double[] { 
					random.NextDouble() * ((1 - random_mins[i][0]) + random_mins[i][0]), 
					random.NextDouble() * ((1 - random_mins[i][1]) + random_mins[i][1]),
					random.NextDouble() * ((1 - random_mins[i][2]) + random_mins[i][2]) };

			Console.WriteLine(random_query_count + " random range queries...");

			int[] query_count_omnitree = new int[random_query_count];
			int[] query_count_list = new int[random_query_count];
			int[] query_count_linkedlist = new int[random_query_count];

			Console.WriteLine("Querying Range (Omnitree):  " + Seven.Diagnostics.Performance.Time_StopWatch(() =>
			{
				for (int i = 0; i < random_query_count; i++)
				{
					omnitree.Stepper((TestObject record) => { query_count_omnitree[i]++; }, random_mins[i], random_maxes[i]);
				}
			}));

			Console.WriteLine("Querying Range (List):      " + Seven.Diagnostics.Performance.Time_StopWatch(() =>
			{
				for (int i = 0; i < random_query_count; i++)
				{
					foreach (TestObject record in list)
					{
						if (record.X >= random_mins[i][0] && record.X <= random_maxes[i][0] &&
							record.Y >= random_mins[i][1] && record.Y <= random_maxes[i][1] &&
							record.Z >= random_mins[i][2] && record.Z <= random_maxes[i][2])
						{
							query_count_list[i]++;
						}
					}
				}
			}));

			Console.WriteLine("Querying Range (L-List):    " + Seven.Diagnostics.Performance.Time_StopWatch(() =>
			{
				for (int i = 0; i < random_query_count; i++)
				{
					foreach (TestObject record in linkedlist)
					{
						if (record.X >= random_mins[i][0] && record.X <= random_maxes[i][0] &&
							record.Y >= random_mins[i][1] && record.Y <= random_maxes[i][1] &&
							record.Z >= random_mins[i][2] && record.Z <= random_maxes[i][2])
						{
							query_count_linkedlist[i]++;
						}
					}
				}
			}));

			for (int i = 0; i < random_query_count; i++)
				if (query_count_omnitree[i] != query_count_list[i] || query_count_list[i] != query_count_linkedlist[i])
					throw new System.Exception();

			Console.WriteLine();

			foreach (TestObject record in records)
			{
				record.X += Math.Max(0d, Math.Min(1d, (random.NextDouble() / 100D) - .5D));
				record.Y += Math.Max(0d, Math.Min(1d, (random.NextDouble() / 100D) - .5D));
				record.Z += Math.Max(0d, Math.Min(1d, (random.NextDouble() / 100D) - .5D));
			}

			Console.WriteLine("Updating (Omnitree):        " + Seven.Diagnostics.Performance.Time_StopWatch(() =>
			{
				omnitree.Update();
			}));

			Console.WriteLine();

			Console.WriteLine("Removing Single (Omnitree): " + Seven.Diagnostics.Performance.Time_StopWatch(() =>
			{
				for (int i = 0; i < count; i++)
				{
					//// Removal Method #1
					omnitree.Remove(records[i]);

					//// Removal Method #2
					//omnitree.Remove(locate(records[i]), locate(records[i]));

					//// Removal Method #3
					//omnitree.Remove(locate(records[i]), locate(records[i]), (TestObject step) => { return records[i].Id == step.Id; });

					//// Removal Method #4
					//double[] location = new double[] { locate(records[i])(0), locate(records[i])(1), locate(records[i])(2) };
					//omnitree.Remove(location, location);

					//// Removal Method #5
					//double[] location = new double[] { locate(records[i])(0), locate(records[i])(1), locate(records[i])(2) };
					//omnitree.Remove(location, location, (omnitree_record step) => { return records[i].Id == step.Id; });
				}
			}));

			Console.WriteLine("Removing Single (List):     " + Seven.Diagnostics.Performance.Time_StopWatch(() =>
			{
				for (int i = 0; i < count; i++)
				{
					//list.Remove(records[i]);

					for (int j = 0; j < list.Count; j++)
					{
						if (list[j].X == records[i].X && list[j].Y == records[i].Y && list[j].Z == records[i].Z)
						{
							list.RemoveAt(j);
							break;
						}
					}
				}
			}));

			Console.WriteLine("Removing Single (L-List):   " + Seven.Diagnostics.Performance.Time_StopWatch(() =>
			{
				for (int i = 0; i < count; i++)
				{
					//linkedlist.Remove(records[i]);

					LinkedList<TestObject> temp = new LinkedList<TestObject>();
					foreach (TestObject record in linkedlist)
						if (record.X == records[i].X && record.Y == records[i].Y && record.Z == records[i].Z)
						{
							temp.AddLast(record);
							break;
						}
					foreach (TestObject record in temp)
						linkedlist.Remove(record);
				}
			}));

			for (int i = 0; i < count; i++)
			{
				omnitree.Add(records[i]);
				list.Add(records[i]);
				linkedlist.AddLast(records[i]);
			}

			Console.WriteLine();

			TimeSpan omnitree_remove_span = TimeSpan.Zero;
			for (int i = 0; i < random_query_count; i++)
			{
				System.Collections.Generic.List<TestObject> temp = new System.Collections.Generic.List<TestObject>();
				omnitree[locate(records[i])]((TestObject record) => { temp.Add(record); });
				omnitree_remove_span += Seven.Diagnostics.Performance.Time_StopWatch(() =>
				{
					omnitree.Remove(random_mins[i], random_maxes[i]);
				});
				foreach (TestObject record in temp)
					omnitree.Add(record);
			}
			Console.WriteLine("Removing Range (Omnitree):  " + omnitree_remove_span);

			TimeSpan list_remove_span = TimeSpan.Zero;
			for (int i = 0; i < random_query_count; i++)
			{
				System.Collections.Generic.List<TestObject> temp = new System.Collections.Generic.List<TestObject>();

				foreach (TestObject record in list)
				{
					if (record.X >= random_mins[i][0] && record.X <= random_maxes[i][0] &&
						record.Y >= random_mins[i][1] && record.Y <= random_maxes[i][1] &&
						record.Z >= random_mins[i][2] && record.Z <= random_maxes[i][2])
					{
						temp.Add(record);
					}
				}

				list_remove_span += Seven.Diagnostics.Performance.Time_StopWatch(() =>
				{
					list.RemoveAll((TestObject record) =>
					{
						return record.X >= random_mins[i][0] && record.X <= random_maxes[i][0] &&
							record.Y >= random_mins[i][1] && record.Y <= random_maxes[i][1] &&
							record.Z >= random_mins[i][2] && record.Z <= random_maxes[i][2];
					});
					//for (int j = 0; j < list.Count; j++)
					//{
					//	if (list[j].X >= random_mins[i][0] && list[j].X <= random_maxes[i][0] &&
					//		list[j].Y >= random_mins[i][1] && list[j].Y <= random_maxes[i][1] &&
					//		list[j].Z >= random_mins[i][2] && list[j].Z <= random_maxes[i][2])
					//	{
					//		list.RemoveAll.RemoveAt(i);
					//	}
					//}
				});
				foreach (TestObject record in temp)
					list.Add(record);
			}
			Console.WriteLine("Removing Range (List):      " + list_remove_span);

			TimeSpan linkedlist_remove_span = TimeSpan.Zero;
			for (int i = 0; i < random_query_count; i++)
			{
				System.Collections.Generic.List<TestObject> temp = new System.Collections.Generic.List<TestObject>();

				foreach (TestObject record in linkedlist)
				{
					if (record.X >= random_mins[i][0] && record.X <= random_maxes[i][0] &&
						record.Y >= random_mins[i][1] && record.Y <= random_maxes[i][1] &&
						record.Z >= random_mins[i][2] && record.Z <= random_maxes[i][2])
					{
						temp.Add(record);
					}
				}

				linkedlist_remove_span += Seven.Diagnostics.Performance.Time_StopWatch(() =>
				{
					System.Collections.Generic.List<TestObject> temp2 = new System.Collections.Generic.List<TestObject>();
					foreach (TestObject record in linkedlist)
					{
						if (record.X >= random_mins[i][0] && record.X <= random_maxes[i][0] &&
							record.Y >= random_mins[i][1] && record.Y <= random_maxes[i][1] &&
							record.Z >= random_mins[i][2] && record.Z <= random_maxes[i][2])
						{
							temp2.Add(record);
						}
					}
					foreach (TestObject record in temp2)
						linkedlist.Remove(record);
				});
				foreach (TestObject record in temp)
					list.Add(record);
			}
			Console.WriteLine("Removing Range (L-List):    " + linkedlist_remove_span);

			#endregion

			Console.WriteLine();
			Console.WriteLine("Done...");
			Console.ReadLine();
		}
	}
}
