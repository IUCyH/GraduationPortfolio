using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EndingCondition
{
    A,
    B
}

public class GameStoryManager : Singleton<GameStoryManager>
{
    IChapter[] chapters;    

    int currChapter;
    int currLineCount;
    int endingFlag;

    protected override void OnStart()
    {
        var id = GameManager.Instance.PlayerID;
        currChapter = DataManager.Instance.GetCurrentChapter(id);
        chapters = GetComponentsInChildren<IChapter>();
    }

    public void InitAllChapterScripts()
    {
        for (int i = 0; i < chapters.Length; i++)
        {
            chapters[i].Init();
        }
    }

    public void AddEndingFlag(EndingCondition condition)
    {
        endingFlag |= (int)condition;
    }
    
    /// <summary>
    /// 값을 받아오고 나서 null 검사 필수!
    /// </summary>
    /// <param name="dialogueIndex">받아가야 할 대사의 인덱스 번호(대사의 순서번호)</param>
    /// <returns></returns>
    public string GetDialogue(int dialogueIndex)
    {
        return chapters[currChapter].GetLine(dialogueIndex);
    }
}
