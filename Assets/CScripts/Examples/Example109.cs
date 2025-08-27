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
public class Example109 : ExecuteBase100
{
    [CSharpCallLua]
    public delegate void TargetFunc(Transform transform, Vector3 param1);
    [CSharpCallLua]
    public delegate TargetFunc CreateFunc();

    public override bool Static => true;
    public override string Method => "payload(Transform,Vector3): void;";
    public override ExecuteTarget Target => ExecuteTarget.CSCallScript;

    public override object RunCSharp(int count)
    {
        throw new System.NotImplementedException();
    }

    public override Delegate GetJsFunction(ScriptEnv env)
    {
        var func = env.Eval<TargetFunc>(@"
function payload(transform, param1){
    transform.Rotate(param1);
}

payload;
");
        return func;
    }
    public override Delegate GetLuaFunction(ScriptEnv env)
    {
        var func = env.Eval<TargetFunc>(@"
local function payload(transform, param1)
    transform:Rotate(param1);
end

return payload;
");
        return func; 
    }
    public override Delegate GetLuaFunction(LuaEnv env)
    {
        var create = env.LoadString<CreateFunc>(@"
local function payload(transform, param1)
    transform:Rotate(param1);
end

return payload;
");
        return create(); ;
    }

    public override object Invoke(Delegate func, int count)
    {
        var _func = (TargetFunc)func;
        var obj = new GameObject().transform;
        var eulers = new Vector3(1f, 2f, 3f);
        for (int i = 0; i < count; i++)
        {
            _func(obj, eulers);
        }
        var result = obj.rotation;
        UnityEngine.Object.DestroyImmediate(obj.gameObject);

        return result;
    }
}
