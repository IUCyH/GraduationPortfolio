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
        talkData.Add(0, new string[] { "����� �������ڴ�" });


        talkData.Add(10, new string[] { "�ȳ�?",
                                          "�̰��� ó�� �Ա���?" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
