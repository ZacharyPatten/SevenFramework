// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

using System;
using System.Threading;
using Seven.Mathematics;

namespace Seven.Parallels
{
  public static class AutoParallel
  {
    private static int _cores = Logic.Max(System.Environment.ProcessorCount, 1);

    public delegate void Parallel();
    public delegate Parallel Parallel_Factory(int current, int max);

    /// <summary>
    /// Handles the parallelization of a dynamic number of threads 
    /// tied to the number of cores on the current hardware. Will not
    /// return until all threads have completed.
    /// </summary>
    /// <param name="factory">
    /// <param name="max">The max number of threads to make.</param>
    /// A thread factory that will construct threads to be run
    /// in parallel based on current-max values.
    /// </param>
    public static void Divide(Parallel_Factory factory, int max)
    {
      object lock_obj = new object();
      int completed = 0;
      int threads = Logic.Min(max, _cores);

      for (int i = 0; i < threads; i++)
      {
        factory(i, threads).BeginInvoke(
          (IAsyncResult result) =>
          {
            lock (lock_obj)
            {
              completed++;
              Monitor.Pulse(lock_obj);
            }
          }, null);
      }

      lock (lock_obj)
        while (completed < threads)
          Monitor.Wait(lock_obj);
    }
  }
}
