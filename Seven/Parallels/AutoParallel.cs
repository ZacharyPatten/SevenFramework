// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

using System;
using System.Threading;

namespace Seven.Parallels
{
  public static class AutoParallel
  {
    private static int _cores = System.Environment.ProcessorCount / 2;

    public delegate void Parallel();
    public delegate Parallel Parallel_Factory(int current, int max);

    /// <summary>
    /// Handles the parallelization of a dynamic number of threads 
    /// tied to the number of cores on the current hardware.
    /// </summary>
    /// <param name="factory">
    /// A thread factory that will construct threads to be run
    /// in parallel based on current-max values.
    /// </param>
    public static void Invoke(Parallel_Factory factory)
    {
      Parallel[] parallels = new Parallel[_cores];
      object lock_obj = new object();
      int completed = 0;

      for (int i = 0; i < _cores; i++)
        (parallels[i] = factory(i, _cores)).BeginInvoke(
          (IAsyncResult result) => 
          { 
            completed++; 
            lock(lock_obj) 
            { 
              Monitor.Pulse(lock_obj); 
            } 
          }, 
          null);

      lock (lock_obj)
        while (completed < _cores)
          Monitor.Wait(lock_obj);
    }

    public static void Invoke(Parallel[] parallels)
    {
      object lock_obj = new object();
      int completed = 0;

      for (int i = 0; i < parallels.Length; i++)
        parallels[i].BeginInvoke(
          (IAsyncResult result) => { completed++; Monitor.Pulse(lock_obj); }, null);

      lock (lock_obj)
        while (completed < parallels.Length)
          Monitor.Wait(lock_obj);
    }
  }
}
