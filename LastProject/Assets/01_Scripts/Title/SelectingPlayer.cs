using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingPlayer : MonoBehaviour
{
    SpriteRenderer sprRenderer;
    Animator animator;

    Vector3 originPos;
    
    public bool IsSelected { get; private set; }

    void Awake()
    {
        originPos = transform.position;
        sprRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        if (sprRenderer != null)
        {
            ChangeSpriteColor(Color.gray);
        }
    }

    void OnMouseUp()
    {
        if (IsSelected) return;
        
        ChangeSpriteColor(Color.white);
        ChangeScale(1.3f, 1.3f, 1.3f);
        IsSelected = true;
        
        TitleManager.Instance.GoNextSelectionLevel();
    }

    void OnMouseEnter()
    {
        if (IsSelected) return;
        
        ChangeSpriteColor(Color.white);
        ChangeScale(1.3f, 1.3f, 1.3f);
        //animator.SetBool("SelectingAnimation", true);
    }

    void OnMouseExit()
    {
        if (IsSelected) return;
        
        ChangeSpriteColor(Color.gray);
        ChangeScale(1f, 1f, 1f);
        //animator.SetBool("SelectingAnimation", false);
    }

    void ChangeSpriteColor(Color color)
    {
        sprRenderer.color = color;
    }

    void ChangeScale(float x, float y, float z)
    {
        transform.localScale = new Vector3(x, y, z);
    }

    public void Init()
    {
        transform.position = originPos;
        IsSelected = false;
        
        ChangeSpriteColor(Color.gray);
        ChangeScale(1f, 1f, 1f);
        gameObject.SetActive(true);
    }

    public void SetPlayerPosToInformationPos(Vector3 pos)
    {
        transform.position = pos;
    }
}
