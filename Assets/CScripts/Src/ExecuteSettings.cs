using System;
using System.Collections.Generic;
using Puerts;
using UnityEngine;
using XLua;

public class ExecuteSettings
{
    /// <summary>
    /// 检查内存状态
    /// </summary>
    public bool CheckMemory;
    /// <summary>
    /// 使用独立的env环境
    /// </summary>
    public bool Exclusive;
    /// <summary>
    /// 自动执行GC
    /// </summary>
    public bool AutoGC;

    public readonly Environments e = new Environments();

    public static ExecuteSettings Default => new ExecuteSettings()
    {
        CheckMemory = !Application.isEditor
    };

    /// <summary>
    /// 初始化虚拟机环境
    /// </summary>
    /// <param name="id"></param>
    public void Prepare(int id)
    {
        if (Exclusive)
        {
            if (id == 0)
                return;
            e.CleanEnvironment();   //初始化独立虚拟机, 并立即执行GC
            e.InitEnvironment(id);
        }
        else
        {
            if (id == 0)
            {
                e.CleanEnvironment();   //一次性初始化全部虚拟机
                e.InitEnvironment(id);
            }
            else if (AutoGC)
            {
                e.GarbageCollect();     //自动触发GC

            }
        }
    }

    public class Environments
    {
        public LuaEnv xlua;
        public ScriptEnv puertsV8;
        public ScriptEnv puertsQuickjs;
        public ScriptEnv puertsLua;

        public readonly int preExecute;

        public Environments(int preExecute = 0)
        {
            this.preExecute = preExecute;
        }

        public void InitAll()
        {
            var jsLoader = new DefaultLoader();
            var luaLoader = new LuaDefaultLoader();

            xlua = new LuaEnv();
            puertsV8 = new ScriptEnv(new BackendV8(jsLoader));
            puertsQuickjs = new ScriptEnv(new BackendQuickJS(jsLoader));
            puertsLua = new ScriptEnv(new BackendLua(luaLoader));
        }
        public void Tick()
        {
            xlua?.Tick();
            puertsV8?.Tick();
            puertsQuickjs?.Tick();
            puertsLua?.Tick();
        }
        public void Clear()
        {
            xlua?.Dispose();
            puertsV8?.Dispose();
            puertsQuickjs?.Dispose();
            puertsLua?.Dispose();

            xlua = null;
            puertsV8 = null;
            puertsQuickjs = null;
            puertsLua = null;
        }

        /// <summary>
        /// 初始化测试环境: 0:初始化全部, 1:xlua, 2:puerts(v8) 3:puerts(quickjs) 4:puerts(lua), -1表示不需要操作
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void InitEnvironment(int id)
        {
            if (xlua != null || puertsV8 != null || puertsQuickjs != null || puertsLua != null)
                throw new InvalidOperationException("init environment error");

            switch (id)
            {
                default:
                case 0:
                    InitAll();
                    break;
                case 1:
                    xlua = new LuaEnv();
                    break;
                case 2:
                    puertsV8 = new ScriptEnv(new BackendV8(new DefaultLoader()));
                    break;
                case 3:
                    puertsQuickjs = new ScriptEnv(new BackendQuickJS(new DefaultLoader()));
                    break;
                case 4:
                    puertsLua = new ScriptEnv(new BackendLua(new LuaDefaultLoader()));
                    break;
                case -1:
                    //什么都不做
                    break;
            }
        }
        public void CleanEnvironment()
        {
            Clear();
            GarbageCollect();
        }

        public void GarbageCollect()
        {
            // 手动清理 GC 和 Finalizer 队列，保证干净的测试环境
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect(); // 再收一次，确保 finalizer 释放的对象也被清理
            System.Threading.Thread.Sleep(50); // 给 GC 一点缓冲时间(可选)
        }
    }
}
