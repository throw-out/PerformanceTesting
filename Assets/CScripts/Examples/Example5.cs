using Puerts;
using XLua;

/// <summary>
/// 静态方法调用, 三个值类型参数, 返回参数之和
/// </summary>
[Tests]
public class Example5 : IExecute
{
    public string Method => "static void Payload(int param1, int param2, float param3);";

    public object RunCS(int count)
    {
        float result = 0f;
        for (var i = 0; i < count; i++)
        {
            result += Example5.Payload(i, i + 1, i + 2f);
        }
        return result;
    }
    public object RunJS(JsEnv env, int count)
    {
        float result = env.Eval<float>(string.Format(
@"
var Example = require('csharp').Example5;
var result = 0;
for(let i = 0; i < {0}; i++){{
    result += Example.Payload(1, i + 1, i + 2);
}}

result;
", count));
        return result;
    }
    public object RunLua(LuaEnv env, int count)
    {
        object[] result = env.DoString(string.Format(
@"
local Example = CS.Example5;
local result = 0;
for i = 0,{0} do
    result = result + Example.Payload(1, i + 1, i + 2);
end

return result;
", count - 1));

        return result != null && result.Length > 0 ? result[0] : null;
    }

    public static float Payload(int param1, int param2, float param3)
    {
        return param1 + param2 + param3;
    }
}
