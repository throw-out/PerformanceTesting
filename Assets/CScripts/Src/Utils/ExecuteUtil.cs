using System;
using System.Linq;
using Puerts;
using XLua;

public static class ExecuteUtil
{
    public static IExecute[] GetExecutes()
    {
        return (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetExportedTypes()
                where typeof(IExecute).IsAssignableFrom(type) && type.IsDefined(typeof(TestAttribute), false)
                orderby (type.GetCustomAttributes(typeof(TestAttribute), false).FirstOrDefault() as TestAttribute).priority descending
                select System.Activator.CreateInstance(type) as IExecute
        ).ToArray();
    }

    public static ExecuteState InvokeCS(IExecute execute, int count)
    {
        double duration;
        object result;

        Timer timer = new Timer();
        try
        {
            result = execute.RunCS(count);
            duration = timer.End();
        }
        catch (Exception)
        {
            result = null;
            duration = -1;
        }
        return new ExecuteState()
        {
            Duration = duration,
            Result = result
        };
    }
    public static ExecuteState InvokeJs(JsEnv env, IExecute execute, int count)
    {
        double duration;
        object result;

        Timer timer = new Timer();
        try
        {
            result = execute.RunJS(env, count);
            duration = timer.End();
        }
        catch (Exception)
        {
            result = null;
            duration = -1;
        }
        return new ExecuteState()
        {
            Duration = duration,
            Result = result
        };
    }
    public static ExecuteState InvokeLua(LuaEnv env, IExecute execute, int count)
    {
        double duration;
        object result;

        Timer timer = new Timer();
        try
        {
            result = execute.RunLua(env, count);
            duration = timer.End();
        }
        catch (Exception)
        {
            result = null;
            duration = -1;
        }
        return new ExecuteState()
        {
            Duration = duration,
            Result = result
        };
    }
}