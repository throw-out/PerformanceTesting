using System;
using Puerts;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   无
/// 参数:   无
/// 返回值: 无
/// </summary>
[Test]
[TestGroup("Static vs Instance", 1, Desc = "静态函数 vs 实例函数")]
[TestGroup("ParameterCompare", 1, Desc = "无参数 vs 有参数")]
[TestChart(0)]
public class Example1 : ExecuteBase
{
    private const string LuaFunctionTemplate = @"
local function workload()
    local CS = CS or require('csharp');
    local Example = CS.Example1;
    for i = 1,{0} do
        Example.Workload();
    end
end
return workload;
";
    private const string JsFunctionTemplate = @"
function workload() {{
    let Example = CS.Example1;
    for(let i = 0; i < {0}; i++){{
        Example.Workload();
    }}
}}
workload;
";
    public static void Workload()
    {
    }


    public override bool Static => true;
    public override string Method => "void Workload();";
    public override ExecuteTarget Target => ExecuteTarget.ScriptCallCS;


    protected override Delegate GetCSharpFunction(int count)
    {
        return new Action(() =>
        {
            for (var i = 0; i < count; i++)
            {
                Example1.Workload();
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
