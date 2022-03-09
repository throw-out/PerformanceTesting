using System;
using Puerts;
using UnityEngine;
using XLua;

/// <summary>
/// 调用脚本function
/// 逻辑:   调用Transform.Rotate
/// 参数:   1引用类型, 3个值类型参数
/// 返回值: UnityEngine.Quaternion
/// </summary>
[Test(100)]
public class Example108 : IExecute
{
    [CSharpCallLua]
    public delegate void TargetFunc(Transform transform, float param1, float param2, float param3);
    [CSharpCallLua]
    public delegate TargetFunc CreateFunc();

    public bool Static => true;
    public string Method => "payload(Transform,float,float,float): void;";
    public CallTarget Target => CallTarget.CSharpCallScript;

    public object RunCS(int count)
    {
        throw new System.NotImplementedException();
    }

    public object RunJS(JsEnv env, int count)
    {
        var func = env.Eval<TargetFunc>(@"
function payload(transform, param1, param2, param3){
    transform.Rotate(param1, param2, param3);
}

payload;
");
        var obj = new GameObject().transform;
        for (int i = 0; i < count; i++)
        {
            func(obj, i % 3f, i % 4f, i % 5f);
        }
        var result = obj.rotation;
        UnityEngine.Object.Destroy(obj.gameObject);

        return result;
    }
    public object RunLua(LuaEnv env, int count)
    {
        var create = env.LoadString<CreateFunc>(@"
local function payload(transform, param1, param2, param3)
    transform:Rotate(param1, param2, param3);
end

return payload;
");
        var func = create();
        var obj = new GameObject().transform;
        for (int i = 0; i < count; i++)
        {
            func(obj, i % 3f, i % 4f, i % 5f);
        }
        var result = obj.rotation;
        UnityEngine.Object.Destroy(obj.gameObject);

        return result;
    }
}
