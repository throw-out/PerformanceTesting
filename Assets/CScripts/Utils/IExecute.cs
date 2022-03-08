using Puerts;
using XLua;

public interface IExecute
{
    string Method { get; }
    object RunCS(int count);
    object RunJS(JsEnv env, int count);
    object RunLua(LuaEnv env, int count);
}