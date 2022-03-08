using Puerts;
using XLua;

/// <summary>
/// 静态方法调用, 无参, 无返回值
/// </summary>
[Tests]
public class Example1 : IExecute
{
    public string Name => "static void Payload();";

    public void RunCS(int num)
    {
        for (var i = 0; i < num; i++)
        {
            Example1.Payload();
        }
    }

    public void RunJS(JsEnv env, int num)
    {
        env.Eval(string.Format(
@"
var Example = require('csharp').Example1;
for(let i = 0; i < {0}; i++){{
    Example.Payload();
}}
", num));
    }
    public void RunLua(LuaEnv env, int num)
    {
        env.DoString(string.Format(
@"
local Example = CS.Example1;
for i = 1,{0} do
    Example.Payload();
end
", num));
    }

    public static void Payload()
    {

    }
}
