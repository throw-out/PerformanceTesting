using System;
using Puerts;
using XLua;

public abstract class ExecuteBase
{
    public abstract bool Static { get; }
    public abstract string Method { get; }
    public abstract ExecuteTarget Target { get; }

    public abstract object RunCSharp(int count);
    public abstract object RunPuertsWithJs(ScriptEnv env, int count);
    public abstract object RunPuertsWithLua(ScriptEnv env, int count);
    public abstract object RunXLua(LuaEnv env, int count);
}

public abstract class ExecuteBase1 : ExecuteBase
{
    public abstract string GetJsCode(int count);
    public abstract string GetLuaCode(int count);
    public override object RunPuertsWithJs(ScriptEnv env, int count)
    {
        var code = GetJsCode(count);
        return env.Eval<object>(code);
    }
    public override object RunPuertsWithLua(ScriptEnv env, int count)
    {
        var code = GetLuaCode(count);
        return env.Eval<object>(code);
    }
    public override object RunXLua(LuaEnv env, int count)
    {
        var code = GetLuaCode(count);
        object[] result = env.DoString(code);
        return result != null && result.Length > 0 ? result[0] : null;
    }
}
public abstract class ExecuteBase100 : ExecuteBase
{
    public abstract Delegate GetJsFunction(ScriptEnv env);
    public abstract Delegate GetLuaFunction(ScriptEnv env);
    public abstract Delegate GetLuaFunction(LuaEnv env);
    public abstract object Invoke(Delegate func, int count);

    public override object RunPuertsWithJs(ScriptEnv env, int count)
    {
        var func = GetJsFunction(env);
        return Invoke(func, count);
    }
    public override object RunPuertsWithLua(ScriptEnv env, int count)
    {
        var func = GetLuaFunction(env);
        return Invoke(func, count);
    }
    public override object RunXLua(LuaEnv env, int count)
    {
        var func = GetLuaFunction(env);
        return Invoke(func, count);
    }
}