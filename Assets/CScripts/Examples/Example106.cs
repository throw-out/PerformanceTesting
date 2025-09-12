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
[TestChart(100)]
public class Example106 : ExecuteBase
{
    private const string LuaFunctionTemplate = @"
local function workload()
    return 1 + 2 + 3;
end
return workload;
";
    private const string JsFunctionTemplate = @"
function workload() {{
    return 1 + 2 + 3;
}}
workload;
";

    public override bool Static => true;
    public override string Method => "workload(): number;";
    public override ExecuteTarget Target => ExecuteTarget.CSCallScript;

    protected override Delegate GetCSharpFunction(int count)
    {
        throw new NotImplementedException();
    }

    protected override Delegate GetLuaFunction(LuaEnv env, int count)
    {
        var creator = env.LoadString<ReturnFloat_Creator>(LuaFunctionTemplate);
        return creator();
    }

    protected override Delegate GetLuaFunction(ScriptEnv env, int count)
    {
        return env.Eval<ReturnFloat>(LuaFunctionTemplate);
    }

    protected override Delegate GetJsFunction(ScriptEnv env, int count)
    {
        return env.Eval<ReturnFloat>(JsFunctionTemplate);
    }

    protected override object Invoke(Delegate workload, int count)
    {
        var func = (ReturnFloat)workload;
        float result = 0f;
        for (int i = 0; i < count; i++)
        {
            result += func();
        }
        return result;
    }
}
