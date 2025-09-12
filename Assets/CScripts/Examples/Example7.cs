using System;
using Puerts;
using UnityEngine;
using XLua;
using Object = UnityEngine.Object;

/// <summary>
/// 静态方法调用
/// 逻辑:   调用Transform.Rotate
/// 参数:   1引用类型
/// 返回值: UnityEngine.Quaternion
/// </summary>
[Test]
[TestChart(0)]
public class Example7 : ExecuteBase
{
    private const string LuaFunctionTemplate = @"
local function workload()
    local CS = CS or require('csharp');
    local Example = CS.Example7;

    local obj = CS.UnityEngine.GameObject().transform;
    for i = 0,{0} do
        Example.Workload(obj);
    end
    local result = obj.rotation;
    CS.UnityEngine.Object.DestroyImmediate(obj.gameObject);

    return result;
end
return workload;
";
    private const string JsFunctionTemplate = @"
function workload() {{
    let Example = CS.Example7;

    let obj = new CS.UnityEngine.GameObject().transform;
    for(let i = 0; i < {0}; i++){{
        Example.Workload(obj);
    }}
    let result = obj.rotation;
    CS.UnityEngine.Object.DestroyImmediate(obj.gameObject);

    return result;
}}
workload;
";
    public static void Workload(Transform transform)
    {
        transform.Rotate(1, 1, 1);
    }

    public override bool Static => true;
    public override string Method => "Quaternion Workload(Transform);";
    public override ExecuteTarget Target => ExecuteTarget.ScriptCallCS;

    protected override Delegate GetCSharpFunction(int count)
    {
        return new ReturnQuaternion(() =>
        {
            var obj = new GameObject().transform;
            for (var i = 0; i < count; i++)
            {
                Example7.Workload(obj);
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
