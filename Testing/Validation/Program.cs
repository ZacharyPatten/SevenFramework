using System;

using Seven;
using Seven.Mathematics;
using Seven.Structures;

namespace Validation
{
	public class omnitree_record
	{
		public int Id { get; set; }
		public double X { get; set; }
		public double Y { get; set; }
		public double Z { get; set; }

		public omnitree_record(int id, double x, double y, double z)
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
			//Console.WriteLine("Negate:         " + (Compute<int>.Negate(7) == -7));
			//Console.WriteLine("Add:            " + (Compute<int>.Add(7, 7) == 14));
			//Console.WriteLine("Subtract:       " + (Compute<int>.Subtract(14, 7) == 7));
			//Console.WriteLine("Multiply:       " + (Compute<int>.Multiply(7, 7) == 49));
			//Console.WriteLine("Divide:         " + (Compute<int>.Divide(14, 7) == 2));
			//Console.WriteLine("AbsoluteValue:  " + (Compute<int>.AbsoluteValue(7) == 7 && Compute<int>.AbsoluteValue(-7) == 7));
			//Console.WriteLine("Clamp:          " + (Compute<int>.Clamp(7, 6, 8) == 7));
			//Console.WriteLine("Maximum:        " + (Compute<int>.Maximum((Step<int> step) => { step(1); step(2); step(3); }) == 3));
			//Console.WriteLine("Minimum:        " + (Compute<int>.Minimum((Step<int> step) => { step(1); step(2); step(3); }) == 1));
			//Console.WriteLine("LessThan:       " + (Compute<int>.LessThan(1, 2) == true && Compute<int>.LessThan(2, 1) == false));
			//Console.WriteLine("GreaterThan:    " + (Compute<int>.GreaterThan(2, 1) == true && Compute<int>.GreaterThan(1, 2) == false));
			//Console.WriteLine("Compare:        " + (Compute<int>.Compare(2, 1) == Comparison.Greater && Compute<int>.Compare(1, 2) == Comparison.Less && Compute<int>.Compare(1, 1) == Comparison.Equal));
			//Console.WriteLine("Equate:         " + (Compute<int>.Equate(2, 1) == false && Compute<int>.Equate(1, 1) == true));
			//Console.WriteLine("EqualsLeniency: " + (Compute<int>.EqualsLeniency(2, 1, 1) == true && Compute<int>.EqualsLeniency(2, 1, 0) == false && Compute<int>.EqualsLeniency(1, 1, 0) == true));
			//Console.WriteLine();
			
			Omnitree.Locate<omnitree_record, double> locate = (omnitree_record record) =>
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
			Omnitree<omnitree_record, double> omnitree = new OmnitreeLinkedLinked<omnitree_record, double>(
				new double[] { 0, 0, 0 },
				new double[] { 1, 1, 1 },
				locate,
				Compute<double>.Compare,
				(double a, double b) => { return (a + b) / 2; });

			Console.WriteLine("Generating random data...");

			Random random = new Random(0);
			int count = 100;
			omnitree_record[] records = new omnitree_record[count];
			for (int i = 0; i < count; i++)
				records[i] = new omnitree_record(i, random.NextDouble(), random.NextDouble(), random.NextDouble());

			Console.WriteLine("Generated random data.");

			Console.WriteLine("Building Omnitree...");

			for (int i = 0; i < count; i++)
			{
				omnitree.Add(records[i]);
				if (i % (count / 10) == 0)
					Console.WriteLine(((double)i / (double)count * 100D) + "%");
			}

			Console.WriteLine("Omnitree Built.");

			Console.WriteLine("OmniTree.Count: " + omnitree.Count);
			Console.WriteLine("OmniTree._top.Count: " + (omnitree as OmnitreeLinkedLinked<omnitree_record, double>)._top.Count);

			int test_count = 0;
			omnitree.Stepper((omnitree_record record) => { test_count++; });
			Console.WriteLine("OmniTree Stepper Count: " + test_count);

			SetHashArray<omnitree_record> setHash = new SetHashArray<omnitree_record>(
				(omnitree_record a, omnitree_record b) => { return a.Id == b.Id; },
				(omnitree_record a) => { return a.Id.GetHashCode(); });
			for (int i = 0; i < count; i++)
				setHash.Add(records[i]);

			bool validated = true;
			omnitree.Stepper((omnitree_record record) => { if (!setHash.Contains(record)) validated = false; });
			if (validated)
				Console.WriteLine("Values Validated.");
			else
				Console.WriteLine("Values INVALID.");

			Console.WriteLine("Value Querying: ");

			bool query_test = false;
			for (int i = 0; i < count; i++)
			{
				query_test = false;
				omnitree[locate(records[i])]((omnitree_record record) => { query_test = true; });
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

			Console.WriteLine("Moving randomized data...");

			foreach (omnitree_record record in records)
			{
				record.X += Math.Max(0d, Math.Min( 1d, (random.NextDouble() / 100D) - .5D));
				record.Y += Math.Max(0d, Math.Min( 1d, (random.NextDouble() / 100D) - .5D));
				record.Z += Math.Max(0d, Math.Min( 1d, (random.NextDouble() / 100D) - .5D));
			}

			Console.WriteLine("Randomized data moved.");

			Console.WriteLine("Updating Tree Positions...");
			//// Update Method #1
			omnitree.Update();

			//// Update Method #2
			//omnitree.Update(omnitree.Min, omnitree.Max);

			Console.WriteLine("Tree Positions Updated.");

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

			Console.WriteLine("OmniTree._top.Count: " + (omnitree as OmnitreeLinkedLinked<omnitree_record, double>)._top.Count);

			test_count = 0;
			omnitree.Stepper((omnitree_record record) => { test_count++; });
			Console.WriteLine("OmniTree Stepper Count: " + test_count);

			Console.WriteLine();
			Console.WriteLine("TEST COMPLETE");

				//Console.WriteLine("Range Testing------------------------------");
				//{
				//	Console.WriteLine(" One Dimensional:");
				//	Range<int> range1 = new Range<int>(1, 7);
				//	Console.WriteLine("  range1............................" + range1);// + range1.Min[0] + "-" + range1.Max[0]);
				//	Range<int> range2 = new Range<int>(4, 10);
				//	Console.WriteLine("  range2............................" + range2);// + range2.Min[0] + "-" + range2.Max[0]);
				//	//Range<int> range3 = range1 ^ range2;
				//	//Console.WriteLine("  range1 ^ range2 (Complement)......" + range3);// + range3.Min[0] + "-" + range3.Max[0]);
				//	//Range<int> range4 = range1 | range2;
				//	//Console.WriteLine("  range1 | range2 (Union)..........." + range4);// + range4.Min[0] + "-" + range4.Max[0]);
				//	Range<int> range5 = range1 & range2;
				//	Console.WriteLine("  range1 & range2 (Intersection)...." + range5);// + range5.Min[0] + "-" + range5.Max[0]);
				//}
				//{
				//	Console.WriteLine(" Two Dimensional:");
				//	Range<double> range1 = new Range<double>(new Vector<double>(1, 2), new Vector<double>(7, 8));
				//	Console.WriteLine("  range1............................" + range1);// + range1.Min[0] + "," + range1.Min[1] + ")-(" + range1.Max[0] + "," + range1.Max[1] + ")");
				//	Range<double> range2 = new Range<double>(new Vector<double>(4, 5), new Vector<double>(10, 11));
				//	Console.WriteLine("  range2............................" + range2);// + range2.Min[0] + "," + range2.Min[1] + ")-(" + range2.Max[0] + "," + range2.Max[1] + ")");
				//	//Range<double> range3 = range1 ^ range2;
				//	//Console.WriteLine("  range1 ^ range2 (Complement)......" + range3);// + range3.Min[0] + "," + range3.Min[1] + ")-(" + range3.Max[0] + "," + range3.Max[1] + ")");
				//	//Range<double> range4 = range1 | range2;
				//	//Console.WriteLine("  range1 | range2 (Union)..........." + range4);// + range4.Min[0] + "," + range4.Min[1] + ")-(" + range4.Max[0] + "," + range4.Max[1] + ")");
				//	Range<double> range5 = range1 & range2;
				//	Console.WriteLine("  range1 & range2 (Intersection)...." + range5);// + range5.Min[0] + "," + range5.Min[1] + ")-(" + range5.Max[0] + "," + range5.Max[1] + ")");
				//}

				Console.ReadLine();
		}
	}
}
