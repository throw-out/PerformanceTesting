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
            execute.InitGarbageCollect(settings, mode);
            //预执行代码
            if (settings.Prepare)
            {
                execute.Run(settings, mode);
                settings.e.GarbageCollect();
            }

            //多次执行测试, 取平均值
            long duration = -1, monoMemory = -1, nativeMemory = -1, envMemory = -1;
            object ret = null;
            if (settings.Debounce >= 3)
            {
                List<long> durations = new List<long>(settings.Debounce);
                for (int i = 0; i < settings.Debounce; i++)
                {
                    //先执行一次完整的GC
                    settings.e.GarbageCollect();
                    //尝试暂停虚拟机GC
                    execute.SetGarbageCollect(false);

                    Watcher watcher = Watcher.StartNew(settings.CheckMemory, execute.GetGarbageCollectMemory);
                    ret = execute.Run(settings, mode);
                    watcher.Stop();

                    //还原虚拟机GC
                    execute.SetGarbageCollect(true);

                    durations.Add(watcher.ElapsedMilliseconds);
                    if (i == 0)
                    {
                        monoMemory = watcher.MonoMemory;
                        nativeMemory = watcher.NativeMemory;
                        envMemory = watcher.EnvMemory;
                    }
                }
                durations.Sort();
                duration = (long)durations.Skip(1).Take(durations.Count - 2).Average();
            }
            else
            {
                //先执行一次完整的GC
                settings.e.GarbageCollect();
                //尝试暂停虚拟机GC
                execute.SetGarbageCollect(false);

                Watcher watcher = Watcher.StartNew(settings.CheckMemory, execute.GetGarbageCollectMemory);
                ret = execute.Run(settings, mode);
                watcher.Stop();

                //还原虚拟机GC
                execute.SetGarbageCollect(true);

                duration = watcher.ElapsedMilliseconds;
                monoMemory = watcher.MonoMemory;
                nativeMemory = watcher.NativeMemory;
                envMemory = watcher.EnvMemory;
            }

            data = new ExecuteData()
            {
                Duration = duration,
                Result = ret,
                MonoMemory = monoMemory,
                NativeMemory = nativeMemory,
                EnvMemory = envMemory,
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
        private readonly Func<long> GetEnvMemory;

        private long beforeMonoMemory;
        private long beforeNativeMemory;
        private long beforeEnvMemory;
        private System.Diagnostics.Stopwatch w;

        public long ElapsedMilliseconds => w?.ElapsedMilliseconds ?? -1;

        /// <summary>
        /// C#托管内存使用
        /// </summary>
        public long MonoMemory { get; private set; } = -1;
        /// <summary>
        /// Native非托管内存使用
        /// </summary>
        public long NativeMemory { get; private set; } = -1;
        /// <summary>
        /// 虚拟机内存占用
        /// </summary>
        public long EnvMemory { get; private set; } = -1;

        public Watcher(bool checkMemory, Func<long> getEnvMemory)
        {
            this.checkMemory = checkMemory;
            this.GetEnvMemory = getEnvMemory;
        }

        public void Start()
        {
            if (checkMemory)
            {
#if !UNITY_EDITOR
                UnityEngine.Scripting.GarbageCollector.GCMode = UnityEngine.Scripting.GarbageCollector.Mode.Disabled;
#endif
                beforeMonoMemory = UnityEngine.Profiling.Profiler.GetMonoUsedSizeLong();
                beforeNativeMemory = UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong();
                beforeEnvMemory = GetEnvMemory?.Invoke() ?? -1;
            }
            w = System.Diagnostics.Stopwatch.StartNew();
        }
        public void Stop()
        {
            w.Stop();

            if (checkMemory)
            {
                if (beforeMonoMemory >= 0)
                {
                    MonoMemory = UnityEngine.Profiling.Profiler.GetMonoUsedSizeLong() - beforeMonoMemory;
                }
                if (beforeNativeMemory >= 0)
                {
                    NativeMemory = UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong() - beforeNativeMemory;
                }
                if (beforeEnvMemory >= 0 && GetEnvMemory != null)
                {
                    EnvMemory = GetEnvMemory() - beforeEnvMemory;
                }
#if !UNITY_EDITOR
                UnityEngine.Scripting.GarbageCollector.GCMode = UnityEngine.Scripting.GarbageCollector.Mode.Enabled;
#endif
            }
        }

        public static Watcher StartNew(bool checkMemory, Func<long> getEnvMemory)
        {
            var watcher = new Watcher(checkMemory, getEnvMemory);
            watcher.Start();
            return watcher;
        }
    }
}