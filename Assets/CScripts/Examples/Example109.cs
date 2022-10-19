using System;
using Puerts;
using UnityEngine;
using XLua;

/// <summary>
/// 调用脚本function
/// 逻辑:   调用Transform.Rotate
/// 参数:   1引用类型, 1个值类型(Vector3)
/// 返回值: UnityEngine.Quaternion
/// </summary>
[Test(100)]
public class Example109 : IExecute
{
    [CSharpCallLua]
    public delegate void TargetFunc(Transform transform, Vector3 param1);
    [CSharpCallLua]
    public delegate TargetFunc CreateFunc();

    public bool Static => true;
    public string Method => "payload(Transform,Vector3): void;";
    public CallTarget Target => CallTarget.CSharpCallScript;

    public object RunCS(int count)
    {
        throw new System.NotImplementedException();
    }

    public object RunJS(JsEnv env, int count)
    {
        var func = env.Eval<TargetFunc>(@"
function payload(transform, param1){
    transform.Rotate(param1);
}

payload;
");
        var obj = new GameObject().transform;
        var eulers = new Vector3(1f, 2f, 3f);
        for (int i = 0; i < count; i++)
        {
            func(obj, eulers);
        }
        var result = obj.rotation;
        UnityEngine.Object.DestroyImmediate(obj.gameObject);

        return result;
    }
    public object RunLua(LuaEnv env, int count)
    {
        var create = env.LoadString<CreateFunc>(@"
local function payload(transform, param1)
    transform:Rotate(param1);
end

return payload;
");
        var func = create();
        var obj = new GameObject().transform;
        var eulers = new Vector3(1f, 2f, 3f);
        for (int i = 0; i < count; i++)
        {
            func(obj, eulers);
        }
        var result = obj.rotation;
        UnityEngine.Object.DestroyImmediate(obj.gameObject);

        return result;
    }
}
