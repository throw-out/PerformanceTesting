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
    /// <summary>
    /// 预执行代码
    /// </summary>
    public bool Prepare;
    /// <summary>
    /// 执行多次测试(次数>=3时有效)
    /// 消耗时长: 去掉最高最低值取平均值
    /// Memory: 取最高值
    /// Result: 取最后值
    /// </summary>
    public int Debounce = -1;

    /// <summary>
    /// 文件名追加时间戳
    /// </summary>
    public bool SaveTimestampFile;

    /// <summary>
    /// 生成并保存图表文件
    /// </summary>
    public bool SaveChartFile;

    public readonly Environments e = new Environments();

    public static ExecuteSettings Default => new ExecuteSettings()
    {
        CheckMemory = !Application.isEditor
    };

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
        public void InitEnvironment(ExecuteMode mode)
        {
            if (xlua != null || puertsV8 != null || puertsQuickjs != null || puertsLua != null)
                throw new InvalidOperationException("init environment error");

            switch (mode)
            {
                default:
                case ExecuteMode.None:
                    InitAll();
                    break;
                case ExecuteMode.XLua:
                    xlua = new LuaEnv();
                    break;
                case ExecuteMode.PuertsWithV8:
                    puertsV8 = new ScriptEnv(new BackendV8(new DefaultLoader()));
                    break;
                case ExecuteMode.PuertsWithQuickjs:
                    puertsQuickjs = new ScriptEnv(new BackendQuickJS(new DefaultLoader()));
                    break;
                case ExecuteMode.PuertsWithLua:
                    puertsLua = new ScriptEnv(new BackendLua(new LuaDefaultLoader()));
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
