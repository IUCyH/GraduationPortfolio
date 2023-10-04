using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStoryManager : Singleton<GameStoryManager>
{
    float progressTimer;

    protected override void OnStart()
    {
        var id = GameManager.Instance.PlayerID;
        progressTimer = DataManager.Instance.GetProgress(id);
    }

    void Update()
    {
        progressTimer += Time.deltaTime; //다른 로직으로 변경 가능
    }
}
