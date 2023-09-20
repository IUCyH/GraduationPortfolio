using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeTest : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sprRenderer;
    [SerializeField]
    Animator animator;

    void Start()
    {
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
        animator.SetBool("SelectingAnimation", true);
    }

    void OnMouseExit()
    {
        ChangeSpriteColor(Color.gray);
        animator.SetBool("SelectingAnimation", false);
    }

    void ChangeSpriteColor(Color color)
    {
        sprRenderer.color = color;
    }
}
