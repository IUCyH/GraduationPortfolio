using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectPlayer : MonoBehaviour, ISelectWindow
{
    [SerializeField]
    List<PlayerSelectController> players = new List<PlayerSelectController>();
    [SerializeField]
    TextMeshProUGUI[] playerInfoTexts;
    [SerializeField]
    GameObject parentOfPlayerInfoObj;

    int currSelectedPlayer;
    
    public int Level { get; } = 1;

    void Start()
    {
        playerInfoTexts = parentOfPlayerInfoObj.GetComponentsInChildren<TextMeshProUGUI>();
        UpdatePlayerInfo();
        
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);

        for (int i = 0; i < players.Count; i++)
        {
            players[i].Init(currSelectedPlayer);
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void OnPressNextPlayerButton()
    {
        var playerCount = players.Count;
        for (int i = playerCount - 1; i > 0; i--)
        {
            var firstPlayer = players[i].ThisRectTransform;
            var secondPlayer = players[i - 1].ThisRectTransform;

            (firstPlayer.position, secondPlayer.position) = (secondPlayer.position, firstPlayer.position);
            (firstPlayer.localScale, secondPlayer.localScale) = (secondPlayer.localScale, firstPlayer.localScale);
        }
        
        SetPrevPlayer();
        
        if (++currSelectedPlayer > playerCount - 1)
        {
            currSelectedPlayer = 0;
        }

        SetCurrentPlayer();
        UpdatePlayerInfo();
    }

    public void OnPressPrevPlayerButton()
    {
        var playerCount = players.Count;
        for (int i = 0; i < playerCount - 1; i++)
        {
            var firstPlayer = players[i].ThisRectTransform;
            var secondPlayer = players[i + 1].ThisRectTransform;

            (firstPlayer.position, secondPlayer.position) = (secondPlayer.position, firstPlayer.position);
            (firstPlayer.localScale, secondPlayer.localScale) = (secondPlayer.localScale, firstPlayer.localScale);
        }
        
        SetPrevPlayer();
        
        if (--currSelectedPlayer < 0)
        {
            currSelectedPlayer = playerCount - 1;
        }

        SetCurrentPlayer();
        UpdatePlayerInfo();
    }

    void SetPrevPlayer()
    {
        players[currSelectedPlayer].ChangeImageColor(Color.gray);
        players[currSelectedPlayer].StopSelectAnimation();
    }

    void SetCurrentPlayer()
    {
        players[currSelectedPlayer].ChangeImageColor(Color.white);
        players[currSelectedPlayer].PlaySelectAnimation();


    }
    
    void UpdatePlayerInfo()
    {
        var playerInfo = CharacterDataTable.GetInfo(currSelectedPlayer);

        for (int i = 0; i < playerInfoTexts.Length; i++)
        {
            playerInfoTexts[i].text = playerInfo.infoList[i];
        }
    }
}
