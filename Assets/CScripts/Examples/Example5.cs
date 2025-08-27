using Puerts;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   参数求和并返回
/// 参数:   三个值类型参数
/// 返回值: 值类型
/// </summary>
[Test]
public class Example5 : ExecuteBase1
{
    public override bool Static => true;
    public override string Method => "float Payload(int, int, float);";
    public override ExecuteTarget Target => ExecuteTarget.ScriptCallCS;

    public override object RunCSharp(int count)
    {
        float result = 0f;
        for (var i = 0; i < count; i++)
        {
            result += Example5.Payload(i, i + 1, i + 2f);
        }
        return result;
    }
    public override string GetJsCode(int count)
    {
        return string.Format(
@"(function() {{
    var Example = CS.Example5;
    var result = 0;
    for(let i = 0; i < {0}; i++){{
        result += Example.Payload(i, i + 1, i + 2);
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
    local Example = CS.Example5;
    local result = 0;
    for i = 0,{0} do
        result = result + Example.Payload(i, i + 1, i + 2);
    end

    return result;
end)()
", count - 1);
    }

    public static float Payload(int param1, int param2, float param3)
    {
        return param1 + param2 + param3;
    }
}
