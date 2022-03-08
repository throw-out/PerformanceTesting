using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class MarkdownUtil
{
    public static string Generate(List<ExecuteStates> states)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("\n# System Environment");
        builder.Append(GetEnvironment());

        builder.Append("\n# All Data");
        builder.Append(FromatToTable(states));

        return builder.ToString();
    }
    public static string GetEnvironment()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("\n* System: {0}", SystemInfo.operatingSystem);          //操作系统版本
        builder.AppendFormat("\n* Memory: {0}MB", SystemInfo.systemMemorySize);       //系统内存大小
        builder.AppendFormat("\n* CPU: {0}", SystemInfo.processorType);               //处理器名称
        builder.AppendFormat("\n* CPU-Count: {0}", SystemInfo.processorCount);        //处理器数量
        builder.AppendFormat("\n* CPU-Frequency: {0}", SystemInfo.processorFrequency);//处理器频率
        builder.AppendFormat("\n* Graphics: {0}", SystemInfo.graphicsDeviceType);     //显卡类型
        builder.AppendFormat("\n* Graphics-Name: {0}", SystemInfo.graphicsDeviceName);//显卡名称
        return builder.ToString();
    }

    public static string FromatToTable(List<ExecuteStates> states)
    {
        Func<double, string> FormatDuration =
            (duration) => duration >= 0 ? duration.ToString("f1") : "`fail`";
        Func<object, string> FormatResult =
            (result) => result != null ? result.ToString() : "`null`";
        Func<Type, string> FormatScriptPath = (type) =>
        {
            string scriptPath;
#if UNITY_EDITOR
            string scriptName = $"/{type.Name}.cs";
            scriptPath = UnityEditor.AssetDatabase.GetAllAssetPaths().FirstOrDefault(p => p.EndsWith(scriptName) && UnityEditor.AssetDatabase.GetMainAssetTypeAtPath(p) == typeof(UnityEditor.MonoScript));
#endif

            return scriptPath != null ? $"[#](./{scriptPath})" : "#";
        };


        StringBuilder builder = new StringBuilder();

        builder.Append("\n| File      | Method    |  Static   | Call      | csDuration(ms)    | jsDuration(ms)    | luaDuration(ms)   | csResult  | jsResult  | luaResult |");
        builder.Append("\n| :----:    | :----     |  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |");

        foreach (var state in states)
        {
            builder.AppendLine();
            builder.AppendFormat(
                       "| {0}       | {1}       | {2}       | {3}       | {4}       | {5}       | {6}       | {7}       | {8}       | {9}       |",
                FormatScriptPath(state.Type),
                state.Method,
                state.Static ? "√" : "×",
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
}