using Puerts;
using UnityEngine;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   调用Transform.Rotate
/// 参数:   无
/// 返回值: 无
/// </summary>
[Tests]
public class Example7 : IExecute
{
    public string Method => "static void Payload();";

    public object RunCS(int count)
    {
        var obj = new GameObject().transform;
        for (var i = 0; i < count; i++)
        {
            Example7.Payload(obj, i % 3f, i % 4f, i % 5f);
        }
        var result = obj.rotation;
        Object.Destroy(obj.gameObject);
        
        return result;
    }
    public object RunJS(JsEnv env, int count)
    {
        var result = env.Eval<Quaternion>(string.Format(
 @"
var Example = require('csharp').Example7;

var obj = new (require('csharp').UnityEngine.GameObject)().transform;
for(let i = 0; i < {0}; i++){{
    Example.Payload(obj, i % 3, i % 4, i % 5);
}}
var result = obj.rotation;
require('csharp').UnityEngine.Object.Destroy(obj.gameObject);

result;
", count));
        return result;
    }
    public object RunLua(LuaEnv env, int count)
    {
        var result = env.DoString(string.Format(
@"
local Example = CS.Example7;

local obj = CS.UnityEngine.GameObject().transform;
for i = 0,{0} do
    Example.Payload(obj, i % 3, i % 4, i % 5);
end
local result = obj.rotation;
CS.UnityEngine.Object.Destroy(obj.gameObject);

return result;
", count - 1));

        return result != null && result.Length > 0 ? result[0] : null;
    }

    public static void Payload(Transform transform, float x, float y, float z)
    {
        transform.Rotate(x, y, z);
    }
}
