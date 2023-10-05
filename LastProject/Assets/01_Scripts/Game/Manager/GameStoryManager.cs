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
    int currChapter;
    int endingFlag;

    protected override void OnStart()
    {
        var id = GameManager.Instance.PlayerID;
        currChapter = DataManager.Instance.GetCurrentChapter(id);
    }

    public void AddEndingFlag(EndingCondition condition)
    {
        endingFlag |= (int)condition;
    }
}
