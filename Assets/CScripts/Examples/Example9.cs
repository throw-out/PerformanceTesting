using System;
using Puerts;
using UnityEngine;
using XLua;
using Object = UnityEngine.Object;

/// <summary>
/// 静态方法调用
/// 逻辑:   调用Transform.Rotate
/// 参数:   1引用类型, 1个值类型(Vector3)
/// 返回值: UnityEngine.Quaternion
/// </summary>
[Test]
[TestGroup("xyz vs Vector3")]
[TestChart(0)]
public class Example9 : ExecuteBase
{
    private const string LuaFunctionTemplate = @"
local function workload()
    local CS = CS or require('csharp');
    local Example = CS.Example9;

    local obj = CS.UnityEngine.GameObject().transform;
    local eulers = CS.UnityEngine.Vector3(1, 2, 3);
    for i = 0,{0} do
        Example.Workload(obj, eulers);
    end
    local result = obj.rotation;
    CS.UnityEngine.Object.DestroyImmediate(obj.gameObject);

    return result;
end
return workload;
";
    private const string JsFunctionTemplate = @"
function workload() {{
    var Example = CS.Example9;

    var obj = new CS.UnityEngine.GameObject().transform;
    var eulers = new CS.UnityEngine.Vector3(1, 2, 3);
    for(let i = 0; i < {0}; i++){{
        Example.Workload(obj, eulers);
    }}
    var result = obj.rotation;
    CS.UnityEngine.Object.DestroyImmediate(obj.gameObject);

    return result;
}}
workload;
";
    public static void Workload(Transform transform, Vector3 eulers)
    {
        transform.Rotate(eulers);
    }

    public override bool Static => true;
    public override string Method => "Quaternion Workload(Transform, Vector3);";
    public override ExecuteTarget Target => ExecuteTarget.ScriptCallCS;

    protected override System.Delegate GetCSharpFunction(int count)
    {
        return new ReturnQuaternion(() =>
        {
            var obj = new GameObject().transform;
            var eulers = new Vector3(1f, 2f, 3f);
            for (var i = 0; i < count; i++)
            {
                Example9.Workload(obj, eulers);
            }
            var result = obj.rotation;
            Object.DestroyImmediate(obj.gameObject);

            return result;
        });
    }

    protected override Delegate GetLuaFunction(LuaEnv env, int count)
    {
        var creator = env.LoadString<ReturnQuaternion_Creator>(string.Format(LuaFunctionTemplate, count));
        return creator();
    }

    protected override Delegate GetLuaFunction(ScriptEnv env, int count)
    {
        return env.Eval<ReturnQuaternion>(string.Format(LuaFunctionTemplate, count));
    }

    protected override Delegate GetJsFunction(ScriptEnv env, int count)
    {
        return env.Eval<ReturnQuaternion>(string.Format(JsFunctionTemplate, count));
    }

    protected override object Invoke(Delegate workload, int count)
    {
        return ((ReturnQuaternion)workload)();
    }
}
