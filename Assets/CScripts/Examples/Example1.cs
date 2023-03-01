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
public class Example1 : IExecute
{
    public bool Static => true;
    public string Method => "void Payload();";
    public CallTarget Target => CallTarget.ScriptCallCSharp;

    public object RunCS(int count)
    {
        for (var i = 0; i < count; i++)
        {
            Example1.Payload();
        }
        return null;
    }

    public object RunJS(JsEnv env, int count)
    {
        env.Eval(string.Format(
@"(function() {{
    var Example = require('csharp').Example1;
    for(let i = 0; i < {0}; i++){{
        Example.Payload();
    }}
}})()", count));
        return null;
    }
    public object RunLua(LuaEnv env, int count)
    {
        env.DoString(string.Format(
@"
(function()
    local Example = CS.Example1;
    for i = 1,{0} do
        Example.Payload();
    end
end)()
", count));
        return null;
    }

    public static void Payload()
    {

    }
}
