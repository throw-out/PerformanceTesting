using System;
using Puerts;
using XLua;

/// <summary>
/// 调用脚本function
/// 逻辑:   无
/// 参数:   3个值类型
/// 返回值: 无
/// </summary>
[Test(100)]
[TestChart(100)]
public class Example104 : ExecuteBase
{
    private const string LuaFunctionTemplate = @"
local function workload(param1,param2,param3)
end
return workload;
";
    private const string JsFunctionTemplate = @"
function workload(param1,param2,param3) {{
}}
workload;
";
    public override bool Static => true;
    public override string Method => "workload(number,number,number): void;";
    public override ExecuteTarget Target => ExecuteTarget.CSCallScript;

    protected override Delegate GetCSharpFunction(int count)
    {
        throw new NotImplementedException();
    }

    protected override Delegate GetLuaFunction(LuaEnv env, int count)
    {
        var creator = env.LoadString<ParamsIntIntFloat_Creator>(LuaFunctionTemplate);
        return creator();
    }

    protected override Delegate GetLuaFunction(ScriptEnv env, int count)
    {
        return env.Eval<ParamsIntIntFloat>(LuaFunctionTemplate);
    }

    protected override Delegate GetJsFunction(ScriptEnv env, int count)
    {
        return env.Eval<ParamsIntIntFloat>(JsFunctionTemplate);
    }
    protected override object Invoke(Delegate workload, int count)
    {
        var func = (ParamsIntIntFloat)workload;
        for (int i = 0; i < count; i++)
        {
            func(i, i + 1, i + 2f);
        }
        return null;
    }
}
