using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class MarkdownUtil
{
    public static string Generate(IEnumerable<ExecuteStates> states)
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine();
        builder.Append("# 软件版本");
        builder.Append(GetVersion());

        builder.AppendLine();
        builder.Append("# 系统环境");
        builder.Append(GetEnvironment());

        var groupTable = GetGroupTable(states);
        if (!string.IsNullOrEmpty(groupTable))
        {
            builder.AppendLine();
            builder.Append("# 数据对照");
            builder.Append(groupTable);
        }

        builder.AppendLine();
        builder.Append("# 所有数据");
        builder.Append(FromatToTable(states));

        return builder.ToString();
    }
    public static string GetVersion()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine();
        builder.AppendFormat("| Name            | Value             |");
        builder.AppendLine();
        builder.AppendFormat("| :----           | :----:            |");
        builder.AppendLine();
        builder.AppendFormat("| Unity           | {0}               |", Application.unityVersion);
        builder.AppendLine();
        builder.AppendFormat("| puerts          | {0}               |", Puerts.PuertsDLL.GetLibVersion());
        builder.AppendLine();
        builder.AppendFormat("| xLua            | {0}               |", XLua.LuaDLL.Lua.xlua_get_lib_version());
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
        builder.AppendFormat("| isEditor        | {0}               |", Application.isEditor);          //是否为编辑器模式
        builder.AppendLine();
        builder.AppendFormat("| Date            | {0}               |", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));  //本地电脑时间
        return builder.ToString();
    }

    public static string GetGroupTable(IEnumerable<ExecuteStates> states)
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
                builder.Append(FromatToTable(groupStates.Count > totalCompareCount ? groupStates.Skip(groupStates.Count - totalCompareCount) : groupStates));
            }
        }

        return builder.ToString();
    }
    public static string FromatToTable(IEnumerable<ExecuteStates> states)
    {
        Func<double, string> FormatDuration =
            (duration) => duration >= 0 ? duration.ToString("f1") : "`fail`";
        Func<object, string> FormatResult =
            (result) => result != null ? result.ToString() : "`null`";
        Func<CallTarget, string> FormatTarget =
            (target) => Enum.GetName(typeof(CallTarget), target);
        Func<Type, string> FormatScriptPath = (type) =>
        {
            string scriptPath;
#if UNITY_EDITOR
            string scriptName = $"/{type.Name}.cs";
            scriptPath = UnityEditor.AssetDatabase.GetAllAssetPaths().FirstOrDefault(p => p.EndsWith(scriptName) && UnityEditor.AssetDatabase.GetMainAssetTypeAtPath(p) == typeof(UnityEditor.MonoScript));
#endif
            //return scriptPath != null ? $"[![#](/pic/code.png)](/{scriptPath})" : "#";    //use picture or emoji
            return scriptPath != null ? $"[:fa-file-text-o:](/{scriptPath})" : "#";
        };


        StringBuilder builder = new StringBuilder();

        builder.AppendLine();
        builder.Append("| File      | Method    | Static    | Target    | Call      | csharp(ms)| puerts(ms)| xLua(ms)  | csharpResult  | puertsResult  | xLuaResult    |");
        builder.AppendLine();
        builder.Append("| :----:    | :----     | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:        | :----:        | :----:        |");

        foreach (var state in states)
        {
            builder.AppendLine();
            builder.AppendFormat(
                       "| {0}       | {1}       | {2}       | {3}       | {4}       | {5}       | {6}       | {7}       | {8}           | {9}           | {10}          |",
                FormatScriptPath(state.Type),
                state.Method,
                state.Static ? "√" : "×",
                FormatTarget(state.Target),
                state.Count,
                FormatDuration(state.CsInvoke.Duration),
                FormatDuration(state.JsInvoke.Duration),
                FormatDuration(state.LuaInvoke.Duration),
                FormatResult(state.CsInvoke.Result),
                FormatResult(state.JsInvoke.Result),
                FormatResult(state.LuaInvoke.Result)
            );
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