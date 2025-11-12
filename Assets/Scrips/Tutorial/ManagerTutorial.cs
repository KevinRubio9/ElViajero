using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;


public class ManagerTutorial : MonoBehaviour
{
    [Header("Resolutions")]

    public Toggle toggle;
    public TMP_Dropdown resolutionsDropDown;
    Resolution[] resolutions;

    [Header("Audio Volume")]

    public Slider generalVolumeSlider;

    [Header("Music Volume")]

    public Slider musicSlider;

    [Header("Brightness")]

    public Slider sliderB;
    public float sliderValueB;
    public Image brightnessPanel;
    public List<string> options = new List<string>();

    void Start()
    {
        //Resolution

        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }

        else
        {
            toggle.isOn = false;
        }

        CheckResolution();

        //Audio Volume

        generalVolumeSlider.value = PlayerPrefs.GetFloat("AudioVolume");

        //Music Volume
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        //Brightness

        sliderB.value = PlayerPrefs.GetFloat("brightness", 0.5f);
        brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, sliderB.value);
    }

    public void FullScreenActivated(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void CheckResolution()
    {
        resolutions = Screen.resolutions;
        resolutionsDropDown.ClearOptions();
        Debug.Log(Screen.currentResolution.refreshRateRatio.numerator);
        int actualResolution = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            if (resolutions[i].refreshRateRatio.numerator == Screen.currentResolution.refreshRateRatio.numerator)
            {
                options.Add(option);
            }

            if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                actualResolution = i;
            }
        }

        resolutionsDropDown.AddOptions(options);
        resolutionsDropDown.value = actualResolution;
        resolutionsDropDown.RefreshShownValue();

        resolutionsDropDown.value = PlayerPrefs.GetInt("resolutionNumber", 0);
    }

    public void ChangeResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("resolutionNumber", resolutionsDropDown.value);

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void ChangeGeneralVolume()
    {
        AudioManager.Instance.ChanceMasterVolume(generalVolumeSlider.value * -1);
        PlayerPrefs.SetFloat("AudioVolume", generalVolumeSlider.value * -1);

    }
    public void ChangeMusicVolume()
    {
        AudioManager.Instance.ChanceMusicVolume(musicSlider.value * -1);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value * -1);

    }

    public void ChangeSliderBrightness(float value)
    {
        PlayerPrefs.SetFloat("brightness", value);
        brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, sliderB.value);
    }
}

