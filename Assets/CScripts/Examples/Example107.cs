using System;
using Puerts;
using UnityEngine;
using XLua;

/// <summary>
/// 调用脚本function
/// 逻辑:   调用Transform.Rotate
/// 参数:   1引用类型
/// 返回值: UnityEngine.Quaternion
/// </summary>
[Test(100)]
public class Example107 : IExecute
{
    [CSharpCallLua]
    public delegate void TargetFunc(Transform transform);
    [CSharpCallLua]
    public delegate TargetFunc CreateFunc();

    public bool Static => true;
    public string Method => "payload(Transform): void;";
    public CallTarget Target => CallTarget.CSharpCallScript;

    public object RunCS(int count)
    {
        throw new System.NotImplementedException();
    }

    public object RunJS(JsEnv env, int count)
    {
        var func = env.Eval<TargetFunc>(@"
function payload(transform){
    transform.Rotate(1, 1, 1);
}

payload;
");
        var obj = new GameObject().transform;
        for (int i = 0; i < count; i++)
        {
            func(obj);
        }
        var result = obj.rotation;
        UnityEngine.Object.DestroyImmediate(obj.gameObject);

        return result;
    }
    public object RunLua(LuaEnv env, int count)
    {
        var create = env.LoadString<CreateFunc>(@"
local function payload(transform)
    transform:Rotate(1, 1, 1);
end

return payload;
");
        var func = create();
        var obj = new GameObject().transform;
        for (int i = 0; i < count; i++)
        {
            func(obj);
        }
        var result = obj.rotation;
        UnityEngine.Object.DestroyImmediate(obj.gameObject);

        return result;
    }
}
