using System.Collections.Generic;
using UnityEngine;

public class TalkInformationManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    //엔터 한 번당 문장 하나
    void GenerateData()
    {

        talkData.Add(1000, new string[] { "안녕?",
                                          "이곳에 처음 왔구나?" });

        talkData.Add(100, new string[] { "평범한 나무상자다" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
