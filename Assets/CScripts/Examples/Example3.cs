using System;
using Puerts;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   无
/// 参数:   一个值类型参数
/// 返回值: 无
/// </summary>
[Test]
[TestGroup("ParameterCompare")]
[TestChart(0)]
public class Example3 : ExecuteBase
{
    private const string LuaFunctionTemplate = @"
local function workload()
    local CS = CS or require('csharp');
    local Example = CS.Example3;
    for i = 1,{0} do
        Example.Workload(i);
    end
end
return workload;
";
    private const string JsFunctionTemplate = @"
function workload() {{
    let Example = CS.Example3;
    for(let i = 0; i < {0}; i++){{
        Example.Workload(i);
    }}
}}
workload;
";
    public static void Workload(int param1)
    {
    }

    public override bool Static => true;
    public override string Method => "void Workload(int);";
    public override ExecuteTarget Target => ExecuteTarget.ScriptCallCS;

    protected override Delegate GetCSharpFunction(int count)
    {
        return new Action(() =>
        {
            for (var i = 0; i < count; i++)
            {
                Example3.Workload(i);
            }
        });
    }

    protected override Delegate GetLuaFunction(LuaEnv env, int count)
    {
        var creator = env.LoadString<Action_Creator>(string.Format(LuaFunctionTemplate, count));
        return creator();
    }

    protected override Delegate GetLuaFunction(ScriptEnv env, int count)
    {
        return env.Eval<Action>(string.Format(LuaFunctionTemplate, count));
    }

    protected override Delegate GetJsFunction(ScriptEnv env, int count)
    {
        return env.Eval<Action>(string.Format(JsFunctionTemplate, count));
    }

    protected override object Invoke(Delegate workload, int count)
    {
        ((Action)workload)();
        return null;
    }
}
