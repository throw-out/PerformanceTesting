using Puerts;
using UnityEngine;
using XLua;

/// <summary>
/// 静态方法调用
/// 逻辑:   调用Transform.Rotate
/// 参数:   1引用类型
/// 返回值: UnityEngine.Quaternion
/// </summary>
[Test]
public class Example7 : ExecuteBase1
{
    public override bool Static => true;
    public override string Method => "Quaternion Payload(Transform);";
    public override ExecuteTarget Target => ExecuteTarget.ScriptCallCS;

    public override object RunCSharp(int count)
    {
        var obj = new GameObject().transform;
        for (var i = 0; i < count; i++)
        {
            Example7.Payload(obj);
        }
        var result = obj.rotation;
        Object.DestroyImmediate(obj.gameObject);

        return result;
    }
    public override string GetJsCode(int count)
    {
        return string.Format(
@"(function() {{
    var Example = CS.Example7;

    var obj = new CS.UnityEngine.GameObject().transform;
    for(let i = 0; i < {0}; i++){{
        Example.Payload(obj);
    }}
    var result = obj.rotation;
    CS.UnityEngine.Object.DestroyImmediate(obj.gameObject);

    return result;
}})()", count);
    }
    public override string GetLuaCode(int count)
    {
        return string.Format(
@"
return (function()
    local CS = CS or require('csharp');
    local Example = CS.Example7;

    local obj = CS.UnityEngine.GameObject().transform;
    for i = 0,{0} do
        Example.Payload(obj);
    end
    local result = obj.rotation;
    CS.UnityEngine.Object.DestroyImmediate(obj.gameObject);

    return result;
end)();
", count - 1);
    }

    public static void Payload(Transform transform)
    {
        transform.Rotate(1, 1, 1);
    }
}
