// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

using Seven.Structures;

namespace Seven.Mathematics
{
  public interface Statistics<T>
  {
    #region method

    /// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
    Statistics.delegates.Mode<T> Mode { get; }
    /// <summary>Computes the mean (or average) between multiple values.</summary>
    Statistics.delegates.Mean<T> Mean { get; }
    /// <summary>Computes the mean (or average) between two values.</summary>
    Statistics.delegates.Mean_2<T> Mean_2 { get; }
    /// <summary>Computes the median of a set of values.</summary>
    Statistics.delegates.Median<T> Median { get; }

    #endregion
  }

  public class Statistics
  {
    #region delegates

    public static class delegates
    {

      /// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
      /// <typeparam name="T">The generic type of the mode operation.</typeparam>
      /// <param name="values">The values to find the mode(s) of.</param>
      /// <returns>A heap containing all the values sorted on their occurence count.</returns>
      public delegate Heap<Link<T, int>> Mode<T>(params T[] values);

      /// <summary>Computes the mean (or average) between multiple values.</summary>
      /// <typeparam name="T">The generic type of the mode operation.</typeparam>
      /// <param name="values">The operands in the mean operation.</param>
      /// <returns>The mean (or average between the operands).</returns>
      public delegate T Mean<T>(params T[] values);

      /// <summary>Computes the mean (or average) between two values.</summary>
      /// <typeparam name="T">The generic type of the mode operation.</typeparam>
      /// <param name="a">The first operand in the mean operation.</param>
      /// <param name="b">The second operand in the mean operation.</param>
      /// <returns>The mean (or average between the operands).</returns>
      public delegate T Mean_2<T>(T a, T b);

      /// <summary>Computes the median of a set of values.</summary>
      /// <typeparam name="T">The generic type of the mode operation.</typeparam>
      /// <param name="values">The values to compute the median of.</param>
      /// <returns>The computed median from the set of values.</returns>
      public delegate T Median<T>(params T[] values);
    }

    #endregion

    #region libraries

    public static Seven.Structures.Map<object, System.Type> _statistics =
      new Seven.Structures.Map_Linked<object, System.Type>(
        (System.Type left, System.Type right) => { return left == right; },
        (System.Type type) => { return type.GetHashCode(); })
				{
          {typeof(string), Statistics.Statistics_string.Get },
          { typeof(Fraction128), Statistics.Statistics_Fraction128.Get },
          { typeof(Fraction64), Statistics.Statistics_Fraction64.Get },
          { typeof(decimal), Statistics.Statistics_decimal.Get },
          { typeof(double), Statistics.Statistics_double.Get },
          { typeof(float), Statistics.Statistics_float.Get },
          { typeof(long), Statistics.Statistics_long.Get },
					{ typeof(int), Statistics.Statistics_int.Get },
          { typeof(Vector<Fraction128>), Statistics.Statistics_Vector_Fraction128.Get },
          { typeof(Vector<Fraction64>), Statistics.Statistics_Vector_Fraction64.Get },
          { typeof(Vector<decimal>), Statistics.Statistics_Vector_decimal.Get },
          { typeof(Vector<double>), Statistics.Statistics_Vector_double.Get },
          {typeof(Vector<float>), Statistics.Statistics_Vector_float.Get },
          {typeof(Vector<long>), Statistics.Statistics_Vector_long.Get },
          {typeof(Vector<int>), Statistics.Statistics_Vector_int.Get },
				};

    /// <summary>Checks to see if a statistic implementaton exists for the given type.</summary>
    /// <typeparam name="T">The type to check for a statistic implementation.</typeparam>
    /// <returns>True is an implementation exists; false if not.</returns>
    public static bool Check<T>()
    {
      return _statistics.Contains(typeof(T));
    }

    /// <summary>Adds an implementation of statistic for a given type.</summary>
    /// <typeparam name="T">The type the statistic library operates on.</typeparam>
    /// <param name="statistics">The statistic library.</param>
    public static void Set<T>(Statistics<T> statistics)
    {
      _statistics[typeof(T)] = statistics;
    }

    /// <summary>Gets a statistic library for the given type.</summary>
    /// <typeparam name="T">The type to get a statistic library for.</typeparam>
    /// <returns>A statistic library for the given type.</returns>
    public static Statistics<T> Get<T>()
    {
      if (_statistics.Contains(typeof(T)))
        return (Statistics<T>)_statistics[typeof(T)];
      else
        return new Statistic_unsupported<T>();
    }

    #region provided

    private class Statistics_Vector_Fraction128 : Statistics<Vector<Fraction128>>
    {
      private Statistics_Vector_Fraction128() { _instance = this; }
      private static Statistics_Vector_Fraction128 _instance;
      private static Statistics_Vector_Fraction128 Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Statistics_Vector_Fraction128();
          else
            return _instance;
        }
      }

      /// <summary>Gets Statistics for "decimal" types.</summary>
      public static Statistics_Vector_Fraction128 Get { get { return Instance; } }

      /// <summary>Finds the number of occurences for each item and sorts them Fraction128o a heap.</summary>
      public Statistics.delegates.Mode<Vector<Fraction128>> Mode { get { return Statistics.Mode; } }
      /// <summary>Computes the mean (or average) between multiple values.</summary>
      public Statistics.delegates.Mean<Vector<Fraction128>> Mean { get { return Statistics.Mean; } }
      /// <summary>Computes the mean (or average) between two values.</summary>
      public Statistics.delegates.Mean_2<Vector<Fraction128>> Mean_2 { get { return Statistics.Mean; } }
      /// <summary>Computes the median of a set of values.</summary>
      public Statistics.delegates.Median<Vector<Fraction128>> Median { get { return Statistics.Median; } }
    }

    private class Statistics_Vector_Fraction64 : Statistics<Vector<Fraction64>>
    {
      private Statistics_Vector_Fraction64() { _instance = this; }
      private static Statistics_Vector_Fraction64 _instance;
      private static Statistics_Vector_Fraction64 Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Statistics_Vector_Fraction64();
          else
            return _instance;
        }
      }

      /// <summary>Gets Statistics for "decimal" types.</summary>
      public static Statistics_Vector_Fraction64 Get { get { return Instance; } }

      /// <summary>Finds the number of occurences for each item and sorts them Fraction64o a heap.</summary>
      public Statistics.delegates.Mode<Vector<Fraction64>> Mode { get { return Statistics.Mode; } }
      /// <summary>Computes the mean (or average) between multiple values.</summary>
      public Statistics.delegates.Mean<Vector<Fraction64>> Mean { get { return Statistics.Mean; } }
      /// <summary>Computes the mean (or average) between two values.</summary>
      public Statistics.delegates.Mean_2<Vector<Fraction64>> Mean_2 { get { return Statistics.Mean; } }
      /// <summary>Computes the median of a set of values.</summary>
      public Statistics.delegates.Median<Vector<Fraction64>> Median { get { return Statistics.Median; } }
    }

    private class Statistics_Vector_decimal : Statistics<Vector<decimal>>
    {
      private Statistics_Vector_decimal() { _instance = this; }
      private static Statistics_Vector_decimal _instance;
      private static Statistics_Vector_decimal Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Statistics_Vector_decimal();
          else
            return _instance;
        }
      }

      /// <summary>Gets Statistics for "decimal" types.</summary>
      public static Statistics_Vector_decimal Get { get { return Instance; } }

      /// <summary>Finds the number of occurences for each item and sorts them decimalo a heap.</summary>
      public Statistics.delegates.Mode<Vector<decimal>> Mode { get { return Statistics.Mode; } }
      /// <summary>Computes the mean (or average) between multiple values.</summary>
      public Statistics.delegates.Mean<Vector<decimal>> Mean { get { return Statistics.Mean; } }
      /// <summary>Computes the mean (or average) between two values.</summary>
      public Statistics.delegates.Mean_2<Vector<decimal>> Mean_2 { get { return Statistics.Mean; } }
      /// <summary>Computes the median of a set of values.</summary>
      public Statistics.delegates.Median<Vector<decimal>> Median { get { return Statistics.Median; } }
    }

    private class Statistics_Vector_double : Statistics<Vector<double>>
    {
      private Statistics_Vector_double() { _instance = this; }
      private static Statistics_Vector_double _instance;
      private static Statistics_Vector_double Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Statistics_Vector_double();
          else
            return _instance;
        }
      }

      /// <summary>Gets Statistics for "decimal" types.</summary>
      public static Statistics_Vector_double Get { get { return Instance; } }

      /// <summary>Finds the number of occurences for each item and sorts them doubleo a heap.</summary>
      public Statistics.delegates.Mode<Vector<double>> Mode { get { return Statistics.Mode; } }
      /// <summary>Computes the mean (or average) between multiple values.</summary>
      public Statistics.delegates.Mean<Vector<double>> Mean { get { return Statistics.Mean; } }
      /// <summary>Computes the mean (or average) between two values.</summary>
      public Statistics.delegates.Mean_2<Vector<double>> Mean_2 { get { return Statistics.Mean; } }
      /// <summary>Computes the median of a set of values.</summary>
      public Statistics.delegates.Median<Vector<double>> Median { get { return Statistics.Median; } }
    }

    private class Statistics_Vector_float : Statistics<Vector<float>>
    {
      private Statistics_Vector_float() { _instance = this; }
      private static Statistics_Vector_float _instance;
      private static Statistics_Vector_float Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Statistics_Vector_float();
          else
            return _instance;
        }
      }

      /// <summary>Gets Statistics for "decimal" types.</summary>
      public static Statistics_Vector_float Get { get { return Instance; } }

      /// <summary>Finds the number of occurences for each item and sorts them floato a heap.</summary>
      public Statistics.delegates.Mode<Vector<float>> Mode { get { return Statistics.Mode; } }
      /// <summary>Computes the mean (or average) between multiple values.</summary>
      public Statistics.delegates.Mean<Vector<float>> Mean { get { return Statistics.Mean; } }
      /// <summary>Computes the mean (or average) between two values.</summary>
      public Statistics.delegates.Mean_2<Vector<float>> Mean_2 { get { return Statistics.Mean; } }
      /// <summary>Computes the median of a set of values.</summary>
      public Statistics.delegates.Median<Vector<float>> Median { get { return Statistics.Median; } }
    }

    private class Statistics_Vector_long : Statistics<Vector<long>>
    {
      private Statistics_Vector_long() { _instance = this; }
      private static Statistics_Vector_long _instance;
      private static Statistics_Vector_long Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Statistics_Vector_long();
          else
            return _instance;
        }
      }

      /// <summary>Gets Statistics for "decimal" types.</summary>
      public static Statistics_Vector_long Get { get { return Instance; } }

      /// <summary>Finds the number of occurences for each item and sorts them longo a heap.</summary>
      public Statistics.delegates.Mode<Vector<long>> Mode { get { return Statistics.Mode; } }
      /// <summary>Computes the mean (or average) between multiple values.</summary>
      public Statistics.delegates.Mean<Vector<long>> Mean { get { return Statistics.Mean; } }
      /// <summary>Computes the mean (or average) between two values.</summary>
      public Statistics.delegates.Mean_2<Vector<long>> Mean_2 { get { return Statistics.Mean; } }
      /// <summary>Computes the median of a set of values.</summary>
      public Statistics.delegates.Median<Vector<long>> Median { get { return Statistics.Median; } }
    }

    private class Statistics_Vector_int : Statistics<Vector<int>>
    {
      private Statistics_Vector_int() { _instance = this; }
      private static Statistics_Vector_int _instance;
      private static Statistics_Vector_int Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Statistics_Vector_int();
          else
            return _instance;
        }
      }

      /// <summary>Gets Statistics for "decimal" types.</summary>
      public static Statistics_Vector_int Get { get { return Instance; } }

      /// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
      public Statistics.delegates.Mode<Vector<int>> Mode { get { return Statistics.Mode; } }
      /// <summary>Computes the mean (or average) between multiple values.</summary>
      public Statistics.delegates.Mean<Vector<int>> Mean { get { return Statistics.Mean; } }
      /// <summary>Computes the mean (or average) between two values.</summary>
      public Statistics.delegates.Mean_2<Vector<int>> Mean_2 { get { return Statistics.Mean; } }
      /// <summary>Computes the median of a set of values.</summary>
      public Statistics.delegates.Median<Vector<int>> Median { get { return Statistics.Median; } }
    }

    private class Statistics_string : Statistics<string>
    {
      private Statistics_string() { _instance = this; }
      private static Statistics_string _instance;
      private static Statistics_string Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Statistics_string();
          else
            return _instance;
        }
      }

      /// <summary>Gets Statistics for "decimal" types.</summary>
      public static Statistics_string Get { get { return Instance; } }

      /// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
      public Statistics.delegates.Mode<string> Mode { get { return Statistics.Mode; } }
      /// <summary>Computes the mean (or average) between multiple values.</summary>
      public Statistics.delegates.Mean<string> Mean { get { return Statistics.Mean; } }
      /// <summary>Computes the mean (or average) between two values.</summary>
      public Statistics.delegates.Mean_2<string> Mean_2 { get { return Statistics.Mean; } }
      /// <summary>Computes the median of a set of values.</summary>
      public Statistics.delegates.Median<string> Median { get { return Statistics.Median; } }
    }

    private class Statistics_Fraction128 : Statistics<Fraction128>
    {
      private Statistics_Fraction128() { _instance = this; }
      private static Statistics_Fraction128 _instance;
      private static Statistics_Fraction128 Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Statistics_Fraction128();
          else
            return _instance;
        }
      }

      /// <summary>Gets Statistics for "Fraction128" types.</summary>
      public static Statistics_Fraction128 Get { get { return Instance; } }

      /// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
      public Statistics.delegates.Mode<Fraction128> Mode { get { return Statistics.Mode; } }
      /// <summary>Computes the mean (or average) between multiple values.</summary>
      public Statistics.delegates.Mean<Fraction128> Mean { get { return Statistics.Mean; } }
      /// <summary>Computes the mean (or average) between two values.</summary>
      public Statistics.delegates.Mean_2<Fraction128> Mean_2 { get { return Statistics.Mean; } }
      /// <summary>Computes the median of a set of values.</summary>
      public Statistics.delegates.Median<Fraction128> Median { get { return Statistics.Median; } }
    }

    private class Statistics_Fraction64 : Statistics<Fraction64>
    {
      private Statistics_Fraction64() { _instance = this; }
      private static Statistics_Fraction64 _instance;
      private static Statistics_Fraction64 Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Statistics_Fraction64();
          else
            return _instance;
        }
      }

      /// <summary>Gets Statistics for "Fraction64" types.</summary>
      public static Statistics_Fraction64 Get { get { return Instance; } }

      /// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
      public Statistics.delegates.Mode<Fraction64> Mode { get { return Statistics.Mode; } }
      /// <summary>Computes the mean (or average) between multiple values.</summary>
      public Statistics.delegates.Mean<Fraction64> Mean { get { return Statistics.Mean; } }
      /// <summary>Computes the mean (or average) between two values.</summary>
      public Statistics.delegates.Mean_2<Fraction64> Mean_2 { get { return Statistics.Mean; } }
      /// <summary>Computes the median of a set of values.</summary>
      public Statistics.delegates.Median<Fraction64> Median { get { return Statistics.Median; } }
    }

    private class Statistics_decimal : Statistics<decimal>
    {
      private Statistics_decimal() { _instance = this; }
      private static Statistics_decimal _instance;
      private static Statistics_decimal Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Statistics_decimal();
          else
            return _instance;
        }
      }

      /// <summary>Gets Statistics for "decimal" types.</summary>
      public static Statistics_decimal Get { get { return Instance; } }

      /// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
      public Statistics.delegates.Mode<decimal> Mode { get { return Statistics.Mode; } }
      /// <summary>Computes the mean (or average) between multiple values.</summary>
      public Statistics.delegates.Mean<decimal> Mean { get { return Statistics.Mean; } }
      /// <summary>Computes the mean (or average) between two values.</summary>
      public Statistics.delegates.Mean_2<decimal> Mean_2 { get { return Statistics.Mean; } }
      /// <summary>Computes the median of a set of values.</summary>
      public Statistics.delegates.Median<decimal> Median { get { return Statistics.Median; } }
    }

    private class Statistics_double : Statistics<double>
    {
      private Statistics_double() { _instance = this; }
      private static Statistics_double _instance;
      private static Statistics_double Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Statistics_double();
          else
            return _instance;
        }
      }

      /// <summary>Gets Statistics for "double" types.</summary>
      public static Statistics_double Get { get { return Instance; } }

      /// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
      public Statistics.delegates.Mode<double> Mode { get { return Statistics.Mode; } }
      /// <summary>Computes the mean (or average) between multiple values.</summary>
      public Statistics.delegates.Mean<double> Mean { get { return Statistics.Mean; } }
      /// <summary>Computes the mean (or average) between two values.</summary>
      public Statistics.delegates.Mean_2<double> Mean_2 { get { return Statistics.Mean; } }
      /// <summary>Computes the median of a set of values.</summary>
      public Statistics.delegates.Median<double> Median { get { return Statistics.Median; } }
    }

    private class Statistics_float : Statistics<float>
    {
      private Statistics_float() { _instance = this; }
      private static Statistics_float _instance;
      private static Statistics_float Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Statistics_float();
          else
            return _instance;
        }
      }

      /// <summary>Gets Statistics for "float" types.</summary>
      public static Statistics_float Get { get { return Instance; } }

      /// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
      public Statistics.delegates.Mode<float> Mode { get { return Statistics.Mode; } }
      /// <summary>Computes the mean (or average) between multiple values.</summary>
      public Statistics.delegates.Mean<float> Mean { get { return Statistics.Mean; } }
      /// <summary>Computes the mean (or average) between two values.</summary>
      public Statistics.delegates.Mean_2<float> Mean_2 { get { return Statistics.Mean; } }
      /// <summary>Computes the median of a set of values.</summary>
      public Statistics.delegates.Median<float> Median { get { return Statistics.Median; } }
    }

    private class Statistics_long : Statistics<long>
    {
      private Statistics_long() { _instance = this; }
      private static Statistics_long _instance;
      private static Statistics_long Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Statistics_long();
          else
            return _instance;
        }
      }

      /// <summary>Gets Statistics for "long" types.</summary>
      public static Statistics_long Get { get { return Instance; } }

      /// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
      public Statistics.delegates.Mode<long> Mode { get { return Statistics.Mode; } }
      /// <summary>Computes the mean (or average) between multiple values.</summary>
      public Statistics.delegates.Mean<long> Mean { get { return Statistics.Mean; } }
      /// <summary>Computes the mean (or average) between two values.</summary>
      public Statistics.delegates.Mean_2<long> Mean_2 { get { return Statistics.Mean; } }
      /// <summary>Computes the median of a set of values.</summary>
      public Statistics.delegates.Median<long> Median { get { return Statistics.Median; } }
    }

    private class Statistics_int : Statistics<int>
    {
      private Statistics_int() { _instance = this; }
      private static Statistics_int _instance;
      private static Statistics_int Instance
      {
        get
        {
          if (_instance == null)
            return _instance = new Statistics_int();
          else
            return _instance;
        }
      }

      /// <summary>Gets Statistics for "int" types.</summary>
      public static Statistics_int Get { get { return Instance; } }

      /// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
      public Statistics.delegates.Mode<int> Mode { get { return Statistics.Mode; } }
      /// <summary>Computes the mean (or average) between multiple values.</summary>
      public Statistics.delegates.Mean<int> Mean { get { return Statistics.Mean; } }
      /// <summary>Computes the mean (or average) between two values.</summary>
      public Statistics.delegates.Mean_2<int> Mean_2 { get { return Statistics.Mean; } }
      /// <summary>Computes the median of a set of values.</summary>
      public Statistics.delegates.Median<int> Median { get { return Statistics.Median; } }
    }

    private class Statistic_unsupported<T> : Statistics<T>
    {
      public Statistic_unsupported() { }
      
      /// <summary>Finds the number of occurences for each item and sorts them into a heap.</summary>
      public Statistics.delegates.Mode<T> Mode { get { return (T[] values) => { throw new Error("Statistics are undefined for type: " + typeof(T)); }; } }
      /// <summary>Computes the mean (or average) between multiple values.</summary>
      public Statistics.delegates.Mean<T> Mean { get { return (T[] values) => { throw new Error("Statistics are undefined for type: " + typeof(T)); }; } }
      /// <summary>Computes the mean (or average) between two values.</summary>
      public Statistics.delegates.Mean_2<T> Mean_2 { get { return (T a, T b) => { throw new Error("Statistics are undefined for type: " + typeof(T)); }; } }
      /// <summary>Computes the median of a set of values.</summary>
      public Statistics.delegates.Median<T> Median { get { return (T[] values) => { throw new Error("Statistics are undefined for type: " + typeof(T)); }; } }
    }

    #endregion

    #endregion

    #region implementations

    #region generic

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <typeparam name="T">The generic type of this operation.</typeparam>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static T Mean<T>(T a, T b)
    {
      return Statistics.Get<T>().Mean_2(a, b);
    }

    public static T Mean<T>(params T[] values)
    {
      return Statistics.Get<T>().Mean(values);
    }

    public static Heap<Link<T, int>> Mode<T>(params T[] values)
    {
      return Statistics.Get<T>().Mode(values);
    }

    public static T Median<T>(params T[] values)
    {
      return Statistics.Get<T>().Median(values);
    }

    #endregion

    #region Vector<Fraction128>

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static Vector<Fraction128> Mean(Vector<Fraction128> a, Vector<Fraction128> b)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(a, null))
        throw new Error("null reference: a");
      if (object.ReferenceEquals(b, null))
        throw new Error("null reference: b");
      if (a.Dimensions != b.Dimensions)
        throw new Error("invalid vectors during mean (a.Dimensions != b.Dimensions)");
#endif

      return (a + b) / (Fraction128)2;
    }

    /// <summary>Computes the mean, or average, between multiple values.</summary>
    /// <param name="traversal">A function for traversing a set.</param>
    /// <returns>The mean of the provided values.</returns>
    public static Vector<Fraction128> Mean(Traversal<Vector<Fraction128>> traversal)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(traversal, null))
        throw new Error("null reference: values");
#endif

      int count = 0;
      Vector<Fraction128> sum = null;
      traversal(
        (Vector<Fraction128> current) =>
        {
          if (count == 0)
            sum = new Vector<Fraction128>(current.Dimensions);

#if no_error_checking
          // nothing
#else
          if (current.Dimensions != sum.Dimensions)
            throw new Error("invalid vector during mean: dimension mismatch");
#endif

          sum += current;
          count++;
        });

#if no_error_checking
          // nothing
#else
      if (count == 0)
        throw new Error("invalid values during mean: (values.Count == 0)");
#endif

      return sum / (Fraction128)count;
    }

    /// <summary>Computes the mean, or average, between multiple values.</summary>
    /// <param name="values">The values to compute the mean of/</param>
    /// <returns>The mean of the provided values.</returns>
    public static Vector<Fraction128> Mean(params Vector<Fraction128>[] values)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(values, null))
        throw new Error("null reference: values");
      if (values.Length < 1)
        throw new Error("invalid values during mean: (values.Length < 1)");
#endif

      Vector<Fraction128> sum =
        new Vector<Fraction128>(values[0].Dimensions);
      foreach (Vector<Fraction128> value in values)
        sum += value;
      return sum / (Fraction128)values.Length;
    }

    /// <summary>Computes the mode (most ocurring) value in a set.</summary>
    /// <param name="traversal">A function for traversing a set.</param>
    /// <returns>A heap sorted along the number of occurences for each item.</returns>
    public static Heap<Link<Vector<Fraction128>, int>> Mode(Traversal<Vector<Fraction128>> traversal)
    {
      throw new System.NotImplementedException();

      Heap<Link<Vector<Fraction128>, int>> heap =
        new Heap_Array<Link<Vector<Fraction128>, int>>(
          (Link<Vector<Fraction128>, int> left, Link<Vector<Fraction128>, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      // Note: can be optimized when the dynamic heap is finished
      Map<int, Vector<Fraction128>> map =
        new Map_Linked<int, Vector<Fraction128>>(
          Vector<Fraction128>.EqualsValue,
          Hash.Default);

      traversal(
        (Vector<Fraction128> vector) =>
        {
          if (map.Contains(vector))
            map[vector]++;
          else
            map.Add(vector, 1);
        });

      traversal(
        (Vector<Fraction128> vector) =>
        {
          if (map.Contains(vector))
          {
            heap.Enqueue(new Link<Vector<Fraction128>, int>(vector, map[vector]));
            map.Remove(vector);
          }
        });

      return heap;
    }

    /// <summary>Computes the mode (most ocurring) value in a set.</summary>
    /// <param name="values">The values to compute the mode of.</param>
    /// <returns>A heap sorted along the number of occurences for each item.</returns>
    public static Heap<Link<Vector<Fraction128>, int>> Mode(params Vector<Fraction128>[] values)
    {
      throw new System.NotImplementedException();

      Heap<Link<Vector<Fraction128>, int>> heap =
        new Heap_Array<Link<Vector<Fraction128>, int>>(
          (Link<Vector<Fraction128>, int> left, Link<Vector<Fraction128>, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      // Note: can be optimized when the dynamic heap is finished
      Map<int, Vector<Fraction128>> map =
        new Map_Linked<int, Vector<Fraction128>>(
          Vector<Fraction128>.EqualsValue,
          Hash.Default);

      foreach (Vector<Fraction128> vector in values)
        if (map.Contains(vector))
          map[vector]++;
        else
          map.Add(vector, 1);

      foreach (Vector<Fraction128> vector in values)
        if (map.Contains(vector))
        {
          heap.Enqueue(new Link<Vector<Fraction128>,int>(vector, map[vector]));
          map.Remove(vector);
        }

      return heap;
    }

    /// <summary>Computes the median value in a set.</summary>
    /// <param name="traversal">A traversal function for a set.</param>
    /// <returns>The computed median of the values.</returns>
    public static Vector<Fraction128> Median(Traversal<Vector<Fraction128>> traversal)
    {
      throw new Error("requires a comparable type");

      //if (values.Length == 1)
      //  return values[0];

      //Fraction128[] sorted = values.Clone() as Fraction128[];
      //Sort.Quick<Fraction128>(Logic.Compare, sorted);
      //if (sorted.Length % 2 == 1)
      //  return sorted[sorted.Length / 2 + 1];
      //else
      //  return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    /// <summary>Computes the median value in a set.</summary>
    /// <param name="traversal">The values to compute the median of.</param>
    /// <returns>The computed median of the values.</returns>
    public static Vector<Fraction128> Median(params Vector<Fraction128>[] values)
    {
      throw new Error("requires a comparable type");

      //if (values.Length == 1)
      //  return values[0];

      //Fraction128[] sorted = values.Clone() as Fraction128[];
      //Sort.Quick<Fraction128>(Logic.Compare, sorted);
      //if (sorted.Length % 2 == 1)
      //  return sorted[sorted.Length / 2 + 1];
      //else
      //  return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    #endregion

    #region Vector<Fraction64>

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static Vector<Fraction64> Mean(Vector<Fraction64> a, Vector<Fraction64> b)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(a, null))
        throw new Error("null reference: a");
      if (object.ReferenceEquals(b, null))
        throw new Error("null reference: b");
      if (a.Dimensions != b.Dimensions)
        throw new Error("invalid vectors during mean (a.Dimensions != b.Dimensions)");
#endif

      return (a + b) / (Fraction64)2;
    }

    /// <summary>Computes the mean, or average, between multiple values.</summary>
    /// <param name="traversal">A function for traversing a set.</param>
    /// <returns>The mean of the provided values.</returns>
    public static Vector<Fraction64> Mean(Traversal<Vector<Fraction64>> traversal)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(traversal, null))
        throw new Error("null reference: values");
#endif

      int count = 0;
      Vector<Fraction64> sum = null;
      traversal(
        (Vector<Fraction64> current) =>
        {
          if (count == 0)
            sum = new Vector<Fraction64>(current.Dimensions);

#if no_error_checking
          // nothing
#else
          if (current.Dimensions != sum.Dimensions)
            throw new Error("invalid vector during mean: dimension mismatch");
#endif

          sum += current;
          count++;
        });

#if no_error_checking
          // nothing
#else
      if (count == 0)
        throw new Error("invalid values during mean: (values.Count == 0)");
#endif

      return sum / (Fraction64)count;
    }

    /// <summary>Computes the mean, or average, between multiple values.</summary>
    /// <param name="values">The values to compute the mean of/</param>
    /// <returns>The mean of the provided values.</returns>
    public static Vector<Fraction64> Mean(params Vector<Fraction64>[] values)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(values, null))
        throw new Error("null reference: values");
      if (values.Length < 1)
        throw new Error("invalid values during mean: (values.Length < 1)");
#endif

      Vector<Fraction64> sum =
        new Vector<Fraction64>(values[0].Dimensions);
      foreach (Vector<Fraction64> value in values)
        sum += value;
      return sum / (Fraction64)values.Length;
    }

    /// <summary>Computes the mode (most ocurring) value in a set.</summary>
    /// <param name="traversal">A function for traversing a set.</param>
    /// <returns>A heap sorted along the number of occurences for each item.</returns>
    public static Heap<Link<Vector<Fraction64>, int>> Mode(Traversal<Vector<Fraction64>> traversal)
    {
      throw new System.NotImplementedException();

      Heap<Link<Vector<Fraction64>, int>> heap =
        new Heap_Array<Link<Vector<Fraction64>, int>>(
          (Link<Vector<Fraction64>, int> left, Link<Vector<Fraction64>, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      // Note: can be optimized when the dynamic heap is finished
      Map<int, Vector<Fraction64>> map =
        new Map_Linked<int, Vector<Fraction64>>(
          Vector<Fraction64>.EqualsValue,
          Hash.Default);

      traversal(
        (Vector<Fraction64> vector) =>
        {
          if (map.Contains(vector))
            map[vector]++;
          else
            map.Add(vector, 1);
        });

      traversal(
        (Vector<Fraction64> vector) =>
        {
          if (map.Contains(vector))
          {
            heap.Enqueue(new Link<Vector<Fraction64>, int>(vector, map[vector]));
            map.Remove(vector);
          }
        });

      return heap;
    }

    /// <summary>Computes the mode (most ocurring) value in a set.</summary>
    /// <param name="values">The values to compute the mode of.</param>
    /// <returns>A heap sorted along the number of occurences for each item.</returns>
    public static Heap<Link<Vector<Fraction64>, int>> Mode(params Vector<Fraction64>[] values)
    {
      throw new System.NotImplementedException();

      Heap<Link<Vector<Fraction64>, int>> heap =
        new Heap_Array<Link<Vector<Fraction64>, int>>(
          (Link<Vector<Fraction64>, int> left, Link<Vector<Fraction64>, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      // Note: can be optimized when the dynamic heap is finished
      Map<int, Vector<Fraction64>> map =
        new Map_Linked<int, Vector<Fraction64>>(
          Vector<Fraction64>.EqualsValue,
          Hash.Default);

      foreach (Vector<Fraction64> vector in values)
        if (map.Contains(vector))
          map[vector]++;
        else
          map.Add(vector, 1);

      foreach (Vector<Fraction64> vector in values)
        if (map.Contains(vector))
        {
          heap.Enqueue(new Link<Vector<Fraction64>, int>(vector, map[vector]));
          map.Remove(vector);
        }

      return heap;
    }

    /// <summary>Computes the median value in a set.</summary>
    /// <param name="traversal">A traversal function for a set.</param>
    /// <returns>The computed median of the values.</returns>
    public static Vector<Fraction64> Median(Traversal<Vector<Fraction64>> traversal)
    {
      throw new Error("requires a comparable type");

      //if (values.Length == 1)
      //  return values[0];

      //Fraction64[] sorted = values.Clone() as Fraction64[];
      //Sort.Quick<Fraction64>(Logic.Compare, sorted);
      //if (sorted.Length % 2 == 1)
      //  return sorted[sorted.Length / 2 + 1];
      //else
      //  return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    /// <summary>Computes the median value in a set.</summary>
    /// <param name="traversal">The values to compute the median of.</param>
    /// <returns>The computed median of the values.</returns>
    public static Vector<Fraction64> Median(params Vector<Fraction64>[] values)
    {
      throw new Error("requires a comparable type");

      //if (values.Length == 1)
      //  return values[0];

      //Fraction64[] sorted = values.Clone() as Fraction64[];
      //Sort.Quick<Fraction64>(Logic.Compare, sorted);
      //if (sorted.Length % 2 == 1)
      //  return sorted[sorted.Length / 2 + 1];
      //else
      //  return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    #endregion

    #region Vector<decimal>

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static Vector<decimal> Mean(Vector<decimal> a, Vector<decimal> b)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(a, null))
        throw new Error("null reference: a");
      if (object.ReferenceEquals(b, null))
        throw new Error("null reference: b");
      if (a.Dimensions != b.Dimensions)
        throw new Error("invalid vectors during mean (a.Dimensions != b.Dimensions)");
#endif

      return (a + b) / (decimal)2;
    }

    /// <summary>Computes the mean, or average, between multiple values.</summary>
    /// <param name="traversal">A function for traversing a set.</param>
    /// <returns>The mean of the provided values.</returns>
    public static Vector<decimal> Mean(Traversal<Vector<decimal>> traversal)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(traversal, null))
        throw new Error("null reference: values");
#endif

      int count = 0;
      Vector<decimal> sum = null;
      traversal(
        (Vector<decimal> current) =>
        {
          if (count == 0)
            sum = new Vector<decimal>(current.Dimensions);

#if no_error_checking
          // nothing
#else
          if (current.Dimensions != sum.Dimensions)
            throw new Error("invalid vector during mean: dimension mismatch");
#endif

          sum += current;
          count++;
        });

#if no_error_checking
          // nothing
#else
      if (count == 0)
        throw new Error("invalid values during mean: (values.Count == 0)");
#endif

      return sum / (decimal)count;
    }

    /// <summary>Computes the mean, or average, between multiple values.</summary>
    /// <param name="values">The values to compute the mean of/</param>
    /// <returns>The mean of the provided values.</returns>
    public static Vector<decimal> Mean(params Vector<decimal>[] values)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(values, null))
        throw new Error("null reference: values");
      if (values.Length < 1)
        throw new Error("invalid values during mean: (values.Length < 1)");
#endif

      Vector<decimal> sum =
        new Vector<decimal>(values[0].Dimensions);
      foreach (Vector<decimal> value in values)
        sum += value;
      return sum / (decimal)values.Length;
    }

    /// <summary>Computes the mode (most ocurring) value in a set.</summary>
    /// <param name="traversal">A function for traversing a set.</param>
    /// <returns>A heap sorted along the number of occurences for each item.</returns>
    public static Heap<Link<Vector<decimal>, int>> Mode(Traversal<Vector<decimal>> traversal)
    {
      throw new System.NotImplementedException();

      Heap<Link<Vector<decimal>, int>> heap =
        new Heap_Array<Link<Vector<decimal>, int>>(
          (Link<Vector<decimal>, int> left, Link<Vector<decimal>, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      // Note: can be optimized when the dynamic heap is finished
      Map<int, Vector<decimal>> map =
        new Map_Linked<int, Vector<decimal>>(
          Vector<decimal>.EqualsValue,
          Hash.Default);

      traversal(
        (Vector<decimal> vector) =>
        {
          if (map.Contains(vector))
            map[vector]++;
          else
            map.Add(vector, 1);
        });

      traversal(
        (Vector<decimal> vector) =>
        {
          if (map.Contains(vector))
          {
            heap.Enqueue(new Link<Vector<decimal>, int>(vector, map[vector]));
            map.Remove(vector);
          }
        });

      return heap;
    }

    /// <summary>Computes the mode (most ocurring) value in a set.</summary>
    /// <param name="values">The values to compute the mode of.</param>
    /// <returns>A heap sorted along the number of occurences for each item.</returns>
    public static Heap<Link<Vector<decimal>, int>> Mode(params Vector<decimal>[] values)
    {
      throw new System.NotImplementedException();

      Heap<Link<Vector<decimal>, int>> heap =
        new Heap_Array<Link<Vector<decimal>, int>>(
          (Link<Vector<decimal>, int> left, Link<Vector<decimal>, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      // Note: can be optimized when the dynamic heap is finished
      Map<int, Vector<decimal>> map =
        new Map_Linked<int, Vector<decimal>>(
          Vector<decimal>.EqualsValue,
          Hash.Default);

      foreach (Vector<decimal> vector in values)
        if (map.Contains(vector))
          map[vector]++;
        else
          map.Add(vector, 1);

      foreach (Vector<decimal> vector in values)
        if (map.Contains(vector))
        {
          heap.Enqueue(new Link<Vector<decimal>, int>(vector, map[vector]));
          map.Remove(vector);
        }

      return heap;
    }

    /// <summary>Computes the median value in a set.</summary>
    /// <param name="traversal">A traversal function for a set.</param>
    /// <returns>The computed median of the values.</returns>
    public static Vector<decimal> Median(Traversal<Vector<decimal>> traversal)
    {
      throw new Error("requires a comparable type");

      //if (values.Length == 1)
      //  return values[0];

      //decimal[] sorted = values.Clone() as decimal[];
      //Sort.Quick<decimal>(Logic.Compare, sorted);
      //if (sorted.Length % 2 == 1)
      //  return sorted[sorted.Length / 2 + 1];
      //else
      //  return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    /// <summary>Computes the median value in a set.</summary>
    /// <param name="traversal">The values to compute the median of.</param>
    /// <returns>The computed median of the values.</returns>
    public static Vector<decimal> Median(params Vector<decimal>[] values)
    {
      throw new Error("requires a comparable type");

      //if (values.Length == 1)
      //  return values[0];

      //decimal[] sorted = values.Clone() as decimal[];
      //Sort.Quick<decimal>(Logic.Compare, sorted);
      //if (sorted.Length % 2 == 1)
      //  return sorted[sorted.Length / 2 + 1];
      //else
      //  return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    #endregion

    #region Vector<double>

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static Vector<double> Mean(Vector<double> a, Vector<double> b)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(a, null))
        throw new Error("null reference: a");
      if (object.ReferenceEquals(b, null))
        throw new Error("null reference: b");
      if (a.Dimensions != b.Dimensions)
        throw new Error("invalid vectors during mean (a.Dimensions != b.Dimensions)");
#endif

      return (a + b) / (double)2;
    }

    /// <summary>Computes the mean, or average, between multiple values.</summary>
    /// <param name="traversal">A function for traversing a set.</param>
    /// <returns>The mean of the provided values.</returns>
    public static Vector<double> Mean(Traversal<Vector<double>> traversal)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(traversal, null))
        throw new Error("null reference: values");
#endif

      int count = 0;
      Vector<double> sum = null;
      traversal(
        (Vector<double> current) =>
        {
          if (count == 0)
            sum = new Vector<double>(current.Dimensions);

#if no_error_checking
          // nothing
#else
          if (current.Dimensions != sum.Dimensions)
            throw new Error("invalid vector during mean: dimension mismatch");
#endif

          sum += current;
          count++;
        });

#if no_error_checking
          // nothing
#else
      if (count == 0)
        throw new Error("invalid values during mean: (values.Count == 0)");
#endif

      return sum / (double)count;
    }

    /// <summary>Computes the mean, or average, between multiple values.</summary>
    /// <param name="values">The values to compute the mean of/</param>
    /// <returns>The mean of the provided values.</returns>
    public static Vector<double> Mean(params Vector<double>[] values)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(values, null))
        throw new Error("null reference: values");
      if (values.Length < 1)
        throw new Error("invalid values during mean: (values.Length < 1)");
#endif

      Vector<double> sum =
        new Vector<double>(values[0].Dimensions);
      foreach (Vector<double> value in values)
        sum += value;
      return sum / (double)values.Length;
    }

    /// <summary>Computes the mode (most ocurring) value in a set.</summary>
    /// <param name="traversal">A function for traversing a set.</param>
    /// <returns>A heap sorted along the number of occurences for each item.</returns>
    public static Heap<Link<Vector<double>, int>> Mode(Traversal<Vector<double>> traversal)
    {
      throw new System.NotImplementedException();

      Heap<Link<Vector<double>, int>> heap =
        new Heap_Array<Link<Vector<double>, int>>(
          (Link<Vector<double>, int> left, Link<Vector<double>, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      // Note: can be optimized when the dynamic heap is finished
      Map<int, Vector<double>> map =
        new Map_Linked<int, Vector<double>>(
          Vector<double>.EqualsValue,
          Hash.Default);

      traversal(
        (Vector<double> vector) =>
        {
          if (map.Contains(vector))
            map[vector]++;
          else
            map.Add(vector, 1);
        });

      traversal(
        (Vector<double> vector) =>
        {
          if (map.Contains(vector))
          {
            heap.Enqueue(new Link<Vector<double>, int>(vector, map[vector]));
            map.Remove(vector);
          }
        });

      return heap;
    }

    /// <summary>Computes the mode (most ocurring) value in a set.</summary>
    /// <param name="values">The values to compute the mode of.</param>
    /// <returns>A heap sorted along the number of occurences for each item.</returns>
    public static Heap<Link<Vector<double>, int>> Mode(params Vector<double>[] values)
    {
      throw new System.NotImplementedException();

      Heap<Link<Vector<double>, int>> heap =
        new Heap_Array<Link<Vector<double>, int>>(
          (Link<Vector<double>, int> left, Link<Vector<double>, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      // Note: can be optimized when the dynamic heap is finished
      Map<int, Vector<double>> map =
        new Map_Linked<int, Vector<double>>(
          Vector<double>.EqualsValue,
          Hash.Default);

      foreach (Vector<double> vector in values)
        if (map.Contains(vector))
          map[vector]++;
        else
          map.Add(vector, 1);

      foreach (Vector<double> vector in values)
        if (map.Contains(vector))
        {
          heap.Enqueue(new Link<Vector<double>, int>(vector, map[vector]));
          map.Remove(vector);
        }

      return heap;
    }

    /// <summary>Computes the median value in a set.</summary>
    /// <param name="traversal">A traversal function for a set.</param>
    /// <returns>The computed median of the values.</returns>
    public static Vector<double> Median(Traversal<Vector<double>> traversal)
    {
      throw new Error("requires a comparable type");

      //if (values.Length == 1)
      //  return values[0];

      //double[] sorted = values.Clone() as double[];
      //Sort.Quick<double>(Logic.Compare, sorted);
      //if (sorted.Length % 2 == 1)
      //  return sorted[sorted.Length / 2 + 1];
      //else
      //  return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    /// <summary>Computes the median value in a set.</summary>
    /// <param name="traversal">The values to compute the median of.</param>
    /// <returns>The computed median of the values.</returns>
    public static Vector<double> Median(params Vector<double>[] values)
    {
      throw new Error("requires a comparable type");

      //if (values.Length == 1)
      //  return values[0];

      //double[] sorted = values.Clone() as double[];
      //Sort.Quick<double>(Logic.Compare, sorted);
      //if (sorted.Length % 2 == 1)
      //  return sorted[sorted.Length / 2 + 1];
      //else
      //  return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    #endregion

    #region Vector<float>

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static Vector<float> Mean(Vector<float> a, Vector<float> b)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(a, null))
        throw new Error("null reference: a");
      if (object.ReferenceEquals(b, null))
        throw new Error("null reference: b");
      if (a.Dimensions != b.Dimensions)
        throw new Error("invalid vectors during mean (a.Dimensions != b.Dimensions)");
#endif

      return (a + b) / (float)2;
    }

    /// <summary>Computes the mean, or average, between multiple values.</summary>
    /// <param name="traversal">A function for traversing a set.</param>
    /// <returns>The mean of the provided values.</returns>
    public static Vector<float> Mean(Traversal<Vector<float>> traversal)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(traversal, null))
        throw new Error("null reference: values");
#endif

      int count = 0;
      Vector<float> sum = null;
      traversal(
        (Vector<float> current) =>
        {
          if (count == 0)
            sum = new Vector<float>(current.Dimensions);

#if no_error_checking
          // nothing
#else
          if (current.Dimensions != sum.Dimensions)
            throw new Error("invalid vector during mean: dimension mismatch");
#endif

          sum += current;
          count++;
        });

#if no_error_checking
          // nothing
#else
      if (count == 0)
        throw new Error("invalid values during mean: (values.Count == 0)");
#endif

      return sum / (float)count;
    }

    /// <summary>Computes the mean, or average, between multiple values.</summary>
    /// <param name="values">The values to compute the mean of/</param>
    /// <returns>The mean of the provided values.</returns>
    public static Vector<float> Mean(params Vector<float>[] values)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(values, null))
        throw new Error("null reference: values");
      if (values.Length < 1)
        throw new Error("invalid values during mean: (values.Length < 1)");
#endif

      Vector<float> sum =
        new Vector<float>(values[0].Dimensions);
      foreach (Vector<float> value in values)
        sum += value;
      return sum / (float)values.Length;
    }

    /// <summary>Computes the mode (most ocurring) value in a set.</summary>
    /// <param name="traversal">A function for traversing a set.</param>
    /// <returns>A heap sorted along the number of occurences for each item.</returns>
    public static Heap<Link<Vector<float>, int>> Mode(Traversal<Vector<float>> traversal)
    {
      throw new System.NotImplementedException();

      Heap<Link<Vector<float>, int>> heap =
        new Heap_Array<Link<Vector<float>, int>>(
          (Link<Vector<float>, int> left, Link<Vector<float>, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      // Note: can be optimized when the dynamic heap is finished
      Map<int, Vector<float>> map =
        new Map_Linked<int, Vector<float>>(
          Vector<float>.EqualsValue,
          Hash.Default);

      traversal(
        (Vector<float> vector) =>
        {
          if (map.Contains(vector))
            map[vector]++;
          else
            map.Add(vector, 1);
        });

      traversal(
        (Vector<float> vector) =>
        {
          if (map.Contains(vector))
          {
            heap.Enqueue(new Link<Vector<float>, int>(vector, map[vector]));
            map.Remove(vector);
          }
        });

      return heap;
    }

    /// <summary>Computes the mode (most ocurring) value in a set.</summary>
    /// <param name="values">The values to compute the mode of.</param>
    /// <returns>A heap sorted along the number of occurences for each item.</returns>
    public static Heap<Link<Vector<float>, int>> Mode(params Vector<float>[] values)
    {
      throw new System.NotImplementedException();

      Heap<Link<Vector<float>, int>> heap =
        new Heap_Array<Link<Vector<float>, int>>(
          (Link<Vector<float>, int> left, Link<Vector<float>, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      // Note: can be optimized when the dynamic heap is finished
      Map<int, Vector<float>> map =
        new Map_Linked<int, Vector<float>>(
          Vector<float>.EqualsValue,
          Hash.Default);

      foreach (Vector<float> vector in values)
        if (map.Contains(vector))
          map[vector]++;
        else
          map.Add(vector, 1);

      foreach (Vector<float> vector in values)
        if (map.Contains(vector))
        {
          heap.Enqueue(new Link<Vector<float>, int>(vector, map[vector]));
          map.Remove(vector);
        }

      return heap;
    }

    /// <summary>Computes the median value in a set.</summary>
    /// <param name="traversal">A traversal function for a set.</param>
    /// <returns>The computed median of the values.</returns>
    public static Vector<float> Median(Traversal<Vector<float>> traversal)
    {
      throw new Error("requires a comparable type");

      //if (values.Length == 1)
      //  return values[0];

      //float[] sorted = values.Clone() as float[];
      //Sort.Quick<float>(Logic.Compare, sorted);
      //if (sorted.Length % 2 == 1)
      //  return sorted[sorted.Length / 2 + 1];
      //else
      //  return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    /// <summary>Computes the median value in a set.</summary>
    /// <param name="traversal">The values to compute the median of.</param>
    /// <returns>The computed median of the values.</returns>
    public static Vector<float> Median(params Vector<float>[] values)
    {
      throw new Error("requires a comparable type");

      //if (values.Length == 1)
      //  return values[0];

      //float[] sorted = values.Clone() as float[];
      //Sort.Quick<float>(Logic.Compare, sorted);
      //if (sorted.Length % 2 == 1)
      //  return sorted[sorted.Length / 2 + 1];
      //else
      //  return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    #endregion

    #region Vector<long>

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static Vector<long> Mean(Vector<long> a, Vector<long> b)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(a, null))
        throw new Error("null reference: a");
      if (object.ReferenceEquals(b, null))
        throw new Error("null reference: b");
      if (a.Dimensions != b.Dimensions)
        throw new Error("invalid vectors during mean (a.Dimensions != b.Dimensions)");
#endif

      return (a + b) / (long)2;
    }

    /// <summary>Computes the mean, or average, between multiple values.</summary>
    /// <param name="traversal">A function for traversing a set.</param>
    /// <returns>The mean of the provided values.</returns>
    public static Vector<long> Mean(Traversal<Vector<long>> traversal)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(traversal, null))
        throw new Error("null reference: values");
#endif

      int count = 0;
      Vector<long> sum = null;
      traversal(
        (Vector<long> current) =>
        {
          if (count == 0)
            sum = new Vector<long>(current.Dimensions);

#if no_error_checking
          // nothing
#else
          if (current.Dimensions != sum.Dimensions)
            throw new Error("invalid vector during mean: dimension mismatch");
#endif

          sum += current;
          count++;
        });

#if no_error_checking
          // nothing
#else
      if (count == 0)
        throw new Error("invalid values during mean: (values.Count == 0)");
#endif

      return sum / (long)count;
    }

    /// <summary>Computes the mean, or average, between multiple values.</summary>
    /// <param name="values">The values to compute the mean of/</param>
    /// <returns>The mean of the provided values.</returns>
    public static Vector<long> Mean(params Vector<long>[] values)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(values, null))
        throw new Error("null reference: values");
      if (values.Length < 1)
        throw new Error("invalid values during mean: (values.Length < 1)");
#endif

      Vector<long> sum =
        new Vector<long>(values[0].Dimensions);
      foreach (Vector<long> value in values)
        sum += value;
      return sum / (long)values.Length;
    }

    /// <summary>Computes the mode (most ocurring) value in a set.</summary>
    /// <param name="traversal">A function for traversing a set.</param>
    /// <returns>A heap sorted along the number of occurences for each item.</returns>
    public static Heap<Link<Vector<long>, int>> Mode(Traversal<Vector<long>> traversal)
    {
      throw new System.NotImplementedException();

      Heap<Link<Vector<long>, int>> heap =
        new Heap_Array<Link<Vector<long>, int>>(
          (Link<Vector<long>, int> left, Link<Vector<long>, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      // Note: can be optimized when the dynamic heap is finished
      Map<int, Vector<long>> map =
        new Map_Linked<int, Vector<long>>(
          Vector<long>.EqualsValue,
          Hash.Default);

      traversal(
        (Vector<long> vector) =>
        {
          if (map.Contains(vector))
            map[vector]++;
          else
            map.Add(vector, 1);
        });

      traversal(
        (Vector<long> vector) =>
        {
          if (map.Contains(vector))
          {
            heap.Enqueue(new Link<Vector<long>, int>(vector, map[vector]));
            map.Remove(vector);
          }
        });

      return heap;
    }

    /// <summary>Computes the mode (most ocurring) value in a set.</summary>
    /// <param name="values">The values to compute the mode of.</param>
    /// <returns>A heap sorted along the number of occurences for each item.</returns>
    public static Heap<Link<Vector<long>, int>> Mode(params Vector<long>[] values)
    {
      throw new System.NotImplementedException();

      Heap<Link<Vector<long>, int>> heap =
        new Heap_Array<Link<Vector<long>, int>>(
          (Link<Vector<long>, int> left, Link<Vector<long>, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      // Note: can be optimized when the dynamic heap is finished
      Map<int, Vector<long>> map =
        new Map_Linked<int, Vector<long>>(
          Vector<long>.EqualsValue,
          Hash.Default);

      foreach (Vector<long> vector in values)
        if (map.Contains(vector))
          map[vector]++;
        else
          map.Add(vector, 1);

      foreach (Vector<long> vector in values)
        if (map.Contains(vector))
        {
          heap.Enqueue(new Link<Vector<long>, int>(vector, map[vector]));
          map.Remove(vector);
        }

      return heap;
    }

    /// <summary>Computes the median value in a set.</summary>
    /// <param name="traversal">A traversal function for a set.</param>
    /// <returns>The computed median of the values.</returns>
    public static Vector<long> Median(Traversal<Vector<long>> traversal)
    {
      throw new Error("requires a comparable type");

      //if (values.Length == 1)
      //  return values[0];

      //long[] sorted = values.Clone() as long[];
      //Sort.Quick<long>(Logic.Compare, sorted);
      //if (sorted.Length % 2 == 1)
      //  return sorted[sorted.Length / 2 + 1];
      //else
      //  return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    /// <summary>Computes the median value in a set.</summary>
    /// <param name="traversal">The values to compute the median of.</param>
    /// <returns>The computed median of the values.</returns>
    public static Vector<long> Median(params Vector<long>[] values)
    {
      throw new Error("requires a comparable type");

      //if (values.Length == 1)
      //  return values[0];

      //long[] sorted = values.Clone() as long[];
      //Sort.Quick<long>(Logic.Compare, sorted);
      //if (sorted.Length % 2 == 1)
      //  return sorted[sorted.Length / 2 + 1];
      //else
      //  return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    #endregion

    #region Vector<int>

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static Vector<int> Mean(Vector<int> a, Vector<int> b)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(a, null))
        throw new Error("null reference: a");
      if (object.ReferenceEquals(b, null))
        throw new Error("null reference: b");
      if (a.Dimensions != b.Dimensions)
        throw new Error("invalid vectors during mean (a.Dimensions != b.Dimensions)");
#endif

      return (a + b) / (int)2;
    }

    /// <summary>Computes the mean, or average, between multiple values.</summary>
    /// <param name="traversal">A function for traversing a set.</param>
    /// <returns>The mean of the provided values.</returns>
    public static Vector<int> Mean(Traversal<Vector<int>> traversal)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(traversal, null))
        throw new Error("null reference: values");
#endif

      int count = 0;
      Vector<int> sum = null;
      traversal(
        (Vector<int> current) =>
        {
          if (count == 0)
            sum = new Vector<int>(current.Dimensions);

#if no_error_checking
          // nothing
#else
          if (current.Dimensions != sum.Dimensions)
            throw new Error("invalid vector during mean: dimension mismatch");
#endif

          sum += current;
          count++;
        });

#if no_error_checking
          // nothing
#else
      if (count == 0)
        throw new Error("invalid values during mean: (values.Count == 0)");
#endif

      return sum / (int)count;
    }

    /// <summary>Computes the mean, or average, between multiple values.</summary>
    /// <param name="values">The values to compute the mean of/</param>
    /// <returns>The mean of the provided values.</returns>
    public static Vector<int> Mean(params Vector<int>[] values)
    {
#if no_error_checking
      // nothing
#else
      if (object.ReferenceEquals(values, null))
        throw new Error("null reference: values");
      if (values.Length < 1)
        throw new Error("invalid values during mean: (values.Length < 1)");
#endif

      Vector<int> sum =
        new Vector<int>(values[0].Dimensions);
      foreach (Vector<int> value in values)
        sum += value;
      return sum / (int)values.Length;
    }

    /// <summary>Computes the mode (most ocurring) value in a set.</summary>
    /// <param name="traversal">A function for traversing a set.</param>
    /// <returns>A heap sorted along the number of occurences for each item.</returns>
    public static Heap<Link<Vector<int>, int>> Mode(Traversal<Vector<int>> traversal)
    {
      throw new System.NotImplementedException();

      Heap<Link<Vector<int>, int>> heap =
        new Heap_Array<Link<Vector<int>, int>>(
          (Link<Vector<int>, int> left, Link<Vector<int>, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      // Note: can be optimized when the dynamic heap is finished
      Map<int, Vector<int>> map =
        new Map_Linked<int, Vector<int>>(
          Vector<int>.EqualsValue,
          Hash.Default);

      traversal(
        (Vector<int> vector) =>
        {
          if (map.Contains(vector))
            map[vector]++;
          else
            map.Add(vector, 1);
        });

      traversal(
        (Vector<int> vector) =>
        {
          if (map.Contains(vector))
          {
            heap.Enqueue(new Link<Vector<int>, int>(vector, map[vector]));
            map.Remove(vector);
          }
        });

      return heap;
    }

    /// <summary>Computes the mode (most ocurring) value in a set.</summary>
    /// <param name="values">The values to compute the mode of.</param>
    /// <returns>A heap sorted along the number of occurences for each item.</returns>
    public static Heap<Link<Vector<int>, int>> Mode(params Vector<int>[] values)
    {
      throw new System.NotImplementedException();

      Heap<Link<Vector<int>, int>> heap =
        new Heap_Array<Link<Vector<int>, int>>(
          (Link<Vector<int>, int> left, Link<Vector<int>, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      // Note: can be optimized when the dynamic heap is finished
      Map<int, Vector<int>> map =
        new Map_Linked<int, Vector<int>>(
          Vector<int>.EqualsValue,
          Hash.Default);

      foreach (Vector<int> vector in values)
        if (map.Contains(vector))
          map[vector]++;
        else
          map.Add(vector, 1);

      foreach (Vector<int> vector in values)
        if (map.Contains(vector))
        {
          heap.Enqueue(new Link<Vector<int>, int>(vector, map[vector]));
          map.Remove(vector);
        }

      return heap;
    }

    /// <summary>Computes the median value in a set.</summary>
    /// <param name="traversal">A traversal function for a set.</param>
    /// <returns>The computed median of the values.</returns>
    public static Vector<int> Median(Traversal<Vector<int>> traversal)
    {
      throw new Error("requires a comparable type");

      //if (values.Length == 1)
      //  return values[0];

      //int[] sorted = values.Clone() as int[];
      //Sort.Quick<int>(Logic.Compare, sorted);
      //if (sorted.Length % 2 == 1)
      //  return sorted[sorted.Length / 2 + 1];
      //else
      //  return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    /// <summary>Computes the median value in a set.</summary>
    /// <param name="traversal">The values to compute the median of.</param>
    /// <returns>The computed median of the values.</returns>
    public static Vector<int> Median(params Vector<int>[] values)
    {
      throw new Error("requires a comparable type");

      //if (values.Length == 1)
      //  return values[0];

      //int[] sorted = values.Clone() as int[];
      //Sort.Quick<int>(Logic.Compare, sorted);
      //if (sorted.Length % 2 == 1)
      //  return sorted[sorted.Length / 2 + 1];
      //else
      //  return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    #endregion

    #region Fraction128

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static Fraction128 Mean(Fraction128 a, Fraction128 b)
    {
      return (a + b) / 2;
    }

    public static Fraction128 Mean(params Fraction128[] values)
    {
      Fraction128 sum = 0;
      foreach (Fraction128 value in values)
        sum += value;
      return sum / (Fraction128)values.Length;
    }

    public static Heap<Link<Fraction128, int>> Mode(params Fraction128[] values)
    {
      Heap<Link<Fraction128, int>> heap =
        new Heap_Array<Link<Fraction128, int>>(
          (Link<Fraction128, int> left, Link<Fraction128, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      Fraction128[] sorted = values.Clone() as Fraction128[];
      Sort.Quick<Fraction128>(Logic.Compare, sorted);

      int temp = 0;

      for (int i = 0; i < sorted.Length; i++)
      {
        temp = i - 1;
        for (; i + 1 < sorted.Length && sorted[i] == sorted[i + 1]; i++)
          continue;
        heap.Enqueue(new Link<Fraction128, int>(sorted[i], i - temp));
      }

      return heap;
    }

    public static Fraction128 Median(params Fraction128[] values)
    {
      if (values.Length == 1)
        return values[0];

      Fraction128[] sorted = values.Clone() as Fraction128[];
      Sort.Quick<Fraction128>(Logic.Compare, sorted);
      if (sorted.Length % 2 == 1)
        return sorted[sorted.Length / 2 + 1];
      else
        return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    #endregion

    #region Fraction64

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static Fraction64 Mean(Fraction64 a, Fraction64 b)
    {
      return (a + b) / 2;
    }

    public static Fraction64 Mean(params Fraction64[] values)
    {
      Fraction64 sum = 0;
      foreach (Fraction64 value in values)
        sum += value;
      return sum / (Fraction64)values.Length;
    }

    public static Heap<Link<Fraction64, int>> Mode(params Fraction64[] values)
    {
      Heap<Link<Fraction64, int>> heap =
        new Heap_Array<Link<Fraction64, int>>(
          (Link<Fraction64, int> left, Link<Fraction64, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      Fraction64[] sorted = values.Clone() as Fraction64[];
      Sort.Quick<Fraction64>(Logic.Compare, sorted);

      int temp = 0;

      for (int i = 0; i < sorted.Length; i++)
      {
        temp = i - 1;
        for (; i + 1 < sorted.Length && sorted[i] == sorted[i + 1]; i++)
          continue;
        heap.Enqueue(new Link<Fraction64, int>(sorted[i], i - temp));
      }

      return heap;
    }

    public static Fraction64 Median(params Fraction64[] values)
    {
      if (values.Length == 1)
        return values[0];

      Fraction64[] sorted = values.Clone() as Fraction64[];
      Sort.Quick<Fraction64>(Logic.Compare, sorted);
      if (sorted.Length % 2 == 1)
        return sorted[sorted.Length / 2 + 1];
      else
        return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    #endregion

    #region string

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static string Mean(string a, string b)
    {
      char[] mean = new char[Logic.Max(a.Length, b.Length)];

      int i = 0;
      for (int i_max = Logic.Min(a.Length, b.Length); i < i_max; i++)
        mean[i] = (char)((a[i] + b[i]) / 2);

      for (; i < a.Length; i++)
        mean[i] = (char)((a[i]) / 2);

      for (; i < b.Length; i++)
        mean[i] = (char)((b[i]) / 2);

      return new string(mean);
    }

    public static string Mean(params string[] values)
    {
      int length = 0;
      foreach (string str in values)
        if (str.Length > length)
          length = str.Length;

      char[] mean = new char[length];

      for (int i = 0; i < length; i++)
      {
        int sum = 0;
        for (int j = 0; j < values.Length; j++)
          if (values[j].Length > i)
            sum += values[j][i];

        mean[i] = (char)(sum / values.Length);
      }

      return new string(mean);
    }

    public static Heap<Link<string, int>> Mode(params string[] values)
    {
      Heap<Link<string, int>> heap =
        new Heap_Array<Link<string, int>>(
          (Link<string, int> left, Link<string, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      string[] sorted = values.Clone() as string[];
      Sort.Quick<string>(Logic.Compare, sorted);

      int temp = 0;

      for (int i = 0; i < sorted.Length; i++)
      {
        temp = i - 1;
        for (; i + 1 < sorted.Length && sorted[i] == sorted[i + 1]; i++)
          continue;
        heap.Enqueue(new Link<string, int>(sorted[i], i - temp));
      }

      return heap;
    }

    public static string Median(params string[] values)
    {
      if (values.Length == 1)
        return values[0];

      string[] sorted = values.Clone() as string[];
      Sort.Quick<string>(Logic.Compare, sorted);
      if (sorted.Length % 2 == 1)
        return sorted[sorted.Length / 2 + 1];
      else
        return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    #endregion

    #region decimal

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static decimal Mean(decimal a, decimal b)
    {
      return (a + b) * 0.5M;
    }

    public static decimal Mean(params decimal[] values)
    {
      decimal sum = 0.0M;
      foreach (decimal value in values)
        sum += value;
      return sum / (decimal)values.Length;
    }

    public static Heap<Link<decimal, int>> Mode(params decimal[] values)
    {
      Heap<Link<decimal, int>> heap =
        new Heap_Array<Link<decimal, int>>(
          (Link<decimal, int> left, Link<decimal, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      decimal[] sorted = values.Clone() as decimal[];
      Sort.Quick<decimal>(Logic.Compare, sorted);

      int temp = 0;

      for (int i = 0; i < sorted.Length; i++)
      {
        temp = i - 1;
        for (; i + 1 < sorted.Length && sorted[i] == sorted[i + 1]; i++)
          continue;
        heap.Enqueue(new Link<decimal, int>(sorted[i], i - temp));
      }

      return heap;
    }

    public static decimal Median(params decimal[] values)
    {
      if (values.Length == 1)
        return values[0];

      decimal[] sorted = values.Clone() as decimal[];
      Sort.Quick<decimal>(Logic.Compare, sorted);
      if (sorted.Length % 2 == 1)
        return sorted[sorted.Length / 2 + 1];
      else
        return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    #endregion

    #region float

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static float Mean(float a, float b)
    {
      return (a + b) * 0.5f;
    }

    public static float Mean(params float[] values)
    {
      float sum = 0.0f;
      foreach (float value in values)
        sum += value;
      return sum / (float)values.Length;
    }

    public static Heap<Link<float, int>> Mode(params float[] values)
    {
      Heap<Link<float, int>> heap =
        new Heap_Array<Link<float, int>>(
          (Link<float, int> left, Link<float, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      float[] sorted = values.Clone() as float[];
      Sort.Quick<float>(Logic.Compare, sorted);

      int temp = 0;

      for (int i = 0; i < sorted.Length; i++)
      {
        temp = i - 1;
        for (; i + 1 < sorted.Length && sorted[i] == sorted[i + 1]; i++)
          continue;
        heap.Enqueue(new Link<float, int>(sorted[i], i - temp));
      }

      return heap;
    }

    public static float Median(params float[] values)
    {
      if (values.Length == 1)
        return values[0];

      float[] sorted = values.Clone() as float[];
      Sort.Quick<float>(Logic.Compare, sorted);
      if (sorted.Length % 2 == 1)
        return sorted[sorted.Length / 2 + 1];
      else
        return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    #endregion

    #region double

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static double Mean(double a, double b)
    {
      return (a + b) / (double)2;
    }

    /// <summary>Computes the mean of a set of values.</summary>
    /// <param name="values">The set values to mean.</param>
    /// <returns>The computed mean of the set.</returns>
    public static double Mean(params double[] values)
    {
      return Statistics.Mean(
        (Foreach<double> function) => 
        {
          foreach (double value in values)
            function(value);
        });
    }

    /// <summary>Computes the mean of a set of values.</summary>
    /// <param name="function">The set values to mean.</param>
    /// <returns>The computed mean of the set.</returns>
    public static double Mean(Traversal<double> function)
    {
      double sum = 0;
      int count = 0;
      function((double current) =>
        {
          count++;
          sum += current;
        });
      return sum / (double)count;
    }

    /// <summary>Computes the geometric mean of a set.</summary>
    /// <param name="values">The set to compute the geometric mean of.</param>
    /// <returns>The computed geometric mean of the set.</returns>
    public static double GeometricMean(params double[] values)
    {
      return Statistics.GeometricMean(
        (Foreach<double> function) =>
        {
          foreach (double value in values)
            function(value);
        });
    }

    /// <summary></summary>
    /// <param name="function"></param>
    /// <returns></returns>
    public static double GeometricMean(Traversal<double> function)
    {
      double multiple = 1;
      int count = 0;
      function((double current) =>
        {
          count++;
          multiple *= current;
        });
      return Algebra.root(multiple, (double)count);
    }

    /// <summary>Findes the mode(s) of a set.</summary>
    /// <param name="modes">The modes that are found.</param>
    /// <param name="ocurrences">The number of occurences of the modes.</param>
    /// <param name="values">The set to find the modes of.</param>
    public static void Mode(out double[] modes, out int ocurrences, params double[] values)
    {
      // Can be improved when the dictionary heap is finished (no clone-sort necessary)
      double[] sorted = values.Clone() as double[];
      Sort.Quick<double>(Logic.Compare, sorted);

      int temp = 0;
      ocurrences = 1;
      List<double> possible_modes = new List_Linked<double>();
      for (int i = 0; i < sorted.Length; i++)
      {
        temp = i - 1;
        for (; i + 1 < sorted.Length && sorted[i] == sorted[i + 1]; i++)
          continue;

        if (ocurrences > 1)
        {
          int i_ocurrences = i - temp;
          if (i_ocurrences > ocurrences)
          {
            possible_modes.Clear();
            ocurrences = i_ocurrences;
            possible_modes.Add(sorted[i]);
          }
          else if (i_ocurrences == ocurrences)
          {
            possible_modes.Add(sorted[i]);
          }
        }
      }

      if (ocurrences == 1)
        modes = sorted;
      else
        modes = possible_modes.ToArray();
    }

    /// <summary>Findes the mode(s) of a set.</summary>
    /// <param name="modes">The modes that are found.</param>
    /// <param name="ocurrences">The number of occurences of the modes.</param>
    /// <param name="function">The set to find the modes of.</param>
    public static void Mode(out double[] modes, out int ocurrences, Traversal<double> function)
    {
      List<double> values = new List_Linked<double>();
      function((double i) => { values.Add(i); });

      double[] sorted = values.ToArray();
      Sort.Quick<double>(Logic.Compare, sorted);

      int temp = 0;
      ocurrences = 1;
      List<double> possible_modes = new List_Linked<double>();
      for (int i = 0; i < sorted.Length; i++)
      {
        temp = i - 1;
        for (; i + 1 < sorted.Length && sorted[i] == sorted[i + 1]; i++)
          continue;

        if (ocurrences > 1)
        {
          int i_ocurrences = i - temp;
          if (i_ocurrences > ocurrences)
          {
            possible_modes.Clear();
            ocurrences = i_ocurrences;
            possible_modes.Add(sorted[i]);
          }
          else if (i_ocurrences == ocurrences)
          {
            possible_modes.Add(sorted[i]);
          }
        }
      }

      if (ocurrences == 1)
        modes = sorted;
      else
        modes = possible_modes.ToArray();
    }

    public static double Median(params double[] values)
    {
      double[] sorted = values.Clone() as double[];
      Sort.Quick<double>(Logic.Compare, sorted);
      if (sorted.Length % 2 == 1)
        return sorted[sorted.Length / 2];
      else
        return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    public static double Median(Traversal<double> function)
    {
      // Note: optimize...
      List<double> values = new List_Linked<double>();
      function((double i) =>
        {
          values.Add(i);
        });

      double[] values_array = values.ToArray();

      Sort.Quick<double>(Logic.Compare, values_array);
      if (values_array.Length % 2 == 1)
        return values_array[values_array.Length / 2];
      else
        return Statistics.Mean(values_array[values_array.Length / 2], values_array[values_array.Length / 2 + 1]);
    }

    public static void Range(out double min, out double max, params double[] values)
    {
      Statistics.Range(out min, out max, (Foreach<double> function) =>
        {
          foreach (double i in values)
            function(i);
        });
    }

    public static void Range(out double min, out double max, Traversal<double> function)
    {
      double temp_min = double.MaxValue;
      double temp_max = double.MinValue;

      function((double i) =>
      {
        temp_min = i < temp_min ? i : temp_min;
        temp_max = i > temp_max ? i : temp_max;
      });

      min = temp_min;
      max = temp_max;
    }

    public static double Variance(params double[] values)
    {
      #region error checking

#if no_error_checking
      // nothing
#else
      if (values == null)
        throw new Error("null reference: values");
#endif

      #endregion

      return Statistics.Variance((Foreach<double> function) =>
        {
          foreach (double i in values)
            function(i);
        });
    }

    public static double Variance(Traversal<double> function)
    {
      #region error checking

#if no_error_checking
      // nothing
#else
      if (function == null)
        throw new Error("null reference: values");
#endif

      #endregion

      double mean = Mean(function);
      double variance = 0;
      int count = 0;
      function((double i) =>
        {
          double i_minus_mean = i - mean;
          variance += i_minus_mean * i_minus_mean;
          count++;
        });
      return variance / (double)count;
    }

    public static double MeanDeviation(params double[] data)
    {
      return Statistics.MeanDeviation((Foreach<double> function) =>
        {
          foreach (double i in data)
            function(i);
        });
    }

    public static double MeanDeviation(Traversal<double> function)
    {
      double mean = Statistics.Mean(function);

      double temp = 0;
      int count = 0;

      function((double i) =>
        {
          temp += Logic.Abs(i - mean);
          count++;
        });

      return temp / (double)count;
    }

    public static double StandardDeviation(params double[] data)
    {
      #region error checking
#if no_error_checking
      // nothing
#else
      if (data == null)
        throw new Error("null reference: data");
#endif
      #endregion

      return Algebra.sqrt(Variance(data));
    }

    public static double StandardDeviation(Traversal<double> function)
    {
      #region error checking

#if no_error_checking
      // nothing
#else
      if (function == null)
        throw new Error("null reference: function");
#endif

      #endregion

      return Algebra.sqrt(Variance(function));
    }

    public static double[] Quantiles(int divisions, params double[] data)
    {
      #region error checking
#if no_error_checking
      // nothing
#else
      if (data == null)
        throw new Error("null reference: data");
      if (divisions < 1)
        throw new Error("invalid numer of dimensions on Quantile division");
#endif
      #endregion

      return Statistics.Quantiles(divisions, (Foreach<double> function) =>
        {
          foreach (double i in data)
            function(i);
        });
    }

    public static double[] Quantiles(int divisions, Traversal<double> function)
    {
      #region error checking

#if no_error_checking
      // nothing
#else
      if (function == null)
        throw new Error("null reference: data");
      if (divisions < 1)
        throw new Error("invalid numer of dimensions on Quantile division");
#endif

      #endregion

      List<double> values = new List_Linked<double>();
      function((double i) => { values.Add(i); });

      double[] ordered = values.ToArray();
      Sort.Quick<double>(Logic.Compare, ordered);

      double[] quantiles = new double[divisions + 1];
      quantiles[0] = ordered[0];
      quantiles[quantiles.Length - 1] = ordered[ordered.Length - 1];
      for (int i = 1; i < divisions; i++)
      {
        float temp = (ordered.Length / (float)(divisions + 1)) * i;
        if (temp % 1 == 0)
          quantiles[i] = ordered[(int)temp];
        else
          quantiles[i] = (ordered[(int)temp] + ordered[(int)temp + 1]) / (double)2;
      }

      return quantiles;
    }

    public static double Correlation(double[] a, double[] b)
    {
      double a_mean = Statistics.Mean(a);
      double b_mean = Statistics.Mean(b);

      // a_temp = a - b_mean
      double[] a_temp = new double[a.Length];
      for (int i = 0; i < a_temp.Length; i++)
        a_temp[i] = a[i] - b_mean;

      // b_temp = b - a_mean
      double[] b_temp = new double[b.Length];
      for (int i = 0; i < b_temp.Length; i++)
        b_temp[i] = b[i] - a_mean;

      double[] a_cross_b = new double[a.Length * b.Length];
      for (int i = 0; i < a_temp.Length; i++)
        for (int j = 0; j < b_temp.Length; j++)
          a_cross_b[i * b_temp.Length + j] = a[i] * b[j];

      // square each entry in a_temp
      for (int i = 0; i < a_temp.Length; i++)
        a_temp[i] *= a_temp[i];

      // square each entry in b_temp
      for (int i = 0; i < b_temp.Length; i++)
        b_temp[i] *= b_temp[i];

      double sum_a_cross_b = 0;
      foreach (double i in a_cross_b)
        sum_a_cross_b += i;

      double sum_a_temp = 0;
      foreach (double i in a_temp)
        sum_a_temp += i;

      double sum_b_temp = 0;
      foreach (double i in b_temp)
        sum_b_temp += i;

      return sum_a_cross_b / Algebra.sqrt(sum_a_temp * sum_b_temp);
    }

    public static double Correlation(Traversal<double> a, Traversal<double> b)
    {
      double a_mean = Statistics.Mean(a);
      double b_mean = Statistics.Mean(b);

      List<double> a_temp = new List_Linked<double>();
      a((double i) => { a_temp.Add(i - b_mean); });

      List<double> b_temp = new List_Linked<double>();
      b((double i) => { b_temp.Add(i - a_mean); });


      double[] a_cross_b = new double[a_temp.Count * b_temp.Count];
      int count = 0;
      a_temp.Foreach((double i_a) =>
        {
          b_temp.Foreach((double i_b) =>
            {
              a_cross_b[count++] = i_a * i_b;
            });
        });

      a_temp.Foreach((ref double i) => { i *= i; });
      b_temp.Foreach((ref double i) => { i *= i; });
      
      double sum_a_cross_b = 0;
      foreach (double i in a_cross_b)
        sum_a_cross_b += i;

      double sum_a_temp = 0;
      a_temp.Foreach((double i) => { sum_a_temp += i; });
      double sum_b_temp = 0;
      b_temp.Foreach((double i) => { sum_b_temp += i; });

      return sum_a_cross_b / Algebra.sqrt(sum_a_temp * sum_b_temp);
    }

    #endregion

    #region long

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static long Mean(long a, long b)
    {
      return (a + b) / 2;
    }

    public static long Mean(params long[] values)
    {
      long sum = 0;
      foreach (long value in values)
        sum += value;
      return sum / (long)values.Length;
    }

    public static Heap<Link<long, int>> Mode(params long[] values)
    {
      Heap<Link<long, int>> heap =
        new Heap_Array<Link<long, int>>(
          (Link<long, int> left, Link<long, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      long[] sorted = values.Clone() as long[];
      Sort.Quick<long>(Logic.Compare, sorted);

      int temp = 0;

      for (int i = 0; i < sorted.Length; i++)
      {
        temp = i - 1;
        for (; i + 1 < sorted.Length && sorted[i] == sorted[i + 1]; i++)
          continue;
        heap.Enqueue(new Link<long, int>(sorted[i], i - temp));
      }

      return heap;
    }

    public static long Median(params long[] values)
    {
      if (values.Length == 1)
        return values[0];

      long[] sorted = values.Clone() as long[];
      Sort.Quick<long>(Logic.Compare, sorted);
      if (sorted.Length % 2 == 1)
        return sorted[sorted.Length / 2 + 1];
      else
        return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    #endregion

    #region int

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static int Mean(int a, int b)
    {
      return (a + b) / 2;
    }

    public static int Mean(params int[] values)
    {
      int sum = 0;
      foreach (int value in values)
        sum += value;
      return sum / (int)values.Length;
    }

    public static Heap<Link<int, int>> Mode(params int[] values)
    {
      Heap<Link<int, int>> heap =
        new Heap_Array<Link<int, int>>(
          (Link<int, int> left, Link<int, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      int[] sorted = values.Clone() as int[];
      Sort.Quick<int>(Logic.Compare, sorted);

      int temp = 0;

      for (int i = 0; i < sorted.Length; i++)
      {
        temp = i - 1;
        for (; i + 1 < sorted.Length && sorted[i] == sorted[i + 1]; i++)
          continue;
        heap.Enqueue(new Link<int, int>(sorted[i], i - temp));
      }

      return heap;
    }

    public static int Median(params int[] values)
    {
      if (values.Length == 1)
        return values[0];

      int[] sorted = values.Clone() as int[];
      Sort.Quick<int>(Logic.Compare, sorted);
      if (sorted.Length % 2 == 1)
        return sorted[sorted.Length / 2 + 1];
      else
        return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    #endregion

    #region short

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static short Mean(short a, short b)
    {
      return (short)((a + b) / 2);
    }

    public static short Mean(params short[] values)
    {
      short sum = 0;
      foreach (short value in values)
        sum += value;
      return (short)(sum / (short)values.Length);
    }

    public static Heap<Link<short, int>> Mode(params short[] values)
    {
      Heap<Link<short, int>> heap =
        new Heap_Array<Link<short, int>>(
          (Link<short, int> left, Link<short, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      short[] sorted = values.Clone() as short[];
      Sort.Quick<short>(Logic.Compare, sorted);

      int temp = 0;

      for (int i = 0; i < sorted.Length; i++)
      {
        temp = i - 1;
        for (; i + 1 < sorted.Length && sorted[i] == sorted[i + 1]; i++)
          continue;
        heap.Enqueue(new Link<short, int>(sorted[i], i - temp));
      }

      return heap;
    }

    public static short Median(params short[] values)
    {
      if (values.Length == 1)
        return values[0];

      short[] sorted = values.Clone() as short[];
      Sort.Quick<short>(Logic.Compare, sorted);
      if (sorted.Length % 2 == 1)
        return sorted[sorted.Length / 2 + 1];
      else
        return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    #endregion

    #region byte

    /// <summary>Computes the mean, or average, between two values.</summary>
    /// <param name="a">An operand of the average operation.</param>
    /// <param name="b">An operand of the average operation.</param>
    /// <returns>The mean of the provides values.</returns>
    public static byte Mean(byte a, byte b)
    {
      return (byte)((a + b) / 2);
    }

    public static byte Mean(params byte[] values)
    {
      byte sum = 0;
      foreach (byte value in values)
        sum += value;
      return (byte)(sum / (byte)values.Length);
    }

    public static Heap<Link<byte, int>> Mode(params byte[] values)
    {
      Heap<Link<byte, int>> heap =
        new Heap_Array<Link<byte, int>>(
          (Link<byte, int> left, Link<byte, int> right) =>
          { return Logic.Compare(left.Two, right.Two); });

      byte[] sorted = values.Clone() as byte[];
      Sort.Quick<byte>(Logic.Compare, sorted);

      int temp = 0;

      for (int i = 0; i < sorted.Length; i++)
      {
        temp = i - 1;
        for (; i + 1 < sorted.Length && sorted[i] == sorted[i + 1]; i++)
          continue;
        heap.Enqueue(new Link<byte, int>(sorted[i], i - temp));
      }

      return heap;
    }

    public static byte Median(params byte[] values)
    {
      if (values.Length == 1)
        return values[0];

      byte[] sorted = values.Clone() as byte[];
      Sort.Quick<byte>(Logic.Compare, sorted);
      if (sorted.Length % 2 == 1)
        return sorted[sorted.Length / 2 + 1];
      else
        return Statistics.Mean(sorted[sorted.Length / 2], sorted[sorted.Length / 2 + 1]);
    }

    #endregion

    #endregion
  }
}
