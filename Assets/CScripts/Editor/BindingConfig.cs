using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            var exampleTypes = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                               where !(assembly.ManifestModule is System.Reflection.Emit.ModuleBuilder)
                               from type in assembly.GetExportedTypes()
                               where typeof(IExecute).IsAssignableFrom(type) && type.IsDefined(typeof(TestAttribute), false)
                               orderby (type.GetCustomAttributes(typeof(TestAttribute), false).FirstOrDefault() as TestAttribute).priority descending
                               select type;

            string[] customAssemblys = new string[] {
                "Assembly-CSharp",
            };
            var delegateTypes = (from assembly in customAssemblys.Select(s => Assembly.Load(s))
                                 where !(assembly.ManifestModule is System.Reflection.Emit.ModuleBuilder)
                                 from type in assembly.GetExportedTypes()
                                 where typeof(Delegate).IsAssignableFrom(type) &&
                                    type != typeof(Puerts.JsEnv.JsEnvCreateCallback) &&
                                    type != typeof(Puerts.JsEnv.JsEnvDisposeCallback)
                                 select type);

            return exampleTypes
                .Concat(delegateTypes)
                .Distinct();
        }
    }
}