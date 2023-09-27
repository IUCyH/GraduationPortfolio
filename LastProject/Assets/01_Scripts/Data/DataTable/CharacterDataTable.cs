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
        characterTable.Add(new PlayerInfo("신영", null, null,null,null));
        characterTable.Add(new PlayerInfo("지은", "망상가득 활기찬 모범반장", "성별 : 여","별자리 : 쌍둥이 자리","특이사항 : 주변이 온통 상상으로 가득참"));
        characterTable.Add(new PlayerInfo("재환", null, null,null,null));
    }

    public static PlayerInfo GetInfo(int characterID)
    {
        if (characterTable.Count - 1 < characterID) return null;
        
        return characterTable[characterID];
    }
}
