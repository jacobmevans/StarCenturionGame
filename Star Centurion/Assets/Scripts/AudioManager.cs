using UnityEngine.UI;
using System.IO;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;

    void Start()
    {
        LoadSettings();
    }

    public void LoadSettings()
    {
        string path = Application.persistentDataPath + "/gamesettings.json";
        if (File.Exists(path))
        {
            //Get game settings from json
            GameSettings gameSettings =
                JsonUtility.FromJson<GameSettings>(
                    File.ReadAllText(path));

            if (gameSettings != null)
            {
                //Load audio settings.
                musicSource.volume = gameSettings.musicVolume;
            }
        }
    }
}