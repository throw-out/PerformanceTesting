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
public class Example3 : ExecuteBase1
{
    public override bool Static => true;
    public override string Method => "void Payload(int);";
    public override ExecuteTarget Target => ExecuteTarget.ScriptCallCS;

    public override object RunCSharp(int count)
    {
        for (var i = 0; i < count; i++)
        {
            Example3.Payload(i);
        }
        return null;
    }
    public override string GetJsCode(int count)
    {
        return string.Format(
@"(function() {{
    var Example = CS.Example3;
    for(let i = 0; i < {0}; i++){{
        Example.Payload(i);
    }}
}})()", count);
    }
    public override string GetLuaCode(int count)
    {
        return string.Format(
@"
(function()
    local CS = CS or require('csharp');
    local Example = CS.Example3;
    for i = 1,{0} do
        Example.Payload(i);
    end
end)()
", count);
    }

    public static void Payload(int param1)
    {

    }
}
