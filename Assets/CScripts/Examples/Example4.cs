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
public class Example4 : IExecute
{
    public bool Static => true;
    public string Method => "void Payload(int, int, float);";
    public CallTarget Target => CallTarget.ScriptCallCSharp;

    public object RunCS(int count)
    {
        for (var i = 0; i < count; i++)
        {
            Example4.Payload(i, i + 1, i + 2f);
        }
        return null;
    }
    public object RunJS(JsEnv env, int count)
    {
        env.Eval(string.Format(
@"
var Example = require('csharp').Example4;
for(let i = 0; i < {0}; i++){{
    Example.Payload(1, i + 1, i + 2);
}}
", count));
        return null;
    }
    public object RunLua(LuaEnv env, int count)
    {
        env.DoString(string.Format(
@"
local Example = CS.Example4;
for i = 1,{0} do
    Example.Payload(1, i + 1, i + 2);
end
", count));
        return null;
    }

    public static void Payload(int param1, int param2, float param3)
    {

    }
}
