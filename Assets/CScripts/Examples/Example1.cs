﻿using Puerts;
using XLua;

/// <summary>
/// 静态方法调用, 无参, 无返回值
/// </summary>
[Tests]
public class Example1 : IExecute
{
    public string Method => "static void Payload();";

    public object RunCS(int count)
    {
        for (var i = 0; i < count; i++)
        {
            Example1.Payload();
        }
        return null;
    }

    public object RunJS(JsEnv env, int count)
    {
        env.Eval(string.Format(
@"
var Example = require('csharp').Example1;
for(let i = 0; i < {0}; i++){{
    Example.Payload();
}}
", count));
        return null;
    }
    public object RunLua(LuaEnv env, int count)
    {
        env.DoString(string.Format(
@"
local Example = CS.Example1;
for i = 1,{0} do
    Example.Payload();
end
", count));
        return null;
    }

    public static void Payload()
    {

    }
}
