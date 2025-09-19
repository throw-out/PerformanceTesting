using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class MarkdownUtil
{
    public static string Generate(ExecuteSettings settings, IEnumerable<ExecuteStates> states)
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine();
        builder.Append("# 系统环境");
        builder.Append(GetEnvironment());
        builder.AppendLine();

        builder.AppendLine();
        builder.Append("# 软件版本");
        builder.Append(GetLibraryVersion());
        builder.AppendLine();

        builder.AppendLine();
        builder.Append("# 运行时参数");
        builder.Append(GetSettings(settings));
        builder.AppendLine();

        var groupTable = GetGroupTable(settings, states);
        if (!string.IsNullOrEmpty(groupTable))
        {
            builder.AppendLine();
            builder.Append("# 数据对照");
            builder.Append(groupTable);
            builder.AppendLine();
        }

        builder.AppendLine();
        builder.Append("# 所有数据");
        if (settings.CheckMemory)
        {
            builder.AppendLine();
            builder.Append("**⚠警告: 内存使用统计仅作参考, 其结果并不完全可靠(js虚拟机无法暂停GC)。** <br>");
            builder.AppendLine();
            builder.Append("**<font color=\"red\">红色:</font> 表示托管内存(C#)** <br>");
            builder.AppendLine();
            builder.Append("**<font color=\"blue\">蓝色:</font> 表示非托管内存** <br>");
            builder.AppendLine();
            builder.Append("**<font color=\"green\">绿色:</font> 表示虚拟机内存** <br>");
            builder.AppendLine();
        }
        builder.Append(FromatToTable(settings, states));
        builder.AppendLine();

        return builder.ToString();
    }
    public static string GetLibraryVersion()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine();
        builder.AppendFormat("| Name            | Value             |");
        builder.AppendLine();
        builder.AppendFormat("| :----           | :----:            |");
        builder.AppendLine();
        builder.AppendFormat("| Unity           | {0}               |", Application.unityVersion);
        builder.AppendLine();
        builder.AppendFormat("| xLua            | {0}               |", XLua.LuaDLL.Lua.xlua_get_lib_version());
        builder.AppendLine();
        builder.AppendFormat("| puerts(lua)     | {0}               |", new Puerts.BackendLua().GetApiVersion());
        builder.AppendLine();
        builder.AppendFormat("| puerts(quickjs) | {0}               |", new Puerts.BackendQuickJS().GetApiVersion());
        builder.AppendLine();
        builder.AppendFormat("| puerts(v8)      | {0}               |", new Puerts.BackendV8().GetApiVersion());
        return builder.ToString();
    }
    public static string GetEnvironment()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine();
        builder.AppendFormat("| Name            | Value             |");
        builder.AppendLine();
        builder.AppendFormat("| :----           | :----:            |");
        builder.AppendLine();
        builder.AppendFormat("| System          | {0}               |", SystemInfo.operatingSystem);    //操作系统版本
        builder.AppendLine();
        builder.AppendFormat("| Memory          | {0}MB             |", SystemInfo.systemMemorySize);   //系统内存大小
        builder.AppendLine();
        builder.AppendFormat("| CPU             | {0}               |", SystemInfo.processorType);      //处理器名称
        builder.AppendLine();
        builder.AppendFormat("| CPU-Core        | {0}               |", SystemInfo.processorCount);     //处理器数量
        builder.AppendLine();
        builder.AppendFormat("| CPU-Frequency   | {0}GHz            |", SystemInfo.processorFrequency * 0.001f); //处理器频率
        builder.AppendLine();
        builder.AppendFormat("| Editor          | {0}               |", Application.isEditor);          //是否为编辑器模式
        builder.AppendLine();
        builder.AppendFormat("| Date            | {0}               |", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));  //本地电脑时间
        return builder.ToString();
    }
    public static string GetSettings(ExecuteSettings settings)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine();
        builder.AppendFormat("| Name            | Value             |");
        builder.AppendLine();
        builder.AppendFormat("| :----           | :----:            |");
        builder.AppendLine();
        builder.AppendFormat("| CheckMemory     | {0}               |", settings.CheckMemory);
        builder.AppendLine();
        builder.AppendFormat("| Exclusive       | {0}               |", settings.Exclusive);
        builder.AppendLine();
        builder.AppendFormat("| AutoGC          | {0}               |", settings.AutoGC);
        builder.AppendLine();
        builder.AppendFormat("| Prepare         | {0}               |", settings.Prepare);
        builder.AppendLine();
        builder.AppendFormat("| Debounce        | {0}               |", settings.Debounce >= 3 ? settings.Debounce : 0);
        return builder.ToString();
    }

    public static string GetGroupTable(ExecuteSettings settings, IEnumerable<ExecuteStates> states)
    {
        StringBuilder builder = new StringBuilder();

        var typeGroups = states
            .Where(o => o.Type.IsDefined(typeof(TestGroupAttribute), false))
            .GroupBy(o => o.Type)
            .ToDictionary(o => o.Key, o => o.Cast<ExecuteStates>().ToList());
        var testDatas = typeGroups.Keys
            .Select(type => type
                .GetCustomAttributes(typeof(TestGroupAttribute), false)
                .Select(
                    o => new TestGroupData { Type = type, Data = ((TestGroupAttribute)o) }
                )
            ).ToArray();
        var testGroups = InnerUtil.Flat(testDatas)
            .GroupBy(o => o.Data.Name)
            .ToDictionary(o => o.Key, o => o.Cast<TestGroupData>().ToList())
            .Where(o => o.Value.Count > 1)
            .ToDictionary(o => o.Key, o => o.Value);
        if (testGroups.Count > 0)
        {
            foreach (var testGroup in testGroups)
            {
                var groupStates = InnerUtil.Flat(testGroup.Value.Select(o => typeGroups[o.Type].ToArray()).ToArray()).ToList();
                if (groupStates.Count == 0)
                {
                    Debug.LogWarning("too little data, invail TestGroupName=" + testGroup.Key);
                    continue;
                }
                var compareDataCount = testGroup.Value.Min(o => o.Data.CompareDataCount);
                if (compareDataCount <= 0)
                {
                    compareDataCount = 1;
                }
                var totalCompareCount = testGroup.Value.Count * compareDataCount;
                var groupDesc = testGroup.Value.Select(o => o.Data.Desc).Where(o => !string.IsNullOrEmpty(o)).FirstOrDefault();

                groupStates.Sort((v1, v2) => v1.Count > v2.Count ? 1 : v1.Count < v2.Count ? -1 : 0);       //ascending order

                builder.AppendLine();
                builder.AppendFormat("* {0}", testGroup.Key);
                if (!string.IsNullOrEmpty(groupDesc))
                {
                    builder.AppendFormat(" | \t`{0}`", groupDesc);
                }
                builder.AppendLine();
                builder.Append(FromatToTable(settings, groupStates.Count > totalCompareCount ? groupStates.Skip(groupStates.Count - totalCompareCount) : groupStates));
            }
        }

        return builder.ToString();
    }
    public static string FromatToTable(ExecuteSettings settings, IEnumerable<ExecuteStates> states)
    {
        static string FormatDuration(double duration) => duration >= 0 ? $"{duration:f1}ms" : "`fail`";
        static string FormatResult(object result) => result != null ? result.ToString() : "`null`";
        static string FormatTarget(ExecuteTarget target) => Enum.GetName(typeof(ExecuteTarget), target);
        static string FormatScriptPath(Type type)
        {
            string scriptPath;
#if UNITY_EDITOR
            string scriptName = $"/{type.Name}.cs";
            scriptPath = UnityEditor.AssetDatabase.GetAllAssetPaths().FirstOrDefault(p => p.EndsWith(scriptName) && UnityEditor.AssetDatabase.GetMainAssetTypeAtPath(p) == typeof(UnityEditor.MonoScript));
#else
            scriptPath = $"/Assets/CScripts/Examples/{type.Name}.cs";   //string.Empty;
#endif
            return scriptPath != null ? $"[{type.Name}](/{scriptPath})" : "#";
        }
        static string FormatMemorySize(long size)
        {
            if (size < 0)
                return "-";
            if (size <= 1024)
                return $"{size}B";
            double s = size / 1024d;
            if (s <= 1024)
                return $"{s:f2}KB";
            s = s / 1024d;
            return $"{s:f2}MB";
        }

        string[] keys = states.FirstOrDefault(s => s.Results != null && s.Results.Count > 0).Results?.Keys.ToArray();
        if (keys == null || keys.Length == 0)
            return string.Empty;

        StringBuilder builder = new StringBuilder();
        builder.AppendLine();
        builder.Append("| File      | Method    | Static    | Target    | Count     |");
        builder.Append(string.Join("|", keys));
        builder.Append("|");

        builder.AppendLine();
        builder.Append("| :----:    | :----     | :----:    | :----:    | :----:    |");
        builder.Append(string.Join("|", keys.Select(k => ":----:")));
        builder.Append("|");

        foreach (var state in states)
        {
            builder.AppendLine();
            builder.AppendFormat(
                       "| {0}       | {1}       | {2}       | {3}       | {4}       |",
                FormatScriptPath(state.Type),
                state.Method,
                state.Static ? "Y" : "N",
                FormatTarget(state.Target),
                state.Count
            );

            bool hasAnyResult = state.Results != null && keys.Any(key => state.Results.TryGetValue(key, out var data) && data.Result != null);
            foreach (var key in keys)
            {
                ExecuteData data = default;
                if (state.Results == null || !state.Results.TryGetValue(key, out data))
                {
                    data.Duration = -1f;
                    data.Result = null;
                }
                builder.Append(FormatDuration(data.Duration));
                if (settings.CheckMemory)
                {
                    builder.AppendFormat(
                        "<br><font color=\"red\">{0}</font> / <font color=\"blue\">{1}</font> / <font color=\"green\">{2}</font>",
                        FormatMemorySize(data.MonoMemory),
                        FormatMemorySize(data.NativeMemory),
                        FormatMemorySize(data.EnvMemory));
                }
                if (hasAnyResult)
                {
                    builder.AppendFormat("<br>{0}",
                        FormatResult(data.Result)
                    );
                }
                builder.Append("|");
            }
        }

        return builder.ToString();
    }

    public static string GenerateCharts(IEnumerable<string> executeChart, IEnumerable<string> memoryChart)
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine();
        builder.Append("# 图表数据");

        builder.AppendLine();
        builder.AppendLine();
        builder.Append("**以下图表使用[QuickChart](https://quickchart.io/)进行生成, 感谢[QuickChart open API](https://quickchart.io/)**");
        builder.AppendLine();

        if (executeChart != null && executeChart.Any())
        {
            builder.AppendLine();
            builder.AppendLine();
            builder.Append("- 执行耗时(越低越好)");
            builder.AppendLine();
            builder.AppendLine();
            foreach (var chartFile in executeChart)
            {
                builder.AppendLine();
                builder.AppendFormat("![](/{0})", chartFile);
            }
        }
        if (memoryChart != null && memoryChart.Any())
        {
            builder.AppendLine();
            builder.AppendLine();
            builder.Append("- 执行内存消耗(越低越好)");
            builder.AppendLine();
            builder.AppendLine();
            foreach (var chartFile in memoryChart)
            {
                builder.AppendLine();
                builder.AppendFormat("![](/{0})", chartFile);
            }
        }
        return builder.ToString();
    }
    struct TestGroupData
    {
        public Type Type;
        public TestGroupAttribute Data;
    }

    static class InnerUtil
    {
        public static T[] Flat<T>(params IEnumerable<T>[] array)
        {
            List<T> result = new List<T>();
            Array.ForEach(array, o => result.AddRange(o));
            return result.ToArray();
        }
        public static T[] Flat<T>(params T[][] array)
        {
            List<T> result = new List<T>();
            Array.ForEach(array, o => result.AddRange(o));
            return result.ToArray();
        }
    }
}