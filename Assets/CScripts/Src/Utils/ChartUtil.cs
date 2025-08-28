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
    public static void Generate(IEnumerable<ExecuteStates> states, Action<int, string> request = null, Action<int, byte[]> saveData = null, Action completed = null)
    {
        if (states == null || !states.Any())
            return;
        int count = states.Select(s => s.Count).Max();
        states = states.Where(s => s.Count == count);

        var groupStates = states
            .Where(s => s.Type.GetCustomAttribute<TestChartAttribute>() != null)
            .GroupBy(s => s.Type.GetCustomAttribute<TestChartAttribute>().Id)
            .ToDictionary(o => o.Key, o => o.Cast<ExecuteStates>().ToList());
        var datas = groupStates
            .Select(group => (group.Key, FormatQuickChartURL(group.Value)))
            .Where(data => data.Item2 != null)
            .ToList();

        if (saveData != null)
        {
            void next()
            {
                if (datas.Count == 0)
                {
                    completed?.Invoke();
                    return;
                }
                var first = datas[0];
                datas.RemoveAt(0);

                request?.Invoke(first.Item1, first.Item2);
                DownloadChart(first.Item2, (d) =>
                {
                    saveData?.Invoke(first.Item1, d);
                    next();
                });
            }
            next();
        }
        else
        {
            foreach (var data in datas)
            {
                request?.Invoke(data.Item1, data.Item2);
            }
            completed?.Invoke();
        }
    }

    private static string FormatQuickChartURL(IEnumerable<ExecuteStates> states)
    {
        static double GetDuration(ExecuteStates state, string key) => state.Results != null && state.Results.TryGetValue(key, out var data) ? data.Duration : -1;

        //获取key
        string[] keys = states.FirstOrDefault(s => s.Results != null && s.Results.Count > 0).Results?.Keys?.ToArray();
        if (keys == null || keys.Length == 0)
            return null;

        string query = JsonUtility.ToJson(new QuickChartQuery()
        {
            type = "bar",
            data = new QuickChartQueryData()
            {
                labels = states.Select(s => s.Type.Name).ToArray(),
                datasets = keys.Select(k => new QuickChartQueryDataSet()
                {
                    label = k,
                    data = states.Select(s => GetDuration(s, k)).ToArray()
                }).ToArray()
            }
        });
        return "https://quickchart.io/chart?c=" + UnityEngine.Networking.UnityWebRequest.EscapeURL(query);
    }

    private static void DownloadChart(string url, Action<byte[]> callback)
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

    [System.Serializable]
    private struct QuickChartQuery
    {
        public string type;
        public QuickChartQueryData data;
    }
    [System.Serializable]
    private struct QuickChartQueryData
    {
        public string[] labels;
        public QuickChartQueryDataSet[] datasets;
    }
    [System.Serializable]
    private struct QuickChartQueryDataSet
    {
        public string label;
        public double[] data;
    }
}