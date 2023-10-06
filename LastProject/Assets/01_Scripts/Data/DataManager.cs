using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton_DontDestroy<DataManager>
{
    const string PlayerDataKey = "PlayerData";

    PlayerData playerData;

    protected override void OnAwake()
    {
        Load();
    }

    public int GetCurrentChapter(int playerID)
    {
        return playerData.chapterEachCharacter[playerID];
    }
    
    public void Load()
    {
        PlayerPrefs.DeleteAll();
        var json = PlayerPrefs.GetString(PlayerDataKey, string.Empty);

        if (!string.IsNullOrEmpty(json))
        {
            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            playerData = new PlayerData { chapterEachCharacter = new List<int>(new int[CharacterDataTable.CharacterCount]) };
            Debug.Log(playerData);
        }

        Save();
    }

    public void Save()
    {
        var json = JsonUtility.ToJson(playerData);
        
        PlayerPrefs.SetString(PlayerDataKey, json);
        PlayerPrefs.Save();
    }
}
