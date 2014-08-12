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

    #region library

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
      return (a + b) * 0.5d;
    }

    public static double Mean(params double[] values)
    {
      double sum = 0.0d;
      foreach (double value in values)
        sum += value;
      return sum / (double)values.Length;
    }

    public static Heap<Link<double, int>> Mode(params double[] values)
    {
      Heap<Link<double, int>> heap =
        new Heap_Array<Link<double, int>>(
          (Link<double, int> left, Link<double, int> right) =>
            { return Logic.Compare(left.Two, right.Two); });

      double[] sorted = values.Clone() as double[];
      Sort.Quick<double>(Logic.Compare, sorted);

      int temp = 0;

      for (int i = 0; i < sorted.Length; i++)
      {
        temp = i - 1;
        for (; i + 1 < sorted.Length && sorted[i] == sorted[i + 1]; i++)
          continue;
        heap.Enqueue(new Link<double, int>(sorted[i], i - temp));
      }

      return heap;
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
