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
[TestChart(100)]
public class Example108 : ExecuteBase
{
    private const string LuaFunctionTemplate = @"
local function workload(transform, param1, param2, param3)
    transform:Rotate(param1, param2, param3);
end
return workload;
";
    private const string JsFunctionTemplate = @"
function workload(transform, param1, param2, param3) {{
    transform.Rotate(param1, param2, param3);
}}
workload;
";

    public override bool Static => true;
    public override string Method => "workload(Transform,float,float,float): void;";
    public override ExecuteTarget Target => ExecuteTarget.CSCallScript;

    protected override Delegate GetCSharpFunction(int count)
    {
        throw new NotImplementedException();
    }

    protected override Delegate GetLuaFunction(LuaEnv env, int count)
    {
        var creator = env.LoadString<ParamsTransformFloatFloatFloat_Creator>(LuaFunctionTemplate);
        return creator();
    }

    protected override Delegate GetLuaFunction(ScriptEnv env, int count)
    {
        return env.Eval<ParamsTransformFloatFloatFloat>(LuaFunctionTemplate);
    }

    protected override Delegate GetJsFunction(ScriptEnv env, int count)
    {
        return env.Eval<ParamsTransformFloatFloatFloat>(JsFunctionTemplate);
    }

    protected override object Invoke(Delegate workload, int count)
    {
        var func = (ParamsTransformFloatFloatFloat)workload;
        var obj = new GameObject().transform;
        for (int i = 0; i < count; i++)
        {
            func(obj, i % 3f, i % 4f, i % 5f);
        }
        var result = obj.rotation;
        UnityEngine.Object.DestroyImmediate(obj.gameObject);

        return result;
    }
}
