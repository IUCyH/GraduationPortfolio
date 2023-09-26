using UnityEngine;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour
{
    public List<TalkObjects> TalkObjectList = new List<TalkObjects>();

    int j;

    void Start()
    {
        InitializeNPCs();
    }

    void InitializeNPCs()
    {
        for (int i = 0; i < TalkObjectList.Count; i++)
        {

            if (TalkObjectList[i] != null)
            {
                TalkObjectList[i].InitializeID(j);
            }
            else
            {
                continue;
            }

            j += 10;
        }
    }
}
