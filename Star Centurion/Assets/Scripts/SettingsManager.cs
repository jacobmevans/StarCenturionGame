using System;
using UnityEngine.UI;
using System.IO;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public Toggle fullscreen;
    public Dropdown resolutionDropDown;
    public Dropdown graphicsQuality;
    public Dropdown antiAliasing;
    public Dropdown vSync;
    public Slider musicVolume;
    public Button applyButton;

    public AudioSource musicSource;
    public Resolution[] resolutions;
    public GameSettings gameSettings;

    void OnEnable()
    {
        gameSettings = new GameSettings();

        fullscreen.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        resolutionDropDown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        graphicsQuality.onValueChanged.AddListener(delegate { OnGraphicsChange(); });
        antiAliasing.onValueChanged.AddListener(delegate { OnAAChange(); });
        vSync.onValueChanged.AddListener(delegate { OnVSyncChange(); });
        musicVolume.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyClicked(); });

        resolutions = Screen.resolutions;
        foreach (Resolution resolution in resolutions)
        {
            resolutionDropDown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        LoadSettings();
    }

    public void OnFullScreenToggle()
    {
        gameSettings.isFullscreen = Screen.fullScreen = fullscreen.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropDown.value].width, resolutions[resolutionDropDown.value].height,
            Screen.fullScreen);
        gameSettings.resolutionIndex = resolutionDropDown.value;
    }

    public void OnGraphicsChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.graphicsQuality = graphicsQuality.value;
    }

    public void OnAAChange()
    {
        QualitySettings.antiAliasing = (int) Mathf.Pow(2, antiAliasing.value);
        gameSettings.antiAliasing = antiAliasing.value;
    }

    public void OnVSyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.vSync = vSync.value;
    }

    public void OnMusicVolumeChange()
    {
        musicSource.volume = musicVolume.value;
        gameSettings.musicVolume = musicVolume.value;
    }

    public void OnApplyClicked()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }

    public void LoadSettings()
    {
        //Get game settings from json

        string path = Application.persistentDataPath + "/gamesettings.json";

        if (File.Exists(path))
        {
            gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(path));

            //Load settings from retrieved json.
            fullscreen.isOn = gameSettings.isFullscreen;
            resolutionDropDown.value = gameSettings.resolutionIndex;
            graphicsQuality.value = gameSettings.graphicsQuality;
            antiAliasing.value = gameSettings.antiAliasing;
            vSync.value = gameSettings.vSync;
            musicVolume.value = gameSettings.musicVolume;
            musicSource.volume = gameSettings.musicVolume;

            resolutionDropDown.RefreshShownValue();
        }
    }
}