using System;
using Puerts;
using XLua;

/// <summary>
/// 调用脚本function
/// 逻辑:   参数求和并返回
/// 参数:   3个值类型
/// 返回值: 值类型
/// </summary>
[Test(100)]
[TestChart(100)]
public class Example105 : ExecuteBase100
{
    [CSharpCallLua]
    public delegate float TargetFunc(int param1, int param2, float param3);
    [CSharpCallLua]
    public delegate TargetFunc CreateFunc();

    public override bool Static => true;
    public override string Method => "payload(number,number,number): number;";
    public override ExecuteTarget Target => ExecuteTarget.CSCallScript;

    public override object RunCSharp(int count)
    {
        throw new System.NotImplementedException();
    }

    public override Delegate GetJsFunction(ScriptEnv env)
    {
        var func = env.Eval<TargetFunc>(@"
function payload(param1,param2,param3){
    return param1 + param2 + param3;
}

payload;
");
        return func;
    }
    public override Delegate GetLuaFunction(ScriptEnv env)
    {
        var func = env.Eval<TargetFunc>(@"
local function payload(param1,param2,param3)
    return param1 + param2 + param3;
end

return payload;
");
        return func;
    }
    public override Delegate GetLuaFunction(LuaEnv env)
    {
        var create = env.LoadString<CreateFunc>(@"
local function payload(param1,param2,param3)
    return param1 + param2 + param3;
end

return payload;
");
        return create();
    }

    public override object Invoke(Delegate func, int count)
    {
        var _func = (TargetFunc)func;
        float result = 0f;
        for (int i = 0; i < count; i++)
        {
            result += _func(i, i + 1, i + 2f);
        }
        return result;
    }
}
