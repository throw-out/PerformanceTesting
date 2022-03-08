using Puerts;
using XLua;

public interface IExecute
{
    string Name { get; }
    void RunCS(int num);
    void RunJS(JsEnv env, int num);
    void RunLua(LuaEnv env, int num);
}