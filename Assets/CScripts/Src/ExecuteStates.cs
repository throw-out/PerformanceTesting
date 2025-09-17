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
    public long MonoMemory;
    public long NativeMemory;

    public static readonly ExecuteData Error = new ExecuteData()
    {
        Duration = -1,
        Result = null,
        MonoMemory = -1,
        NativeMemory = -1,
    };
}