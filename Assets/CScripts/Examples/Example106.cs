using System;
using Puerts;
using XLua;

/// <summary>
/// 调用脚本function
/// 逻辑:   内部求和并返回
/// 参数:   无
/// 返回值: 值类型
/// </summary>
[Test(100)]
public class Example106 : ExecuteBase100
{
    [CSharpCallLua]
    public delegate float TargetFunc();
    [CSharpCallLua]
    public delegate TargetFunc CreateFunc();

    public override bool Static => true;
    public override string Method => "payload(): number;";
    public override ExecuteTarget Target => ExecuteTarget.CSCallScript;

    public override object RunCSharp(int count)
    {
        throw new System.NotImplementedException();
    }

    public override Delegate GetJsFunction(ScriptEnv env)
    {
        var func = env.Eval<TargetFunc>(@"
function payload(param1, param2, param3){
    return 1 + 2 + 3;
}

payload;
");
        return func;
    }
    public override Delegate GetLuaFunction(ScriptEnv env)
    {
        var func = env.Eval<TargetFunc>(@"
local function payload(param1, param2, param3)
    return 1 + 2 + 3;
end

return payload;
");
        return func;
    }
    public override Delegate GetLuaFunction(LuaEnv env)
    {
        var create = env.LoadString<CreateFunc>(@"
local function payload(param1, param2, param3)
    return 1 + 2 + 3;
end

return payload;
");
        return create();
    }
    public override object Invoke(Delegate func, int count)
    {
        float result = 0f;
        var _func = (TargetFunc)func;
        for (int i = 0; i < count; i++)
        {
            result += _func();
        }
        return result;
    }
}
