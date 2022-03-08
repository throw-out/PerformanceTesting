public struct ExecuteStates
{
    public string name;
    public int num;
    public ExecuteState csState;
    public ExecuteState jsState;
    public ExecuteState luaState;
}
public struct ExecuteState
{
    public double time;
    public object result;
}