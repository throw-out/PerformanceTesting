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

    [Tooltip("测试执行次数")]
    public int[] repeatTimes;

    public Text m_ContentText;
    public Button m_StartBtn;
    public Button m_StopBtn;
    public Toggle m_CheckMemoryTog;
    public Toggle m_ExclusiveTog;
    public Toggle m_AutoGCTog;
    public Toggle m_PrepareTog;
    public InputField m_DebounceInput;
    public InputField m_SaveDirectoryInput;

    public Toggle m_SaveTimestampFileTog;
    public Toggle m_SaveChartFileTog;

    public Slider m_ProgressSlider;

    protected Tester tester;

    protected Selectable[] _settingComponents;
    protected Selectable[] SettingComponents
    {
        get
        {
            if (_settingComponents == null)
            {
                _settingComponents = new Selectable[]
                {
                    m_CheckMemoryTog, m_ExclusiveTog, m_AutoGCTog, m_PrepareTog, m_DebounceInput,
                    m_SaveDirectoryInput, m_SaveTimestampFileTog, m_SaveChartFileTog
                };
            }
            return _settingComponents;
        }
    }

    private StringBuilder MockConsole;

    private void Awake()
    {
        string outputPath;
#if UNITY_EDITOR
        outputPath = Path.Combine(Path.GetDirectoryName(Application.dataPath), "States");
#elif UNITY_STANDALONE_WIN
        outputPath = Application.dataPath;
#else
        outputPath = Application.persistentDataPath;
#endif

        tester = new Tester(repeatTimes, outputPath);
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
        foreach (var component in SettingComponents)
        {
            if (component == null)
                continue;
            component.interactable = !isRunning;
        }
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

        int.TryParse(m_DebounceInput.text, out int debounce);
        var settings = new ExecuteSettings()
        {
            CheckMemory = m_CheckMemoryTog.isOn,
            Exclusive = m_ExclusiveTog.isOn,
            AutoGC = m_AutoGCTog.isOn,
            Prepare = m_PrepareTog.isOn,
            Debounce = debounce,
            SaveDirectory = m_SaveDirectoryInput.text,
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
