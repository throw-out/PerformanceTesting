using System.IO;
using UnityEngine;
using System.Collections;

public class CommandLineTests
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("PerformanceTest/run Test")]
#endif
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
        tester.OnLogger += (string info) => UnityEngine.Debug.Log(info);

        IEnumerator enumerator = tester.Start(ExecuteSettings.Default);

        while (enumerator.MoveNext()) { }
    }

}