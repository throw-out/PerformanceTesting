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

        File.WriteAllText(Path.Combine(Application.dataPath, "../TestStates.md"), FromatToMarkdown(states));

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
        StringBuilder builder = new StringBuilder();
        builder.Append("|  Method   | Call      | csTime    | jsTime    | luaTime   | csResult  | jsResult  | luaResult |");
        builder.AppendLine();
        builder.Append("|  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |");

        Func<double, string> FormatTime =
            (time) => time >= 0 ? (time.ToString("f1") + "ms") : "`fail`";
        Func<object, string> FormatResult =
            (result) => result != null ? result.ToString() : "`null`";

        foreach (var state in states)
        {
            builder.AppendLine();
            builder.AppendFormat(
                       "| {0}       | {1}       | {2}       | {3}       | {4}       | {5}       | {6}       | {7}       |",
                state.name,
                state.num,
                FormatTime(state.csState.time),
                FormatTime(state.jsState.time),
                FormatTime(state.luaState.time),
                FormatResult(state.csState.result),
                FormatResult(state.jsState.result),
                FormatResult(state.luaState.result)
            );
        }

        return builder.ToString();
    }
    ExecuteStates Invoke(IExecute execute, int num)
    {
        double csTime, jsTime, luaTime;
        object csResult, jsResult, luaResult;

        var timer = new Timer();
        try
        {
            csResult = execute.RunCS(num);
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
            jsResult = execute.RunJS(jsEnv, num);
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
            luaResult = execute.RunLua(luaEnv, num);
            luaTime = timer.End();
        }
        catch (Exception)
        {
            luaResult = null;
            luaTime = -1;
        }

        return new ExecuteStates()
        {
            name = execute.Name,
            num = num,
            csState = new ExecuteState()
            {
                time = csTime,
                result = csResult
            },
            jsState = new ExecuteState()
            {
                time = jsTime,
                result = jsResult
            },
            luaState = new ExecuteState()
            {
                time = luaTime,
                result = luaResult
            }
        };
    }
}
