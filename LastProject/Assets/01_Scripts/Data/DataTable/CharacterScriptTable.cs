using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class CharacterScriptTable
{
    static int ChapterCount = 1;
    
    static List<CharacterScriptInfo> scriptData = new List<CharacterScriptInfo>();

    static CharacterScriptTable()
    {
        var characterCount = CharacterDataTable.CharacterCount;

        for (int i = 0; i < characterCount; i++)
        {
            scriptData.Add(new CharacterScriptInfo { script = new List<List<string>>() });
            
            for (int j = 0; j < ChapterCount; j++)
            {
                var path = string.Format("Scripts/Player{0:00}/Chapter{1:00}", i, j + 1);
                TextAsset textAsset = Resources.Load<TextAsset>(path);
                StringReader stringReader = new StringReader(textAsset.text);
                
                while (stringReader != null)
                {
                    var line = stringReader.ReadLine();
                    if (line == null) break;
                    if(string.IsNullOrEmpty(line)) continue;
                    
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
