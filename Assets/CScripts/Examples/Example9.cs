using Puerts;
using UnityEngine;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   调用Transform.Rotate
/// 参数:   1引用类型, 1个值类型(Vector3)
/// 返回值: UnityEngine.Quaternion
/// </summary>
[Test]
[TestGroup("xyz vs Vector3")]
public class Example9 : IExecute
{
    public bool Static => true;
    public string Method => "Quaternion Payload(Transform, Vector3);";

    public object RunCS(int count)
    {
        var obj = new GameObject().transform;
        var eulers = new Vector3(1f, 2f, 3f);
        for (var i = 0; i < count; i++)
        {
            Example9.Payload(obj, eulers);
        }
        var result = obj.rotation;
        Object.Destroy(obj.gameObject);

        return result;
    }
    public object RunJS(JsEnv env, int count)
    {
        var result = env.Eval<Quaternion>(string.Format(
 @"
var Example = require('csharp').Example9;

var obj = new (require('csharp').UnityEngine.GameObject)().transform;
var eulers = new (require('csharp').UnityEngine.Vector3)(1, 2, 3);
for(let i = 0; i < {0}; i++){{
    Example.Payload(obj, eulers);
}}
var result = obj.rotation;
require('csharp').UnityEngine.Object.Destroy(obj.gameObject);

result;
", count));
        return result;
    }
    public object RunLua(LuaEnv env, int count)
    {
        object[] result = env.DoString(string.Format(
@"
local Example = CS.Example9;

local obj = CS.UnityEngine.GameObject().transform;
local eulers = CS.UnityEngine.Vector3(1, 2, 3);
for i = 0,{0} do
    Example.Payload(obj, eulers);
end
local result = obj.rotation;
CS.UnityEngine.Object.Destroy(obj.gameObject);

return result;
", count - 1));

        return result != null && result.Length > 0 ? result[0] : null;
    }

    public static void Payload(Transform transform, Vector3 eulers)
    {
        transform.Rotate(eulers);
    }
}
