using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton_DontDestroy<DataManager>
{
    const string PlayerDataKey = "PlayerData";
    const string SettingDataKey = "SettingData";

    PlayerData playerData;
    SettingData settingData;

    protected override void OnAwake()
    {
        Load();
    }

    public int GetCurrentChapter(int playerID)
    {
        return playerData.chapterEachCharacter[playerID];
    }

    public float GetVolume(Audio audio)
    {
        float value = 1f;
        
        switch (audio)
        {
            case Audio.Total:
                value = settingData.totalVolume;
                break;
            case Audio.BGM:
                value = settingData.bgmVolume;
                break;
            case Audio.SFX:
                value = settingData.sfxVolume;
                break;
        }

        return value;
    }

    public void ChangeVolumeData(Audio audio, float value)
    {
        switch (audio)
        {
            case Audio.Total:
                settingData.totalVolume = value;
                break;
            case Audio.BGM:
                settingData.bgmVolume = value;
                break;
            case Audio.SFX:
                settingData.sfxVolume = value;
                break;
        }
    }

    public void Save()
    {
        var jsonOfPlayer = JsonUtility.ToJson(playerData);
        var jsonOfSetting = JsonUtility.ToJson(settingData);

        PlayerPrefs.SetString(PlayerDataKey, jsonOfPlayer);
        PlayerPrefs.SetString(SettingDataKey, jsonOfSetting);

        PlayerPrefs.Save();
        Debug.Log("저장 성공");
    }

    void Load()
    {
        var jsonOfPlayer = PlayerPrefs.GetString(PlayerDataKey, string.Empty);
        var jsonOfSetting = PlayerPrefs.GetString(SettingDataKey, string.Empty);

        if (!string.IsNullOrEmpty(jsonOfSetting) && !string.IsNullOrEmpty(jsonOfPlayer))
        {
            playerData = JsonUtility.FromJson<PlayerData>(jsonOfPlayer);
            settingData = JsonUtility.FromJson<SettingData>(jsonOfSetting);
        }
        else
        {
            playerData = new PlayerData
            {
                chapterEachCharacter = new List<int>(new int[CharacterDataTable.CharacterCount])
            };

            settingData = new SettingData
            {
                totalVolume = 1f,
                bgmVolume = 1f,
                sfxVolume = 1f
            };
        }

        Save();
    }
}
