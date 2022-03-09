using System;
using Puerts;
using XLua;

/// <summary>
/// 调用脚本function
/// 逻辑:   无
/// 参数:   1个值类型
/// 返回值: 无
/// </summary>
[Test(100)]
public class Example103 : IExecute
{
    [CSharpCallLua]
    public delegate void TargetFunc(int value);
    [CSharpCallLua]
    public delegate TargetFunc CreateFunc();

    public bool Static => true;
    public string Method => "payload(number): void;";
    public CallTarget Target => CallTarget.CSharpCallScript;

    public object RunCS(int count)
    {
        throw new System.NotImplementedException();
    }

    public object RunJS(JsEnv env, int count)
    {
        var func = env.Eval<TargetFunc>(@"
function payload(param1){
}

payload;
", nameof(Example101));
        for (int i = 0; i < count; i++)
        {
            func(i);
        }
        return null;
    }
    public object RunLua(LuaEnv env, int count)
    {
        var create = env.LoadString<CreateFunc>(@"
local function payload(param1)
end

return payload;
", nameof(Example101));
        var func = create();
        for (int i = 0; i < count; i++)
        {
            func(i);
        }
        return null;
    }
}
