using Puerts;
using XLua;

/// <summary>
/// 实例方法调用, 无参, 无返回值
/// </summary>
[Tests]
public class Example2 : IExecute
{
    public string Name => "void Payload();";

    public void RunCS(int num)
    {
        var Example = new Example2();
        for (var i = 0; i < num; i++)
        {
            Example.Payload();
        }
    }

    public void RunJS(JsEnv env, int num)
    {
        env.Eval(string.Format(
@"
var Example = new (require('csharp').Example2)();
for(let i = 0; i < {0}; i++){{
    Example.Payload();
}}
", num), nameof(Example2));
    }
    public void RunLua(LuaEnv env, int num)
    {
        env.DoString(string.Format(
@"
--local Example = new CS.Example2();
local Example = CS.Example2.New;
for i = 1,{0} do
    Example.Payload();
end
", num), nameof(Example2));
    }

    public static Example2 New => new Example2();

    public void Payload()
    {

    }
}
