using Puerts;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   无
/// 参数:   三个值类型参数
/// 返回值: 无
/// </summary>
[Test]
[TestGroup("ParameterCompare")]
public class Example4 : ExecuteBase1
{
    public override bool Static => true;
    public override string Method => "void Payload(int, int, float);";
    public override ExecuteTarget Target => ExecuteTarget.ScriptCallCS;

    public override object RunCSharp(int count)
    {
        for (var i = 0; i < count; i++)
        {
            Example4.Payload(i, i + 1, i + 2f);
        }
        return null;
    }
    public override string GetJsCode(int count)
    {
        return string.Format(
@"(function() {{
    var Example = CS.Example4;
    for(let i = 0; i < {0}; i++){{
        Example.Payload(1, i + 1, i + 2);
    }}
}})()", count);
    }
    public override string GetLuaCode(int count)
    {
        return string.Format(
@"
(function()
    local CS = CS or require('csharp');
    local Example = CS.Example4;
    for i = 1,{0} do
        Example.Payload(1, i + 1, i + 2);
    end
end)()
", count);
    }

    public static void Payload(int param1, int param2, float param3)
    {

    }
}
