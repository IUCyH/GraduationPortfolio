using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CharacterDataTable
{
    public static List<PlayerInfo> characterTable = new List<PlayerInfo>();

    static CharacterDataTable()
    {
        characterTable.Add(new PlayerInfo("신영", "활기찬  금손  그림쟁이", "성별 : 여","별자리 : 사자 자리","특이사항 : 전문가  뺨치는  그림실력을  가지고  있음!"));
        characterTable.Add(new PlayerInfo("지은", "망상가득  활기찬  모범반장", "성별 : 여","별자리 : 쌍둥이 자리","특이사항 : 주변이  온통  망상으로  가득참(?)"));
        characterTable.Add(new PlayerInfo("재환", "피곤에  절여진  히키코모리", "성별 : 남","별자리 : 양 자리","특이사항 : 하루  반나절  이상  잠(ZZZ)"));
    }

    public static PlayerInfo GetInfo(int characterID)
    {
        if (characterTable.Count - 1 < characterID) return null;
        
        return characterTable[characterID];
    }
}
