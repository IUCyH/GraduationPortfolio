using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class CharacterScriptTable
{
    static int ChapterCount = 1;
    
    static List<CharacterScriptData> scriptData = new List<CharacterScriptData>();

    static CharacterScriptTable()
    {
        var playerCount = CharacterDataTable.CharacterCount;

        for (int i = 0; i < playerCount; i++)
        {
            scriptData.Add(new CharacterScriptData { script = new List<List<string>>() });
            
            for (int j = 0; j < ChapterCount; j++)
            {
                var path = string.Format("Scripts/Player{0:00}/Chapter{1:00}", i, j + 1);
                TextAsset textAsset = Resources.Load<TextAsset>(path);
                StringReader stringReader = new StringReader(textAsset.text);
                
                while (stringReader != null)
                {
                    var line = stringReader.ReadLine();
                    if (line == null) break;
                    
                    scriptData[i].script.Add(new List<string>());
                    scriptData[i].script[j].Add(line);
                }
            }
        }
    }

    public static List<string> GetScript(int id, int chapter)
    {
        return scriptData[id].script[chapter];
    }
}
