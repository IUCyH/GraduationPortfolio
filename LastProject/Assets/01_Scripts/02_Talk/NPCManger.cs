using UnityEngine;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour
{
    public List<TalkObjects> TalkObjectList = new List<TalkObjects>();

    void Start()
    {
        InitializeNPCs();
    }

    void InitializeNPCs()
    {
        foreach (TalkObjects TalkObject in TalkObjectList)
        {
            for (int i = 0; i < 10; i+= 10) 
            {
                TalkObject.InitializeID(i); 
            }           
        }
    }
}
