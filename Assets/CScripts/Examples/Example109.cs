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
[TestChart(100)]
public class Example109 : ExecuteBase
{
    private const string LuaFunctionTemplate = @"
local function workload(transform, param1)
    transform:Rotate(param1);
end
return workload;
";
    private const string JsFunctionTemplate = @"
function workload(transform, param1) {{
    transform.Rotate(param1); 
}}
workload;
";

    public override bool Static => true;
    public override string Method => "workload(Transform,Vector3): void;";
    public override ExecuteTarget Target => ExecuteTarget.CSCallScript;


    protected override Delegate GetCSharpFunction(int count)
    {
        throw new NotImplementedException();
    }

    protected override Delegate GetLuaFunction(LuaEnv env, int count)
    {
        var creator = env.LoadString<ParamsTransformVector3_Creator>(LuaFunctionTemplate);
        return creator();
    }

    protected override Delegate GetLuaFunction(ScriptEnv env, int count)
    {
        return env.Eval<ParamsTransformVector3>(LuaFunctionTemplate);
    }

    protected override Delegate GetJsFunction(ScriptEnv env, int count)
    {
        return env.Eval<ParamsTransformVector3>(JsFunctionTemplate);
    }

    protected override object Invoke(Delegate workload, int count)
    {
        var func = (ParamsTransformVector3)workload;
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
