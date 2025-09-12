using System;
using Puerts;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   内部求和并返回
/// 参数:   无
/// 返回值: 值类型
/// </summary>
[Test]
[TestChart(0)]
public class Example6 : ExecuteBase
{
    private const string LuaFunctionTemplate = @"
local function workload()
    local CS = CS or require('csharp');
    local Example = CS.Example6;
    local result = 0;
    for i = 1,{0} do
        result = result + Example.Workload();
    end
    return result;
end
return workload;
";
    private const string JsFunctionTemplate = @"
function workload() {{
    let Example = CS.Example6;
    let result = 0;
    for(let i = 0; i < {0}; i++){{
        result += Example.Workload();
    }}
    return result;
}}
workload;
";
    public static float Workload()
    {
        return 1 + 2 + 3f;
    }


    public override bool Static => true;
    public override string Method => "float Workload();";
    public override ExecuteTarget Target => ExecuteTarget.ScriptCallCS;

    protected override Delegate GetCSharpFunction(int count)
    {
        return new ReturnFloat(() =>
        {
            float result = 0f;
            for (var i = 0; i < count; i++)
            {
                result += Example6.Workload();
            }
            return result;
        });
    }

    protected override Delegate GetLuaFunction(LuaEnv env, int count)
    {
        var creator = env.LoadString<ReturnFloat_Creator>(string.Format(LuaFunctionTemplate, count));
        return creator();
    }

    protected override Delegate GetLuaFunction(ScriptEnv env, int count)
    {
        return env.Eval<ReturnFloat>(string.Format(LuaFunctionTemplate, count));
    }

    protected override Delegate GetJsFunction(ScriptEnv env, int count)
    {
        return env.Eval<ReturnFloat>(string.Format(JsFunctionTemplate, count));
    }

    protected override object Invoke(Delegate workload, int count)
    {
        return ((ReturnFloat)workload)();
    }
}
