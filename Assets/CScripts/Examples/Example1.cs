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
public class Example1 : ExecuteBase1
{
    public override bool Static => true;
    public override string Method => "void Payload();";
    public override ExecuteTarget Target => ExecuteTarget.ScriptCallCS;

    public override object RunCSharp(int count)
    {
        for (var i = 0; i < count; i++)
        {
            Example1.Payload();
        }
        return null;
    }

    public override string GetJsCode(int count)
    {
        return string.Format(
@"(function() {{
    var Example = CS.Example1;
    for(let i = 0; i < {0}; i++){{
        Example.Payload();
    }}
}})()", count);
    }

    public override string GetLuaCode(int count)
    {
        return string.Format(
@"
(function()
    local CS = CS or require('csharp');
    local Example = CS.Example1;
    for i = 1,{0} do
        Example.Payload();
    end
end)()
", count);
    }

    public static void Payload()
    {
    }
}
