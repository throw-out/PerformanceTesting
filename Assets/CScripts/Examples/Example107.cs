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
[TestChart(100)]
public class Example107 : ExecuteBase
{
    private const string LuaFunctionTemplate = @"
local function workload(transform)
    transform:Rotate(1, 1, 1);
end
return workload;
";
    private const string JsFunctionTemplate = @"
function workload(transform) {{
    transform.Rotate(1, 1, 1);
}}
workload;
";
    public override bool Static => true;
    public override string Method => "workload(Transform): void;";
    public override ExecuteTarget Target => ExecuteTarget.CSCallScript;

    protected override Delegate GetCSharpFunction(int count)
    {
        throw new NotImplementedException();
    }

    protected override Delegate GetLuaFunction(LuaEnv env, int count)
    {
        var creator = env.LoadString<ParamsTransform_Creator>(LuaFunctionTemplate);
        return creator();
    }

    protected override Delegate GetLuaFunction(ScriptEnv env, int count)
    {
        return env.Eval<ParamsTransform>(LuaFunctionTemplate);
    }

    protected override Delegate GetJsFunction(ScriptEnv env, int count)
    {
        return env.Eval<ParamsTransform>(JsFunctionTemplate);
    }
    protected override object Invoke(Delegate workload, int count)
    {
        var func = (ParamsTransform)workload;
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
