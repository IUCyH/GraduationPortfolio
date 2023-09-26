using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : Singleton<TitleManager>
{
    List<ISelectWindow> selectionWindows;

    const int MaxSelectionLevel = 2;
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

    public void GoNextSelectionLevel()
    {
        if (currSelectionLevel == MaxSelectionLevel) return;

        selectionWindows[currSelectionLevel++].Close();

        selectionWindows[currSelectionLevel].Open();
    }

    public void GoPrevSelectionLevel()
    {
        if (currSelectionLevel == 0) return;

        selectionWindows[currSelectionLevel--].Close();
        
        selectionWindows[currSelectionLevel].Open();
    }

    public void LoadGameScene()
    {
        SceneLoadManager.Instance.Load(Scene.Game);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoPrevSelectionLevel();
        }
    }
}
