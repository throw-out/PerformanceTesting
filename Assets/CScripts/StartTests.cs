using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Puerts;
using UnityEngine;
using XLua;

public class StartTests : MonoBehaviour
{
    public int[] executeNums;

    private JsEnv jsEnv;
    private LuaEnv luaEnv;

    private IExecute[] units
    {
        get
        {
            return (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                    from type in assembly.GetExportedTypes()
                    where typeof(IExecute).IsAssignableFrom(type) && type.IsDefined(typeof(Tests), false)
                    orderby (type.GetCustomAttributes(typeof(Tests), false).FirstOrDefault() as Tests).priority descending
                    select System.Activator.CreateInstance(type) as IExecute
            ).ToArray();
        }
    }

    void Awake()
    {
        jsEnv = new JsEnv();
        luaEnv = new LuaEnv();
    }

    void Start()
    {
        IExecute[] executeUnits = units;
        if (executeUnits == null || executeUnits.Length == 0)
        {
            throw new Exception("Invaild units");
        }

        List<ExecuteStates> states = new List<ExecuteStates>();
        foreach (IExecute execute in executeUnits)
        {
            for (int i = 0; i < executeNums.Length; i++)
            {
                if (executeNums[i] <= 0)
                    continue;
                states.Add(Invoke(execute, executeNums[i]));
            }
        }

        File.WriteAllText(Path.Combine(Application.dataPath, "../STATES.md"), FromatToMarkdown(states));

        Debug.Log("Test Completed.");
    }

    void OnDestroy()
    {
        jsEnv.Dispose();
        jsEnv = null;

        luaEnv.Dispose();
        luaEnv = null;
    }


    string FromatToMarkdown(List<ExecuteStates> states)
    {
        Func<double, string> FormatTime =
            (time) => time >= 0 ? (time.ToString("f1") + "ms") : "`fail`";
        Func<object, string> FormatResult =
            (result) => result != null ? result.ToString() : "`null`";
        Func<Type, string> FormatScriptPath = (type) =>
        {
            string scriptPath;
#if UNITY_EDITOR
            string scriptName = $"/{type.Name}.cs";
            scriptPath = UnityEditor.AssetDatabase.GetAllAssetPaths().FirstOrDefault(p => p.EndsWith(scriptName) && UnityEditor.AssetDatabase.GetMainAssetTypeAtPath(p) == typeof(UnityEditor.MonoScript));
#endif

            return scriptPath != null ? $"[File](./{scriptPath})" : "File";
        };


        StringBuilder builder = new StringBuilder();

        builder.Append("| File      | Method    |  Static   | Call      | csTime    | jsTime    | luaTime   | csResult  | jsResult  | luaResult |");
        builder.AppendLine();
        builder.Append("| :----:    | :----     |  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |");

        foreach (var state in states)
        {
            builder.AppendLine();
            builder.AppendFormat(
                       "| {0}       | {1}       | {2}       | {3}       | {4}       | {5}       | {6}       | {7}       | {8}       | {9}       |",
                FormatScriptPath(state.Type),
                state.Method,
                state.Static ? "√" : "×",
                state.Count,
                FormatTime(state.CsInvoke.Time),
                FormatTime(state.JsInvoke.Time),
                FormatTime(state.LuaInvoke.Time),
                FormatResult(state.CsInvoke.Result),
                FormatResult(state.JsInvoke.Result),
                FormatResult(state.LuaInvoke.Result)
            );
        }

        return builder.ToString();
    }
    ExecuteStates Invoke(IExecute execute, int count)
    {
        double csTime, jsTime, luaTime;
        object csResult, jsResult, luaResult;

        var timer = new Timer();
        try
        {
            csResult = execute.RunCS(count);
            csTime = timer.End();
        }
        catch (Exception)
        {
            csResult = null;
            csTime = -1;
        }

        timer = new Timer();
        try
        {
            jsResult = execute.RunJS(jsEnv, count);
            jsTime = timer.End();
        }
        catch (Exception)
        {
            jsResult = null;
            jsTime = -1;
        }

        timer = new Timer();
        try
        {
            luaResult = execute.RunLua(luaEnv, count);
            luaTime = timer.End();
        }
        catch (Exception)
        {
            luaResult = null;
            luaTime = -1;
        }

        return new ExecuteStates()
        {
            Type = execute.GetType(),
            Method = execute.Method,
            Static = execute.Static,
            Count = count,
            CsInvoke = new ExecuteState()
            {
                Time = csTime,
                Result = csResult
            },
            JsInvoke = new ExecuteState()
            {
                Time = jsTime,
                Result = jsResult
            },
            LuaInvoke = new ExecuteState()
            {
                Time = luaTime,
                Result = luaResult
            }
        };
    }
}
