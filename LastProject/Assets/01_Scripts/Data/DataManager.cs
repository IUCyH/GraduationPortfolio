using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton_DontDestroy<DataManager>
{
    const string PlayerDataKey = "PlayerData";

    PlayerData playerData;
    
    public void Load()
    {
        var json = PlayerPrefs.GetString(PlayerDataKey, string.Empty);

        if (!string.IsNullOrEmpty(json))
        {
            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            playerData = new PlayerData();
        }

        Save();
    }

    public void Save()
    {
        var json = JsonUtility.ToJson(playerData);
        
        PlayerPrefs.SetString(PlayerDataKey, json);
        PlayerPrefs.Save();
        Debug.Log("Save Completed");
        Debug.Log("Current Progress : " + playerData.progress);
    }
}
