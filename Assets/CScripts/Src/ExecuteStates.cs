using System;

public struct ExecuteStates
{
    public Type Type;
    public bool Static;
    public string Method;
    public CallTarget Target;
    public int Count;
    public ExecuteState CsInvoke;
    public ExecuteState JsInvoke;
    public ExecuteState LuaInvoke;
}
public struct ExecuteState
{
    public double Duration;
    public object Result;
}