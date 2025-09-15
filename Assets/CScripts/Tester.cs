using System;
using Puerts;
using XLua;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System.Linq;

public class Tester
{
    private static readonly (ExecuteMode mode, string identifier)[] ExecuteMethods = new (ExecuteMode mode, string identifier)[]
    {
        (ExecuteMode.CSharp, "C#"),
        (ExecuteMode.XLua, "xlua"),
        (ExecuteMode.PuertsWithV8, "puerts(v8)"),
        (ExecuteMode.PuertsWithQuickjs, "puerts(quickjs)"),
        (ExecuteMode.PuertsWithLua, "puerts(lua)"),
    };

    private bool isRunning;
    private readonly int[] repeatTimes;
    private readonly string rootPath;

    public Tester(int[] repeatTimes, string rootPath)
    {
        if (repeatTimes == null || repeatTimes.Length == 0 || repeatTimes.Any(n => n < 0))
            throw new ArgumentException("");
        this.repeatTimes = repeatTimes;
        this.rootPath = rootPath;
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    public void Stop()
    {
        isRunning = false;
        if (IsLogger()) LoggerWrite("test stopped");
    }

    public IEnumerator Start(ExecuteSettings s)
    {
        isRunning = true;
#if UNITY_EDITOR
        if (s.CheckMemory)
        {
            s.CheckMemory = false;
            if (IsLogger()) LoggerWrite("Editor环境下不允许暂停GC, 无法统计内存数据");
        }
#endif

        ExecuteBase[] executes = ExecuteUtil.GetExecutes();
        if (executes == null || executes.Length == 0)
        {
            if (IsLogger()) LoggerWrite("test instance not found");
            isRunning = false;
            yield break;
        }

        Stopwatch sw = new Stopwatch();
        sw.Start();

        if (IsLogger())
        {
            LoggerWrite(string.Empty);
            LoggerWrite("start test: instance = " + executes.Length);
        }
        yield return null;

        //一次性初始化虚拟机环境
        if (!s.Exclusive)
        {
            s.e.CleanEnvironment();
            s.e.InitEnvironment(ExecuteMode.None);
        }

        //进度状态
        int progressIndex = 0, progressTotal = executes.Length * repeatTimes.Length * 5;

        List<ExecuteStates> results = new List<ExecuteStates>();
        for (int i = 0; i < repeatTimes.Length; i++)
        {
            int count = repeatTimes[i];
            if (count <= 0)
                continue;
            foreach (ExecuteBase execute in executes)
            {
                if (!isRunning)
                    yield break;
                var resultDatas = new Dictionary<string, ExecuteData>();
                foreach (var m in ExecuteMethods)
                {
                    if (!isRunning)
                        yield break;

                    if (s.Exclusive)
                    {
                        s.e.CleanEnvironment();
                        s.e.InitEnvironment(m.mode);
                    }
                    else
                    {
                        s.e.GarbageCollect();
                    }

                    ExecuteData result = ExecuteUtil.Run(s, execute, m.mode, count);
                    if (IsLogger()) LoggerWrite(string.Format("{0} | count={1} \t| run {2} = {3}",
                        execute.GetType().FullName,
                        count,
                        m.identifier,
                        result.Duration >= 0 ? $"{result.Duration:f1}ms" : "fail"
                    ));
                    resultDatas[m.identifier] = result;
                    SetProgress(progressIndex++, progressTotal);
                    yield return null;
                }
                results.Add(new ExecuteStates()
                {
                    Type = execute.GetType(),
                    Static = execute.Static,
                    Method = execute.Method,
                    Target = execute.Target,
                    Count = count,
                    Results = resultDatas
                });
            }
        }

        isRunning = false;
        sw.Stop();
        SetProgress(progressTotal, progressTotal);
        if (IsLogger())
        {
            LoggerWrite(string.Empty);
            LoggerWrite(string.Format("test completed! total duration = {0}ms", sw.ElapsedMilliseconds));
        }

        //保存state markdown文件
        DateTime saveTime = DateTime.Now;
        SaveMarkdown(s, results, saveTime, out string statePath);

        //保存chart柱状图
        if (s.SaveChartFile)
        {
            SaveChart(s, results, saveTime, statePath);
        }
    }

    public event Action<string> OnLogger;
    protected bool IsLogger()
    {
        return OnLogger != null;
    }
    protected void LoggerWrite(string info)
    {
        if (OnLogger == null)
            return;
        OnLogger(info);
        OnLogger("\n");
    }

    public event Action<int, int> OnProgress;
    protected void SetProgress(int index, int total)
    {
        if (OnProgress == null)
            return;
        OnProgress(index, total);
    }

    private void SaveMarkdown(ExecuteSettings s, List<ExecuteStates> results, DateTime saveTime, out string statePath)
    {
        statePath = Path.Combine(rootPath, s.SaveTimestampFile ? $"STATES_{saveTime:yyyyMMddHHmmss}.md" : $"STATES.md");
        if (IsLogger())
        {
            LoggerWrite(string.Empty);
            LoggerWrite(string.Format("write states file: {0}", statePath));
        }

        if (File.Exists(statePath))
        {
            File.Delete(statePath);
        }
        File.WriteAllText(statePath, MarkdownUtil.Generate(s, results));
    }

    private void SaveChart(ExecuteSettings s, List<ExecuteStates> results, DateTime saveTime, string statePath = null)
    {
        List<string> charsFiles = new List<string>();
        ChartUtil.Generate(
            results,
            (id, url) =>
            {
                if (IsLogger())
                {
                    LoggerWrite(string.Empty);
                    LoggerWrite($"requrest(chart-{id}): " + url);
                }
            },
            (id, data) =>
            {
                if (data == null)
                {
                    if (IsLogger())
                    {
                        LoggerWrite($"request failure!!!");
                    }
                    return;
                }
                string fileName = s.SaveTimestampFile ? $"CHART_{id}_{saveTime:yyyyMMddHHmmss}.png" : $"CHART_{id}.png";
                charsFiles.Add(fileName);

                var path = Path.Combine(rootPath, fileName);
                if (IsLogger())
                {
                    LoggerWrite($"write to: {path}");
                }
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.WriteAllBytes(path, data);
            },
            () =>
            {
                if (charsFiles.Count == 0 || string.IsNullOrEmpty(statePath) || !File.Exists(statePath))
                    return;
                File.AppendAllText(statePath, MarkdownUtil.GenerateCharts(charsFiles));
            });
    }
}