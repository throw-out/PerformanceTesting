using System;
using Puerts;
using XLua;

/// <summary>
/// 调用脚本function
/// 逻辑:   无
/// 参数:   1个值类型
/// 返回值: 无
/// </summary>
[Test(100)]
[TestChart(100)]
public class Example103 : ExecuteBase100
{
    [CSharpCallLua]
    public delegate void TargetFunc(int param1);
    [CSharpCallLua]
    public delegate TargetFunc CreateFunc();

    public override bool Static => true;
    public override string Method => "payload(number): void;";
    public override ExecuteTarget Target => ExecuteTarget.CSCallScript;

    public override object RunCSharp(int count)
    {
        throw new System.NotImplementedException();
    }

    public override Delegate GetJsFunction(ScriptEnv env)
    {
        var func = env.Eval<TargetFunc>(@"
function payload(param1){
}

payload;
");
        return func;
    }
    public override Delegate GetLuaFunction(ScriptEnv env)
    {
        var func = env.Eval<TargetFunc>(@"
local function payload(param1)
end

return payload;
");
        return func;
    }
    public override Delegate GetLuaFunction(LuaEnv env)
    {
        var create = env.LoadString<CreateFunc>(@"
local function payload(param1)
end

return payload;
");
        return create();
    }
    public override object Invoke(Delegate func, int count)
    {
        var _func = (TargetFunc)func;
        for (int i = 0; i < count; i++)
        {
            _func(i);
        }
        return null;
    }
}
