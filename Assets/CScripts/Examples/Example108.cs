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
public class Example108 : ExecuteBase100
{
    [CSharpCallLua]
    public delegate void TargetFunc(Transform transform, float param1, float param2, float param3);
    [CSharpCallLua]
    public delegate TargetFunc CreateFunc();

    public override bool Static => true;
    public override string Method => "payload(Transform,float,float,float): void;";
    public override ExecuteTarget Target => ExecuteTarget.CSCallScript;

    public override object RunCSharp(int count)
    {
        throw new System.NotImplementedException();
    }

    public override Delegate GetJsFunction(ScriptEnv env)
    {
        var func = env.Eval<TargetFunc>(@"
function payload(transform, param1, param2, param3){
    transform.Rotate(param1, param2, param3);
}

payload;
");
        return func;
    }
    public override Delegate GetLuaFunction(ScriptEnv env)
    {
        var func = env.Eval<TargetFunc>(@"
local function payload(transform, param1, param2, param3)
    transform:Rotate(param1, param2, param3);
end

return payload;
");
        return func;
    }
    public override Delegate GetLuaFunction(LuaEnv env)
    {
        var create = env.LoadString<CreateFunc>(@"
local function payload(transform, param1, param2, param3)
    transform:Rotate(param1, param2, param3);
end

return payload;
");
        return create();
    }
    public override object Invoke(Delegate func, int count)
    {
        var _func = (TargetFunc)func;
        var obj = new GameObject().transform;
        for (int i = 0; i < count; i++)
        {
            _func(obj, i % 3f, i % 4f, i % 5f);
        }
        var result = obj.rotation;
        UnityEngine.Object.DestroyImmediate(obj.gameObject);

        return result;
    }
}
