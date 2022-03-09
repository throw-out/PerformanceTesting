using Puerts;
using XLua;

public interface IExecute
{
    bool Static { get; }
    string Method { get; }
    CallTarget Target { get; }
    object RunCS(int count);
    object RunJS(JsEnv env, int count);
    object RunLua(LuaEnv env, int count);
}