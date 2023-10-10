using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterPortraitTable
{
    static Dictionary<string, Sprite> table;

    static CharacterPortraitTable()
    {
        var sprites = Resources.LoadAll<Sprite>("Sprite/Portrait");

        for (int i = 0; i < sprites.Length; i++)
        {
            table.Add(sprites[i].name, sprites[i]);
        }
    }

    public static Sprite GetPortraitSprite(string id)
    {
        if (!table.ContainsKey(id)) return null;

        return table[id];
    }
}
