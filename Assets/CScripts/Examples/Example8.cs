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
public class Example8 : IExecute
{
    public string Method => "static float Payload();";

    public object RunCS(int count)
    {
        for (var i = 0; i < count; i++)
        {
            Example8.Payload();
        }
        return null;
    }
    public object RunJS(JsEnv env, int count)
    {
        env.Eval(string.Format(
@"
var Example = require('csharp').Example8;
for(let i = 0; i < {0}; i++){{
    Example.Payload();
}}
", count));
        return null;
    }
    public object RunLua(LuaEnv env, int count)
    {
        env.DoString(string.Format(
@"
local Example = CS.Example8;
for i = 0,{0} do
    Example.Payload();
end
", count - 1));

        return null;
    }


    private static GameObject _gameObject;
    private static GameObject gameObject
    {
        get
        {
            if (_gameObject == null)
            {
                _gameObject = new GameObject(nameof(Example8));
            }
            return _gameObject;
        }
    }
    public static void Payload()
    {
        gameObject.transform.Rotate(1, 1, 1);
    }
}
