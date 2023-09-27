using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectController : MonoBehaviour
{
    const string Selection = "Selection";
    
    Image img;
    Animator animator;
    
    int playerID;
    
    public RectTransform ThisRectTransform { get; set; }

    void Awake()
    {
        ThisRectTransform = GetComponent<RectTransform>();
        img = GetComponent<Image>();
        animator = GetComponent<Animator>();

        var splitArr = name.Split("_");
        playerID = int.Parse(splitArr[1]);
        
        if(playerID != 0)
        {
            ChangeImageColor(Color.gray);
        }
    }

    public void Init(int selectedPlayerID)
    {
        if (playerID == selectedPlayerID)
        {
            PlaySelectAnimation();
        }
    }

    public void ChangeImageColor(Color color)
    {
        img.color = color;
    }

    public void PlaySelectAnimation()
    {
        animator.SetBool(Selection, true);
    }

    public void StopSelectAnimation()
    {
        animator.SetBool(Selection, false);
    }
}
