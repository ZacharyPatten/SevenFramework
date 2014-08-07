using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Seven.Parallels
{
  public static class AutoParallel
  {
    private static int _cores = System.Environment.ProcessorCount;

    public delegate void Parallel();
    public delegate Parallel Delegate_Factory(int current, int max);

    public static void Invoke(Delegate_Factory factory)
    {
      Parallel[] parallels = new Parallel[_cores];
      object lock_obj = new object();
      int completed = 0;

      for (int i = 0; i < _cores; i++)
        (parallels[i] = factory(i, _cores)).BeginInvoke(
          (IAsyncResult result) => { completed++; Monitor.Pulse(lock_obj); }, null);

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
