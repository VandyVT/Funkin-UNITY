using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Events;

public class SettingsMenu : MonoBehaviour
{
    Resolution[] resolutions;

    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Toggle FSToggle;
    public AudioMixer musicMixer;
    public AudioMixer soundMixer;

    [Header("Options | Gameplay")]
    public bool HideGF; public Toggle GFToggle;

    const string PrefName = "optionvalue";


    public void SetVolumeMus(float volumeMus)
    {
        musicMixer.SetFloat("MusVol", Mathf.Log10(volumeMus) * 20);
    }
    public void SetVolumeSou(float volumeSou)
    {
        soundMixer.SetFloat("SoundVolume", Mathf.Log10(volumeSou) * 20);
    }

    void Awake()
    {
        qualityDropdown = GameObject.Find("Quality Dropdown").GetComponent<Dropdown>();
        qualityDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(PrefName, qualityDropdown.value);
            PlayerPrefs.Save();
        }));
        FSToggle = GameObject.Find("Fullscreen Toggle").GetComponent<Toggle>();
        GFToggle = GameObject.Find("Hide GF").GetComponent<Toggle>();

        PlayerPrefs.SetInt("GF.pref", (HideGF ? 1 : 0));
        HideGF = (PlayerPrefs.GetInt("GF.pref") != 0);
    }

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        var QLevel = PlayerPrefs.GetInt("GraphicsQuality");
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        int QualityIndex = PlayerPrefs.GetInt("GraphicsQuality");
        qualityDropdown.value = PlayerPrefs.GetInt(PrefName, 0);

        if (PlayerPrefs.GetInt ("Ftoggle") == 1)
        {
            FSToggle.isOn = true;
        }
        else
        {
            FSToggle.isOn = false;
        }

        if (PlayerPrefs.GetInt("GFtoggle") == 1)
        {
            GFToggle.isOn = true;
        }
        else
        {
            GFToggle.isOn = false;
        }
    }

    public void SetQuality(int QualityIndex)
    {
        PlayerPrefs.SetInt("GraphicsQuality", QualityIndex);
        PlayerPrefs.Save();

        QualitySettings.SetQualityLevel(QualityIndex);

        Debug.Log("Set quality to level " + QualitySettings.GetQualityLevel());
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void Update()
    {
        int QualityIndex = PlayerPrefs.GetInt("GraphicsQuality");
        if (FSToggle.isOn == true)
        {
            PlayerPrefs.SetInt("Ftoggle", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Ftoggle", 0);
        }

        int GFIndex = PlayerPrefs.GetInt("GFtoggle");
        if (GFToggle.isOn == true)
        {
            PlayerPrefs.SetInt("GF.pref", 1);
        }
        else
        {
            PlayerPrefs.SetInt("GF.pref", 0);
        }
    }
}