using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Puerts;
using UnityEngine;
using UnityEngine.UI;
using XLua;

public class GUITests : MonoBehaviour
{
    public bool autoStart = true;
    public int[] repeatTimePerSuite;

    public Text m_ContentText;
    public Button m_StartBtn;
    public Button m_StopBtn;
    public Toggle m_CheckMemory;
    public Toggle m_Exclusive;
    public Toggle m_AutoGC;
    public Slider m_Progress;

    protected Tester tester;

    private StringBuilder MockConsole;

    private void Awake()
    {
        tester = new Tester(
            repeatTimePerSuite,
#if UNITY_EDITOR
            Path.GetDirectoryName(Application.dataPath)
#elif UNITY_STANDALONE_WIN
            Application.dataPath
#else
            Application.persistentDataPath
#endif
#if UNITY_EDITOR
            , false
#else
            , true
#endif
            , true
        );
        tester.OnLogInfo += (string newInfo) =>
        {
            MockConsole.Append(newInfo);
            Render(MockConsole.ToString());
        };
        tester.OnProgress += (index, total) =>
        {
            m_Progress.value = (float)index / total;
        };

        this.InitListeners();
    }

    private void Start()
    {
        Render(null);
        m_Progress.value = 0f;
        if (autoStart) StartTest();
    }

    private void Render(string testInfo)
    {
        var isRunning = tester.IsRunning();
        this.m_StartBtn.interactable = !isRunning;
        this.m_StopBtn.interactable = isRunning;
        this.m_ContentText.text = testInfo != null ? testInfo.ToString() : string.Empty;
    }
    private void InitListeners()
    {
        this.m_StartBtn.onClick.AddListener(StartTest);
        this.m_StopBtn.onClick.AddListener(StopTest);
    }

    private void StartTest()
    {
        if (tester.IsRunning())
            return;
        MockConsole = new StringBuilder();
        Render(MockConsole.ToString());
        var settings = new ExecuteSettings()
        {
            CheckMemory = m_CheckMemory.isOn,
            Exclusive = m_Exclusive.isOn,
            AutoGC = m_AutoGC.isOn,
        };
        StartCoroutine(tester.StartTest(settings));
    }
    private void StopTest()
    {
        if (!tester.IsRunning()) return;
        tester.StopTest();
        Render(MockConsole.ToString());
        StopAllCoroutines();
    }
}
