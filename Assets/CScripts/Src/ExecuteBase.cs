using System;
using Puerts;
using UnityEngine;
using XLua;

public abstract class ExecuteBase
{
    public abstract bool Static { get; }
    public abstract string Method { get; }
    public abstract ExecuteTarget Target { get; }

    protected abstract Delegate GetCSharpFunction(int count);
    protected abstract Delegate GetLuaFunction(LuaEnv env, int count);
    protected abstract Delegate GetLuaFunction(ScriptEnv env, int count);
    protected abstract Delegate GetJsFunction(ScriptEnv env, int count);
    protected abstract object Invoke(Delegate workload, int count);

    private int count;
    private Delegate workload;

    /// <summary>
    /// 设置虚拟机GC开启或关闭
    /// </summary>
    public virtual void SetGarbageCollect(ExecuteSettings settings, ExecuteMode mode, bool enabled)
    {
        switch (mode)
        {
            case ExecuteMode.CSharp:
                // do nothing
                break;
            case ExecuteMode.XLua:
                {
                    string code = enabled ? "collectgarbage('restart');collectgarbage('collect');" : "collectgarbage('stop');";
                    settings.e.xlua.DoString(code);
                }
                break;
            case ExecuteMode.PuertsWithV8:
                //not implemented interface
                break;
            case ExecuteMode.PuertsWithQuickjs:
                //not implemented interface
                break;
            case ExecuteMode.PuertsWithLua:
                {
                    string code = enabled ? "collectgarbage('restart');collectgarbage('collect');" : "collectgarbage('stop');";
                    settings.e.puertsLua.Eval(code);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(mode), mode, "unsupport mode");
                //break;
        }
    }

    /// <summary>
    /// 初始化环境
    /// </summary>
    public virtual void Init(ExecuteSettings settings, ExecuteMode mode, int count)
    {
        this.count = count;
        switch (mode)
        {
            case ExecuteMode.CSharp:
                workload = GetCSharpFunction(count);
                break;
            case ExecuteMode.XLua:
                workload = GetLuaFunction(settings.e.xlua, count);
                break;
            case ExecuteMode.PuertsWithV8:
                workload = GetJsFunction(settings.e.puertsV8, count);
                break;
            case ExecuteMode.PuertsWithQuickjs:
                workload = GetJsFunction(settings.e.puertsQuickjs, count);
                break;
            case ExecuteMode.PuertsWithLua:
                workload = GetLuaFunction(settings.e.puertsLua, count);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(mode), mode, "unsupport mode");
                //break;
        }
    }
    /// <summary>
    /// 执行测试
    /// </summary>
    public virtual object Run(ExecuteSettings settings, ExecuteMode mode)
    {
        return Invoke(workload, count);
    }
    /// <summary>
    /// 清理环境
    /// </summary>
    public virtual void Clear()
    {
        count = 0;
        workload = null;
    }

    [CSharpCallLua]
    public delegate Action Action_Creator();

    [CSharpCallLua]
    public delegate float ReturnFloat();
    [CSharpCallLua]
    public delegate ReturnFloat ReturnFloat_Creator();


    [CSharpCallLua]
    public delegate Quaternion ReturnQuaternion();
    [CSharpCallLua]
    public delegate ReturnQuaternion ReturnQuaternion_Creator();


    [CSharpCallLua]
    public delegate void ParamsInt(int p1);
    [CSharpCallLua]
    public delegate ParamsInt ParamsInt_Creator();

    [CSharpCallLua]
    public delegate void ParamsIntIntFloat(int p1, int p2, float p3);
    [CSharpCallLua]
    public delegate ParamsIntIntFloat ParamsIntIntFloat_Creator();

    [CSharpCallLua]
    public delegate float ParamsIntIntFloat_ReturnFloat(int p1, int p2, float p3);
    [CSharpCallLua]
    public delegate ParamsIntIntFloat_ReturnFloat ParamsIntIntFloat_ReturnFloat_Creator();

    [CSharpCallLua]
    public delegate void ParamsTransform(Transform transform);
    [CSharpCallLua]
    public delegate ParamsTransform ParamsTransform_Creator();


    [CSharpCallLua]
    public delegate void ParamsTransformFloatFloatFloat(Transform p1, float p2, float p3, float p4);
    [CSharpCallLua]
    public delegate ParamsTransformFloatFloatFloat ParamsTransformFloatFloatFloat_Creator();

    [CSharpCallLua]
    public delegate void ParamsTransformVector3(Transform p1, Vector3 p2);
    [CSharpCallLua]
    public delegate ParamsTransformVector3 ParamsTransformVector3_Creator();
}