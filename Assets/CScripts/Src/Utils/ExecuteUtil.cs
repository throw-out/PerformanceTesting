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

    public static ExecuteData Run(ExecuteMode mode, ExecuteSettings settings, ExecuteBase execute, int count)
    {
        ExecuteData data;
        try
        {
            execute.Init(mode, settings, count);
            execute.Prepare(mode, settings);

            Watcher watcher = Watcher.StartNew(settings.CheckMemory);
            var ret = execute.Run(mode, settings);
            watcher.Stop();
            data = new ExecuteData()
            {
                Duration = watcher.ElapsedMilliseconds,
                Result = ret,
                TotalMemory = watcher.AllocatedMemory,
                Memory = watcher.Memory,
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
        private long beforeAllocatedMemory;
        private long beforeTotalMemory;
        private System.Diagnostics.Stopwatch w;

        public long ElapsedMilliseconds => w?.ElapsedMilliseconds ?? -1;
        public long AllocatedMemory { get; private set; } = -1;
        public long Memory { get; private set; } = -1;

        public Watcher(bool checkMemory)
        {
            this.checkMemory = checkMemory;
        }

        public void Start()
        {
            if (checkMemory)
            {
                UnityEngine.Scripting.GarbageCollector.GCMode = UnityEngine.Scripting.GarbageCollector.Mode.Disabled;
                beforeAllocatedMemory = UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong();
                beforeTotalMemory = GC.GetTotalMemory(false);
            }
            w = System.Diagnostics.Stopwatch.StartNew();
        }
        public void Stop()
        {
            w.Stop();

            if (checkMemory)
            {
                if (beforeAllocatedMemory > 0)
                {
                    AllocatedMemory = UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong() - beforeAllocatedMemory;
                }
                if (beforeTotalMemory > 0)
                {
                    Memory = GC.GetTotalMemory(false) - beforeTotalMemory;
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