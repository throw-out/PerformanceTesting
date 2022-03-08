using System;
using System.Collections.Generic;
using System.Linq;
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

        foreach (var state in states)
        {
            Debug.LogFormat("{0}; num={1}, csTime={2}, jsTime={3}, luaTime={4}",
                state.name,
                state.num,
                state.csTime >= 0 ? state.csTime.ToString("f1") + "ms" : "Fail",
                state.jsTime >= 0 ? state.jsTime.ToString("f1") + "ms" : "Fail",
                state.luaTime >= 0 ? state.luaTime.ToString("f1") + "ms" : "Fail"
            );
        }
    }

    void OnDestroy()
    {
        jsEnv.Dispose();
        jsEnv = null;

        luaEnv.Dispose();
        luaEnv = null;
    }

    ExecuteStates Invoke(IExecute execute, int num)
    {
        double csTime, jsTime, luaTime;

        var timer = new Timer();
        try
        {
            execute.RunCS(num);
            csTime = timer.End();
        }
        catch (Exception e)
        {
            csTime = -1;
            //Debug.LogWarning(e);
        }

        timer = new Timer();
        try
        {
            execute.RunJS(jsEnv, num);
            jsTime = timer.End();
        }
        catch (Exception e)
        {
            jsTime = -1;
            //Debug.LogWarning(e);
        }


        timer = new Timer();
        try
        {
            execute.RunLua(luaEnv, num);
            luaTime = timer.End();
        }
        catch (Exception e)
        {
            luaTime = -1;
            Debug.LogWarning(e);
        }

        return new ExecuteStates()
        {
            name = execute.Name,
            num = num,
            csTime = csTime,
            jsTime = jsTime,
            luaTime = luaTime,
        };
    }
}
