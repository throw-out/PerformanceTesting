public struct ExecuteStates
{
    public string Name;
    public string Method;
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