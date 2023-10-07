using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

enum KindOfSlider
{
    Total,
    SFX,
    BGM,
    Max
}

enum KindOfToggle
{
    SFX,
    BGM,
    Max
}

public class SettingManager : Singleton_DontDestroy<SettingManager>
{
    [SerializeField]
    GameObject optionWindow;
    [SerializeField]
    List<Slider> sliders;
    [SerializeField]
    List<Toggle> toggles;

    protected override void OnStart()
    {
        CloseOptionWindow();

        InitSliders();
        InitToggles();
    }

    public void OpenOptionWindow()
    {
        optionWindow.SetActive(true);
    }

    public void CloseOptionWindow()
    {
        optionWindow.SetActive(false);
    }

    public void ChangeTotalVolume(float value)
    {
        SoundManager.Instance.ChangeTotalVolume(value);
        DataManager.Instance.SetVolumeData(Audio.Total, value);
        
        DataManager.Instance.Save();
    }

    public void ChangeBGM(float value)
    {
        SoundManager.Instance.ChangeVolume(Audio.BGM, value);
        DataManager.Instance.SetVolumeData(Audio.BGM, value);
        
        DataManager.Instance.Save();
    }

    public void ChangeSFX(float value)
    {
        SoundManager.Instance.ChangeVolume(Audio.SFX, value);
        DataManager.Instance.SetVolumeData(Audio.SFX, value);
        
        DataManager.Instance.Save();
    }

    public void MuteOrOnBGM(bool value)
    {
        SoundManager.Instance.MuteOrOn(Audio.BGM, value);
        DataManager.Instance.SetMuteAudioData(Audio.BGM, value);
        
        DataManager.Instance.Save();
    }

    public void MuteOrOnSFX(bool value)
    {
        SoundManager.Instance.MuteOrOn(Audio.SFX, value);
        DataManager.Instance.SetMuteAudioData(Audio.SFX, value);
        
        DataManager.Instance.Save();
    }

    void InitSliders()
    {
        List<UnityAction<float>> funcList = new List<UnityAction<float>>
        {
            ChangeTotalVolume,
            ChangeSFX,
            ChangeBGM
        };

        for (int i = 0; i < (int)KindOfSlider.Max; i++)
        {
            sliders[i].onValueChanged.AddListener(funcList[i]);
            sliders[i].value = DataManager.Instance.GetVolume((Audio)i - 1);
        }
    }

    void InitToggles()
    {
        List<UnityAction<bool>> funcList = new List<UnityAction<bool>>
        {
            MuteOrOnSFX,
            MuteOrOnBGM
        };

        for (int i = 0; i < (int)KindOfToggle.Max; i++)
        {
            bool isOn = DataManager.Instance.GetIsMute((Audio)i);
            
            toggles[i].onValueChanged.AddListener(funcList[i]);
            toggles[i].isOn = isOn;
            
            SoundManager.Instance.MuteOrOn((Audio)i, isOn);
        }
    }
}
