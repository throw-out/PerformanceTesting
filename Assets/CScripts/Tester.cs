using System;
using Puerts;
using XLua;
using System.IO;
using UnityEngine;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Tester 
{
    private JsEnv jsEnv;
    private LuaEnv luaEnv;
    private bool isTesting;
    public bool IsTesting() 
    {
        return isTesting;
    }
    private int[] repeatTimePerSuite;
    private string statesOutputPath;

    public Tester(int[] repeatTimePerSuite, string statesOutputPath) {
        jsEnv = new JsEnv();
        luaEnv = new LuaEnv();
        this.AutoUsing(jsEnv);
        this.repeatTimePerSuite = repeatTimePerSuite;
        this.statesOutputPath = statesOutputPath;
    }

    private void AutoUsing(JsEnv env)
    {
        const string typeName = "PuertsStaticWrap.AutoStaticCodeUsing";
        var type = (from _assembly in AppDomain.CurrentDomain.GetAssemblies()
                    let _type = _assembly.GetType(typeName, false)
                    where _type != null
                    select _type).FirstOrDefault();
        if (type != null)
        {
            type.GetMethod("AutoUsing").Invoke(null, new object[] { env });
        }
    }

    public void Tick() {
        jsEnv.Tick();
        luaEnv.Tick();
    }

    ~Tester() {
        jsEnv.Dispose();
        luaEnv.Dispose();
    }

    public void StopTest() {
        isTesting = false;
        appendTestInfo("\b test stopped");
    }

    public IEnumerator StartTest() 
    {
        IExecute[] executes = ExecuteUtil.GetExecutes();
        if (executes == null || executes.Length == 0)
        {
            appendTestInfo("\ntest instance not found");
            isTesting = false;
            yield break;
        }

        Timer totalDuration = new Timer();

        appendTestInfo("\nstart test: instance = " + executes.Length);
        yield return null;

        List<ExecuteStates> statesList = new List<ExecuteStates>();
        foreach (IExecute execute in executes)
        {
            for (int i = 0; i < repeatTimePerSuite.Length; i++)
            {
                int count = repeatTimePerSuite[i];
                if (count <= 0)
                    continue;

                ExecuteState csInvoke = ExecuteUtil.InvokeCS(execute, count);
                appendTestInfo("\n{0} | {1} | count={2}, run csharp = {3}",
                    execute.GetType().FullName,
                    execute.Method,
                    count,
                    csInvoke.Duration >= 0 ? (csInvoke.Duration.ToString("f1") + "ms") : "fail"
                );
                yield return null;

                ExecuteState jsInvoke = ExecuteUtil.InvokeJs(jsEnv, execute, count);
                appendTestInfo("\n{0} | {1} | count={2}, run puerts = {3}",
                    execute.GetType().FullName,
                    execute.Method,
                    count,
                    jsInvoke.Duration >= 0 ? (jsInvoke.Duration.ToString("f1") + "ms") : "fail"
                );
                yield return null;

                ExecuteState luaInvoke = ExecuteUtil.InvokeLua(luaEnv, execute, count);
                appendTestInfo("\n{0} | {1} | count={2}, run xLua = {3}",
                    execute.GetType().FullName,
                    execute.Method,
                    count,
                    luaInvoke.Duration >= 0 ? (luaInvoke.Duration.ToString("f1") + "ms") : "fail"
                );
                yield return null;

                statesList.Add(new ExecuteStates()
                {
                    Type = execute.GetType(),
                    Static = execute.Static,
                    Method = execute.Method,
                    Target = execute.Target,
                    Count = count,
                    CsInvoke = csInvoke,
                    JsInvoke = jsInvoke,
                    LuaInvoke = luaInvoke
                });
            }
        }
        isTesting = false;
        appendTestInfo(@"
            
            test completed! total duration = {0}ms
            
            states file write to: {1}" ,

            totalDuration.End().ToString("f1"), 
            OutputResult(statesList)
        );
    }

    protected string OutputResult(List<ExecuteStates> statesList) 
    {
        if (File.Exists(statesOutputPath)) File.Delete(statesOutputPath);
        File.WriteAllText(statesOutputPath, MarkdownUtil.Generate(statesList));
        return statesOutputPath;
    }

    public event Action<string> OnInfoUpdate;

    protected void appendTestInfo(string info, params object[] parameters) {
        OnInfoUpdate(String.Format(info, parameters));
    }
}