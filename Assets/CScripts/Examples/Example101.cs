using System;
using Puerts;
using XLua;

/// <summary>
/// 调用脚本function
/// 逻辑:   无
/// 参数:   无
/// 返回值: 无
/// </summary>
[Test(100)]
[TestChart(100)]
public class Example101 : ExecuteBase
{
    private const string LuaFunctionTemplate = @"
local function workload()
end
return workload;
";
    private const string JsFunctionTemplate = @"
function workload() {{
}}
workload;
";

    public override bool Static => true;
    public override string Method => "workload(): void;";
    public override ExecuteTarget Target => ExecuteTarget.CSCallScript;

    protected override Delegate GetCSharpFunction(int count)
    {
        throw new NotImplementedException();
    }

    protected override Delegate GetLuaFunction(LuaEnv env, int count)
    {
        var creator = env.LoadString<Action_Creator>(LuaFunctionTemplate);
        return creator();
    }

    protected override Delegate GetLuaFunction(ScriptEnv env, int count)
    {
        return env.Eval<Action>(LuaFunctionTemplate);
    }

    protected override Delegate GetJsFunction(ScriptEnv env, int count)
    {
        return env.Eval<Action>(JsFunctionTemplate);
    }

    protected override object Invoke(Delegate workload, int count)
    {
        var func = (Action)workload;
        for (int i = 0; i < count; i++)
        {
            func();
        }
        return null;
    }
}
