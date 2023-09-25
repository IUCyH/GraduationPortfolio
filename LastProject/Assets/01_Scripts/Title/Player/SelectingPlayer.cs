using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingPlayer : MonoBehaviour
{
    SpriteRenderer sprRenderer;
    Animator animator;

    Vector3 originPos;

    void Start()
    {
        originPos = transform.position;
        sprRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        if (sprRenderer != null)
        {
            ChangeSpriteColor(Color.gray);
        }
    }

    void OnMouseEnter()
    {
        ChangeSpriteColor(Color.white);
        //animator.SetBool("SelectingAnimation", true);
    }

    void OnMouseExit()
    {
        ChangeSpriteColor(Color.gray);
        //animator.SetBool("SelectingAnimation", false);
    }

    void ChangeSpriteColor(Color color)
    {
        sprRenderer.color = color;
    }
}
