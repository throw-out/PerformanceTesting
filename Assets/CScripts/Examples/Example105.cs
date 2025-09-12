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
public class Example105 : ExecuteBase
{
    private const string LuaFunctionTemplate = @"
local function workload(param1,param2,param3)
    return param1 + param2 + param3;
end
return workload;
";
    private const string JsFunctionTemplate = @"
function workload(param1,param2,param3) {{
    return param1 + param2 + param3;
}}
workload;
";
    public override bool Static => true;
    public override string Method => "workload(number,number,number): number;";
    public override ExecuteTarget Target => ExecuteTarget.CSCallScript;

    protected override Delegate GetCSharpFunction(int count)
    {
        throw new NotImplementedException();
    }

    protected override Delegate GetLuaFunction(LuaEnv env, int count)
    {
        var creator = env.LoadString<ParamsIntIntFloat_ReturnFloat_Creator>(LuaFunctionTemplate);
        return creator();
    }

    protected override Delegate GetLuaFunction(ScriptEnv env, int count)
    {
        return env.Eval<ParamsIntIntFloat_ReturnFloat>(LuaFunctionTemplate);
    }

    protected override Delegate GetJsFunction(ScriptEnv env, int count)
    {
        return env.Eval<ParamsIntIntFloat_ReturnFloat>(JsFunctionTemplate);
    }

    protected override object Invoke(Delegate workload, int count)
    {
        var func = (ParamsIntIntFloat_ReturnFloat)workload;
        float result = 0f;
        for (int i = 0; i < count; i++)
        {
            result += func(i, i + 1, i + 2f);
        }
        return result;
    }
}
