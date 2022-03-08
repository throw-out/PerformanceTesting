using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Puerts;
using UnityEngine;
using UnityEngine.UI;
using XLua;

public class GUITests : MonoBehaviour
{
    public bool autoStart = true;
    public int[] callCounts;

    public Text m_ContentText;
    public Button m_StartBtn;
    public Button m_StopBtn;

    private JsEnv jsEnv;
    private LuaEnv luaEnv;

    private bool testing;
    private StringBuilder testingInfo;

    private void Awake()
    {
        jsEnv = new JsEnv();
        luaEnv = new LuaEnv();
        testing = false;
        testingInfo = null;

        this.InitListeners();
    }
    private void OnDestroy()
    {
        jsEnv.Dispose();
        luaEnv.Dispose();
        jsEnv = null;
        luaEnv = null;
        testing = false;
        testingInfo = null;
    }
    private void Start()
    {
        Render();
        if (autoStart) StartTest();
    }

    private void Render()
    {
        this.m_StartBtn.interactable = !testing;
        this.m_StopBtn.interactable = testing;
        this.m_ContentText.text = testingInfo != null ? testingInfo.ToString() : string.Empty;
    }
    private void InitListeners()
    {
        this.m_StartBtn.onClick.AddListener(StartTest);
        this.m_StopBtn.onClick.AddListener(StopTest);
    }

    private void StartTest()
    {
        if (testing) return;
        testing = true;
        testingInfo = new StringBuilder();
        StartCoroutine(ExecuteTesting());
        Render();
    }
    private void StopTest()
    {
        if (!testing) return;
        testing = false;
        StopAllCoroutines();
        Render();
    }

    private IEnumerator ExecuteTesting()
    {
        IExecute[] executes = ExecuteUtil.GetExecutes();
        if (executes == null || executes.Length == 0)
        {
            testingInfo.AppendLine();
            testingInfo.Append("test instance not found");
            Render();
            yield break;
        }

        Timer totalDuration = new Timer();

        testingInfo.Append("\nstart test: instance = ");
        testingInfo.Append(executes.Length);
        Render();
        yield return null;

        List<ExecuteStates> statesList = new List<ExecuteStates>();
        foreach (IExecute execute in executes)
        {
            for (int i = 0; i < callCounts.Length; i++)
            {
                int count = callCounts[i];
                if (count <= 0)
                    continue;

                ExecuteState csInvoke = ExecuteUtil.InvokeCS(execute, count);
                testingInfo.AppendFormat("\n{0} | method = {1}, count={2}, cs invoke = {3}",
                    execute.GetType().FullName,
                    execute.Method,
                    count,
                    csInvoke.Duration >= 0 ? (csInvoke.Duration.ToString("f1") + "ms") : "fail"
                );
                Render();
                yield return null;

                ExecuteState jsInvoke = ExecuteUtil.InvokeJs(jsEnv, execute, count);
                testingInfo.AppendFormat("\n{0} | method = {1}, count={2}, js invoke = {3}",
                    execute.GetType().FullName,
                    execute.Method,
                    count,
                    jsInvoke.Duration >= 0 ? (jsInvoke.Duration.ToString("f1") + "ms") : "fail"
                );
                Render();
                yield return null;

                ExecuteState luaInvoke = ExecuteUtil.InvokeLua(luaEnv, execute, count);
                testingInfo.AppendFormat("\n{0} | method = {1}, count={2}, lua invoke = {3}",
                    execute.GetType().FullName,
                    execute.Method,
                    count,
                    luaInvoke.Duration >= 0 ? (luaInvoke.Duration.ToString("f1") + "ms") : "fail"
                );
                Render();
                yield return null;

                statesList.Add(new ExecuteStates()
                {
                    Type = execute.GetType(),
                    Method = execute.Method,
                    Static = execute.Static,
                    Count = count,
                    CsInvoke = csInvoke,
                    JsInvoke = jsInvoke,
                    LuaInvoke = luaInvoke
                });
            }
        }

        string statesFilePath = Path.Combine(Application.dataPath, "../STATES.md");
        File.WriteAllText(statesFilePath, MarkdownUtil.Generate(statesList));

        testingInfo.AppendFormat("\n\ntest completed! total duration = {0}ms", totalDuration.End().ToString("f1"));
        Render();
    }
}
