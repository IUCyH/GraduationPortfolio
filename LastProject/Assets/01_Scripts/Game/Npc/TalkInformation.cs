using System.Collections.Generic;
using UnityEngine;

public class TalkInformation : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(0, new string[] { "평범한 나무상자다" });


        talkData.Add(10, new string[] { "안녕?",
                                          "이곳에 처음 왔구나?" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
