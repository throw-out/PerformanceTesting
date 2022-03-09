using System;
using Puerts;
using XLua;

/// <summary>
/// 调用脚本function
/// 逻辑:   无
/// 参数:   无
/// 返回值: 无
/// </summary>
[Test(100)]
public class Example101 : IExecute
{
    [CSharpCallLua]
    public delegate void TargetFunc();
    [CSharpCallLua]
    public delegate TargetFunc CreateFunc();

    public bool Static => true;
    public string Method => "payload(): void;";
    public CallTarget Target => CallTarget.CSharpCallScript;

    public object RunCS(int count)
    {
        throw new System.NotImplementedException();
    }

    public object RunJS(JsEnv env, int count)
    {
        var func = env.Eval<TargetFunc>(@"
function payload(){
}

payload;
");
        for (int i = 0; i < count; i++)
        {
            func();
        }
        return null;
    }
    public object RunLua(LuaEnv env, int count)
    {
        var create = env.LoadString<CreateFunc>(@"
function payload()
end

return payload;
");
        var func = create();
        for (int i = 0; i < count; i++)
        {
            func();
        }
        return null;
    }
}
