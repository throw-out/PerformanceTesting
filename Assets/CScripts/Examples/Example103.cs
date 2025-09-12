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
public class Example103 : ExecuteBase
{
    private const string LuaFunctionTemplate = @"
local function workload(param1)
end
return workload;
";
    private const string JsFunctionTemplate = @"
function workload(param1) {{
}}
workload;
";
    public override bool Static => true;
    public override string Method => "workload(number): void;";
    public override ExecuteTarget Target => ExecuteTarget.CSCallScript;

    protected override Delegate GetCSharpFunction(int count)
    {
        throw new NotImplementedException();
    }

    protected override Delegate GetLuaFunction(LuaEnv env, int count)
    {
        var creator = env.LoadString<ParamsInt_Creator>(LuaFunctionTemplate);
        return creator();
    }

    protected override Delegate GetLuaFunction(ScriptEnv env, int count)
    {
        return env.Eval<ParamsInt>(LuaFunctionTemplate);
    }

    protected override Delegate GetJsFunction(ScriptEnv env, int count)
    {
        return env.Eval<ParamsInt>(JsFunctionTemplate);
    }
    protected override object Invoke(Delegate workload, int count)
    {
        var func = (ParamsInt)workload;
        for (int i = 0; i < count; i++)
        {
            func(i);
        }
        return null;
    }
}
