using System;

public struct ExecuteStates
{
    public Type Type;
    public string Method;
    public bool Static;
    public int Count;
    public ExecuteState CsInvoke;
    public ExecuteState JsInvoke;
    public ExecuteState LuaInvoke;
}
public struct ExecuteState
{
    public double Time;
    public object Result;
}