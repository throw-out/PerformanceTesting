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
    public Toggle m_CheckMemoryTog;
    public Toggle m_ExclusiveTog;
    public Toggle m_AutoGCTog;
    public Toggle m_Prepare;
    public InputField m_Debounce;

    public Toggle m_SaveTimestampFileTog;
    public Toggle m_SaveChartFileTog;

    public Slider m_ProgressSlider;

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
        );
        tester.OnLogger += (string newInfo) =>
        {
            MockConsole.Append(newInfo);
            Render(MockConsole.ToString());
        };
        tester.OnProgress += (index, total) =>
        {
            m_ProgressSlider.value = (float)index / total;
        };

        this.InitListeners();
    }

    private void Start()
    {
        Render(null);
        m_ProgressSlider.value = 0f;
        if (autoStart) StartTest();
    }

    private void Render(string testInfo)
    {
        var isRunning = tester.IsRunning();
        this.m_StartBtn.interactable = !isRunning;
        this.m_StopBtn.interactable = isRunning;
        this.m_ContentText.text = testInfo != null ? testInfo.ToString() : string.Empty;

        this.m_CheckMemoryTog.interactable = !isRunning;
        this.m_ExclusiveTog.interactable = !isRunning;
        this.m_AutoGCTog.interactable = !isRunning;
        this.m_Prepare.interactable = !isRunning;
        this.m_Debounce.interactable = !isRunning;
        this.m_SaveTimestampFileTog.interactable = !isRunning;
        this.m_SaveChartFileTog.interactable = !isRunning;
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

        int.TryParse(m_Debounce.text, out int debounce);
        var settings = new ExecuteSettings()
        {
            CheckMemory = m_CheckMemoryTog.isOn,
            Exclusive = m_ExclusiveTog.isOn,
            AutoGC = m_AutoGCTog.isOn,
            Prepare = m_Prepare.isOn,
            Debounce = debounce,
            SaveTimestampFile = m_SaveTimestampFileTog.isOn,
            SaveChartFile = m_SaveChartFileTog.isOn,
        };
        StartCoroutine(tester.Start(settings));
    }
    private void StopTest()
    {
        if (!tester.IsRunning()) return;
        tester.Stop();
        Render(MockConsole.ToString());
        StopAllCoroutines();
    }
}
