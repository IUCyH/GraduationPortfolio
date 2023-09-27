using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    GameObject pausePopup;

    void Start()
    {
        pausePopup.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePopup.activeSelf)
            {
                pausePopup.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                pausePopup.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void ResumeButton()
    {
        pausePopup.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SaveButton()
    {

    }

    public void SettingButton()
    {

    }

    public void ExitToMainScene()
    {
        SceneManager.LoadScene(0);
    }
}
