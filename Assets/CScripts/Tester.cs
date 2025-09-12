using System;
using Puerts;
using XLua;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class Tester
{
    private static readonly ExecuteMode[] ExecuteModes = new ExecuteMode[]
    {
        ExecuteMode.CSharp,
        ExecuteMode.XLua,
        ExecuteMode.PuertsWithV8,
        ExecuteMode.PuertsWithQuickjs,
        ExecuteMode.PuertsWithLua,
    };

    private bool isRunning;
    public bool IsRunning()
    {
        return isRunning;
    }
    private readonly int[] repeatTimePerSuite;
    private readonly string rootPath;

    public Tester(int[] repeatTimePerSuite, string rootPath)
    {
        this.repeatTimePerSuite = repeatTimePerSuite;
        this.rootPath = rootPath;
    }

    public void StopTest()
    {
        isRunning = false;
        AppendLog("\b test stopped");
    }

    public IEnumerator StartTest(ExecuteSettings s)
    {
        isRunning = true;
#if UNITY_EDITOR
        if (s.CheckMemory)
        {
            s.CheckMemory = false;
            Debug.LogError("Editor环境下不允许暂停GC, 无法统计内存数据");
        }
#endif

        ExecuteBase[] executes = ExecuteUtil.GetExecutes();
        if (executes == null || executes.Length == 0)
        {
            AppendLog("\ntest instance not found");
            isRunning = false;
            yield break;
        }

        Stopwatch sw = new Stopwatch();
        sw.Start();

        AppendLog("\nstart test: instance = " + executes.Length);
        yield return null;

        s.Prepare(0);
        //进度状态
        int index = 0, total = executes.Length * repeatTimePerSuite.Length * 5;
        List<ExecuteStates> statesList = new List<ExecuteStates>();
        foreach (ExecuteBase execute in executes)
        {
            for (int i = 0; i < repeatTimePerSuite.Length; i++)
            {
                int count = repeatTimePerSuite[i];
                if (count <= 0)
                    continue;

                s.Prepare(-1);
                ExecuteData csResult = ExecuteUtil.Run(ExecuteMode.CSharp, s, execute, count);
                AppendLog("\n{0} | count={1} \t| run csharp = {2}",
                    execute.GetType().FullName,
                    count,
                    csResult.Duration >= 0 ? $"{csResult.Duration:f1}ms" : "fail"
                );
                SetProgress(index++, total);
                yield return null;

                s.Prepare(1);
                ExecuteData xluaResult = ExecuteUtil.Run(ExecuteMode.XLua, s, execute, count);
                AppendLog("\n{0} | count={1} \t| run xlua = {2}",
                    execute.GetType().FullName,
                    count,
                    xluaResult.Duration >= 0 ? $"{xluaResult.Duration:f1}ms" : "fail"
                );
                SetProgress(index++, total);
                yield return null;

                s.Prepare(2);
                ExecuteData puertsV8Result = ExecuteUtil.Run(ExecuteMode.PuertsWithV8, s, execute, count);
                AppendLog("\n{0} | count={1} \t| run puerts(v8) = {2}",
                    execute.GetType().FullName,
                    count,
                    puertsV8Result.Duration >= 0 ? $"{puertsV8Result.Duration:f1}ms" : "fail"
                );
                SetProgress(index++, total);
                yield return null;

                s.Prepare(3);
                ExecuteData puerstQuickjsResult = ExecuteUtil.Run(ExecuteMode.PuertsWithQuickjs, s, execute, count);

                AppendLog("\n{0} | count={1} \t| run puerts(quickjs) = {2}",
                    execute.GetType().FullName,
                    count,
                    puerstQuickjsResult.Duration >= 0 ? $"{puerstQuickjsResult.Duration:f1}ms" : "fail"
                );
                SetProgress(index++, total);
                yield return null;

                s.Prepare(4);
                ExecuteData puertsLuaResult = ExecuteUtil.Run(ExecuteMode.PuertsWithLua, s, execute, count);
                AppendLog("\n{0} | count={1} \t| run puerts(lua) = {2}",
                    execute.GetType().FullName,
                    count,
                    puertsLuaResult.Duration >= 0 ? $"{puertsLuaResult.Duration:f1}ms" : "fail"
                );
                SetProgress(index++, total);
                yield return null;

                statesList.Add(new ExecuteStates()
                {
                    Type = execute.GetType(),
                    Static = execute.Static,
                    Method = execute.Method,
                    Target = execute.Target,
                    Count = count,
                    Results = new Dictionary<string, ExecuteData>()
                    {
                        {"C#", csResult},
                        {"xLua", xluaResult},
                        {"puerts(v8)", puertsV8Result},
                        {"puerts(quickjs)", puerstQuickjsResult},
                        {"puerts(lua)", puertsLuaResult},
                    }
                });
            }
        }

        isRunning = false;
        sw.Stop();
        SetProgress(total, total);
        AppendLog("\n\ntest completed! total duration = {0}ms", sw.ElapsedMilliseconds);

        //保存state markdown文件
        DateTime saveTime = DateTime.Now;
        string statePath = Path.Combine(rootPath, s.SaveTimestampFile ? $"STATES_{saveTime:yyyyMMddHHmmss}.md" : $"STATES.md");
        AppendLog("\nstates file write to: {0}", statePath);
        if (File.Exists(statePath))
        {
            File.Delete(statePath);
        }
        File.WriteAllText(statePath, MarkdownUtil.Generate(s, statesList));

        //保存chart柱状图
        if (s.SaveChartFile)
        {
            List<string> charsFiles = new List<string>();
            ChartUtil.Generate(statesList,
                (id, url) =>
                {
                    AppendLog($"\n\nrequrest(chart-{id}): " + url);
                },
                (id, data) =>
                {
                    if (data == null)
                    {
                        AppendLog($"\nrequest failure!!!");
                        return;
                    }
                    string fileName = s.SaveTimestampFile ? $"CHART_{id}_{saveTime:yyyyMMddHHmmss}.png" : $"CHART_{id}.png";
                    charsFiles.Add(fileName);

                    var path = Path.Combine(rootPath, fileName);
                    AppendLog($"\n\nwrite to: {path}");
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    File.WriteAllBytes(path, data);
                },
                () =>
                {
                    if (charsFiles.Count == 0 || !File.Exists(statePath))
                        return;
                    File.AppendAllText(statePath, MarkdownUtil.GenerateCharts(charsFiles));
                });
        }
    }

    public event Action<string> OnLogInfo;
    protected void AppendLog(string info, params object[] parameters)
    {
        if (OnLogInfo == null)
            return;
        OnLogInfo(String.Format(info, parameters));
    }
    public event Action<int, int> OnProgress;
    protected void SetProgress(int index, int total)
    {
        if (OnProgress == null)
            return;
        OnProgress(index, total);
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
        /// 初始化测试环境: 0:初始化全部, 1:xlua, 2:puerts(v8) 3:puerts(quickjs) 4:puerts(lua)
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void InitEnvironment(int index)
        {
            if (xlua != null || puertsV8 != null || puertsQuickjs != null || puertsLua != null)
                throw new InvalidOperationException("init environment error");

            switch (index)
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
            }
        }
        public void CleanEnvironment()
        {
            Clear();

            // 手动清理 GC 和 Finalizer 队列，保证干净的测试环境
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect(); // 再收一次，确保 finalizer 释放的对象也被清理
            System.Threading.Thread.Sleep(50); // 给 GC 一点缓冲时间(可选)
        }
    }
}