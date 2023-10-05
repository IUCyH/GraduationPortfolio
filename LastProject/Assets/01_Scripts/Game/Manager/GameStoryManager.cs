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

    float durationTimer;
    float textDisplayDuration = 0.8f;

    protected override void OnStart()
    {
        var id = GameManager.Instance.PlayerID;
        currChapter = DataManager.Instance.GetCurrentChapter(1);
        chapters = GetComponentsInChildren<IChapter>();
    }

    public void AddEndingFlag(EndingCondition condition)
    {
        endingFlag |= (int)condition;
    }

    public string GetDialogue(int dialogueIndex)
    {
        //호출하는 곳에서 null검사 필수
        return chapters[currChapter].GetLine(dialogueIndex);
    }

    void Update()
    {
        durationTimer += Time.deltaTime;
        if (durationTimer >= textDisplayDuration)
        {
            var dialogue = GetDialogue(currLineCount++);
            if (dialogue != null)
            {
                Debug.Log(dialogue);
            }

            durationTimer = 0f;
        }
    }
}
