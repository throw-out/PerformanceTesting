using Puerts;
using XLua;

/// <summary>
/// 静态方法调用, 一个值类型参数, 无返回值
/// </summary>
[Tests]
public class Example3 : IExecute
{
    public string Name => "static void Payload(int param1);";

    public void RunCS(int num)
    {
        for (var i = 0; i < num; i++)
        {
            Example3.Payload(1);
        }
    }
    public void RunJS(JsEnv env, int num)
    {
        env.Eval(string.Format(
@"
var Example = require('csharp').Example3;
for(let i = 0; i < {0}; i++){{
    Example.Payload(1);
}}
", num));
    }
    public void RunLua(LuaEnv env, int num)
    {
        env.DoString(string.Format(
@"
local Example = CS.Example3;
for i = 1,{0} do
    Example.Payload(1);
end
", num));
    }

    public static void Payload(int param1)
    {

    }
}
