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
public class Example2 : ExecuteBase1
{
    public override bool Static => false;
    public override string Method => "void Payload();";
    public override ExecuteTarget Target => ExecuteTarget.ScriptCallCS;

    public override object RunCSharp(int count)
    {
        var Example = new Example2();
        for (var i = 0; i < count; i++)
        {
            Example.Payload();
        }
        return null;
    }

    public override string GetJsCode(int count)
    {
        return string.Format(
@"(function() {{
    var Example = new CS.Example2();
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
    local Example = CS.Example2();
    for i = 1,{0} do
        Example:Payload();
    end
end)()
", count);
    }

    public void Payload()
    {

    }
}