using System;
using Puerts;
using XLua;

/// <summary>
/// 调用脚本function
/// 逻辑:   内部求和并返回
/// 参数:   无
/// 返回值: 值类型
/// </summary>
[Test(100)]
public class Example106 : IExecute
{
    [CSharpCallLua]
    public delegate float TargetFunc();
    [CSharpCallLua]
    public delegate TargetFunc CreateFunc();

    public bool Static => true;
    public string Method => "payload(): number;";
    public CallTarget Target => CallTarget.CSharpCallScript;

    public object RunCS(int count)
    {
        throw new System.NotImplementedException();
    }

    public object RunJS(JsEnv env, int count)
    {
        var func = env.Eval<TargetFunc>(@"
function payload(param1, param2, param3){
    return 1 + 2 + 3;
}

payload;
");
        float result = 0f;
        for (int i = 0; i < count; i++)
        {
            result += func();
        }
        return result;
    }
    public object RunLua(LuaEnv env, int count)
    {
        var create = env.LoadString<CreateFunc>(@"
local function payload(param1, param2, param3)
    return 1 + 2 + 3;
end

return payload;
");
        var func = create();
        float result = 0f;
        for (int i = 0; i < count; i++)
        {
            result += func();
        }
        return result;
    }
}
