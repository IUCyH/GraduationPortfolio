using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> potraitData;

    [SerializeField]
    Sprite[] potraitArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        potraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(10, new string[] { "평범한 나무상자다" });


        talkData.Add(1000, new string[] { "안녕?:0",
                                          "이곳에 처음 왔구나?:1" });
        talkData.Add(2000, new string[] { "여어:1",
                                          "이 호수는 정말 아름답지?:1" });


        potraitData.Add(1000 + 0, potraitArr[0]);
        potraitData.Add(1000 + 1, potraitArr[1]);
        potraitData.Add(1000 + 2, potraitArr[2]);
        potraitData.Add(1000 + 3, potraitArr[3]);

        potraitData.Add(2000 + 0, potraitArr[4]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPotrait(int id, int potraitIndex)
    {
        return potraitData[id + potraitIndex];
    }
}
