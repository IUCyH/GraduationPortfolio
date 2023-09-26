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

    //���� �� ���� ���� �ϳ�
    void GenerateData()
    {

        talkData.Add(1000, new string[] { "�ȳ�?",
                                          "�̰��� ó�� �Ա���?" });

        talkData.Add(100, new string[] { "����� �������ڴ�" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
