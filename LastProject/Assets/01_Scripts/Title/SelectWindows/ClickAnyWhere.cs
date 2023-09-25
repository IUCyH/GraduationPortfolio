using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickAnyWhere : MonoBehaviour, IPointerClickHandler, ISelectWindow
{
    public int Level { get; } = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        TitleManager.Instance.GoNextSelectionLevel();
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
