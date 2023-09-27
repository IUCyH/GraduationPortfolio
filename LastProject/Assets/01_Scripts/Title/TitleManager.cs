using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : Singleton<TitleManager>
{
    List<ISelectWindow> selectionWindows;
    [SerializeField]
    Image exitButtonImg;

    const int MaxSelectionLevel = 1;
    int currSelectionLevel;

    protected override void OnAwake()
    {
        var windows = GameObject.FindGameObjectsWithTag("SelectionWindow");

        selectionWindows = new List<ISelectWindow>(new ISelectWindow[windows.Length]);
        for (int i = 0; i < windows.Length; i++)
        {
            var selectWindowObj = windows[i].GetComponent<ISelectWindow>();
            selectionWindows[selectWindowObj.Level] = selectWindowObj;
        }
    }

    protected override void OnStart()
    {
        DataManager.Instance.Load();
        
        ShowOrHideExitButton();
    }

    public void GoNextSelectionLevel()
    {
        if (currSelectionLevel == MaxSelectionLevel) return;

        selectionWindows[currSelectionLevel++].Close();

        selectionWindows[currSelectionLevel].Open();
        
        ShowOrHideExitButton();
    }

    public void GoPrevSelectionLevel()
    {
        if (currSelectionLevel == 0) return;

        selectionWindows[currSelectionLevel--].Close();
        
        selectionWindows[currSelectionLevel].Open();
        
        ShowOrHideExitButton();
    }

    public void LoadGameScene()
    {
        SceneLoadManager.Instance.Load(Scene.Game);
    }

    void ShowOrHideExitButton()
    {
        if (currSelectionLevel != 0)
        {
            exitButtonImg.enabled = true;
        }

        else
        {
            exitButtonImg.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoPrevSelectionLevel();
        }
    }
}
