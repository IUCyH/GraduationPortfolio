using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum KindOfSlider
{
    Total,
    BGM,
    SFX
}

public class SettingManager : Singleton_DontDestroy<SettingManager>
{
    [SerializeField]
    GameObject optionWindow;
    [SerializeField]
    List<Slider> sliders;

    protected override void OnStart()
    {
        OnPressCloseOptionWindowButton();

        InitSliders();
    }

    public void OnPressOpenOptionWindowButton()
    {
        optionWindow.SetActive(true);
    }

    public void OnPressCloseOptionWindowButton()
    {
        optionWindow.SetActive(false);
    }

    public void ChangeTotalVolume(float value)
    {
        SoundManager.Instance.ChangeTotalVolume(value);
        DataManager.Instance.ChangeVolumeData(Audio.Total, value);
        
        DataManager.Instance.Save();
    }

    public void ChangeBGM(float value)
    {
        SoundManager.Instance.ChangeVolume(Audio.BGM, value);
        DataManager.Instance.ChangeVolumeData(Audio.BGM, value);
        
        DataManager.Instance.Save();
    }

    public void ChangeSFX(float value)
    {
        SoundManager.Instance.ChangeVolume(Audio.SFX, value);
        DataManager.Instance.ChangeVolumeData(Audio.SFX, value);
        
        DataManager.Instance.Save();
    }

    void InitSliders()
    {
        sliders[(int)KindOfSlider.Total].onValueChanged.AddListener(ChangeTotalVolume);
        sliders[(int)KindOfSlider.BGM].onValueChanged.AddListener(ChangeBGM);
        sliders[(int)KindOfSlider.SFX].onValueChanged.AddListener(ChangeSFX);

        sliders[(int)KindOfSlider.Total].value = DataManager.Instance.GetVolume(Audio.Total);
        sliders[(int)KindOfSlider.BGM].value = DataManager.Instance.GetVolume(Audio.BGM);
        sliders[(int)KindOfSlider.SFX].value = DataManager.Instance.GetVolume(Audio.SFX);
    }
}
