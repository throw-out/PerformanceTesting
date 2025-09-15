using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Puerts;
using UnityEngine;
using XLua;

public static class ExecuteUtil
{
    public static ExecuteBase[] GetExecutes()
    {
        return (from assembly in AppDomain.CurrentDomain.GetAssemblies()
#if UNITY_EDITOR
                where !(assembly.ManifestModule is System.Reflection.Emit.ModuleBuilder)
#endif
                from type in assembly.GetExportedTypes()
                where typeof(ExecuteBase).IsAssignableFrom(type) && type.IsDefined(typeof(TestAttribute), false)
                orderby (type.GetCustomAttributes(typeof(TestAttribute), false).FirstOrDefault() as TestAttribute).Priority descending
                select System.Activator.CreateInstance(type) as ExecuteBase
        ).ToArray();
    }

    public static ExecuteData Run(ExecuteSettings settings, ExecuteBase execute, ExecuteMode mode, int count)
    {
        ExecuteData data;
        try
        {
            execute.Init(settings, mode, count);
            //预执行代码
            if (settings.Prepare)
            {
                execute.Run(settings, mode);
            }

            //多次执行测试, 取平均值
            long duration = -1, memory = -1;
            object ret = null;
            if (settings.Debounce >= 3)
            {
                List<long> durations = new List<long>(settings.Debounce);
                for (int i = 0; i < settings.Debounce; i++)
                {
                    settings.e.GarbageCollect();

                    Watcher watcher = Watcher.StartNew(settings.CheckMemory);
                    ret = execute.Run(settings, mode);
                    watcher.Stop();

                    durations.Add(watcher.ElapsedMilliseconds);
                    if (watcher.Memory > memory)
                    {
                        memory = watcher.Memory;
                    }
                }
                durations.Sort();
                duration = (long)durations.Skip(1).Take(durations.Count - 2).Average();
            }
            else
            {
                Watcher watcher = Watcher.StartNew(settings.CheckMemory);
                ret = execute.Run(settings, mode);
                watcher.Stop();

                memory = watcher.Memory;
                duration = watcher.ElapsedMilliseconds;
            }

            data = new ExecuteData()
            {
                Duration = duration,
                Result = ret,
                Memory = memory,
            };
        }
        catch (Exception e)
        {
            data = ExecuteData.Error;
            if (!(e is System.NotImplementedException))
            {
                UnityEngine.Debug.LogWarning($"{execute.GetType().FullName} ExecuteMode={Enum.GetName(typeof(ExecuteMode), mode)} throw Exception: \n" + e);
            }
        }
        finally
        {
            execute?.Clear();
        }
        return data;
    }

    private class Watcher
    {
        private readonly bool checkMemory;
        private long beforeTotalMemory;
        private System.Diagnostics.Stopwatch w;
        private System.Diagnostics.Process p;

        public long ElapsedMilliseconds => w?.ElapsedMilliseconds ?? -1;
        public long Memory { get; private set; } = -1;

        public Watcher(bool checkMemory)
        {
            this.checkMemory = checkMemory;
        }

        public void Start()
        {
            if (checkMemory)
            {
                p = System.Diagnostics.Process.GetCurrentProcess();

                UnityEngine.Scripting.GarbageCollector.GCMode = UnityEngine.Scripting.GarbageCollector.Mode.Disabled;
                //UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong();
                //beforeTotalMemory = GC.GetTotalMemory(false);  //获取托管内存
                beforeTotalMemory = p.PrivateMemorySize64;  //获取进程内存(包含托管和非托管)
            }
            w = System.Diagnostics.Stopwatch.StartNew();
        }
        public void Stop()
        {
            w.Stop();

            if (checkMemory)
            {
                if (beforeTotalMemory > 0 && p != null)
                {
                    //Memory = GC.GetTotalMemory(false) - beforeTotalMemory;
                    Memory = p.PrivateMemorySize64 - beforeTotalMemory;
                }
                UnityEngine.Scripting.GarbageCollector.GCMode = UnityEngine.Scripting.GarbageCollector.Mode.Enabled;
            }
        }

        public static Watcher StartNew(bool checkMemory)
        {
            var watcher = new Watcher(checkMemory);
            watcher.Start();
            return watcher;
        }
    }
}