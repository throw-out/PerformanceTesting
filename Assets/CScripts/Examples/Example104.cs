using System;
using Puerts;
using XLua;

/// <summary>
/// 调用脚本function
/// 逻辑:   无
/// 参数:   3个值类型
/// 返回值: 无
/// </summary>
[Test(100)]
public class Example104 : IExecute
{
    [CSharpCallLua]
    public delegate void TargetFunc(int param1, int param2, float param3);
    [CSharpCallLua]
    public delegate TargetFunc CreateFunc();

    public bool Static => true;
    public string Method => "payload(number,number,number): void;";
    public CallTarget Target => CallTarget.CSharpCallScript;

    public object RunCS(int count)
    {
        throw new System.NotImplementedException();
    }

    public object RunJS(JsEnv env, int count)
    {
        var func = env.Eval<TargetFunc>(@"
function payload(param1,param2,param3){
}

payload;
");
        for (int i = 0; i < count; i++)
        {
            func(i, i + 1, i + 2f);
        }
        return null;
    }
    public object RunLua(LuaEnv env, int count)
    {
        var create = env.LoadString<CreateFunc>(@"
local function payload(param1,param2,param3)
end

return payload;
");
        var func = create();
        for (int i = 0; i < count; i++)
        {
            func(i, i + 1, i + 2f);
        }
        return null;
    }
}
