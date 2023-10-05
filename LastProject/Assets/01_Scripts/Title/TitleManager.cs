using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : Singleton<TitleManager>
{
    List<ISelectWindow> selectionWindows;
    [SerializeField]
    Image exitButtonImg;
    [SerializeField]
    Image quitGameButtonImg;

    const int MaxSelectionLevel = 1;
    int currSelectionLevel;
    
    public int SelectedPlayerID { get; set; }

    protected override void OnAwake()
    {
        var windows = GameObject.FindGameObjectsWithTag("SelectionWindow");

        selectionWindows = new List<ISelectWindow>(new ISelectWindow[windows.Length]);
        for (int i = 0; i < windows.Length; i++)
        {
            var selectWindowObj = windows[i].GetComponent<ISelectWindow>();
            selectionWindows[selectWindowObj.Level] = selectWindowObj;
        }
        
        SoundManager.Instance.PlayBGM(BGM.Title);
    }

    protected override void OnStart()
    {
        DataManager.Instance.Load();

        ShowOrHideExitButtonAndQuitButton();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoPrevSelectionLevel();
        }
    }

    public void GoNextSelectionLevel()
    {
        if (currSelectionLevel == MaxSelectionLevel) return;

        selectionWindows[currSelectionLevel++].Close();

        selectionWindows[currSelectionLevel].Open();

        ShowOrHideExitButtonAndQuitButton();
    }

    public void GoPrevSelectionLevel()
    {
        if (currSelectionLevel == 0) return;

        selectionWindows[currSelectionLevel--].Close();
        
        selectionWindows[currSelectionLevel].Open();

        ShowOrHideExitButtonAndQuitButton();
    }

    public void OnPressGameStartButton()
    {
        SoundManager.Instance.StopBGM();
        SoundManager.Instance.PlaySFX(SFX.StartButton);
        SceneLoadManager.Instance.Load(Scene.Game, SelectedPlayerID); //이런식으로 작성가능
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    void ShowOrHideExitButtonAndQuitButton()
    {
        if (currSelectionLevel != 0)
        {
            exitButtonImg.enabled = true;
            quitGameButtonImg.enabled = false;
        }

        else
        {
            exitButtonImg.enabled = false;
            quitGameButtonImg.enabled = true;
        }
    }
}
