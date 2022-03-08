using Puerts;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   内部求和并返回
/// 参数:   无
/// 返回值: 值类型
/// </summary>
[Tests]
public class Example6 : IExecute
{
    public bool Static => true;
    public string Method => "float Payload();";

    public object RunCS(int count)
    {
        float result = 0f;
        for (var i = 0; i < count; i++)
        {
            result += Example6.Payload();
        }
        return result;
    }
    public object RunJS(JsEnv env, int count)
    {
        float result = env.Eval<float>(string.Format(
@"
var Example = require('csharp').Example6;
var result = 0;
for(let i = 0; i < {0}; i++){{
    result += Example.Payload();
}}

result;
", count));
        return result;
    }
    public object RunLua(LuaEnv env, int count)
    {
        object[] result = env.DoString(string.Format(
@"
local Example = CS.Example6;
local result = 0;
for i = 0,{0} do
    result = result + Example.Payload();
end

return result;
", count - 1));

        return result != null && result.Length > 0 ? result[0] : null;
    }

    public static float Payload()
    {
        return 1 + 2 + 3f;
    }
}
