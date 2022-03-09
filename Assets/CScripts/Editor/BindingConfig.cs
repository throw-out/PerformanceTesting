using System;
using System.Collections.Generic;
using System.Linq;
using XLua;

[Puerts.Configure]
public static class XLuaConfig
{
    [Puerts.Binding]
    [XLua.LuaCallCSharp]
    [XLua.CSharpCallLua]
    static IEnumerable<Type> DynamicBindings
    {
        get
        {
            return from assembly in AppDomain.CurrentDomain.GetAssemblies()
                   from type in assembly.GetExportedTypes()
                   where typeof(IExecute).IsAssignableFrom(type) && type.IsDefined(typeof(TestAttribute), false)
                   orderby (type.GetCustomAttributes(typeof(TestAttribute), false).FirstOrDefault() as TestAttribute).priority descending
                   select type;
        }
    }
}