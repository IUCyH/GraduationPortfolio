using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public List<int> chapterEachCharacter;
}

[Serializable]
public class CharacterInfo
{
    public List<string> infoList;
    public string name;
    public string summary;
    public string gender;
    public string constellation;
    public string specialNote;

    public CharacterInfo(string name, string summary, string gender, string constellation, string specialNote)
    {
        SetInfo(name, summary, gender, constellation, specialNote);
        
        infoList = new List<string>
        {
            this.name,
            this.summary,
            this.gender,
            this.constellation,
            this.specialNote
        };
    }

    void SetInfo(string name, string summary, string gender, string constellation, string specialNote)
    {
        this.name = name;
        this.summary = summary;
        this.gender = gender;
        this.constellation = constellation;
        this.specialNote = specialNote;
    }
}

[Serializable]
public class CharacterScriptInfo
{
    public List<List<string>> script;
}

[Serializable]
public class SettingData
{
    public float totalVolume;
    public float bgmVolume;
    public float sfxVolume;
    public bool muteBGM;
    public bool muteSFX;
}
