using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking;

public static class ChartUtil
{
    public static void Generate(IEnumerable<ExecuteStates> states, Action<int, byte[]> saveData = null)
    {
        Generate(states, saveData);
    }
    public static void Generate(IEnumerable<ExecuteStates> states, Action<int, string> request = null, Action<int, byte[]> response = null, Action completed = null)
    {
        static string GetTitle(IEnumerable<ExecuteStates> states)
        {
            foreach (var state in states)
            {
                var attr = state.Type.GetCustomAttribute<TestChartAttribute>();
                if (attr != null && !string.IsNullOrEmpty(attr.Title))
                {
                    return attr.Title;
                }
            }
            return null;
        }

        if (states == null || !states.Any())
            return;
        int count = states.Select(s => s.Count).Max();
        states = states.Where(s => s.Count == count);

        var groupStates = states
            .Where(s => s.Type.IsDefined(typeof(TestChartAttribute), false))
            .GroupBy(s => s.Type.GetCustomAttribute<TestChartAttribute>().Id)
            .ToDictionary(o => o.Key, o => o.Cast<ExecuteStates>().ToList());
        var groupsDatas = groupStates
            .Select(group => new
            {
                id = group.Key,
                title = GetTitle(group.Value),
                states = group.Value
            })
            .ToList();

        if (response != null)
        {
            DownloadTextureList(groupsDatas,
                (data) =>
                {
                    request?.Invoke(data.id, data.title);
                    string url = "https://quickchart.io/chart";
                    string postData = JsonUtility.ToJson(new QuickChart.ChartQuery()
                    {
                        devicePixelRatio = 1f,
                        chart = QuickChart.ChartConfiguration.From(data.states)
                    });
                    return (url, postData);
                },
                (data, buffer) =>
                {
                    response?.Invoke(data.id, buffer);
                },
                completed
            );
        }
        else
        {
            // foreach (var data in groupsDatas)
            // {
            //     request?.Invoke(data.id, data.title);
            // }
            completed?.Invoke();
        }
    }

    private static string FormatQuickChartURL(IEnumerable<ExecuteStates> states)
    {
        static double GetDuration(ExecuteStates state, string key, double defaultValue = 0)
        {
            double duration = state.Results != null && state.Results.TryGetValue(key, out var data) ? data.Duration : -1;
            if (duration < 0)
                return defaultValue;
            return duration;
        }

        //获取key
        string[] keys = states.FirstOrDefault(s => s.Results != null && s.Results.Count > 0).Results?.Keys?.ToArray();
        if (keys == null || keys.Length == 0)
            return null;

        //double maxDuration = states.SelectMany(s => s.Results?.Values.Select(v => v.Duration)).Max();
        string query = JsonUtility.ToJson(new ChartConfiguration()
        {
            type = "bar",
            data = new ChartTemplates()
            {
                labels = states.Select(s => s.Type.Name).ToArray(),
                datasets = keys.Select(k => new ChartDataSet()
                {
                    label = k,
                    data = states.Select(s => GetDuration(s, k)).ToArray()
                }).ToArray()
            }
        });
        return "https://quickchart.io/chart?c=" + UnityEngine.Networking.UnityWebRequest.EscapeURL(query);
    }

    private static void DownloadTextureList<T>(List<T> list, Func<T, (string url, string postData)> request, Action<T, byte[]> response, Action completed)
    {
        if (list.Count == 0)
        {
            completed?.Invoke();
            return;
        }

        var first = list[0];
        list.RemoveAt(0);
        var (url, postData) = request?.Invoke(first) ?? default;
        if (string.IsNullOrEmpty(url))
        {
            DownloadTextureList(list, request, response, completed);
            return;
        }

        if (!string.IsNullOrEmpty(postData))
        {
            DownloadTexture(url, postData, (d) =>
            {
                response?.Invoke(first, d);
                DownloadTextureList(list, request, response, completed);
            });
        }
        else
        {
            DownloadTexture(url, (d) =>
            {
                response?.Invoke(first, d);
                DownloadTextureList(list, request, response, completed);
            });
        }
    }
    private static void DownloadTexture(string url, Action<byte[]> callback)
    {
        var handler = new DownloadHandlerTexture();
        var request = UnityWebRequest.Get(url);
        request.timeout = 30;
        request.downloadHandler = handler;

        var operation = request.SendWebRequest();
        operation.completed += (op) =>
        {
            if (request.result == UnityWebRequest.Result.ConnectionError || !string.IsNullOrEmpty(request.error))
            {
                Debug.LogError(request.error);
                callback(null);
            }
            else
            {
                callback(handler.texture != null ? handler.texture.EncodeToPNG() : null);
            }
        };
    }
    private static void DownloadTexture(string url, string postData, Action<byte[]> callback)
    {
        var handler = new DownloadHandlerTexture();
        var request = UnityWebRequest.Post(url, postData);
        request.timeout = 30;
        request.downloadHandler = handler;
        request.SetRequestHeader("Content-Type", "application/json");

        var operation = request.SendWebRequest();
        operation.completed += (op) =>
        {
            if (request.result == UnityWebRequest.Result.ConnectionError || !string.IsNullOrEmpty(request.error))
            {
                Debug.LogError(request.error);
                callback(null);
            }
            else
            {
                callback(handler.texture != null ? handler.texture.EncodeToPNG() : null);
            }
        };
    }


    [System.Serializable]
    private struct QuickChartQuery111
    {
        public int? width;  //图像宽度（以像素为单位）。默认为 500
        public int? height; //图像高度（以像素为单位）。默认为 300
        public float? devicePixelRatio;   //设备像素比（DPR）。默认为 2
        public string backgroundColor;  //RGB、HEX、HSL 或颜色名称。默认为透明
        public string format;   //PNG、WEBP、SVG 或 PDF。默认为 png
        public string key;   //API key (optional)
        public ChartConfiguration chart;
    }

    [System.Serializable]
    private struct ChartConfiguration
    {
        public string type; //bar:柱状图, line:折线图, pie:饼图
        public ChartTemplates data;
    }
    [System.Serializable]
    private struct ChartTemplates
    {
        public string title; //图表标题
        public string[] labels;
        public ChartDataSet[] datasets;
    }
    [System.Serializable]
    private struct ChartDataSet
    {
        public string type; //bar:柱状图, line:折线图
        public string label;
        public double[] data;
    }
}

namespace QuickChart
{
    [System.Serializable]
    public class ChartQuery
    {
        public int? width;  //图像宽度（以像素为单位）。默认为 500
        public int? height; //图像高度（以像素为单位）。默认为 300
        public float? devicePixelRatio;   //设备像素比（DPR）。默认为 2
        public string backgroundColor;  //RGB、HEX、HSL 或颜色名称。默认为透明
        public string format;   //PNG、WEBP、SVG 或 PDF。默认为 png
        public string key;   //API key (optional)
        public ChartConfiguration chart;
    }

    [System.Serializable]
    public class ChartConfiguration
    {
        public string type; //bar:柱状图, line:折线图, pie:饼图
        public ChartTemplates data;
        public ChartOptions options;

        public static ChartConfiguration From(IEnumerable<ExecuteStates> states)
        {
            static double GetDuration(ExecuteStates state, string key, double defaultValue = 0)
            {
                double duration = state.Results != null && state.Results.TryGetValue(key, out var data) ? data.Duration : -1;
                if (duration < 0)
                    return defaultValue;
                return duration;
            }
            //获取key
            string[] keys = states.FirstOrDefault(s => s.Results != null && s.Results.Count > 0).Results?.Keys?.ToArray();
            if (keys == null || keys.Length == 0)
                return null;

            return new ChartConfiguration()
            {
                type = "bar",
                data = new ChartTemplates()
                {
                    labels = states.Select(s => s.Type.Name).ToArray(),
                    datasets = keys.Select(k => new ChartDataSet()
                    {
                        label = k,
                        data = states.Select(s => GetDuration(s, k)).ToArray()
                    }).ToArray()
                }
            };
        }
    }

    [System.Serializable]
    public class ChartTemplates
    {
        public string[] labels;
        public ChartDataSet[] datasets;
    }
    [System.Serializable]
    public class ChartDataSet
    {
        public string type; //bar:柱状图, line:折线图
        public string label;
        public double[] data;
    }

    [System.Serializable]
    public class ChartOptions
    {
        public ChartOptionsTitle title;
    }
    [System.Serializable]
    public class ChartOptionsTitle
    {
        public bool display;
        public string text;
    }
}