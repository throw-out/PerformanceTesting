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

    protected Tester tester;

    private StringBuilder MockConsole;

    private void Awake()
    {
        
        tester = new Tester(
            repeatTimePerSuite,
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            Path.Combine(Application.dataPath, "../STATES.md")
#else
            Path.Combine(Application.persistentDataPath, "./STATES.md")
#endif
        );
        tester.OnInfoUpdate += (string newInfo) =>
        {
            MockConsole.Append(newInfo);
            Render(MockConsole.ToString());
        };
        this.InitListeners();
    }
    private void Update()
    {
        tester.Tick();
    }

    private void Start()
    {
        Render(null);
        MockConsole = new StringBuilder();
        if (autoStart) StartTest();
    }

    private void Render(string testInfo)
    {
        var testing = tester.IsTesting();
        this.m_StartBtn.interactable = !testing;
        this.m_StopBtn.interactable = testing;
        this.m_ContentText.text = testInfo != null ? testInfo.ToString() : string.Empty;
    }
    private void InitListeners()
    {
        this.m_StartBtn.onClick.AddListener(StartTest);
        this.m_StopBtn.onClick.AddListener(StopTest);
    }

    private void StartTest()
    {
        if (tester.IsTesting()) return;
        StartCoroutine(tester.StartTest());
    }
    private void StopTest()
    {
        if (!tester.IsTesting()) return;
        tester.StopTest();
        StopAllCoroutines();
    }
}
