using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int level;
    public int progress;
}

public class PlayerInfo
{
    public List<string> infoList;
    public string name;
    public string summary;
    public string gender;
    public string constellation;
    public string specialNote;

    public PlayerInfo(string name, string summary, string gender, string constellation, string specialNote)
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
