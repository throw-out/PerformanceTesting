using System;
using Puerts;
using XLua;

public static class ExecuteUtil
{
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