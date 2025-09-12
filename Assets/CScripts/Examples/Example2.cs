using System;
using Puerts;
using XLua;

/// <summary>
/// 实例方法调用
/// 逻辑:   无
/// 参数:   无
/// 返回值: 无
/// </summary>
[Test]
[TestGroup("Static vs Instance")]
[TestChart(0)]
public class Example2 : ExecuteBase
{
    private const string LuaFunctionTemplate = @"
local function workload()
    local CS = CS or require('csharp');
    local Example = CS.Example2();
    for i = 1,{0} do
        Example:Workload();
    end
end
return workload;
";
    private const string JsFunctionTemplate = @"
function workload() {{
    let Example = new CS.Example2();
    for(let i = 0; i < {0}; i++){{
        Example.Workload();
    }}
}}
workload;
";
    public void Workload()
    {
    }

    public override bool Static => false;
    public override string Method => "void Workload();";
    public override ExecuteTarget Target => ExecuteTarget.ScriptCallCS;

    protected override Delegate GetCSharpFunction(int count)
    {
        return new Action(() =>
        {
            var Example = new Example2();
            for (var i = 0; i < count; i++)
            {
                Example.Workload();
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