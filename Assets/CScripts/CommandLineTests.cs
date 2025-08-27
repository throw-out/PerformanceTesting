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
                type.GetMethod("GenAll").Invoke(null, new object[] { });
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
        tester.OnLogInfo += (string info) => UnityEngine.Debug.Log(info);

        IEnumerator enumerator = tester.StartTest(ExecuteSettings.Default);

        while (enumerator.MoveNext()) { }
    }
}