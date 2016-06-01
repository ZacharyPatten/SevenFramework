using System;

using Seven;
using Seven.Mathematics;
using Seven.Structures;

namespace Validation
{
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

	class Program
	{
		static void Main(string[] args)
		{
			TestOmnitree1();
			Console.WriteLine();
			TestOmnitree2();
			Console.WriteLine();
			Console.WriteLine("Press Enter To Exit...");
			Console.ReadLine();
		}

		public static void TestMath()
		{
			#region math stuffs

			Console.WriteLine("Negate:         " + (Compute<int>.Negate(7) == -7));
			Console.WriteLine("Add:            " + (Compute<int>.Add(7, 7) == 14));
			Console.WriteLine("Subtract:       " + (Compute<int>.Subtract(14, 7) == 7));
			Console.WriteLine("Multiply:       " + (Compute<int>.Multiply(7, 7) == 49));
			Console.WriteLine("Divide:         " + (Compute<int>.Divide(14, 7) == 2));
			Console.WriteLine("AbsoluteValue:  " + (Compute<int>.AbsoluteValue(7) == 7 && Compute<int>.AbsoluteValue(-7) == 7));
			Console.WriteLine("Clamp:          " + (Compute<int>.Clamp(7, 6, 8) == 7));
			Console.WriteLine("Maximum:        " + (Compute<int>.Maximum((Step<int> step) => { step(1); step(2); step(3); }) == 3));
			Console.WriteLine("Minimum:        " + (Compute<int>.Minimum((Step<int> step) => { step(1); step(2); step(3); }) == 1));
			Console.WriteLine("LessThan:       " + (Compute<int>.LessThan(1, 2) == true && Compute<int>.LessThan(2, 1) == false));
			Console.WriteLine("GreaterThan:    " + (Compute<int>.GreaterThan(2, 1) == true && Compute<int>.GreaterThan(1, 2) == false));
			Console.WriteLine("Compare:        " + (Compute<int>.Compare(2, 1) == Comparison.Greater && Compute<int>.Compare(1, 2) == Comparison.Less && Compute<int>.Compare(1, 1) == Comparison.Equal));
			Console.WriteLine("Equate:         " + (Compute<int>.Equate(2, 1) == false && Compute<int>.Equate(1, 1) == true));
			Console.WriteLine("EqualsLeniency: " + (Compute<int>.EqualsLeniency(2, 1, 1) == true && Compute<int>.EqualsLeniency(2, 1, 0) == false && Compute<int>.EqualsLeniency(1, 1, 0) == true));

			#endregion
		}

		public static void TestOmnitree1()
		{
			#region construction

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
				new double[] { 0, 0, 0 },
				new double[] { 1, 1, 1 },
				locate,
				Compute<double>.Compare,
				(double a, double b) => { return (a + b) / 2; });

			#endregion

			#region random generation

			Console.WriteLine("Generating random data...");

			Random random = new Random(0);
			int count = 100;
			TestObject[] records = new TestObject[count];
			for (int i = 0; i < count; i++)
				records[i] = new TestObject(i, random.NextDouble(), random.NextDouble(), random.NextDouble());

			Console.WriteLine("Generated random data.");

			#endregion

			#region adding

			Console.WriteLine("Building Omnitree...");

			for (int i = 0; i < count; i++)
			{
				omnitree.Add(records[i]);
				if (i % (count / 10) == 0)
					Console.WriteLine(((double)i / (double)count * 100D) + "%");
			}

			Console.WriteLine("OmniTree.Count: " + omnitree.Count);
			Console.WriteLine("OmniTree._top.Count: " + (omnitree as OmnitreeLinked<TestObject, double>)._top.Count);

			int test_count = 0;
			omnitree.Stepper((TestObject record) => { test_count++; });
			Console.WriteLine("OmniTree Stepper Count: " + test_count);

			#endregion

			#region validation

			SetHashArray<TestObject> setHash = new SetHashArray<TestObject>(
				(TestObject a, TestObject b) => { return a.Id == b.Id; },
				(TestObject a) => { return a.Id.GetHashCode(); });
			for (int i = 0; i < count; i++)
				setHash.Add(records[i]);

			bool validated = true;
			omnitree.Stepper((TestObject record) => { if (!setHash.Contains(record)) validated = false; });
			if (validated)
				Console.WriteLine("Values Validated.");
			else
				Console.WriteLine("Values INVALID.");

			#endregion

			#region querying

			Console.WriteLine("Value Querying: ");

			bool query_test = false;
			for (int i = 0; i < count; i++)
			{
				query_test = false;
				omnitree[locate(records[i])]((TestObject record) => { query_test = true; });
				if (query_test == false)
				{
					Console.WriteLine("Querying INVALID on value: " + i);
					break;
				}
				if (i % (count / 10) == 0)
					Console.WriteLine(((double)i / (double)count * 100D) + "%");
			}
			if (query_test == true)
				Console.WriteLine("Querying Validated.");
			else
				Console.WriteLine("Querying INVALID.");

			#endregion

			#region dynamic values (re-randomizing)

			Console.WriteLine("Moving randomized data...");

			foreach (TestObject record in records)
			{
				record.X += Math.Max(0d, Math.Min(1d, (random.NextDouble() / 100D) - .5D));
				record.Y += Math.Max(0d, Math.Min(1d, (random.NextDouble() / 100D) - .5D));
				record.Z += Math.Max(0d, Math.Min(1d, (random.NextDouble() / 100D) - .5D));
			}

			Console.WriteLine("Randomized data moved.");

			#endregion

			#region Updating

			Console.WriteLine("Updating Tree Positions...");
			//// Update Method #1
			omnitree.Update();

			//// Update Method #2
			//omnitree.Update(omnitree.Min, omnitree.Max);

			Console.WriteLine("Tree Positions Updated.");

			#endregion

			#region removal

			Console.WriteLine("Removing Values: ");
			for (int i = 0; i < count; i++)
			{
				//// Removal Method #1
				omnitree.Remove(records[i]);

				//// Removal Method #2
				//omnitree.Remove(locate(records[i]), locate(records[i]));

				//// Removal Method #3
				//omnitree.Remove(locate(records[i]), locate(records[i]), (omnitree_record step) => { return records[i].Id == step.Id; });

				//// Removal Method #4
				//double[] location = new double[] { locate(records[i])(0), locate(records[i])(1), locate(records[i])(2) };
				//omnitree.Remove(location, location);

				//// Removal Method #5
				//double[] location = new double[] { locate(records[i])(0), locate(records[i])(1), locate(records[i])(2) };
				//omnitree.Remove(location, location, (omnitree_record step) => { return records[i].Id == step.Id; });

				if (omnitree.Count != count - (i + 1))
					throw new System.Exception();
				if (i % (count / 10) == 0)
					Console.WriteLine(((double)i / (double)count * 100D) + "%");
			}
			Console.WriteLine("Values Removed: ");

			Console.WriteLine("OmniTree.Count: " + omnitree.Count);

			Console.WriteLine("OmniTree._top.Count: " + (omnitree as OmnitreeLinked<TestObject, double>)._top.Count);

			test_count = 0;
			omnitree.Stepper((TestObject record) => { test_count++; });
			Console.WriteLine("OmniTree Stepper Count: " + test_count);

			#endregion

			Console.WriteLine();
			Console.WriteLine("TEST COMPLETE");
		}

		public static void TestOmnitree2()
		{
			#region construction

			Omnitree.Locate<TestObject, object> Locate = (TestObject record) =>
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
						case 3:
							return record.Id % 2 == 0;
						default:
							throw new System.Exception();
					}
				};
			};

			Omnitree.Average<object> Average = (object a, object b) =>
			{
				if (a is double && b is double)
				{
					return ((double)a + (double)b) / 2d;
				}
				else if (a is bool && b is bool)
				{
					return false;
				}
				else
				{
					throw new System.Exception();
				}
			};

			Compare<object> Compare = (object a, object b) =>
			{
				if (a is double && b is double)
				{
					if ((double)a < (double)b)
						return Comparison.Less;
					else if ((double)a > (double)b)
						return Comparison.Greater;
					else
						return Comparison.Equal;
				}
				else if (a is bool && b is bool)
				{
					if ((bool)a == (bool)b)
						return Comparison.Equal;
					else if ((bool)a == false)
						return Comparison.Less;
					else
						return Comparison.Greater;
				}
				else
				{
					throw new System.Exception();
				}
			};

			Omnitree<TestObject, object> omnitree = new OmnitreeLinked<TestObject, object>(
				new object[] { 0d, 0d, 0d, false },
				new object[] { 1d, 1d, 1d, true },
				Locate,
				Compare,
				Average);

			#endregion

			#region random generation

			Console.WriteLine("Generating random data...");

			Random random = new Random(0);
			int count = 100;
			TestObject[] records = new TestObject[count];
			for (int i = 0; i < count; i++)
				records[i] = new TestObject(i, random.NextDouble(), random.NextDouble(), random.NextDouble());

			Console.WriteLine("Generated random data.");

			#endregion

			#region adding

			Console.WriteLine("Building Omnitree...");

			for (int i = 0; i < count; i++)
			{
				omnitree.Add(records[i]);
				if (i % (count / 10) == 0)
					Console.WriteLine(((double)i / (double)count * 100D) + "%");
			}

			Console.WriteLine("Omnitree Built.");

			Console.WriteLine("OmniTree.Count: " + omnitree.Count);
			Console.WriteLine("OmniTree._top.Count: " + (omnitree as OmnitreeLinked<TestObject, object>)._top.Count);

			int test_count = 0;
			omnitree.Stepper((TestObject record) => { test_count++; });
			Console.WriteLine("OmniTree Stepper Count: " + test_count);

			#endregion

			#region validation

			SetHashArray<TestObject> setHash = new SetHashArray<TestObject>(
				(TestObject a, TestObject b) => { return a.Id == b.Id; },
				(TestObject a) => { return a.Id.GetHashCode(); });
			for (int i = 0; i < count; i++)
				setHash.Add(records[i]);

			bool validated2 = true;
			omnitree.Stepper((TestObject record) => { if (!setHash.Contains(record)) validated2 = false; });
			if (validated2)
				Console.WriteLine("Values Validated.");
			else
				Console.WriteLine("Values INVALID.");

			#endregion

			#region querying

			Console.WriteLine("Value Querying: ");
			
			bool query_test2 = false;
			for (int i = 0; i < count; i++)
			{
				query_test2 = false;
				omnitree[Locate(records[i])]((TestObject record) => { query_test2 = true; });
				if (query_test2 == false)
				{
					Console.WriteLine("Querying INVALID on value: " + i);
					break;
				}
				if (i % (count / 10) == 0)
					Console.WriteLine(((double)i / (double)count * 100D) + "%");
			}
			if (query_test2 == true)
				Console.WriteLine("Querying Validated.");
			else
				Console.WriteLine("Querying INVALID.");

			#endregion

			#region dynamic values (re-randomizing)

			Console.WriteLine("Moving randomized data...");

			foreach (TestObject record in records)
			{
				record.X += Math.Max(0d, Math.Min(1d, (random.NextDouble() / 100D) - .5D));
				record.Y += Math.Max(0d, Math.Min(1d, (random.NextDouble() / 100D) - .5D));
				record.Z += Math.Max(0d, Math.Min(1d, (random.NextDouble() / 100D) - .5D));
			}

			Console.WriteLine("Randomized data moved.");

			#endregion

			#region updating

			Console.WriteLine("Updating Tree Positions...");
			//// Update Method #1
			omnitree.Update();

			//// Update Method #2
			//omnitree.Update(omnitree.Min, omnitree.Max);

			Console.WriteLine("Tree Positions Updated.");

			#endregion

			#region removal

			Console.WriteLine("Removing Values: ");
			for (int i = 0; i < count; i++)
			{
				//// Removal Method #1
				omnitree.Remove(records[i]);

				//// Removal Method #2
				//omnitree.Remove(locate(records[i]), locate(records[i]));

				//// Removal Method #3
				//omnitree.Remove(locate(records[i]), locate(records[i]), (omnitree_record step) => { return records[i].Id == step.Id; });

				//// Removal Method #4
				//double[] location = new double[] { locate(records[i])(0), locate(records[i])(1), locate(records[i])(2) };
				//omnitree.Remove(location, location);

				//// Removal Method #5
				//double[] location = new double[] { locate(records[i])(0), locate(records[i])(1), locate(records[i])(2) };
				//omnitree.Remove(location, location, (omnitree_record step) => { return records[i].Id == step.Id; });

				if (omnitree.Count != count - (i + 1))
					throw new System.Exception();
				if (i % (count / 10) == 0)
					Console.WriteLine(((double)i / (double)count * 100D) + "%");
			}
			Console.WriteLine("Values Removed: ");

			Console.WriteLine("OmniTree.Count: " + omnitree.Count);

			Console.WriteLine("OmniTree._top.Count: " + (omnitree as OmnitreeLinked<TestObject, object>)._top.Count);

			test_count = 0;
			omnitree.Stepper((TestObject record) => { test_count++; });
			Console.WriteLine("OmniTree Stepper Count: " + test_count);

			#endregion

			Console.WriteLine();
			Console.WriteLine("TEST COMPLETE");
		}
	}
}
