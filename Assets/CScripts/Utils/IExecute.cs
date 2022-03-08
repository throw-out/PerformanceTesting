using Puerts;
using XLua;

public interface IExecute
{
    string Name { get; }
    object RunCS(int num);
    object RunJS(JsEnv env, int num);
    object RunLua(LuaEnv env, int num);
}