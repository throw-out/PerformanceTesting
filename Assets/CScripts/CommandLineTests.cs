using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEditor;

public class CommandLineTests
{
    [MenuItem(("PerformanceTest/Gen Code"))]
    public static void GenCode()
    {
        {
            const string typeName = "CSObjectWrapEditor.Generator";
            var type = (from _assembly in AppDomain.CurrentDomain.GetAssemblies()
                let _type = _assembly.GetType(typeName, false)
                where _type != null
                select _type).FirstOrDefault();
            if (type != null)
            {
                type.GetMethod("GenAll").Invoke(null, new object[] {});
            }
        }
        { // old puerts
            const string typeName = "Puerts.Editor.Generator.Menu";
            var type = (from _assembly in AppDomain.CurrentDomain.GetAssemblies()
                let _type = _assembly.GetType(typeName, false)
                where _type != null
                select _type).FirstOrDefault();
            if (type != null)
            {
                type.GetMethod("GenerateCode").Invoke(null, new object[] {});
            }
        }
        { // new puerts
            const string typeName = "Puerts.Editor.Generator.UnityMenu";
            var type = (from _assembly in AppDomain.CurrentDomain.GetAssemblies()
                let _type = _assembly.GetType(typeName, false)
                where _type != null
                select _type).FirstOrDefault();
            if (type != null)
            {
                type.GetMethod("GenerateCode").Invoke(null, new object[] {});
            }
        }
        {
            const string typeName = "Puerts.Editor.GeneratorUsing";
            var type = (from _assembly in AppDomain.CurrentDomain.GetAssemblies()
                let _type = _assembly.GetType(typeName, false)
                where _type != null
                select _type).FirstOrDefault();
            if (type != null)
            {
                type.GetMethod("GenerateUsingCode").Invoke(null, new object[] {});
            }
        }
    }

    [MenuItem("PerformanceTest/run Test")]
    public static void RunTest()
    {
        Tester tester = new Tester(
            new int[] { 10000, 100000 },
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            Path.Combine(Application.dataPath, "../STATES.md")
#else
            Path.Combine(Application.persistentDataPath, "./STATES.md")
#endif
        );
        tester.OnInfoUpdate += (string info) => UnityEngine.Debug.Log(info);

        IEnumerator enumerator = tester.StartTest();

        while (enumerator.MoveNext()) { }
    }
}