using System;
using UnityEngine;

public class GameDataSystem : GameSystem
{
    private Data data;
    private string dataPath = "Data";
    public override void Init()
    {
        LoadData();
    }
    public override void AfterInit()
    {

    }

    public void SetVolume(float volume)
    {
        data.volume = volume;
    }

    public float GetVolume()
    {
        return data.volume;
    }

    public void SetLanguage(Language language)
    {
        data.language = language;
    }

    public Language GetLanguage()
    {
        return data.language;
    }

    public void SaveData()
    {
        string str = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(dataPath, str);
    }
    public void LoadData()
    {
        string str = PlayerPrefs.GetString(dataPath);
        data = JsonUtility.FromJson<Data>(str);
    }
}

[Serializable]
public class Data
{
    public float volume;
    public Language language;
}

public enum Language
{
    Russian,
    English
}
