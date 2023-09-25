using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionController : MonoBehaviour, ISelectWindow
{
    [SerializeField]
    List<SelectingPlayer> players;

    [SerializeField]
    Vector3 selectedPlayerPosition;

    public int Level { get; } = 1;

    void Start()
    {
        Close();
    }

    public void Open()
    {
        foreach (var player in players)
        {
            player.Init();
        }
    }

    public void Close()
    {
        foreach (var player in players)
        {
            if (player.IsSelected)
            {
                player.SetPlayerPosToInformationPos(selectedPlayerPosition);
                continue;
            }
            
            player.gameObject.SetActive(false);
        }
    }
}
