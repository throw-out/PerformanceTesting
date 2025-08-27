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
public class Example6 : ExecuteBase1
{
    public override bool Static => true;
    public override string Method => "float Payload();";
    public override ExecuteTarget Target => ExecuteTarget.ScriptCallCS;

    public override object RunCSharp(int count)
    {
        float result = 0f;
        for (var i = 0; i < count; i++)
        {
            result += Example6.Payload();
        }
        return result;
    }
    public override string GetJsCode(int count)
    {
        return string.Format(
@"(function() {{
    var Example = CS.Example6;
    var result = 0;
    for(let i = 0; i < {0}; i++){{
        result += Example.Payload();
    }}

    return result;
}})()", count);
    }
    public override string GetLuaCode(int count)
    {
        return string.Format(
@"
return (function()
    local CS = CS or require('csharp');
    local Example = CS.Example6;
    local result = 0;
    for i = 0,{0} do
        result = result + Example.Payload();
    end

    return result;
end)();
", count - 1);
    }

    public static float Payload()
    {
        return 1 + 2 + 3f;
    }
}
