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
                    where typeof(IExecute).IsAssignableFrom(type) && type.IsDefined(typeof(TestAttribute), false)
                    orderby (type.GetCustomAttributes(typeof(TestAttribute), false).FirstOrDefault() as TestAttribute).priority descending
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

        List<ExecuteStates> statesList = new List<ExecuteStates>();
        foreach (IExecute execute in executeUnits)
        {
            for (int i = 0; i < executeNums.Length; i++)
            {
                int count = executeNums[i];
                if (count <= 0)
                    continue;

                statesList.Add(new ExecuteStates()
                {
                    Type = execute.GetType(),
                    Method = execute.Method,
                    Static = execute.Static,
                    Count = count,
                    CsInvoke = ExecuteUtil.InvokeCS(execute, count),
                    JsInvoke = ExecuteUtil.InvokeJs(jsEnv, execute, count),
                    LuaInvoke = ExecuteUtil.InvokeLua(luaEnv, execute, count)
                });
            }
        }

        File.WriteAllText(Path.Combine(Application.dataPath, "../STATES.md"), MarkdownUtil.FromatToTable(statesList));

        Debug.Log("Test Completed.");
    }

    void OnDestroy()
    {
        jsEnv.Dispose();
        jsEnv = null;

        luaEnv.Dispose();
        luaEnv = null;
    }
}
