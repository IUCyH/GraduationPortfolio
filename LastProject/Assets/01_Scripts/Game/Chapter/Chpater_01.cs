using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chpater_01 : MonoBehaviour, IChapter
{
    const int Chapter = 0;
    
    List<string> script = new List<string>();

    void Start()
    {
        var id = GameManager.Instance.PlayerID;
        script = CharacterScriptTable.GetScript(id, Chapter);
    }

    public void PrintLine(int lineCount)
    {
        if (lineCount > script.Count - 1) return;
        
        Debug.Log(script[lineCount]);
    }
}
