using System;
using System.Collections.Generic;

public struct ExecuteStates
{
    public Type Type;
    public bool Static;
    public string Method;
    public ExecuteTarget Target;
    public int Count;

    public Dictionary<string, ExecuteData> Results;
}
public struct ExecuteData
{
    public double Duration;
    public object Result;
    public long TotalMemory;
    public long Memory;

    public static readonly ExecuteData Error = new ExecuteData()
    {
        Duration = -1,
        Result = null,
        TotalMemory = -1,
        Memory = -1,
    };
}