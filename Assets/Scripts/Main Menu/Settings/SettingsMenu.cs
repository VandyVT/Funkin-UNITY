using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public AudioMixer voiceMixer;

    [Header("Options | Gameplay")]
    bool loadedTest = false;
    public bool HideGF; public Toggle GFToggle;
    public bool HideBF; public Toggle BFToggle;
    public bool HideEnemy; public Toggle EnemyToggle;
    public bool HideEnemyArrows; public Toggle EnemyArrowsToggle;
    public bool HideStage; public Toggle StageToggle;

    [Header("Technical Stuff")]
    public AudioSource musicSource;
    public GameObject introSource;


    const string PrefName = "optionvalue";


    public void SetVolumeMus(float volumeMus)
    {
        musicMixer.SetFloat("MusVol", Mathf.Log10(volumeMus) * 20);
    }
    public void SetVolumeSou(float volumeSou)
    {
        soundMixer.SetFloat("SoundVolume", Mathf.Log10(volumeSou) * 20);
    }
    public void SetVolumeVoi(float volumeSou)
    {
        voiceMixer.SetFloat("VoiceVolume", Mathf.Log10(volumeSou) * 20);
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
    }

    void Start()
    {
        introSource = GameObject.Find("IntroMusic");
        if (musicSource.isPlaying && introSource != null)
        {
            if (introSource.GetComponent<AudioSource>().isPlaying)
            {
                musicSource.timeSamples = introSource.GetComponent<AudioSource>().timeSamples;
                Destroy(introSource);
            }
        }

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        var QLevel = PlayerPrefs.GetInt("GraphicsQuality");
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
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

        //Fullscreen PlayerPrefs
        if (PlayerPrefs.GetInt("Ftoggle") == 1)
        {
            FSToggle.isOn = true;
        }
        else
        {
            FSToggle.isOn = false;
        }

        //Hide GF PlayerPrefs
        if (PlayerPrefs.GetInt("GFPref") == 1)
        {
            GFToggle.isOn = true;
        }
        else
        {
            GFToggle.isOn = false;
        }

        //Hide BF PlayerPrefs
        if (PlayerPrefs.GetInt("BFPref") == 1)
        {
            BFToggle.isOn = true;
        }
        else
        {
            BFToggle.isOn = false;
        }

        //Hide Enemy PlayerPrefs
        if (PlayerPrefs.GetInt("EnemyPref") == 1)
        {
            EnemyToggle.isOn = true;
        }
        else
        {
            EnemyToggle.isOn = false;
        }

        //Hide Enemy Arrows PlayerPrefs
        if (PlayerPrefs.GetInt("EnemyArrowPref") == 1)
        {
            EnemyArrowsToggle.isOn = true;
        }
        else
        {
            EnemyArrowsToggle.isOn = false;
        }

        //Hide Stage PlayerPrefs
        if (PlayerPrefs.GetInt("StagePref") == 1)
        {
            StageToggle.isOn = true;
        }
        else
        {
            StageToggle.isOn = false;
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

    public void LoadTestScene()
    {
        loadedTest = true;
        SceneManager.LoadScene("FreshTest", LoadSceneMode.Additive);
    }

    public void UnloadTestScene()
    {
        loadedTest = false;
        SceneManager.UnloadSceneAsync("FreshTest");
    }

    public void SetMusicBack()
    {
        musicSource.timeSamples = 0;
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

        //Hide GF Toggle
        if (GFToggle.isOn)
        {
            if(loadedTest == true && HideGF == false)
            {
                PlayerPrefs.SetInt("GFPref", 1);
                HideGF = true;
            }
        }
        if (!GFToggle.isOn)
        {
            if (loadedTest == true && HideGF == true)
            {
                PlayerPrefs.SetInt("GFPref", 0);
                HideGF = false;
            }
        }

        //Hide BF Toggle
        if (BFToggle.isOn)
        {
            if (loadedTest == true && HideBF == false)
            {
                PlayerPrefs.SetInt("BFPref", 1);
                HideBF = true;
            }
        }
        if (!BFToggle.isOn)
        {
            if (loadedTest == true && HideBF == true)
            {
                PlayerPrefs.SetInt("BFPref", 0);
                HideBF = false;
            }
        }

        //Hide Enemy Toggle
        if (EnemyToggle.isOn)
        {
            if (loadedTest == true && HideEnemy == false)
            {
                PlayerPrefs.SetInt("EnemyPref", 1);
                HideEnemy = true;
            }
        }
        if (!EnemyToggle.isOn)
        {
            if (loadedTest == true && HideEnemy == true)
            {
                PlayerPrefs.SetInt("EnemyPref", 0);
                HideEnemy = false;
            }
        }

        //Hide Enemy Arrow Toggle
        if (EnemyArrowsToggle.isOn)
        {
            if (loadedTest == true && HideEnemyArrows == false)
            {
                PlayerPrefs.SetInt("EnemyArrowPref", 1);
                HideEnemyArrows = true;
            }
        }
        if (!EnemyArrowsToggle.isOn)
        {
            if (loadedTest == true && HideEnemyArrows == true)
            {
                PlayerPrefs.SetInt("EnemyArrowPref", 0);
                HideEnemyArrows = false;
            }
        }

        //Hide Stage Toggle
        if (StageToggle.isOn)
        {
            if (loadedTest == true && HideStage == false)
            {
                PlayerPrefs.SetInt("StagePref", 1);
                HideStage = true;
            }
        }
        if (!StageToggle.isOn)
        {
            if (loadedTest == true && HideStage == true)
            {
                PlayerPrefs.SetInt("StagePref", 0);
                HideStage = false;
            }
        }
    }
}