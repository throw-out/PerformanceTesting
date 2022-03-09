using System;
using System.Collections.Generic;
using XLua;

public static class XLuaConfig
{
    [LuaCallCSharp]
    [CSharpCallLua]
    static IEnumerable<Type> DynamicBindings = new List<Type>()
    {
        //typeof(Example103.TargetFunc),
        //typeof(Example103.CreateFunc)
    };
}